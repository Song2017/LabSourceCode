using System.Windows.Forms;
using Finder.Properties;

namespace Finder
{
    //主界面
    public partial class FrmMain : Form
    {
        //构造函数
        public FrmMain()
        {
            InitializeComponent();
            this.Icon = Resources.app;
            this.Init();
        }

        //初始化
        private void Init()
        {
            this.InitUI();
            this.InitLogic();
        }
    }
}
