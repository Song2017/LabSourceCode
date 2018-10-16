using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseExtensions;
using DataAccess;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace AccountWithSQL
{
    public partial class FormType : Form
    {
        FormAccountSQLite accountSQLite = new FormAccountSQLite();

        public FormType()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitUI();
            InitLogic();
            DataReload();
        }

        private void InitUI()
        {
            gv.SetShowRowNo();
            gv.SetMultiSelect();
        }

        private void InitLogic()
        {
            //  增加
            btnAdd.Click += delegate(object sender, EventArgs e)
            {
                DataTable dt = gc.DataSource as DataTable;
                DataRow drNew = dt.NewRow();
                drNew["name"] = string.Empty;
                drNew["code"] = string.Empty;
                dt.Rows.Add(drNew);
            };

            // 保存
            btnSav.Click += delegate(object sender, EventArgs e)
            {
                if (!SaveCheck())
                    return;
                AccountSave();
                DataReload();
            };

            // 删除
            btnDel.Click += delegate(object sender, EventArgs e)
            {
                gv.DeleteSelectedRows();
            };

            // 修改前校验
            gv.ShowingEditor += delegate(object sender, CancelEventArgs e)
            {
                if (!gv.FocusedColumn.FieldName.Equals("code"))
                    return;
                DataRow dr = gv.GetFocusedDataRow();
                if (dr == null)
                    return;

                if (dr.RowState == DataRowState.Unchanged || dr.RowState == DataRowState.Deleted)
                    gv.Columns["code"].OptionsColumn.ReadOnly = true;
                else
                    gv.Columns["code"].OptionsColumn.ReadOnly = false;
            };

            
        }

        private void AccountSave()
        {
            DataTable dt = gc.DataSource as DataTable;
            if (dt == null)
                return;

            SQLiteConnection conn = accountSQLite.OpenConnection();
            SQLiteCommand comm = new SQLiteCommand();

            DataRow[] drSavs = dt.Select(null, null, DataViewRowState.Added);
            foreach (DataRow drSav in drSavs)
            {
                comm.CommandText = string.Format("insert into accounttype ( name,code  ) values ( '{0}','{1}' ) ",
                   drSav["name"].ToStringEx(), drSav["code"].ToStringEx() );
                comm.Connection = conn;
                comm.ExecuteNonQuery();
            }

            DataRow[] drMdys = dt.Select(null, null, DataViewRowState.ModifiedCurrent);
            foreach (DataRow drMdy in drMdys)
            {
                comm.CommandText = string.Format("update accounttype set name = '{0}'  where code = '{1}'   ",
                        drMdy["name"].ToStringEx(), drMdy["code"].ToStringEx());
                comm.Connection = conn;
                comm.ExecuteNonQuery();
            }

            DataRow[] drDels = dt.Select(null, null, DataViewRowState.Deleted);
            foreach (DataRow drDel in drDels)
            {
                comm.CommandText = string.Format("delete from accounttype where code = '{0}'   ",
                          drDel["code", DataRowVersion.Original].ToStringEx() );
                comm.Connection = conn;
                comm.ExecuteNonQuery();
            }

            conn.Close();
        }

        private bool SaveCheck()
        {
            gv.CloseEditor();
            gv.UpdateCurrentRow();

            DataTable dt = gc.DataSource as DataTable;
            if (dt == null || dt.Rows.Count <= 0)
                return false;

            dt.RemoveEmptyRows("code","name");

            var varRep = dt.AsEnumerable()
                .Where(a => a.RowState == DataRowState.Added || a.RowState == DataRowState.Modified)
                .GroupBy(a => new string[] { "code" })
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


        private void DataReload()
        {
            string StrSQLQry = string.Format("select name,code from accounttype ",string.Empty);
            
            DataTable dt = accountSQLite.GetData(StrSQLQry);
            if (dt == null)
                return;

            gc.DataSource = dt;
        }
    }
}
