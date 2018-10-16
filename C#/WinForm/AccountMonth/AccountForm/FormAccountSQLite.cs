using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseExtensions;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.IO;
using System.Data.SQLite;

namespace AccountWithSQL
{
    public partial class FormAccountSQLite : Form
    {
        public string dbPath = Environment.CurrentDirectory + "\\test.db";
        private string StrSQLQry = string.Empty;
        private string[] strsColumnsNames = new string[] { "name", "typetmp", "moneytyp", "datetype", "comment" };//导入数据列 箱单号码,原始凭单,物品代码,实收数量

        public FormAccountSQLite()
        {
            dbPath = "Data Source =" + dbPath;

            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitDataBase();
            InitUI();
            InitLogic();

            DataReload();
            InitUICombox();
        }

        private void InitDataBase()
        {
            //不存在重新复制一份
            if (File.Exists(dbPath.Replace("Data Source =", string.Empty)))
                return;

            using (SQLiteConnection conn = OpenConnection())
            {
                SQLiteCommand cmd = new SQLiteCommand(conn);
                cmd.CommandText = "create table if not exists accountname(code varchar(255),name varchar(255),pswd varchar(255));";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "create table if not exists accounttype(code varchar(255),name varchar(255),pswd varchar(255));";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "create table if not exists account(name varchar(255),typetmp varchar(255),moneytmp varchar(255),datetmp varchar(255),comment varchar(255),kcczhm varchar(255));";
                cmd.ExecuteNonQuery();

                cmd.CommandText = " insert into accountname values ('1','1','1');";
                cmd.ExecuteNonQuery();
            }
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
                if (dt == null)
                    return;
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

            #region 用户
            btnUser.Click += delegate(object sender, EventArgs e)
            {
                using (FormUser form = new FormUser())
                {
                    if (form.DialogResult != DialogResult.Cancel)
                        form.ShowDialog();
                }

                InitUICombox();

            };
            #endregion

            #region 一键结清
            btnClear.Visible = false;
            btnClear.Click += delegate(object sender, EventArgs e)
            {

                DataTable dt = GetData(string.Format("select name,typetmp,moneytmp,datetmp,comment,kcczhm from account  order by datetmp asc "));
                if (dt == null)
                    return;

                using (FormClear form = new FormClear(dt, cbxName.EditValue.ToStringEx()))
                {
                    if (form.DialogResult != DialogResult.Cancel)
                        form.ShowDialog();
                }
            };
            #endregion

            #region 导出
            btnExport.Click += delegate
            {
                using (SaveFileDialog sf = new SaveFileDialog())
                {
                    if (sf.ShowDialog() != DialogResult.OK)
                        return;
                    sf.Title = "导出Csv文件";
                    sf.Filter = "Csv文件|*.Csv";
                    sf.RestoreDirectory = true;
                    sf.DefaultExt = ".csv";

                    gv.OptionsView.ShowFooter = false;
                    gc.ExportToCsv(sf.FileName.ToStringEx() + ".csv");
                    gv.OptionsView.ShowFooter = true;
                }
            };
            #endregion

            #region 导入
            btnImport.Click += delegate
            {
                ImportFromCSVFile();

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

            using (SQLiteConnection conn = OpenConnection())
            {
                using (SQLiteCommand comm = new SQLiteCommand())
                {
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
                }
            }

        }

        private void InitUICombox()
        {
            string StrComboxNameSQLQry = string.Format("select name,code from accountname where length('{0}') = 0 or code = '{1}' order by code asc "
                    , string.Empty, string.Empty);
            DataTable dtName = GetData(StrComboxNameSQLQry);

            if (dtName == null)
                return;
            DataRow drNewName = dtName.NewRow();
            drNewName["code"] = string.Empty;
            drNewName["name"] = "全部";
            dtName.Rows.InsertAt(drNewName, 0);
            cbxName.BindDataSource(dtName, "code", "name", true);
            RepositoryItemImageComboBox rcbxName = new RepositoryItemImageComboBox();
            rcbxName.BindDataSource(dtName, "code", "name");
            rcbxName.ImmediatePopup = true;
            rcbxName.ParseEditValue += delegate(object sender, ConvertEditValueEventArgs e)
            {
                e.Value = e.Value.ToString();
                e.Handled = true;
            };
            gv.Columns["name"].ColumnEdit = rcbxName;


            string StrComboxTypeSQLQry = string.Format("select name,code from accounttype where length('{0}') = 0 or code = '{1}' order by code asc "
                     , string.Empty, string.Empty);
            DataTable dtType = GetData(StrComboxTypeSQLQry);
            if (dtType == null)
                return;
            DataRow drNewType = dtType.NewRow();
            drNewType["code"] = string.Empty;
            drNewType["name"] = "全部";
            dtType.Rows.InsertAt(drNewType, 0);
            cbxType.BindDataSource(dtType, "code", "name", true);
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
            StrSQLQry = string.Format("select name,typetmp,moneytmp,datetmp,comment,kcczhm from account where (length('{0}') = 0 or name = '{1}') and (length('{2}') = 0 or typetmp = '{3}') order by datetmp asc "
               , cbxName.EditValue.ToStringEx(), cbxName.EditValue.ToStringEx(), cbxType.EditValue.ToStringEx(), cbxType.EditValue.ToStringEx());

            DataTable dt = GetData(StrSQLQry);
            if (dt == null)
                return;

            gc.DataSource = dt;
        }

        //DataAccess
        public DataTable GetData(string strSql)
        {
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = strSql;

                    SQLiteDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr, LoadOption.OverwriteChanges);
                    return dt;
                }
            }





