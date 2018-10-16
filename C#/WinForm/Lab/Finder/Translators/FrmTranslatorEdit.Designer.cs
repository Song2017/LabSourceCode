namespace Finder.Translators
{
    partial class FrmTranslatorEdit
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtFind = new DevExpress.XtraEditors.MemoEdit();
            this.txtReplace = new DevExpress.XtraEditors.MemoEdit();
            this.txtBanPrefix = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtBanSuffix = new DevExpress.XtraEditors.MemoEdit();
            this.chkCaseMatch = new DevExpress.XtraEditors.CheckEdit();
            this.chkWordMatch = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtIncludeFiles = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtExcludeFiles = new DevExpress.XtraEditors.MemoEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.tabIndexProvider1 = new BaseExtensions.Controls.TabIndexProvider();
            this.txtName = new DevExpress.XtraEditors.ButtonEdit();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplace.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanPrefix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanSuffix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaseMatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWordMatch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncludeFiles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExcludeFiles.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(36, 51);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "查找:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(38, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 14);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "替换:";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl3.Location = new System.Drawing.Point(12, 282);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 14);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "禁用前缀:";
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(73, 51);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(415, 219);
            this.txtFind.TabIndex = 3;
            this.txtFind.UseOptimizedRendering = true;
            // 
            // txtReplace
            // 
            this.txtReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReplace.Location = new System.Drawing.Point(75, 51);
            this.txtReplace.Name = "txtReplace";
            this.txtReplace.Size = new System.Drawing.Size(415, 219);
            this.txtReplace.TabIndex = 3;
            this.txtReplace.UseOptimizedRendering = true;
            // 
            // txtBanPrefix
            // 
            this.txtBanPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBanPrefix.Location = new System.Drawing.Point(73, 282);
            this.txtBanPrefix.Name = "txtBanPrefix";
            this.txtBanPrefix.Size = new System.Drawing.Size(415, 64);
            this.txtBanPrefix.TabIndex = 5;
            this.txtBanPrefix.UseOptimizedRendering = true;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl4.Location = new System.Drawing.Point(14, 282);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(52, 14);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "禁用后缀:";
            // 
            // txtBanSuffix
            // 
            this.txtBanSuffix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBanSuffix.Location = new System.Drawing.Point(75, 282);
            this.txtBanSuffix.Name = "txtBanSuffix";
            this.txtBanSuffix.Size = new System.Drawing.Size(415, 64);
            this.txtBanSuffix.TabIndex = 5;
            this.txtBanSuffix.UseOptimizedRendering = true;
            // 
            // chkCaseMatch
            // 
            this.chkCaseMatch.Location = new System.Drawing.Point(70, 16);
            this.chkCaseMatch.Name = "chkCaseMatch";
            this.chkCaseMatch.Properties.Caption = "大小写匹配";
            this.chkCaseMatch.Size = new System.Drawing.Size(116, 19);
            this.chkCaseMatch.TabIndex = 0;
            // 
            // chkWordMatch
            // 
            this.chkWordMatch.Location = new System.Drawing.Point(196, 16);
            this.chkWordMatch.Name = "chkWordMatch";
            this.chkWordMatch.Properties.Caption = "全字匹配";
            this.chkWordMatch.Size = new System.Drawing.Size(102, 19);
            this.chkWordMatch.TabIndex = 1;
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl5.Location = new System.Drawing.Point(12, 360);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(52, 14);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "包含文件:";
            // 
            // txtIncludeFiles
            // 
            this.txtIncludeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncludeFiles.Location = new System.Drawing.Point(73, 360);
            this.txtIncludeFiles.Name = "txtIncludeFiles";
            this.txtIncludeFiles.Size = new System.Drawing.Size(415, 147);
            this.txtIncludeFiles.TabIndex = 7;
            this.txtIncludeFiles.UseOptimizedRendering = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelControl6.Location = new System.Drawing.Point(14, 360);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(52, 14);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "排除文件:";
            // 
            // txtExcludeFiles
            // 
            this.txtExcludeFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExcludeFiles.Location = new System.Drawing.Point(75, 360);
            this.txtExcludeFiles.Name = "txtExcludeFiles";
            this.txtExcludeFiles.Size = new System.Drawing.Size(415, 147);
            this.txtExcludeFiles.TabIndex = 7;
            this.txtExcludeFiles.UseOptimizedRendering = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(334, 527);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(415, 527);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(36, 18);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(28, 14);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "名称:";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(73, 14);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.txtName.Size = new System.Drawing.Size(415, 22);
            this.txtName.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelControl7);
            this.splitContainer1.Panel1.Controls.Add(this.txtName);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl3);
            this.splitContainer1.Panel1.Controls.Add(this.txtFind);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl5);
            this.splitContainer1.Panel1.Controls.Add(this.txtBanPrefix);
            this.splitContainer1.Panel1.Controls.Add(this.txtIncludeFiles);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.chkCaseMatch);
            this.splitContainer1.Panel2.Controls.Add(this.btnOK);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl2);
            this.splitContainer1.Panel2.Controls.Add(this.chkWordMatch);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl4);
            this.splitContainer1.Panel2.Controls.Add(this.labelControl6);
            this.splitContainer1.Panel2.Controls.Add(this.txtReplace);
            this.splitContainer1.Panel2.Controls.Add(this.txtExcludeFiles);
            this.splitContainer1.Panel2.Controls.Add(this.txtBanSuffix);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 562);
            this.splitContainer1.SplitterDistance = 502;
            this.splitContainer1.TabIndex = 0;
            // 
            // FrmTranslatorEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "FrmTranslatorEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "翻译器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.txtFind.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReplace.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanPrefix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBanSuffix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCaseMatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkWordMatch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIncludeFiles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExcludeFiles.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtFind;
        private DevExpress.XtraEditors.MemoEdit txtReplace;
        private DevExpress.XtraEditors.MemoEdit txtBanPrefix;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.MemoEdit txtBanSuffix;
        private DevExpress.XtraEditors.CheckEdit chkCaseMatch;
        private DevExpress.XtraEditors.CheckEdit chkWordMatch;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.MemoEdit txtIncludeFiles;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtExcludeFiles;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private BaseExtensions.Controls.TabIndexProvider tabIndexProvider1;
        private DevExpress.XtraEditors.ButtonEdit txtName;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}