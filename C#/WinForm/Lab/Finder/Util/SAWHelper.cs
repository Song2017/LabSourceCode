using System.Diagnostics;
using System.IO;
using System.Text;
using BaseExtensions;

namespace Finder
{
    public static class SAWHelper
    {
        private static readonly char[] CHARS_DIRECTORY_END = new char[] { '/', '\\' };//目录结束符

        //签出文件
        public static void CheckOut(this Config config, FileInfo fileInfo)
        {
            if (!config.Enabled)
                return;

            //签出参数
            string relative = FilePathHelper.GetDirectoryName(fileInfo.FullName).Trim(CHARS_DIRECTORY_END).Substring(config.WorkDir.Trim(CHARS_DIRECTORY_END).Length).Trim(CHARS_DIRECTORY_END).Replace("\\", "/");
            StringBuilder args = new StringBuilder();
            args.Append(" CheckOutFile");//签出
            args.Append(" -server ").Append(config.Server);
            args.Append(" -port ").Append(config.Port);
            args.Append(" -username ").Append(config.UserName);
            args.Append(" -pwd ").Append(config.Pwd);
            args.Append(" -alias ").Append(config.Alias);
            args.Append(" -prj ").Append(config.Prj.Trim(CHARS_DIRECTORY_END).Replace("\\", "/")).Append(relative.Length > 0 ? "/" : string.Empty).Append(relative);
            args.Append(" -workdir ").Append(config.WorkDir.Trim(CHARS_DIRECTORY_END).Replace("\\", "/")).Append(relative.Length > 0 ? "/" : string.Empty).Append(relative);
            args.Append(" -file ").Append(fileInfo.Name);
            args.Append(" -replace");

            //尝试三次签出
            for (int i = 0; i < 3; i++)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = FilePathHelper.GetAbsolutePath("SAWVCmd.exe"),
                    Arguments = args.ToStringEx(),
                    WindowStyle = ProcessWindowStyle.Hidden,
                };
                Process process = Process.Start(startInfo);
                process.WaitForExit();

                //签出成功返回
                fileInfo.Refresh();
                if (!fileInfo.IsReadOnly)
                    return;
            }
        }
    }
}
