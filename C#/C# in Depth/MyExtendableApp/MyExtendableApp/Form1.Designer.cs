namespace MyExtendableApp
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.File = new System.Windows.Forms.ToolStripMenuItem();
            this.snapInModuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lstLoadedSnapIns = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(603, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // File
            // 
            this.File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.snapInModuleToolStripMenuItem});
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(37, 20);
            this.File.Text = "File";
            // 
            // snapInModuleToolStripMenuItem
            // 
            this.snapInModuleToolStripMenuItem.Name = "snapInModuleToolStripMenuItem";
            this.snapInModuleToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.snapInModuleToolStripMenuItem.Text = "Snap in Module";
            // 
            // lstLoadedSnapIns
            // 
            this.lstLoadedSnapIns.FormattingEnabled = true;
            this.lstLoadedSnapIns.Location = new System.Drawing.Point(0, 27);
            this.lstLoadedSnapIns.Name = "lstLoadedSnapIns";
            this.lstLoadedSnapIns.Size = new System.Drawing.Size(530, 173);
            this.lstLoadedSnapIns.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 314);
            this.Controls.Add(this.lstLoadedSnapIns);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem File;
        private System.Windows.Forms.ToolStripMenuItem snapInModuleToolStripMenuItem;
        private System.Windows.Forms.ListBox lstLoadedSnapIns;
    }
}

