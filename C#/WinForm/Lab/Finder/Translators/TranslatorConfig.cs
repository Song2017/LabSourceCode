namespace Finder.Translators
{
    //翻译器配置
    public class TranslatorConfig
    {
        //工作目录
        public string WorkFolder { get; set; }

        //排除顶层文件
        public bool ExceptTopFile { get; set; }

        //是否执行Git提交
        public bool AutoGitCommit { get; set; }
    }
}
