using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using BaseExtensions;
using BaseExtensions.Threading;
using Finder.Properties;

namespace Finder
{
    /// <summary>
    /// 批处理控制台
    /// </summary>
    /// <typeparam name="T">数据类型</typeparam>
    public partial class FrmBatch<T> : Form
    {
        private bool m_UserClose = false;//是否用户关闭
        private int m_RowIndex = 0;//行索引
        private int m_ThreadCount = 0;//批处理工作线程数量
        private bool m_CloseOnComplete = false;//完成后是否立即关闭
        private ProducerConsumerQueue<T> m_Queue = new ProducerConsumerQueue<T>();//生产者消费者队列模型

        /// <summary>
        /// 获取队列中未处理的工作数量
        /// </summary>
        public int Count
        {
            get
            {
                return this.m_Queue == null ? 0 : this.m_Queue.Count;
            }
        }

        /// <summary>
        /// 获取日志
        /// </summary>
        public string Log
        {
            get
            {
                return this.txtLog.Text;
            }
        }

        /// <summary>
        /// 工作,该内容在子线程中运行.
        /// </summary>
        public event BaseExtensions.EventHandler<T> Work
        {
            add
            {
                this.m_Queue.Work += value;
            }
            remove
            {
                this.m_Queue.Work -= value;
            }
        }

        /// <summary>
        /// 所有任务执行完成后发生,该内容在子线程执行
        /// </summary>
        public event EventHandler AllWorkComplete
        {
            add
            {
                this.m_Queue.AllWorkComplete += value;
            }
            remove
            {
                this.m_Queue.AllWorkComplete -= value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="threadCount">批处理工作线程数量.范围(0-8)</param>
        /// <param name="closeOnComplete">完成后是否立即关闭</param>
        public FrmBatch(int threadCount, bool closeOnComplete = false)
        {
            //单个客户端线程数量不应过大,以免增加服务端负担
            Debug.Assert(threadCount > 0 && threadCount <= 10);

            InitializeComponent();
            this.Icon = Resources.app;
            this.m_ThreadCount = threadCount;
            this.m_CloseOnComplete = closeOnComplete;
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item">对象</param>
        public void Enqueue(T item)
        {
            this.m_Queue.Enqueue(item);
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="log">日志</param>
        /// <param name="args"> 一个对象数组,其中包含零个或多个要设置格式的对象</param>
        public void WriteLog(string log, params object[] args)
        {
            //在UI线程执行,不需要加锁
            this.SuperInvoke(() =>
            {
                try
                {
                    this.txtLog.AppendLine(string.Format("{0}.{1}", ++m_RowIndex, string.Format(log, args)));
                    this.txtLog.SelectionStart = this.txtLog.TextLength;
                    this.txtLog.ScrollToCaret();
                }
                catch
                {
                }
            });
        }

        /// <summary>
        /// 现实后开始执行
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(System.EventArgs e)
        {
            base.OnShown(e);

            int nMax = this.m_Queue.Count;
            this.progress.Step = 1;
            this.progress.Minimum = 0;
            this.progress.Maximum = nMax;
            this.m_Queue.WorkError += (sender1, e1) => this.WriteLog("发生了严重错误:{0}", e1.Argument2.ToStringEx());
            this.m_Queue.WorkComplete += delegate(object sender2, EventArgs<T> e2)
            {
                try
                {
                    this.SuperInvoke(() =>
                    {
                        this.progress.PerformStep();
                    });
                }
                catch
                {
                }
            };
            this.m_Queue.AllWorkComplete += delegate(object sender3, EventArgs e3)
            {
                try
                {
                    bool allSuccess = false;//默认没有全部成功
                    this.SuperInvoke(() =>
                    {
                        this.progress.Refresh();
                        this.Text = (allSuccess = this.txtLog.Text.IsNullOrEmpty()) ? "已成功完成!" : "已完成!";
                    });

                    //最后处理
                    if (this.m_CloseOnComplete)//完成后不等待
                    {
                        this.SuperInvoke(this.CloseCore);
                    }
                    else if (allSuccess)//全部成功休眠2秒后关闭
                    {
                        Thread.Sleep(2000);
                        this.SuperInvoke(this.CloseCore);
                    }
                    else//允许用户关闭
                    {
                        this.SuperInvoke(this.AllowUserClose);
                    }
                }
                catch
                {
                }
            };
            this.m_Queue.Start(this.m_ThreadCount);
        }

        /// <summary>
        /// 未完成不允许关闭
        /// </summary>
        /// <param name="e">数据</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!this.m_UserClose)
            {
                e.Cancel = true;
                return;
            }
            base.OnFormClosing(e);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        /// <param name="disposing">释放托管资源则为true,否则为false</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                    this.components = null;
                }
                if (this.m_Queue != null)
                {
                    this.m_Queue.Dispose();
                    this.m_Queue = null;
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 允许用户关闭
        /// </summary>
        private void AllowUserClose()
        {
            this.m_UserClose = true;
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        private void CloseCore()
        {
            this.AllowUserClose();
            this.Close();
        }
    }
}
