using System;
using System.Text;
using Finder.Translators;

namespace Finder
{
    public partial class FrmMain
    {
        private FrmTranslator dialog;

        private void InitLogic()
        {
            //设置
            this.btnConfig.Click += delegate(object sender, EventArgs e)
            {
                using (FrmConfig dialog = new FrmConfig())
                {
                    dialog.ShowDialog(this);
                }
            };

            //翻译
            this.btnTranslate.Click += delegate(object sender, EventArgs e)
            {
                if (this.dialog == null || dialog.IsDisposed)
                {
                    this.dialog = new FrmTranslator();
                    this.dialog.Shown += (sender1, e1) => this.Hide();
                    this.dialog.Disposed += (sender2, e2) => this.Show();
                }
                this.dialog.Show();
            };

            //查找
            this.btnFind.Click += delegate(object sender, EventArgs e)
            {
                //重置
                if (this.rbtnMultiLine.Checked)
                    this.txtResult.Text = string.Empty;
                else
                    this.txtBottom.Text = string.Empty;

                //操作
                StringBuilder result = new StringBuilder(1024);
                int count = FindReplace.Find(this, this.GenSearchConfig(), result);
                result.Insert(0, string.Format("查找到以下文件,共 {0} 个\r\n", count));

                //结果
                if (this.rbtnMultiLine.Checked)
                    this.txtResult.Text = result.ToString();
                else
                    this.txtBottom.Text = result.ToString();
            };

            //替换
            this.btnReplace.Click += delegate(object sender, EventArgs e)
            {
                //重置
                if (this.rbtnMultiLine.Checked)
                    this.txtResult.Text = string.Empty;
                else
                    this.txtBottom.Text = string.Empty;

                //操作
                StringBuilder result = new StringBuilder(1024);
                int count = FindReplace.Replace(this, this.GenSearchConfig(), result);
                result.Insert(0, string.Format("已修改以下文件,共 {0} 个\r\n", count));

                //结果
                if (this.rbtnMultiLine.Checked)
                    this.txtResult.Text = result.ToString();
                else
                    this.txtBottom.Text = result.ToString();
            };

            //关闭
            this.btnClose.Click += delegate(object sender, EventArgs e)
            {
                this.Close();
            };

            this.btnCheckOut.Click += delegate
            {   //重置
                if (this.rbtnMultiLine.Checked)
                    this.txtResult.Text = string.Empty;
                else
                    this.txtBottom.Text = string.Empty;

                //操作
                StringBuilder result = new StringBuilder(1024);
                int count = FindReplace.CheckOut(this, this.GenSearchConfig(), result);
                result.Insert(0, string.Format("已签出以下文件,共 {0} 个\r\n", count));

                //结果
                if (this.rbtnMultiLine.Checked)
                    this.txtResult.Text = result.ToString();
                else
                    this.txtBottom.Text = result.ToString();

            };
        }

        //生成查询参数
        private SearchConfig GenSearchConfig()
        {
            return new SearchConfig(this.chkUseWildCard.Checked, this.txtWildcard.Text, this.chkCaseMatch.Checked, this.chkWordMatch.Checked, this.rbtnMultiLine.Checked ? SearchConfig.GenFindReplace(this.txtTop.Text, this.txtBottom.Text) : SearchConfig.GenFindReplace(this.txtTop.Text));
        }
    }
}
