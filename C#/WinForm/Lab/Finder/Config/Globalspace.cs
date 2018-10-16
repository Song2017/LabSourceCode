using System.Diagnostics;
using System.IO;
using System.Text;
using BaseExtensions;

namespace Finder
{
    //配置
    public static class Globalspace
    {
        private const string SECTION = "CONFIG";
        private const string ENABLED = "Enabled";
        private const string SERVER = "Server";
        private const string PORT = "Port";
        private const string USERNAME = "UserName";
        private const string PWD = "Pwd";
        private const string ALIAS = "Alias";
        private const string PRJ = "Prj";
        private const string WORKDIR = "WorkDir";
        private const string WORKMODE = "WorkMode";
        private const string CASEMATCH = "CaseMatch";
        private const string WORDMATCH = "WordMatch";
        private const string USEWILDCARD = "UseWildcard";
        private const string WILDCARD = "Wildcard";
        private const string TOP = "Top";
        private const string BOTTOM = "Bottom";
        private const string RESULT = "Result";

        private const string TR_WORKDIR = "TR_WorkDir";
        private const string TR_EXCLUDEHOMEFILE = "TR_ExcludeHomeFile";
        private const string TR_AUTOGITCOMMIT = "TR_AutoGitCommit";
        private const string TR_LOG = "TR_Log";

        private static IniFile m_Config = new IniFile(FilePathHelper.GetAbsolutePath(Process.GetCurrentProcess().MainModule.ModuleName + ".ini"));
        private static string m_TranslatorsPath = FilePathHelper.GetAbsolutePath(Process.GetCurrentProcess().MainModule.ModuleName + ".trans");


        //是否自动签出
        public static bool Enabled
        {
            get
            {
                return m_Config.ReadBoolean(SECTION, ENABLED, false);
            }
            set
            {
                m_Config.WriteBoolean(SECTION, ENABLED, value);
            }
        }

        //服务端IP
        public static string Server
        {
            get
            {
                return m_Config.ReadString(SECTION, SERVER, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, SERVER, value);
            }
        }

        //端口
        public static string Port
        {
            get
            {
                return m_Config.ReadString(SECTION, PORT, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, PORT, value);
            }
        }

        //用户名
        public static string UserName
        {
            get
            {
                return m_Config.ReadString(SECTION, USERNAME, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, USERNAME, value);
            }
        }

        //密码
        public static string Pwd
        {
            get
            {
                return m_Config.ReadLargeString(SECTION, PWD, string.Empty);
            }
            set
            {
                m_Config.WriteLargeString(SECTION, PWD, value);
            }
        }

        //数据库
        public static string Alias
        {
            get
            {
                return m_Config.ReadString(SECTION, ALIAS, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, ALIAS, value);
            }
        }

        //服务端目录
        public static string Prj
        {
            get
            {
                return m_Config.ReadString(SECTION, PRJ, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, PRJ, value);
            }
        }

        //客户端工作目录
        public static string WorkDir
        {
            get
            {
                return m_Config.ReadString(SECTION, WORKDIR, FilePathHelper.GetDirectoryName(FilePathHelper.GetAbsolutePath(string.Empty)));
            }
            set
            {
                m_Config.WriteString(SECTION, WORKDIR, value);
            }
        }

        //工作模式
        public static WorkMode WorkMode
        {
            get
            {
                return m_Config.ReadEnum<WorkMode>(SECTION, WORKMODE, WorkMode.MultiLine);
            }
            set
            {
                m_Config.WriteEnum<WorkMode>(SECTION, WORKMODE, value);
            }
        }

        //文件名使用通配符
        public static bool FileUseWildcard
        {
            get
            {
                return m_Config.ReadBoolean(SECTION, USEWILDCARD, false);
            }
            set
            {
                m_Config.WriteBoolean(SECTION, USEWILDCARD, value);
            }
        }

        //文件名通配符
        public static string FileWildcard
        {
            get
            {
                return m_Config.ReadString(SECTION, WILDCARD, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, WILDCARD, value);
            }
        }

        //大小写
        public static bool CaseMatch
        {
            get
            {
                return m_Config.ReadBoolean(SECTION, CASEMATCH, false);
            }
            set
            {
                m_Config.WriteBoolean(SECTION, CASEMATCH, value);
            }
        }

        //全字
        public static bool WordMatch
        {
            get
            {
                return m_Config.ReadBoolean(SECTION, WORDMATCH, false);
            }
            set
            {
                m_Config.WriteBoolean(SECTION, WORDMATCH, value);
            }
        }

        //上
        public static string Top
        {
            get
            {
                return m_Config.ReadLargeString(SECTION, TOP, string.Empty);
            }
            set
            {
                m_Config.WriteLargeString(SECTION, TOP, value);
            }
        }

        //下
        public static string Bottom
        {
            get
            {
                return m_Config.ReadLargeString(SECTION, BOTTOM, string.Empty);
            }
            set
            {
                m_Config.WriteLargeString(SECTION, BOTTOM, value);
            }
        }

        //结果
        public static string Result
        {
            get
            {
                return m_Config.ReadLargeString(SECTION, RESULT, string.Empty);
            }
            set
            {
                m_Config.WriteLargeString(SECTION, RESULT, value);
            }
        }


        //翻译器-工作目录
        public static string TR_WorkDir
        {
            get
            {
                return m_Config.ReadString(SECTION, TR_WORKDIR, string.Empty);
            }
            set
            {
                m_Config.WriteString(SECTION, TR_WORKDIR, value);
            }
        }

        //翻译器-排除顶层文件
        public static bool TR_ExcludeHomeFile
        {
            get
            {
                return m_Config.ReadBoolean(SECTION, TR_EXCLUDEHOMEFILE, false);
            }
            set
            {
                m_Config.WriteBoolean(SECTION, TR_EXCLUDEHOMEFILE, value);
            }
        }

        //翻译器-自动Git提交
        public static bool TR_AutoGitCommmit
        {
            get
            {
                return m_Config.ReadBoolean(SECTION, TR_AUTOGITCOMMIT, false);
            }
            set
            {
                m_Config.WriteBoolean(SECTION, TR_AUTOGITCOMMIT, value);
            }
        }

        //翻译器-数据
        public static string TR_Translators
        {
            get
            {
                //文件不存在创建
                FileInfo fiInfo = new FileInfo(m_TranslatorsPath);
                if (!fiInfo.Exists)
                {
                    using (FileStream fs = fiInfo.OpenWrite())
                    {
                        fs.Seek(0, SeekOrigin.Begin);
                        fs.SetLength(0);
                    }
                }

                //文件夹不存在创建
                string dirPath = FilePathHelper.GetAbsolutePath("backup");
                DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
                if (!dirInfo.Exists)
                    dirInfo.Create();

                //创建备份
                string backupFileName = string.Format("{0}.{1}.trans", Process.GetCurrentProcess().MainModule.ModuleName, fiInfo.LastWriteTime.ToString("yyyy-MM-dd HH.mm.ss"));
                string backupFilePath = FilePathHelper.GetAbsolutePath(backupFileName, dirPath);
                fiInfo.CopyTo(backupFilePath, true);
                return File.ReadAllText(m_TranslatorsPath, Encoding.UTF8);
            }
            set
            {
                File.WriteAllText(m_TranslatorsPath, value, Encoding.UTF8);
            }
        }

        //翻译器-日志
        public static string TR_Log
        {
            get
            {
                return m_Config.ReadLargeString(SECTION, TR_LOG, string.Empty);
            }
            set
            {
                m_Config.WriteLargeString(SECTION, TR_LOG, value);
            }
        }
    }
}
