using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AccountBase;

namespace AccountWithSQL
{
    public partial class FormLogin : Form
    {
        public string Result { get; set; }

        FormAccountSQLite accountSQLite = new FormAccountSQLite();
        XmlData xd;//读写xml文件

        public FormLogin()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitLogic();
        }

        private void InitLogic()
        {
            //登录
            simpleButton1.Click += delegate(object sender, EventArgs e)
            {
                if ((txtName.EditValue ?? string.Empty).Equals("sa") && (txtPswd.EditValue ?? string.Empty).Equals("123"))
                {
                    this.Result = "OK";
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else if (UserCheck())
                {
                    this.Result = "OK";
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    xd = new XmlData((txtName.EditValue ?? string.Empty).ToString(), (txtPswd.EditValue ?? string.Empty).ToString());
                }
                else
                {
                    this.Result = "NO";
                    MessageBox.Show(this, "登录失败,清重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            #region 右键弹出快捷菜单
            this.MouseClick += delegate(object sender, MouseEventArgs e)
            {
                if (e.Button == MouseButtons.Right)
                    contextMenuStrip1.Show(this, new Point(e.X + 5, e.Y));
            };

            toolStripMenuItem1.Click += delegate
            {
                MessageBox.Show(this, "添加", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            toolStripMenuItem2.Click += delegate
            {
                xd = new XmlData("sa","123");
                //xd.DeleteXmlFile();
                MessageBox.Show(this, "删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            toolStripMenuItem3.Click += delegate
            {
                xd = new XmlData();
                DataTable dt = xd.ReadXmlToDataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (Application.OpenForms.Count <= 0)
                        return;
                    Form mainForm = Application.OpenForms[0];
                    System.Threading.Tasks.Task.Factory.StartNew(() =>
                    {
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            this.txtName.EditValue = dt.Rows[0][0].ToString() ?? string.Empty;
                            this.txtPswd.EditValue = dt.Rows[0][1].ToString() ?? string.Empty;
                        }));
                    })
                    .ContinueWith((s) =>
                    {
                        System.Threading.Thread.Sleep(1000);
                        mainForm.Invoke(new MethodInvoker(() =>
                        {
                            this.simpleButton1.PerformClick();
                        }));
                    });

                }


            };
            #endregion
        }

        //校验用户密码
        private bool UserCheck()
        {
            if (txtName.EditValue == null || txtName.EditValue.ToString() == "")
                return false;
            if (txtPswd.EditValue == null || txtPswd.EditValue.ToString() == "")
                return false;



            //获取用户帐号及密码

            string StrComboxNameSQLQry = string.Format("select name,code,pswd from accountname where length('{0}') = 0 or code = '{1}' order by code asc "
                       , string.Empty, string.Empty);
            DataTable dtName = accountSQLite.GetData(StrComboxNameSQLQry);

            DataRow[] drs = dtName.Select(string.Format(" name = '{0}'", txtName.EditValue.ToString()));
            if (drs.Length > 0)
                if (drs[0]["pswd"].ToString().Equals(txtPswd.EditValue.ToString()))
                {
                    //string strUser = BaseConfigure.GetConfig("USER", txtName.EditValue.ToString());
                    //string strPassWord = BaseConfigure.GetConfig("PASSWORD", txtPawd.EditValue.ToString());
                    //BaseConfigure.SaveConfing("USER", txtName.EditValue.ToString());
                    //BaseConfigure.SaveConfing("PASSWORD", txtPawd.EditValue.ToString());

                    return true;
                }

            return false;
        }

    }
}
