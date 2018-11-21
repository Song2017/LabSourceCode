namespace Temp
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.memoEdit1 = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(3, 12);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(300, 100);
            this.memoEdit1.TabIndex = 0;
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(332, 27);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 23);
            this.btn.TabIndex = 1;
            this.btn.Text = "btn";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 287);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.memoEdit1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox memoEdit1;
        private System.Windows.Forms.Button btn;
    }
}

