using System;

namespace Finder
{
    public partial class FrmMain
    {
        private void InitUI()
        {
            //工作模式
            EventHandler handler = delegate(object sender, EventArgs e)
            {
                if (this.rbtnMultiLine.Checked)
                {
                    this.lblTop.Text = "查找内容:";
                    this.lblBottom.Text = "替换为:";
                    this.pnlResult.Visible = true;
                    this.splitBottom.Visible = true;
                    this.mainContainer.BringToFront();
                    Globalspace.WorkMode = WorkMode.MultiLine;
                }
                else if (this.rbtnSingleLine.Checked)
                {
                    this.lblTop.Text = "查找和替换(查找时每行一个,替换时查找替换同行用空格或制表符间隔):";
                    this.lblBottom.Text = "操作结果:";
                    this.pnlResult.Visible = false;
                    this.splitBottom.Visible = false;
                    Globalspace.WorkMode = WorkMode.SingleLine;
                }
            };
            this.rbtnMultiLine.CheckedChanged += handler;
            this.rbtnSingleLine.CheckedChanged += handler;
            //查找范围
            this.chkCaseMatch.CheckedChanged += (sender, e) => Globalspace.CaseMatch = this.chkCaseMatch.Checked;
            this.chkWordMatch.CheckedChanged += (sender, e) => Globalspace.WordMatch = this.chkWordMatch.Checked;
            this.chkUseWildCard.CheckedChanged += (sender, e) =>
            {
                this.txtWildcard.Enabled = this.chkUseWildCard.Checked;
                if (!this.chkUseWildCard.Checked)
                    this.txtWildcard.Text = string.Empty;
                Globalspace.FileUseWildcard = this.chkUseWildCard.Checked;
            };
            this.txtWildcard.TextChanged += (sender, e) => Globalspace.FileWildcard = this.txtWildcard.Text;
            //查找替换
            this.txtTop.TextChanged += (sender, e) => Globalspace.Top = this.txtTop.Text;
            this.txtBottom.TextChanged += (sender, e) => Globalspace.Bottom = this.txtBottom.Text;
            this.txtResult.TextChanged += (sender, e) => Globalspace.Result = this.txtResult.Text;


            //读取
            this.ReadUI();
        }

        private void ReadUI()
        {
            if (Globalspace.WorkMode == WorkMode.MultiLine)
                this.rbtnMultiLine.Checked = true;
            else
                this.rbtnSingleLine.Checked = true;

            this.chkCaseMatch.Checked = Globalspace.CaseMatch;
            this.chkWordMatch.Checked = Globalspace.WordMatch;
            this.chkUseWildCard.Checked = Globalspace.FileUseWildcard;
            this.txtWildcard.Text = Globalspace.FileWildcard;
            this.txtTop.Text = Globalspace.Top;
            this.txtBottom.Text = Globalspace.Bottom;
            this.txtResult.Text = Globalspace.Result;
        }
    }
}
