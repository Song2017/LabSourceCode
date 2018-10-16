using System.Diagnostics;
using Finder.Translators;

namespace Finder
{
    //Git助手
    public static class GitHelper
    {
        //添加所有文件,包含未追踪文件
        public static void GitAdd(string folder)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "C:\\Program Files\\Git\\cmd\\git.exe";
                process.StartInfo.Arguments = "add -A";
                process.StartInfo.WorkingDirectory = folder;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
        }

        //添加并提交,只限追踪文件
        public static void GitCommit(string folder, string comment)
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = "C:\\Program Files\\Git\\cmd\\git.exe";
                process.StartInfo.Arguments = string.Format("commit -am \"{0}\"", comment);
                process.StartInfo.WorkingDirectory = folder;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.Start();
                process.WaitForExit();
            }
        }


        //添加所有文件,包含未追踪文件
        public static void GitAdd(TranslatorConfig config)
        {
            if (!config.AutoGitCommit)
                return;

            GitAdd(config.WorkFolder);
        }

        //添加并提交,只限追踪文件
        public static void GitCommit(TranslatorConfig config, string comment)
        {
            if (!config.AutoGitCommit)
                return;

            GitCommit(config.WorkFolder, comment);
        }
    }
}