            //SqlCommand comm = new SqlCommand(strSql.ToStringEx(), OpenConnection());
            //SqlDataReader dr = comm.ExecuteReader();

            //DataTable dt = new DataTable();
            //dt.Load(dr, LoadOption.OverwriteChanges);
            //OpenConnection().Close();
            //return dt;
        }
        internal SQLiteConnection OpenConnection()
        {
            SQLiteConnection conn = new SQLiteConnection(dbPath);
            conn.Open();
            return conn;
        }

        //Import
        private void ImportFromCSVFile()
        {
            using (OpenFileDialog of = new OpenFileDialog())
            {
                of.Filter = "CSV文件|*.CSV";
                of.RestoreDirectory = true;
                if (of.ShowDialog() != DialogResult.OK)
                    return;
                string strFileName = of.FileName;
                if (strFileName.IsNullOrEmpty())
                    return;
                DataTable dtName = cbxName.GetDataSource();
                DataTable dtType = cbxType.GetDataSource();

                using (FileStream fs = new FileStream(strFileName.ToStringEx(), FileMode.Open, FileAccess.Read))
                {
                    using (StreamReader sr = new StreamReader(fs, System.Text.Encoding.Default))
                    {
                        DataTable dtImport = GetDataTableFromCsv(sr, ',', strsColumnsNames);
                        //导入数据到gridControl
                        if (dtImport == null || dtImport.Rows.Count <= 0)
                            return;
                        dtImport.RemoveRows(a => a[0].ToStringEx() == "姓名" || a[0].ToStringEx().Contains("合计"));



                        foreach (DataRow drName in dtName.Rows)
                            UpdateRowByColumn(drName[0].ToStringEx(), drName[1].ToStringEx(), "name", ref dtImport);
                        foreach (DataRow drType in dtType.Rows)
                            UpdateRowByColumn(drType[0].ToStringEx(), drType[1].ToStringEx(), "typetmp", ref dtImport);

                        DataTable dt = gc.DataSource as DataTable;
                        DataRow drNew;
                        foreach (DataRow drImport in dtImport.Rows)
                        {
                            drNew = dt.NewRow();
                            drNew.ItemArray = drImport.ItemArray;
                            dt.Rows.Add(drNew);
                        }
                    };
                };
            };
        }
        private DataTable GetDataTableFromCsv(StreamReader sr, char splitter, string[] tableNames)
        {
            if (tableNames == null || tableNames.Length <= 0)
                return null;
            DataTable dtImport = new DataTable();
            foreach (string strTableName in tableNames)
                dtImport.Columns.Add(strTableName, typeof(string));

            string strLine = string.Empty;
            string[] strsLineData;
            do
            {
                strLine = sr.ReadLine();
                if (strLine.IsNullOrEmpty())
                    break;
                strsLineData = strLine.Split(splitter);
                DataRow drNew = dtImport.NewRow();
                for (int columnCnt = 0; columnCnt < strsLineData.Length; columnCnt++)
                {
                    try
                    {
                        drNew[columnCnt] = strsLineData[columnCnt].ToStringEx().Trim();
                    }
                    catch
                    {
                        continue;
                    }
                }
                dtImport.Rows.Add(drNew);
            } while (!strLine.IsNullOrEmpty());

            dtImport.RemoveEmptyRows();
            return dtImport;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p">搜索值</param>
        /// <param name="p_2">更新值</param>
        /// <param name="p_3">搜索列</param>
        /// <param name="dtImport">更新数据表</param>
        private void UpdateRowByColumn(string p, string p_2, string p_3, ref DataTable dtImport)
        {
            DataRow[] drs = dtImport.Select(string.Format(" {0} = '{1}'", p_3.ToStringEx(), p.ToStringEx()));
            if (drs.Length > 0)
                foreach (DataRow dr in drs)
                    dr[p_3] = p_2.ToStringEx();
        }
    }
}
