namespace Finder
{
    partial class FrmMain
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
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtBottom = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.lblTop = new System.Windows.Forms.Label();
            this.lblBottom = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtWildcard = new System.Windows.Forms.TextBox();
            this.chkUseWildCard = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtnSingleLine = new System.Windows.Forms.RadioButton();
            this.rbtnMultiLine = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkCaseMatch = new System.Windows.Forms.CheckBox();
            this.chkWordMatch = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.splitBottom = new System.Windows.Forms.Splitter();
            this.tabIndexProvider1 = new BaseExtensions.Controls.TabIndexProvider();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTop
            // 
            this.txtTop.AcceptsReturn = true;
            this.txtTop.AcceptsTab = true;
            this.txtTop.AllowDrop = true;
            this.txtTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTop.Location = new System.Drawing.Point(0, 25);
            this.txtTop.MaxLength = 1048576;
            this.txtTop.Multiline = true;
            this.txtTop.Name = "txtTop";
            this.txtTop.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtTop.Size = new System.Drawing.Size(1008, 105);
            this.txtTop.TabIndex = 1;
            this.txtTop.WordWrap = false;
            // 
            // txtBottom
            // 
            this.txtBottom.AcceptsReturn = true;
            this.txtBottom.AcceptsTab = true;
            this.txtBottom.AllowDrop = true;
            this.txtBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBottom.Location = new System.Drawing.Point(0, 25);
            this.txtBottom.MaxLength = 1048576;
            this.txtBottom.Multiline = true;
            this.txtBottom.Name = "txtBottom";
            this.txtBottom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBottom.Size = new System.Drawing.Size(1008, 105);
            this.txtBottom.TabIndex = 1;
            this.txtBottom.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCheckOut);
            this.panel1.Controls.Add(this.btnTranslate);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnReplace);
            this.panel1.Controls.Add(this.btnFind);
            this.panel1.Controls.Add(this.btnConfig);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 50);
            this.panel1.TabIndex = 5;
            // 
            // btnTranslate
            // 
            this.btnTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTranslate.Location = new System.Drawing.Point(93, 15);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(75, 23);
            this.btnTranslate.TabIndex = 1;
            this.btnTranslate.Text = "逐词替换";
            this.btnTranslate.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(921, 15);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnReplace
            // 
            this.btnReplace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReplace.Location = new System.Drawing.Point(840, 15);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(75, 23);
            this.btnReplace.TabIndex = 3;
            this.btnReplace.Text = "替换";
            this.btnReplace.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(678, 15);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "查找";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfig.Location = new System.Drawing.Point(12, 15);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(75, 23);
            this.btnConfig.TabIndex = 0;
            this.btnConfig.Text = "设置";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 109);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.txtTop);
            this.mainContainer.Panel1.Controls.Add(this.lblTop);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.txtBottom);
            this.mainContainer.Panel2.Controls.Add(this.lblBottom);
            this.mainContainer.Size = new System.Drawing.Size(1008, 270);
            this.mainContainer.SplitterDistance = 130;
            this.mainContainer.SplitterWidth = 10;
            this.mainContainer.TabIndex = 2;
            // 
            // lblTop
            // 
            this.lblTop.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTop.Location = new System.Drawing.Point(0, 0);
            this.lblTop.Name = "lblTop";
            this.lblTop.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblTop.Size = new System.Drawing.Size(1008, 25);
            this.lblTop.TabIndex = 0;
            this.lblTop.Text = "Top:";
            // 
            // lblBottom
            // 
            this.lblBottom.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblBottom.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblBottom.Location = new System.Drawing.Point(0, 0);
            this.lblBottom.Name = "lblBottom";
            this.lblBottom.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblBottom.Size = new System.Drawing.Size(1008, 25);
            this.lblBottom.TabIndex = 0;
            this.lblBottom.Text = "Bottom:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtWildcard);
            this.panel2.Controls.Add(this.chkUseWildCard);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.rbtnSingleLine);
            this.panel2.Controls.Add(this.rbtnMultiLine);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 56);
            this.panel2.TabIndex = 0;
            // 
            // txtWildcard
            // 
            this.txtWildcard.Location = new System.Drawing.Point(447, 29);
            this.txtWildcard.Name = "txtWildcard";
            this.txtWildcard.Size = new System.Drawing.Size(301, 21);
            this.txtWildcard.TabIndex = 4;
            // 
            // chkUseWildCard
            // 
            this.chkUseWildCard.AutoSize = true;
            this.chkUseWildCard.Location = new System.Drawing.Point(345, 31);
            this.chkUseWildCard.Name = "chkUseWildCard";
            this.chkUseWildCard.Size = new System.Drawing.Size(96, 16);
            this.chkUseWildCard.TabIndex = 3;
            this.chkUseWildCard.Text = "文件名通配符";
            this.chkUseWildCard.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(1008, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "工作模式:";
            // 
            // rbtnSingleLine
            // 
            this.rbtnSingleLine.AutoSize = true;
            this.rbtnSingleLine.Location = new System.Drawing.Point(191, 31);
            this.rbtnSingleLine.Name = "rbtnSingleLine";
            this.rbtnSingleLine.Size = new System.Drawing.Size(107, 16);
            this.rbtnSingleLine.TabIndex = 2;
            this.rbtnSingleLine.TabStop = true;
            this.rbtnSingleLine.Text = "单行多个关键字";
            this.rbtnSingleLine.UseVisualStyleBackColor = true;
            // 
            // rbtnMultiLine
            // 
            this.rbtnMultiLine.AutoSize = true;
            this.rbtnMultiLine.Location = new System.Drawing.Point(40, 31);
            this.rbtnMultiLine.Name = "rbtnMultiLine";
            this.rbtnMultiLine.Size = new System.Drawing.Size(107, 16);
            this.rbtnMultiLine.TabIndex = 1;
            this.rbtnMultiLine.TabStop = true;
            this.rbtnMultiLine.Text = "多行单个关键字";
            this.rbtnMultiLine.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkCaseMatch);
            this.panel3.Controls.Add(this.chkWordMatch);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 56);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1008, 53);
            this.panel3.TabIndex = 1;
            // 
            // chkCaseMatch
            // 
            this.chkCaseMatch.AutoSize = true;
            this.chkCaseMatch.Location = new System.Drawing.Point(40, 31);
            this.chkCaseMatch.Name = "chkCaseMatch";
            this.chkCaseMatch.Size = new System.Drawing.Size(84, 16);
            this.chkCaseMatch.TabIndex = 1;
            this.chkCaseMatch.Text = "大小写匹配";
            this.chkCaseMatch.UseVisualStyleBackColor = true;
            // 
            // chkWordMatch
            // 
            this.chkWordMatch.AutoSize = true;
            this.chkWordMatch.Location = new System.Drawing.Point(191, 31);
            this.chkWordMatch.Name = "chkWordMatch";
            this.chkWordMatch.Size = new System.Drawing.Size(72, 16);
            this.chkWordMatch.TabIndex = 2;
            this.chkWordMatch.Text = "全字匹配";
            this.chkWordMatch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.label4.Size = new System.Drawing.Size(1008, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "查找选项:";
            // 
            // pnlResult
            // 
            this.pnlResult.Controls.Add(this.txtResult);
            this.pnlResult.Controls.Add(this.lblResult);
            this.pnlResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlResult.Location = new System.Drawing.Point(0, 382);
            this.pnlResult.Name = "pnlResult";
            this.pnlResult.Size = new System.Drawing.Size(1008, 130);
            this.pnlResult.TabIndex = 4;
            // 
            // txtResult
            // 
            this.txtResult.AcceptsReturn = true;
            this.txtResult.AcceptsTab = true;
            this.txtResult.AllowDrop = true;
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(0, 25);
            this.txtResult.MaxLength = 1048576;
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(1008, 105);
            this.txtResult.TabIndex = 1;
            this.txtResult.WordWrap = false;
            // 
            // lblResult
            // 
            this.lblResult.BackColor = System.Drawing.SystemColors.ControlDark;
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Padding = new System.Windows.Forms.Padding(20, 5, 0, 0);
            this.lblResult.Size = new System.Drawing.Size(1008, 25);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "操作结果:";
            // 
            // splitBottom
            // 
            this.splitBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitBottom.Location = new System.Drawing.Point(0, 379);
            this.splitBottom.Name = "splitBottom";
            this.splitBottom.Size = new System.Drawing.Size(1008, 3);
            this.splitBottom.TabIndex = 3;
            this.splitBottom.TabStop = false;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckOut.Location = new System.Drawing.Point(759, 15);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(75, 23);
            this.btnCheckOut.TabIndex = 5;
            this.btnCheckOut.Text = "签出";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 562);
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.splitBottom);
            this.Controls.Add(this.pnlResult);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查找和替换";
            this.panel1.ResumeLayout(false);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel1.PerformLayout();
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlResult.ResumeLayout(false);
            this.pnlResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Label lblBottom;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rbtnMultiLine;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtnSingleLine;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtWildcard;
        private System.Windows.Forms.CheckBox chkUseWildCard;
        private System.Windows.Forms.CheckBox chkCaseMatch;
        private System.Windows.Forms.CheckBox chkWordMatch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlResult;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Splitter splitBottom;
        private BaseExtensions.Controls.TabIndexProvider tabIndexProvider1;
        private System.Windows.Forms.Button btnTranslate;
        private System.Windows.Forms.Button btnCheckOut;
    }
}