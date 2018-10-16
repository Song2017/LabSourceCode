using System;
using System.Windows.Forms;

namespace Finder
{
    //配置设置界面
    public partial class FrmConfig : Form
    {
        //构造函数
        public FrmConfig()
        {
            InitializeComponent();
            this.Init();
        }

        //初始化
        private void Init()
        {
            //加载
            this.chkEnabled.Checked = Globalspace.Enabled;
            this.txtServer.Text = Globalspace.Server;
            this.txtPort.Text = Globalspace.Port;
            this.txtUserName.Text = Globalspace.UserName;
            this.txtPwd.Text = Globalspace.Pwd;
            this.txtAlias.Text = Globalspace.Alias;
            this.txtPrj.Text = Globalspace.Prj;
            this.txtWorkDir.Text = Globalspace.WorkDir;

            //引用
            this.btnApply.Click += delegate(object sender, EventArgs e)
            {
                Globalspace.Enabled = this.chkEnabled.Checked;
                Globalspace.Server = this.txtServer.Text;
                Globalspace.Port = this.txtPort.Text;
                Globalspace.UserName = this.txtUserName.Text;
                Globalspace.Pwd = this.txtPwd.Text;
                Globalspace.Alias = this.txtAlias.Text;
                Globalspace.Prj = this.txtPrj.Text;
                Globalspace.WorkDir = this.txtWorkDir.Text;
            };

            //取消
            this.btnCancel.Click += delegate(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            };
        }
    }
}
