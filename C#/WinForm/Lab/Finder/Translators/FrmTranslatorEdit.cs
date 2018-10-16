using System;
using System.Linq;
using System.Windows.Forms;
using BaseExtensions;
using Finder.Properties;

namespace Finder.Translators
{
    //翻译器编辑窗口
    public partial class FrmTranslatorEdit : Form
    {
        public Translator Tran { get; private set; }

        //构造函数
        public FrmTranslatorEdit(Translator tran = null)
        {
            InitializeComponent();
            this.Icon = Resources.app;

            if (tran == null)
                tran = new Translator() { ID = Guid.NewGuid().ToStringEx(), IsFolder = false };
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
            this.chkCaseMatch.EditValue = this.Tran.CaseMatch;
            this.chkWordMatch.EditValue = this.Tran.WordMatch;
            this.txtFind.EditValue = this.Tran.Find;
            this.txtReplace.EditValue = this.Tran.Replace;
            this.txtBanPrefix.EditValue = this.Tran.BanPrefix;
            this.txtBanSuffix.EditValue = this.Tran.BanSuffix;
            this.txtIncludeFiles.EditValue = this.Tran.IncludeFile == null ? string.Empty : string.Join("\r\n", this.Tran.IncludeFile.Distinct().OrderBy(a => a));
            this.txtExcludeFiles.EditValue = this.Tran.ExcludeFile == null ? string.Empty : string.Join("\r\n", this.Tran.ExcludeFile.Distinct().OrderBy(a => a));
            this.txtName.ButtonClick += (sender, e) => this.txtName.EditValue = null;
        }

        //初始化逻辑
        private void InitLogic()
        {
            this.btnOK.Click += delegate(object sender, EventArgs e)
            {
                if (this.txtFind.EditValue.IsNullOrEmpty())
                {
                    MessageBox.Show("查找不能为空");
                    return;
                }

                this.Tran.Name = this.txtName.EditValue.IsNullOrEmpty() ? (this.txtFind.EditValue.ToStringEx() + "=>" + this.txtReplace.EditValue.ToStringEx()) : this.txtName.EditValue.ToStringEx();
                this.Tran.CaseMatch = this.chkCaseMatch.EditValue.ToDefaultableBoolean();
                this.Tran.WordMatch = this.chkWordMatch.EditValue.ToDefaultableBoolean();
                this.Tran.Find = this.txtFind.EditValue.ToStringEx();
                this.Tran.Replace = this.txtReplace.EditValue.ToStringEx();
                this.Tran.BanPrefix = this.txtBanPrefix.EditValue.ToStringEx();
                this.Tran.BanSuffix = this.txtBanSuffix.EditValue.ToStringEx();
                this.Tran.IncludeFile = this.txtIncludeFiles.EditValue.ToStringEx().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(a => a).ToArray();
                this.Tran.ExcludeFile = this.txtExcludeFiles.EditValue.ToStringEx().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).Distinct().OrderBy(a => a).ToArray();
                this.Tran.ModifyTime = DateTime.Now;
                this.DialogResult = DialogResult.OK;
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
