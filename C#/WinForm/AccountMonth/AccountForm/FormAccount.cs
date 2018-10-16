using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseExtensions;
using BaseGridControl;
using DataAccess;
using EcBase;
using BaseUserControl;
using System.Data.SqlClient;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;


namespace AccountWithSQL
{
    public partial class FormAccount : Form
    {
        public const string StrSQLDefault = @"Data Source = 192.168.1.194,1433; Initial Catalog = test; Integrated Security = false; " +
                                                            @"User ID = sa; Password = 123;";
        string StrSQLQry = string.Empty;

        public FormAccount()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitUI();
            InitLogic();

            DataReload();
            InitUICombox();
        }

        private void InitUI()
        {
            gv.SetMultiSelect();
            gv.SetShowRowNo();
            gv.OptionsView.ShowFooter = true;
            gv.Columns["name"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Custom;
            gv.Columns["name"].SummaryItem.DisplayFormat = "合计 :";
            gv.Columns["moneytmp"].SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            gv.Columns["moneytmp"].SetFormat(DataFormatType.Money);

            gv.Columns["datetmp"].SetFormat(DataFormatType.Date);

        }

        private void InitLogic()
        {
            #region  增加
            btnAdd.Click += delegate(object sender, EventArgs e)
            {
                DataTable dt = gc.DataSource as DataTable;
                DataRow drNew = dt.NewRow();
                drNew["name"] = cbxName.EditValue.ToStringEx();
                drNew["typetmp"] = cbxType.EditValue.ToStringEx();
                drNew["datetmp"] = DateTime.Now.ToStringEx();
                drNew["moneytmp"] = 0;
                drNew["kcczhm"] = dt.Compute("max(kcczhm)", null).ToDefaultableInt32() + 1;
                dt.Rows.Add(drNew);
            };
            #endregion

            #region 保存
            btnSav.Click += delegate(object sender, EventArgs e)
            {
                if (!SaveCheck())
                    return;
                AccountSave();
                DataReload();
            };
            #endregion

            #region 删除
            btnDel.Click += delegate(object sender, EventArgs e)
            {
                gv.DeleteSelectedRows();
            };
            #endregion

            #region 查询
            btnQry.Click += delegate(object sender, EventArgs e)
            {
                DataReload();
            };
            #endregion

            #region 明细类型
            btnType.Click += delegate(object sender, EventArgs e)
            {
                using (FormType form = new FormType())
                {
                    if (form.DialogResult != DialogResult.Cancel)
                        form.ShowDialog();
                }

                InitUICombox();

            };
            #endregion

            #region 一键结清
            btnClear.Click += delegate(object sender, EventArgs e)
            {

                DataTable dt = GetData( string.Format("select name,typetmp,moneytmp,datetmp,comment,kcczhm from account  order by datetmp asc "));
                if (dt == null)
                    return;


                using (FormClear form = new FormClear(dt,cbxName.EditValue.ToStringEx()))
                {
                    if (form.DialogResult != DialogResult.Cancel)
                        form.ShowDialog();
                }
            };
            #endregion

        }

        private bool SaveCheck()
        {
            gv.CloseEditor();
            gv.UpdateCurrentRow();

            DataTable dt = gc.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return false;

            dt.RemoveEmptyRows("name");

            var varRep = dt.AsEnumerable()
                .Where(a => a.RowState == DataRowState.Added || a.RowState == DataRowState.Modified)
                .GroupBy(a => new string[] { "name", "kcczhm" })
                .Select(a => new
                {
                    Primary = a.Key,
                    count = a.Count()
                });

            foreach (var v in varRep)
                if (v.count >= 2)
                    return false;

            return true;
        }

        private void AccountSave()
        {
            DataTable dt = gc.DataSource as DataTable;
            if (dt == null)
                return;
            InvokeProc r = new InvokeProc();
            int i = 0;

            SqlConnection conn = OpenConnection();
            SqlCommand comm = new SqlCommand();
            DataRow[] drSavs = dt.Select(null, null, DataViewRowState.Added);
            foreach (DataRow drSav in drSavs)
            {
                comm.CommandText = string.Format("insert into account ( name,typetmp,moneytmp,datetmp,comment,kcczhm ) values ( '{0}','{1}','{2}','{3}','{4}','{5}' ) ",
                   drSav["name"].ToStringEx(), drSav["typetmp"].ToStringEx(), drSav["moneytmp"].ToStringEx(), drSav["datetmp"].ToStringEx(), drSav["comment"].ToStringEx(), drSav["kcczhm"].ToStringEx());
                comm.Connection = conn;
                comm.ExecuteNonQuery();
            }

            DataRow[] drMdys = dt.Select(null, null, DataViewRowState.ModifiedCurrent);
            foreach (DataRow drMdy in drMdys)
            {
                comm.CommandText = string.Format("update account set typetmp = '{0}',datetmp = '{1}',comment = '{2}',moneytmp = '{3}' where kcczhm = '{4}' and name = '{5}' ",
                             drMdy["typetmp"].ToStringEx(), drMdy["datetmp"].ToStringEx(), drMdy["comment"].ToStringEx(), drMdy["moneytmp"].ToStringEx(), drMdy["kcczhm"].ToStringEx(), drMdy["name"].ToStringEx());
                comm.Connection = conn;
                comm.ExecuteNonQuery();
            }

            DataRow[] drDels = dt.Select(null, null, DataViewRowState.Deleted);
            foreach (DataRow drDel in drDels)
            {
                comm.CommandText = string.Format("delete from account where kcczhm = '{0}' and name = '{1}' ",
                          drDel["kcczhm", DataRowVersion.Original].ToStringEx(), drDel["name", DataRowVersion.Original].ToStringEx());
                comm.Connection = conn;
                comm.ExecuteNonQuery();
            }

            conn.Close();
            //r.addService("fs" + i++, FsDel(drDel["kcczhm", DataRowVersion.Original].ToStringEx(), drDel["name", DataRowVersion.Original].ToStringEx(), "D"));
        }

        private void InitUICombox()
        {
            string StrComboxNameSQLQry = string.Format("select name,code from accountname where len('{0}') = 0 or code = '{1}' order by code asc "
                    , string.Empty, string.Empty);
            DataTable dtName = GetData(StrComboxNameSQLQry);
            if (dtName == null)
                return;
            DataRow drNewName = dtName.NewRow();
            drNewName["code"] = string.Empty;
            drNewName["name"] = "全部";
            dtName.Rows.InsertAt(drNewName,0);
            cbxName.BindDataSource(dtName, "code", "name",true);
            RepositoryItemImageComboBox rcbxName = new RepositoryItemImageComboBox();
            rcbxName.BindDataSource(dtName, "code", "name");
            rcbxName.ImmediatePopup = true;
            rcbxName.ParseEditValue += delegate(object sender, ConvertEditValueEventArgs e)
            {
                e.Value = e.Value.ToString();
                e.Handled = true;
            };
            gv.Columns["name"].ColumnEdit = rcbxName;


            string StrComboxTypeSQLQry = string.Format("select name,code from accounttype where len('{0}') = 0 or code = '{1}' order by code asc "
                     , string.Empty, string.Empty);
            DataTable dtType = GetData(StrComboxTypeSQLQry);
            if (dtType == null)
                return;
            DataRow drNewType = dtType.NewRow();
            drNewType["code"] = string.Empty;
            drNewType["name"] = "全部";
            dtType.Rows.InsertAt(drNewType, 0);
            cbxType.BindDataSource(dtType, "code", "name",true);
            RepositoryItemImageComboBox rcbxType = new RepositoryItemImageComboBox();
            rcbxType.BindDataSource(dtType, "code", "name");
            rcbxType.ImmediatePopup = true;
            rcbxType.ParseEditValue += delegate(object sender, ConvertEditValueEventArgs e)
            {
                e.Value = e.Value.ToString();
                e.Handled = true;
            };
            gv.Columns["typetmp"].ColumnEdit = rcbxType;

        }

        private void DataReload()
        {
            StrSQLQry = string.Format("select name,typetmp,moneytmp,datetmp,comment,kcczhm from account where (len('{0}') = 0 or name = '{1}') and (len('{2}') = 0 or typetmp = '{3}') order by datetmp asc "
               , cbxName.EditValue.ToStringEx(), cbxName.EditValue.ToStringEx(), cbxType.EditValue.ToStringEx(), cbxType.EditValue.ToStringEx());

            DataTable dt = GetData(StrSQLQry);
            if (dt == null)
                return;

            gc.DataSource = dt;
        }

        public DataTable GetData(string strSql)
        {
            SqlCommand comm = new SqlCommand(strSql.ToStringEx(), OpenConnection());
            SqlDataReader dr = comm.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr, LoadOption.OverwriteChanges);
            OpenConnection().Close();
            return dt;
        }

        internal SqlConnection OpenConnection()
        {
            SqlConnection conn = new SqlConnection(StrSQLDefault);
            conn.Open();
            return conn;
        }

    }
}
