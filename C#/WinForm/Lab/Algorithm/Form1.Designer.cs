namespace Algorithm
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
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.btnGetNum = new System.Windows.Forms.Button();
            this.btnShift = new System.Windows.Forms.Button();
            this.txtShiftOut = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(30, 52);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(291, 20);
            this.txtInput.TabIndex = 0;
            this.txtInput.Text = "12fds3g45,wg.r653";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Please input a string: ";
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(30, 99);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.Size = new System.Drawing.Size(291, 20);
            this.txtOutput.TabIndex = 2;
            this.txtOutput.Text = "12fds3g45,wg.r653";
            // 
            // btnGetNum
            // 
            this.btnGetNum.Location = new System.Drawing.Point(246, 74);
            this.btnGetNum.Name = "btnGetNum";
            this.btnGetNum.Size = new System.Drawing.Size(75, 23);
            this.btnGetNum.TabIndex = 3;
            this.btnGetNum.Text = "GetNum";
            this.btnGetNum.UseVisualStyleBackColor = true;
            // 
            // btnShift
            // 
            this.btnShift.Location = new System.Drawing.Point(246, 193);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(75, 23);
            this.btnShift.TabIndex = 7;
            this.btnShift.Text = "Shift";
            this.btnShift.UseVisualStyleBackColor = true;
            // 
            // txtShiftOut
            // 
            this.txtShiftOut.Location = new System.Drawing.Point(30, 218);
            this.txtShiftOut.Name = "txtShiftOut";
            this.txtShiftOut.Size = new System.Drawing.Size(291, 20);
            this.txtShiftOut.TabIndex = 6;
            this.txtShiftOut.Text = "0,0,3,4,5,6,7,8,9";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(254, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Please input shift offset(negative means shift to left): ";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(30, 171);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(291, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "Here is Array: 1,2,3,4,5,6,7,8,9";
            // 
            // txtOffset
            // 
            this.txtOffset.Location = new System.Drawing.Point(30, 193);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(105, 20);
            this.txtOffset.TabIndex = 8;
            this.txtOffset.Text = "2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 290);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.btnShift);
            this.Controls.Add(this.txtShiftOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnGetNum);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnGetNum;
        private System.Windows.Forms.Button btnShift;
        private System.Windows.Forms.TextBox txtShiftOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtOffset;
    }
}

