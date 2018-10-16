using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BaseExtensions;
using DevExpress.XtraBars;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace Finder.Translators
{
    //逻辑
    partial class FrmTranslator
    {
        private TreeListNode m_PopupNode;//弹出菜单所在的Node
        private Translator m_PopupTran;//弹出菜单所在的Translator
        private Translator m_ClipboardTran;//剪切板

        private void InitLogic()
        {
            //快捷键
            this.treeTranslators.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                TreeListNode node = this.treeTranslators.FocusedNode;
                if (node == null)
                    return;
                Translator tran = this.treeTranslators.GetDataRecordByNode(node) as Translator;
                if (tran == null)
                    return;
                switch (e.KeyData)
                {
                    case (Keys.Control | Keys.C):
                        TreeListColumn col = this.treeTranslators.FocusedColumn;
                        if (col == null)
                            break;
                        PropertyInfo propInfo = typeof(Translator).GetProperty(col.FieldName, BindingFlags.Instance | BindingFlags.Public);
                        if (propInfo == null)
                            break;
                        Clipboard.SetText(propInfo.GetValue(tran, null).ToStringEx());
                        e.Handled = true;
                        break;
                    case (Keys.Control | Keys.X):
                        this.DoCut(node, tran);
                        e.Handled = true;
                        break;
                    case (Keys.Control | Keys.V):
                        this.DoPaste(node, tran);
                        e.Handled = true;
                        break;
                    default:
                        break;
                }
            };

            //树菜单
            this.treeTranslators.MouseUp += delegate(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Right || Control.ModifierKeys != Keys.None)
                    return;

                if (this.treeTranslators.State != TreeListState.Regular)
                    return;

                Point screenPoint = Control.MousePosition;
                TreeListHitInfo hitInfo = this.treeTranslators.CalcHitInfo(this.treeTranslators.PointToClient(screenPoint));
                if (new HitInfoType[] { HitInfoType.Empty, HitInfoType.Row, HitInfoType.Cell }.Contains(hitInfo.HitInfoType))
                {
                    this.treeTranslators.FocusedNode = hitInfo.Node;
                    this.treeTranslators.FocusedColumn = hitInfo.Column;
                    this.ShowTreeMenu(hitInfo.Node, this.treeTranslators.GetDataRecordByNode(hitInfo.Node) as Translator, screenPoint);
                }
            };

            //添加文件夹
            this.funAddFolder.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                this.DoAddFolder(this.m_PopupNode, this.m_PopupTran);
            };

            //添加翻译器
            this.funAddTranslator.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                this.DoAddTranslator(this.m_PopupNode, this.m_PopupTran);
            };

            //删除
            this.funDelete.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                this.DoDelete(this.m_PopupNode, this.m_PopupTran);
            };

            //编辑
            this.funEdit.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                this.DoEdit(this.m_PopupNode, this.m_PopupTran);
            };

            //剪切
            this.funCut.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                this.DoCut(this.m_PopupNode, this.m_PopupTran);
            };

            //粘贴
            this.funPaste.ItemClick += delegate(object sender, ItemClickEventArgs e)
            {
                this.DoPaste(this.m_PopupNode, this.m_PopupTran);
            };

            //双击编辑
            this.treeTranslators.MouseDoubleClick += delegate(object sender, MouseEventArgs e)
            {
                if (e.Button != MouseButtons.Left || Control.ModifierKeys != Keys.None)
                    return;

                Point screenPoint = Control.MousePosition;
                TreeListHitInfo hitInfo = this.treeTranslators.CalcHitInfo(this.treeTranslators.PointToClient(screenPoint));
                if (hitInfo.HitInfoType != HitInfoType.Cell)
                    return;
                Translator tran = this.treeTranslators.GetDataRecordByNode(hitInfo.Node) as Translator;
                if (tran == null || tran.IsFolder)
                    return;
                this.DoEdit(hitInfo.Node, tran);
            };

            //替换官方资源
            this.btnReplaceResourceOrg.Click += delegate(object sender, EventArgs e)
            {
                this.DoReplaceResourceOrg();
            };

            //替换富友资源
            this.btnReplaceResourceWfy.Click += delegate(object sender, EventArgs e)
            {
                this.DoReplaceResourceWfy();
            };

            //查找
            this.btnFind.Click += delegate(object sender, EventArgs e)
            {
                this.DoFind();
            };

            //替换
            this.btnReplace.Click += delegate(object sender, EventArgs e)
            {
                this.DoReplace();
            };
        }

        private void DoAddFolder(TreeListNode node, Translator tran)
        {
            using (FrmTranslatorFolderEdit dialog = new FrmTranslatorFolderEdit())
            {
                dialog.Text = "新建文件夹";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                //预处理
                Translator subTran = dialog.Tran;
                subTran.ParentID = tran == null ? ROOT : tran.ID;
                //保存刷新
                this.m_DataSource.Trans.Add(subTran);
                this.SaveAndRefreshDataSource();
                //设置焦点节点
                TreeListNode subNode = this.treeTranslators.VisitNodes().FirstOrDefault(a => (this.treeTranslators.GetDataRecordByNode(a) as Translator).ID == subTran.ID);
                if (subNode == null)
                    return;
                this.treeTranslators.FocusedNode = subNode;
            }
        }

        private void DoAddTranslator(TreeListNode node, Translator tran)
        {
            using (FrmTranslatorEdit dialog = new FrmTranslatorEdit())
            {
                dialog.Text = "新建翻译器";
                if (dialog.ShowDialog(this) != DialogResult.OK)
                    return;

                //预处理
                Translator subTran = dialog.Tran;
                subTran.ParentID = tran == null ? ROOT : tran.ID;
                //保存刷新
                this.m_DataSource.Trans.Add(subTran);
                this.SaveAndRefreshDataSource();
                //设置焦点节点
                TreeListNode subNode = this.treeTranslators.VisitNodes().FirstOrDefault(a => (this.treeTranslators.GetDataRecordByNode(a) as Translator).ID == subTran.ID);
                if (subNode == null)
                    return;
                this.treeTranslators.FocusedNode = subNode;
                subNode.Checked = true;
            }
        }

        private void DoEdit(TreeListNode node, Translator tran)
        {
            if (tran == null)
                return;

            if (tran.IsFolder)
                using (FrmTranslatorFolderEdit dialog = new FrmTranslatorFolderEdit(tran))
                {
                    dialog.Text = "编辑文件夹";
                    if (dialog.ShowDialog(this) != DialogResult.OK)
                        return;
                    //保存刷新
                    this.SaveAndRefreshDataSource();
                }
            else
                using (FrmTranslatorEdit dialog = new FrmTranslatorEdit(tran))
                {
                    dialog.Text = "编辑翻译器";
                    if (dialog.ShowDialog(this) != DialogResult.OK)
                        return;
                    //保存刷新
                    this.SaveAndRefreshDataSource();
                }
        }

        private void DoDelete(TreeListNode node, Translator tran)
        {
            if (tran == null)
                return;

            if (MessageBox.Show(string.Format("确定要删除 [{0}]?", tran.Name), "提示", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            //预处理
            TreeListNode prevNode = node.PrevVisibleNode;
            Translator prevTran = prevNode == null ? null : (this.treeTranslators.GetDataRecordByNode(prevNode) as Translator);
            //保存刷新
            this.DeleteData(tran);
            this.SaveAndRefreshDataSource();
            //设置焦点节点
            if (prevTran == null)
                return;
            TreeListNode _prevNode = this.treeTranslators.VisitNodes().FirstOrDefault(a => (this.treeTranslators.GetDataRecordByNode(a) as Translator).ID == prevTran.ID);
            if (_prevNode == null)
                return;
            this.treeTranslators.FocusedNode = _prevNode;
        }

        private void DoCut(TreeListNode node, Translator tran)
        {
            if (tran == null)
                return;

            this.m_ClipboardTran = tran;
        }

        private void DoPaste(TreeListNode node, Translator tran)
        {
            if (this.m_ClipboardTran == null)
                return;

            //预处理
            this.m_ClipboardTran.ParentID = tran == null ? ROOT : tran.ID;
            //保存刷新
            this.SaveAndRefreshDataSource();
            //设置焦点节点
            TreeListNode clipboardNode = this.treeTranslators.VisitNodes().FirstOrDefault(a => (this.treeTranslators.GetDataRecordByNode(a) as Translator).ID == this.m_ClipboardTran.ID);
            if (clipboardNode != null)
                this.treeTranslators.FocusedNode = clipboardNode;
            this.m_ClipboardTran = null;
        }

        private void DoReplaceResourceOrg()
        {
            this.txtLog.ClearEdit();

            TranslatorConfig config = new TranslatorConfig
            {
                WorkFolder = this.txtWorkDir.EditValue.ToStringEx(),
                ExceptTopFile = this.chkExceptTopFile.EditValue.ToDefaultableBoolean(),
                AutoGitCommit = this.chkAutoGitCommit.EditValue.ToDefaultableBoolean(),
            };

            if (config.WorkFolder.IsNullOrEmpty())
                return;

            StringBuilder result = FindReplace.TranslatorReplaceResourceOrg(config);
            this.txtLog.AppendLine(result.ToStringEx());
            this.txtLog.AppendLine("=======================================\r\n");
        }

        private void DoReplaceResourceWfy()
        {
            this.txtLog.ClearEdit();

            TranslatorConfig config = new TranslatorConfig
            {
                WorkFolder = this.txtWorkDir.EditValue.ToStringEx(),
                ExceptTopFile = this.chkExceptTopFile.EditValue.ToDefaultableBoolean(),
                AutoGitCommit = this.chkAutoGitCommit.EditValue.ToDefaultableBoolean(),
            };

            if (config.WorkFolder.IsNullOrEmpty())
                return;

            StringBuilder result = FindReplace.TranslatorReplaceResourceWfy(config);
            this.txtLog.AppendLine(result.ToStringEx());
            this.txtLog.AppendLine("=======================================\r\n");
        }

        private void DoFind()
        {
            this.txtLog.ClearEdit();

            List<Translator> trans = this.treeTranslators.VisitNodes()
                .Where(a => a.Checked)
                .Select(a => this.treeTranslators.GetDataRecordByNode(a) as Translator)
                .Where(b => !b.IsFolder)
                .ToList();

            TranslatorConfig config = new TranslatorConfig
            {
                WorkFolder = this.txtWorkDir.EditValue.ToStringEx(),
                ExceptTopFile = this.chkExceptTopFile.EditValue.ToDefaultableBoolean(),
                AutoGitCommit = this.chkAutoGitCommit.EditValue.ToDefaultableBoolean(),
            };

            if (config.WorkFolder.IsNullOrEmpty())
                return;

            foreach (Translator tran in trans)
            {
                StringBuilder result = FindReplace.TranslatorFind(this, config, tran);
                this.txtLog.AppendLine(result.ToStringEx());
                this.txtLog.AppendLine("=======================================\r\n");
            }
        }

        private void DoReplace()
        {
            this.txtLog.ClearEdit();

            List<Translator> trans = this.treeTranslators.VisitNodes()
               .Where(a => a.Checked)
               .Select(a => this.treeTranslators.GetDataRecordByNode(a) as Translator)
               .Where(b => !b.IsFolder)
               .ToList();

            TranslatorConfig config = new TranslatorConfig
            {
                WorkFolder = this.txtWorkDir.EditValue.ToStringEx(),
                ExceptTopFile = this.chkExceptTopFile.EditValue.ToDefaultableBoolean(),
                AutoGitCommit = this.chkAutoGitCommit.EditValue.ToDefaultableBoolean(),
            };

            if (config.WorkFolder.IsNullOrEmpty())
                return;

            Translator parent;
            string comment;
            foreach (Translator tran in trans)
            {
                parent = this.m_DataSource.Trans.FirstOrDefault(a => a.ID == tran.ParentID);
                comment = parent == null ? tran.Name : string.Format("【{0}】{1}", parent.Name, tran.Name);
                StringBuilder result = FindReplace.TranslatorReplace(this, config, tran, comment);
                this.txtLog.AppendLine(result.ToStringEx());
                this.txtLog.AppendLine("=======================================\r\n");
            }
        }


        //显示右键菜单
        private void ShowTreeMenu(TreeListNode node, Translator tran, Point screenPoint)
        {
            if (tran == null)
            {
                this.funAddFolder.Visibility = BarItemVisibility.Always;
                this.funAddTranslator.Visibility = BarItemVisibility.Always;
                this.funDelete.Visibility = BarItemVisibility.Never;
                this.funEdit.Visibility = BarItemVisibility.Never;
                this.funCut.Enabled = false;
                this.funPaste.Enabled = this.m_ClipboardTran != null;
            }
            else if (tran.IsFolder)
            {
                this.funAddFolder.Visibility = BarItemVisibility.Always;
                this.funAddTranslator.Visibility = BarItemVisibility.Always;
                this.funDelete.Visibility = BarItemVisibility.Always;
                this.funEdit.Visibility = BarItemVisibility.Always;
                this.funCut.Enabled = true;
                this.funPaste.Enabled = this.m_ClipboardTran != null;
            }
            else
            {
                this.funAddFolder.Visibility = BarItemVisibility.Never;
                this.funAddTranslator.Visibility = BarItemVisibility.Never;
                this.funDelete.Visibility = BarItemVisibility.Always;
                this.funEdit.Visibility = BarItemVisibility.Always;
                this.funCut.Enabled = true;
                this.funPaste.Enabled = false;
            }
            this.m_PopupNode = node;
            this.m_PopupTran = tran;
            this.treeMenu.ShowPopup(screenPoint);
        }

        //删除指定翻译器及其子翻译器
        private void DeleteData(Translator tran)
        {
            foreach (Translator _node in this.m_DataSource.Trans.Where(a => a.ParentID == tran.ID).ToList())
                this.DeleteData(_node);
            this.m_DataSource.Trans.Remove(tran);
        }

        //保存刷新翻译器数据
        private void SaveAndRefreshDataSource()
        {
            this.treeTranslators.BeginUpdate();
            int leftCoord = this.treeTranslators.LeftCoord;
            TreeListColumn column = this.treeTranslators.FocusedColumn;
            int topVisibleNodeIndex = this.treeTranslators.TopVisibleNodeIndex;
            try
            {
                //重新从数据源加载
                this.treeTranslators.RefreshDataSource();
                //校正勾选状态
                this.treeTranslators.CorrectNodesCheckState();
                //勾选处理
                if (this.m_DataSource != null)
                {
                    this.m_DataSource.CheckedIds.Clear();
                    this.m_DataSource.CheckedIds.AddRange(this.treeTranslators.GetAllCheckedNodes().Select(a => (this.treeTranslators.GetDataRecordByNode(a) as Translator).ID));
                }
                //保存
                Globalspace.TR_Translators = JsonSerializer.Serialize(this.m_DataSource);
            }
            finally
            {
                this.treeTranslators.TopVisibleNodeIndex = topVisibleNodeIndex;
                this.treeTranslators.FocusedColumn = column;
                this.treeTranslators.LeftCoord = leftCoord;
                this.treeTranslators.EndUpdate();
            }
        }
    }
}
