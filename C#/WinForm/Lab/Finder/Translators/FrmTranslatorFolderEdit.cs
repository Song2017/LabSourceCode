using System;
using System.Windows.Forms;
using BaseExtensions;
using Finder.Properties;

namespace Finder.Translators
{
    //文件夹
    public partial class FrmTranslatorFolderEdit : Form
    {
        public Translator Tran { get; private set; }

        //构造函数
        public FrmTranslatorFolderEdit(Translator tran = null)
        {
            InitializeComponent();
            this.Icon = Resources.app;

            if (tran == null)
                tran = new Translator() { ID = Guid.NewGuid().ToStringEx(), IsFolder = true };
            this.Tran = tran;
            this.Init();
        }

        //初始化
        private void Init()
        {
            this.InitUI();
            this.InitLogic();
        }

        //初始化界面
        private void InitUI()
        {
            this.txtName.EditValue = this.Tran.Name;
        }

        //初始化逻辑
        private void InitLogic()
        {
            this.btnOK.Click += delegate(object sender, EventArgs e)
            {
                if (this.txtName.EditValue.IsNullOrEmpty())
                {
                    MessageBox.Show("名称不能为空");
                    return;
                }

                this.Tran.Name = this.txtName.EditValue.ToStringEx();
                this.Tran.ModifyTime = DateTime.Now;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            };

            this.btnCancel.Click += delegate(object sender, EventArgs e)
            {
                this.DialogResult = DialogResult.Cancel;
            };
        }

        //快捷键
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    this.btnCancel.PerformClick();
                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
    }
}
