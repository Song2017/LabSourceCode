using System.Web.Script.Serialization;

namespace Finder.Translators
{
    //翻译器包装
    public class TranslatorWrapper
    {
        //主键
        public string ID { get; set; }
        //父节点主键
        public string ParentID { get; set; }
        //名称
        public string Name { get; set; }
        //翻译器
        public Translator Translator { get; set; }

        //查找
        [ScriptIgnore]
        public string Find
        {
            get
            {
                return this.Translator == null ? null : this.Translator.Find;
            }
        }
        //替换
        [ScriptIgnore]
        public string Replace
        {
            get
            {
                return this.Translator == null ? null : this.Translator.Replace;
            }
        }
        //禁止前缀
        [ScriptIgnore]
        public string BanSuffix
        {
            get
            {
                return this.Translator == null ? null : this.Translator.BanSuffix;
            }
        }
        //禁止后缀
        [ScriptIgnore]
        public string BanPrefix
        {
            get
            {
                return this.Translator == null ? null : this.Translator.BanPrefix;
            }
        }
        //大小写匹配
        [ScriptIgnore]
        public bool CaseMatch
        {
            get
            {
                return this.Translator == null ? false : this.Translator.CaseMatch;
            }
        }
        //全字匹配
        [ScriptIgnore]
        public bool WordMatch
        {
            get
            {
                return this.Translator == null ? false : this.Translator.WordMatch;
            }
        }
        //包含文件通配符,无表示全部
        [ScriptIgnore]
        public string IncludeFile
        {
            get
            {
                return this.Translator == null ? null : (this.Translator.IncludeFile == null ? null : string.Join("  ", this.Translator.IncludeFile));
            }
        }
        //排除文件通配符,无表示不排除
        [ScriptIgnore]
        public string ExcludeFile
        {
            get
            {
                return this.Translator == null ? null : (this.Translator.ExcludeFile == null ? null : string.Join("  ", this.Translator.ExcludeFile));
            }
        }
        //是否文件夹
        [ScriptIgnore]
        public bool IsFolder
        {
            get
            {
                return this.Translator == null;
            }
        }
        //图片索引
        [ScriptIgnore]
        public int ImageIndex
        {
            get
            {
                return this.Translator == null ? 0 : 1;
            }
        }
    }
}
