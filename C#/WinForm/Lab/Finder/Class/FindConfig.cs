using System;
using System.Collections.Generic;
using System.Linq;
using BaseExtensions;

namespace Finder
{
    //查找配置
    public class SearchConfig
    {
        //工作目录设置
        public Config Config { get; private set; }

        //查找范围-使用通配符
        public bool FileUseWildcard { get; private set; }

        //查找范围-通配符
        public string FileWildcard { get; private set; }

        //查找范围-大小写
        public bool CaseMatch { get; private set; }

        //查找范围-全字
        public bool WordMatch { get; private set; }

        //查找替换内容,查找的时候只使用Key
        public Dictionary<string, string> Find { get; private set; }


        //构造函数
        public SearchConfig(bool fileUseWildcard, string fileWildcard, bool caseMatch, bool wordMatch, Dictionary<string, string> find)
        {
            this.Config = new Config();
            this.FileUseWildcard = fileUseWildcard;
            this.FileWildcard = fileWildcard;
            this.CaseMatch = caseMatch;
            this.WordMatch = wordMatch;
            this.Find = find;
        }

        //生成
        public static Dictionary<string, string> GenFindReplace(string keyValues)
        {
            string[] lines = keyValues.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> dic = new Dictionary<string, string>();
            foreach (string line in lines)
            {
                List<string> splits = line.Contains("\"")
                    ? line.Replace("\" ", "\"$$$$$$$").Replace("\"　", "\"$$$$$$$").Replace("\"\t", "\"$$$$$$$").Split(new string[] { "$$$$$$$" }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim('\"')).Where(a => !a.IsNullOrEmpty()).ToList()
                    : line.Split(new char[] { ' ', '　', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).Where(a => !a.IsNullOrEmpty()).ToList();

                if (splits.Count < 1)
                    continue;
                else if (splits.Count == 1)
                    dic.Add(splits[0], string.Empty);
                else
                    dic.Add(splits[0], splits[1]);
            }
            return dic;
        }

        //生成
        public static Dictionary<string, string> GenFindReplace(string key, string value)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (key.IsNullOrEmpty())
                return dic;
            dic.Add(key, value.ToStringEx());
            return dic;
        }
    }
}
