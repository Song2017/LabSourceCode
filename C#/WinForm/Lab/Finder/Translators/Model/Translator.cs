using System;
using System.Web.Script.Serialization;

namespace Finder.Translators
{
    //翻译器
    public class Translator
    {
        //主键
        public string ID { get; set; }
        //父节点主键
        public string ParentID { get; set; }
        //名称
        public string Name { get; set; }


        //是否文件夹
        public bool IsFolder { get; set; }
        //查找
        public string Find { get; set; }
        //替换
        public string Replace { get; set; }
        //禁止前缀
        public string BanSuffix { get; set; }
        //禁止后缀
        public string BanPrefix { get; set; }
        //大小写匹配
        public bool CaseMatch { get; set; }
        //全字匹配
        public bool WordMatch { get; set; }
        //包含文件通配符,无表示全部
        public string[] IncludeFile { get; set; }
        //排除文件通配符,无表示不排除
        public string[] ExcludeFile { get; set; }
        //修改时间
        public DateTime? ModifyTime { get; set; }

        //图片索引
        [ScriptIgnore]
        public int ImageIndex
        {
            get
            {
                return this.IsFolder ? 0 : 1;
            }
        }
        //包含文件通配符,无表示全部
        [ScriptIgnore]
        public string IncludeFileDisplay
        {
            get
            {
                return this.IncludeFile == null ? null : string.Join("  ", this.IncludeFile);
            }
        }
        //排除文件通配符,无表示不排除
        [ScriptIgnore]
        public string ExcludeFileDisplay
        {
            get
            {
                return this.ExcludeFile == null ? null : string.Join("  ", this.ExcludeFile);
            }
        }
    }
}
