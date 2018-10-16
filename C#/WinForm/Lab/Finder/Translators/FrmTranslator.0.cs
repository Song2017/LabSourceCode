using System.Windows.Forms;
using Finder.Properties;

namespace Finder.Translators
{
    //翻译界面
    public partial class FrmTranslator : Form
    {
        private const string ROOT = "0";//根级父ID
        private TranslatorDataSource m_DataSource;//树

        //构造
        public FrmTranslator()
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
