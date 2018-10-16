using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.Threading;

namespace AppConnectNetWorkCheck
{
    public partial class Form1 : Form, IDisposable
    {

        ProgressBar pb = null;
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            InitUI();
            InitLogic();
        }


        //初始界面
        private void InitUI()
        {
            string strUrl = PubTools.GetConfig("URL", "http://localhost:8080/");
            this.textEdit1.EditValue = strUrl;

            this.progressBar1.Visible = false;

        }

        //初始事件
        private void InitLogic()
        {
            //获取本机IP
            this.linkLabel1.Click += delegate
            {
                this.richTextBox1.Text = GetIP6();
            };

            //网络测试
            this.BtnTest.Click += delegate
            {
                ConnectNetwork.ConfigUrl = this.textEdit1.EditValue.ToStringEx();
                if (ConnectNetwork.ConnectNetworkCheck())
                    MessageBox.Show(this, "已连接!", "连接状态");
                else
                    MessageBox.Show(this, "未连接", "连接状态");
            };

            this.MouseDoubleClick += new MouseEventHandler(Form1_MouseDoubleClick);
        }

        void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (pb == null)
                    pb = new ProgressBar();
                this.Controls.Add(pb);

                pb.Anchor = AnchorStyles.Bottom;
                pb.Dock = DockStyle.Bottom;
                pb.Size = new Size(this.Width, 25);
                pb.Style = ProgressBarStyle.Marquee;
                pb.Minimum = 0;
                pb.Maximum = 100;
            }

            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (pb != null)
                    if (!pb.Disposing)
                        pb.Dispose();

                this.Controls.Remove(pb);
                pb = null;

            }

            //if (MessageBox.Show(this, "测试进度条", string.Empty, MessageBoxButtons.OK) != DialogResult.OK)
            //    return;

            //if (!this.progressBar1.Visible)
            //    progressBar1.Visible = true;
            //progressBar1.Style = ProgressBarStyle.Marquee;
            //for (int i = 0; i <= 10; i++)
            //{
            //    Thread.Sleep(1000);
            //    this.progressBar1.Value = i * 10;
            //}

        }

        private string GetIP6()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "ipconfig.exe";//设置程序名   
            cmd.StartInfo.Arguments = "/all";  //参数   
            //重定向标准输出   
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.CreateNoWindow = true;//不显示窗口（控制台程序是黑屏）   
            cmd.StartInfo.WindowStyle = ProcessWindowStyle.Normal;//暂时不明白什么意思   
            /* 收集一下 有备无患 
            关于:ProcessWindowStyle.Hidden隐藏后如何再显示？ 
            hwndWin32Host = Win32Native.FindWindow(null, win32Exinfo.windowsName); 
            Win32Native.ShowWindow(hwndWin32Host, 1);     //先FindWindow找到窗口后再ShowWindow 
            */
            cmd.Start();
            string info = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            cmd.Close();

            return info.ToStringEx().Replace("\r\n\r\n", "\r\n");


            //string HostName = Dns.GetHostName();
            ////
            //string[] AddressIPs = Dns.GetHostEntry(HostName).AddressList.
            //    Where(a => a.AddressFamily.ToString() == "InterNetwork").
            //    Select(a => a.ToStringEx()).ToArray();
        }

    }
}
