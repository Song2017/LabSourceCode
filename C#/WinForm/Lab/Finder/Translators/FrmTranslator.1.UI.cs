using System.Windows.Forms;
using BaseExtensions;

namespace Finder.Translators
{
    partial class FrmTranslator
    {
        private void InitUI()
        {
            //设置
            this.treeTranslators.SetCheckable(true);
            this.treeTranslators.SetShowRowNo();

            //读取
            this.ReadUI();

            //界面改变保存
            this.txtWorkDir.EditValueChanged += (sender, e) => Globalspace.TR_WorkDir = this.txtWorkDir.EditValue.ToStringEx();
            this.chkExceptTopFile.EditValueChanged += (sender, e) => Globalspace.TR_ExcludeHomeFile = this.chkExceptTopFile.EditValue.ToDefaultableBoolean();
            this.chkAutoGitCommit.EditValueChanged += (sender, e) => Globalspace.TR_AutoGitCommmit = this.chkAutoGitCommit.EditValue.ToDefaultableBoolean();
            this.txtLog.EditValueChanged += (sender, e) => Globalspace.TR_Log = this.txtLog.EditValue.ToStringEx();
            this.treeTranslators.AfterCheckNode += (sender, e) =>
            {
                this.SaveAndRefreshDataSource();//保存刷新
            };

            //浏览
            this.txtWorkDir.ButtonClick += (sender, e) =>
            {
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        this.txtWorkDir.EditValue = dialog.SelectedPath;
                }
            };

        }

        private void ReadUI()
        {
            this.txtWorkDir.EditValue = Globalspace.TR_WorkDir;
            this.chkExceptTopFile.EditValue = Globalspace.TR_ExcludeHomeFile;
            this.chkAutoGitCommit.EditValue = Globalspace.TR_AutoGitCommmit;
            string error;
            JsonSerializer.Deserialize<TranslatorDataSource>(Globalspace.TR_Translators, out this.m_DataSource, out error);
            if (this.m_DataSource == null)
                this.m_DataSource = new TranslatorDataSource();
            this.treeTranslators.ImageIndexFieldName = "ImageIndex";
            this.treeTranslators.BindDataSource(this.m_DataSource.Trans, "ID", "ParentID", ROOT);
            this.treeTranslators.ExpandLevel(1);
            this.treeTranslators.CheckNodes(node => this.m_DataSource.CheckedIds.Contains((this.treeTranslators.GetDataRecordByNode(node) as Translator).ID));
            this.txtLog.EditValue = Globalspace.TR_Log;
        }
    }
}
