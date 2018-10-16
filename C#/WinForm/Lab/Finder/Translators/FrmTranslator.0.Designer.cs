namespace Finder.Translators
{
    partial class FrmTranslator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTranslator));
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.treeTranslators = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn4 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn5 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn6 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn7 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn8 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn9 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn10 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.treeListColumn11 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.funAddFolder = new DevExpress.XtraBars.BarButtonItem();
            this.funAddTranslator = new DevExpress.XtraBars.BarButtonItem();
            this.funEdit = new DevExpress.XtraBars.BarButtonItem();
            this.funDelete = new DevExpress.XtraBars.BarButtonItem();
            this.funCut = new DevExpress.XtraBars.BarButtonItem();
            this.funPaste = new DevExpress.XtraBars.BarButtonItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.chkExceptTopFile = new DevExpress.XtraEditors.CheckEdit();
            this.txtLog = new DevExpress.XtraEditors.MemoEdit();
            this.splitterControl1 = new DevExpress.XtraEditors.SplitterControl();
            this.btnReplace = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtWorkDir = new DevExpress.XtraEditors.ButtonEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.chkAutoGitCommit = new DevExpress.XtraEditors.CheckEdit();
            this.btnReplaceResourceWfy = new DevExpress.XtraEditors.SimpleButton();
            this.btnReplaceResourceOrg = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.treeMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.tabIndexProvider1 = new BaseExtensions.Controls.TabIndexProvider();
            this.treeListColumn12 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeTranslators)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExceptTopFile.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkDir.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoGitCommit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(840, 40);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 8;
            this.btnFind.Text = "查找";
            // 
            // treeTranslators
            // 
            this.treeTranslators.Appearance.FocusedCell.BackColor = System.Drawing.Color.DodgerBlue;
            this.treeTranslators.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.treeTranslators.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeTranslators.Appearance.FocusedRow.BackColor = System.Drawing.Color.DodgerBlue;
            this.treeTranslators.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.DodgerBlue;
            this.treeTranslators.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeTranslators.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3,
            this.treeListColumn4,
            this.treeListColumn5,
            this.treeListColumn6,
            this.treeListColumn7,
            this.treeListColumn8,
            this.treeListColumn9,
            this.treeListColumn10,
            this.treeListColumn11,
            this.treeListColumn12});
            this.treeTranslators.CustomizationFormBounds = new System.Drawing.Rectangle(936, 416, 234, 217);
            this.treeTranslators.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeTranslators.Location = new System.Drawing.Point(0, 69);
            this.treeTranslators.MenuManager = this.barManager1;
            this.treeTranslators.Name = "treeTranslators";
            this.treeTranslators.OptionsBehavior.Editable = false;
            this.treeTranslators.OptionsBehavior.PopulateServiceColumns = true;
            this.treeTranslators.OptionsView.AutoWidth = false;
            this.treeTranslators.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2});
            this.treeTranslators.SelectImageList = this.imageCollection1;
            this.treeTranslators.Size = new System.Drawing.Size(300, 493);
            this.treeTranslators.TabIndex = 2;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn1.Caption = "翻译器";
            this.treeListColumn1.FieldName = "Name";
            this.treeListColumn1.MinWidth = 100;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.OptionsColumn.AllowSort = false;
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            this.treeListColumn1.Width = 300;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn2.Caption = "类型";
            this.treeListColumn2.FieldName = "IsFolder";
            this.treeListColumn2.MinWidth = 100;
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.OptionsColumn.AllowSort = false;
            this.treeListColumn2.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumn2.SortOrder = System.Windows.Forms.SortOrder.Descending;
            this.treeListColumn2.Width = 100;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn3.Caption = "名称";
            this.treeListColumn3.FieldName = "Name";
            this.treeListColumn3.MinWidth = 100;
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.OptionsColumn.AllowSort = false;
            this.treeListColumn3.OptionsColumn.ShowInCustomizationForm = false;
            this.treeListColumn3.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.treeListColumn3.Width = 100;
            // 
            // treeListColumn4
            // 
            this.treeListColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn4.Caption = "查找";
            this.treeListColumn4.FieldName = "Find";
            this.treeListColumn4.MinWidth = 100;
            this.treeListColumn4.Name = "treeListColumn4";
            this.treeListColumn4.OptionsColumn.AllowSort = false;
            this.treeListColumn4.Visible = true;
            this.treeListColumn4.VisibleIndex = 3;
            this.treeListColumn4.Width = 160;
            // 
            // treeListColumn5
            // 
            this.treeListColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn5.Caption = "替换";
            this.treeListColumn5.FieldName = "Replace";
            this.treeListColumn5.MinWidth = 100;
            this.treeListColumn5.Name = "treeListColumn5";
            this.treeListColumn5.OptionsColumn.AllowSort = false;
            this.treeListColumn5.Visible = true;
            this.treeListColumn5.VisibleIndex = 4;
            this.treeListColumn5.Width = 160;
            // 
            // treeListColumn6
            // 
            this.treeListColumn6.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn6.Caption = "禁用前缀";
            this.treeListColumn6.FieldName = "BanPrefix";
            this.treeListColumn6.MinWidth = 100;
            this.treeListColumn6.Name = "treeListColumn6";
            this.treeListColumn6.OptionsColumn.AllowSort = false;
            this.treeListColumn6.Visible = true;
            this.treeListColumn6.VisibleIndex = 5;
            this.treeListColumn6.Width = 100;
            // 
            // treeListColumn7
            // 
            this.treeListColumn7.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn7.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn7.Caption = "禁用后缀";
            this.treeListColumn7.FieldName = "BanSuffix";
            this.treeListColumn7.MinWidth = 100;
            this.treeListColumn7.Name = "treeListColumn7";
            this.treeListColumn7.OptionsColumn.AllowSort = false;
            this.treeListColumn7.Visible = true;
            this.treeListColumn7.VisibleIndex = 6;
            this.treeListColumn7.Width = 100;
            // 
            // treeListColumn8
            // 
            this.treeListColumn8.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn8.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn8.Caption = "包含文件";
            this.treeListColumn8.FieldName = "IncludeFileDisplay";
            this.treeListColumn8.MinWidth = 100;
            this.treeListColumn8.Name = "treeListColumn8";
            this.treeListColumn8.OptionsColumn.AllowSort = false;
            this.treeListColumn8.Visible = true;
            this.treeListColumn8.VisibleIndex = 7;
            this.treeListColumn8.Width = 100;
            // 
            // treeListColumn9
            // 
            this.treeListColumn9.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn9.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn9.Caption = "排除文件";
            this.treeListColumn9.FieldName = "ExcludeFileDisplay";
            this.treeListColumn9.MinWidth = 100;
            this.treeListColumn9.Name = "treeListColumn9";
            this.treeListColumn9.OptionsColumn.AllowSort = false;
            this.treeListColumn9.Visible = true;
            this.treeListColumn9.VisibleIndex = 8;
            this.treeListColumn9.Width = 100;
            // 
            // treeListColumn10
            // 
            this.treeListColumn10.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn10.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn10.Caption = "大小写匹配";
            this.treeListColumn10.ColumnEdit = this.repositoryItemCheckEdit1;
            this.treeListColumn10.FieldName = "CaseMatch";
            this.treeListColumn10.MinWidth = 80;
            this.treeListColumn10.Name = "treeListColumn10";
            this.treeListColumn10.OptionsColumn.AllowSort = false;
            this.treeListColumn10.Visible = true;
            this.treeListColumn10.VisibleIndex = 1;
            this.treeListColumn10.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // treeListColumn11
            // 
            this.treeListColumn11.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn11.Caption = "全字匹配";
            this.treeListColumn11.ColumnEdit = this.repositoryItemCheckEdit2;
            this.treeListColumn11.FieldName = "WordMatch";
            this.treeListColumn11.MinWidth = 80;
            this.treeListColumn11.Name = "treeListColumn11";
            this.treeListColumn11.OptionsColumn.AllowSort = false;
            this.treeListColumn11.Visible = true;
            this.treeListColumn11.VisibleIndex = 2;
            this.treeListColumn11.Width = 80;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.funAddFolder,
            this.funAddTranslator,
            this.funEdit,
            this.funDelete,
            this.funCut,
            this.funPaste});
            this.barManager1.MaxItemId = 13;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1008, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 562);
            this.barDockControlBottom.Size = new System.Drawing.Size(1008, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 562);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1008, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 562);
            // 
            // funAddFolder
            // 
            this.funAddFolder.Caption = "添加文件夹";
            this.funAddFolder.Glyph = ((System.Drawing.Image)(resources.GetObject("funAddFolder.Glyph")));
            this.funAddFolder.Id = 3;
            this.funAddFolder.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("funAddFolder.LargeGlyph")));
            this.funAddFolder.Name = "funAddFolder";
            // 
            // funAddTranslator
            // 
            this.funAddTranslator.Caption = "添加翻译器";
            this.funAddTranslator.Glyph = ((System.Drawing.Image)(resources.GetObject("funAddTranslator.Glyph")));
            this.funAddTranslator.Id = 4;
            this.funAddTranslator.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("funAddTranslator.LargeGlyph")));
            this.funAddTranslator.Name = "funAddTranslator";
            // 
            // funEdit
            // 
            this.funEdit.Caption = "编辑";
            this.funEdit.Glyph = ((System.Drawing.Image)(resources.GetObject("funEdit.Glyph")));
            this.funEdit.Id = 7;
            this.funEdit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("funEdit.LargeGlyph")));
            this.funEdit.Name = "funEdit";
            // 
            // funDelete
            // 
            this.funDelete.Caption = "删除";
            this.funDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("funDelete.Glyph")));
            this.funDelete.Id = 5;
            this.funDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("funDelete.LargeGlyph")));
            this.funDelete.Name = "funDelete";
            // 
            // funCut
            // 
            this.funCut.Caption = "剪切";
            this.funCut.Glyph = ((System.Drawing.Image)(resources.GetObject("funCut.Glyph")));
            this.funCut.Id = 10;
            this.funCut.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("funCut.LargeGlyph")));
            this.funCut.Name = "funCut";
            // 
            // funPaste
            // 
            this.funPaste.Caption = "粘贴";
            this.funPaste.Glyph = ((System.Drawing.Image)(resources.GetObject("funPaste.Glyph")));
            this.funPaste.Id = 11;
            this.funPaste.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("funPaste.LargeGlyph")));
            this.funPaste.Name = "funPaste";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.InsertGalleryImage("open_16x16.png", "images/actions/open_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/open_16x16.png"), 0);
            this.imageCollection1.Images.SetKeyName(0, "open_16x16.png");
            this.imageCollection1.InsertGalleryImage("withtextwrapping_topright_16x16.png", "images/arrange/withtextwrapping_topright_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/arrange/withtextwrapping_topright_16x16.png"), 1);
            this.imageCollection1.Images.SetKeyName(1, "withtextwrapping_topright_16x16.png");
            // 
            // chkExceptTopFile
            // 
            this.chkExceptTopFile.Location = new System.Drawing.Point(122, 42);
            this.chkExceptTopFile.Name = "chkExceptTopFile";
            this.chkExceptTopFile.Size = new System.Drawing.Size(19, 19);
            this.chkExceptTopFile.TabIndex = 3;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(305, 69);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(703, 493);
            this.txtLog.TabIndex = 5;
            this.txtLog.UseOptimizedRendering = true;
            // 
            // splitterControl1
            // 
            this.splitterControl1.Location = new System.Drawing.Point(300, 69);
            this.splitterControl1.Name = "splitterControl1";
            this.splitterControl1.Size = new System.Drawing.Size(5, 493);
            this.splitterControl1.TabIndex = 4;
            this.splitterControl1.TabStop = false;
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.Location = new System.Drawing.Point(921, 40);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 9;
            this.btnReplace.Text = "替换";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(52, 14);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "工作目录:";
            // 
            // txtWorkDir
            // 
            this.txtWorkDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWorkDir.Location = new System.Drawing.Point(76, 12);
            this.txtWorkDir.Name = "txtWorkDir";
            this.txtWorkDir.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtWorkDir.Properties.ReadOnly = true;
            this.txtWorkDir.Size = new System.Drawing.Size(920, 22);
            this.txtWorkDir.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelControl4);
            this.panel1.Controls.Add(this.chkAutoGitCommit);
            this.panel1.Controls.Add(this.btnReplaceResourceWfy);
            this.panel1.Controls.Add(this.btnReplaceResourceOrg);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.btnReplace);
            this.panel1.Controls.Add(this.chkExceptTopFile);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.txtWorkDir);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 69);
            this.panel1.TabIndex = 1;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(186, 44);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(103, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "自动提交到Git仓库:";
            // 
            // chkAutoGitCommit
            // 
            this.chkAutoGitCommit.Location = new System.Drawing.Point(293, 42);
            this.chkAutoGitCommit.Name = "chkAutoGitCommit";
            this.chkAutoGitCommit.Size = new System.Drawing.Size(19, 19);
            this.chkAutoGitCommit.TabIndex = 5;
            // 
            // btnReplaceResourceWfy
            // 
            this.btnReplaceResourceWfy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceResourceWfy.Location = new System.Drawing.Point(692, 40);
            this.btnReplaceResourceWfy.Name = "btnReplaceResourceWfy";
            this.btnReplaceResourceWfy.Size = new System.Drawing.Size(106, 23);
            this.btnReplaceResourceWfy.TabIndex = 7;
            this.btnReplaceResourceWfy.Text = "替换富友资源";
            // 
            // btnReplaceResourceOrg
            // 
            this.btnReplaceResourceOrg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplaceResourceOrg.Location = new System.Drawing.Point(580, 40);
            this.btnReplaceResourceOrg.Name = "btnReplaceResourceOrg";
            this.btnReplaceResourceOrg.Size = new System.Drawing.Size(106, 23);
            this.btnReplaceResourceOrg.TabIndex = 6;
            this.btnReplaceResourceOrg.Text = "替换官方资源";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 44);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(100, 14);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "排除根目录下文件:";
            // 
            // treeMenu
            // 
            this.treeMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.funAddFolder),
            new DevExpress.XtraBars.LinkPersistInfo(this.funAddTranslator),
            new DevExpress.XtraBars.LinkPersistInfo(this.funEdit),
            new DevExpress.XtraBars.LinkPersistInfo(this.funDelete),
            new DevExpress.XtraBars.LinkPersistInfo(this.funCut, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.funPaste)});
            this.treeMenu.Manager = this.barManager1;
            this.treeMenu.Name = "treeMenu";
            // 
            // treeListColumn12
            // 
            this.treeListColumn12.AppearanceHeader.Options.UseTextOptions = true;
            this.treeListColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.treeListColumn12.Caption = "修改时间";
            this.treeListColumn12.FieldName = "ModifyTime";
            this.treeListColumn12.Format.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.treeListColumn12.Format.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.treeListColumn12.MinWidth = 100;
            this.treeListColumn12.Name = "treeListColumn12";
            this.treeListColumn12.OptionsColumn.AllowSort = false;
            this.treeListColumn12.Visible = true;
            this.treeListColumn12.VisibleIndex = 9;
            this.treeListColumn12.Width = 120;
            // 
            // FrmTranslator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.splitterControl1);
            this.Controls.Add(this.treeTranslators);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "FrmTranslator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "翻译器";
            ((System.ComponentModel.ISupportInitialize)(this.treeTranslators)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkExceptTopFile.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWorkDir.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAutoGitCommit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraTreeList.TreeList treeTranslators;
        private DevExpress.XtraEditors.CheckEdit chkExceptTopFile;
        private DevExpress.XtraEditors.MemoEdit txtLog;
        private DevExpress.XtraEditors.SplitterControl splitterControl1;
        private DevExpress.XtraEditors.SimpleButton btnReplace;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit txtWorkDir;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.PopupMenu treeMenu;
        private DevExpress.XtraBars.BarButtonItem funAddFolder;
        private DevExpress.XtraBars.BarButtonItem funAddTranslator;
        private DevExpress.XtraBars.BarButtonItem funDelete;
        private DevExpress.XtraBars.BarButtonItem funEdit;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
        private BaseExtensions.Controls.TabIndexProvider tabIndexProvider1;
        private DevExpress.XtraBars.BarButtonItem funCut;
        private DevExpress.XtraBars.BarButtonItem funPaste;
        private DevExpress.XtraEditors.SimpleButton btnReplaceResourceOrg;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chkAutoGitCommit;
        private DevExpress.XtraEditors.SimpleButton btnReplaceResourceWfy;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn4;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn5;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn6;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn7;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn8;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn9;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn11;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn12;
    }
}