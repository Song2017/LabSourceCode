using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace testLicensesClear
{
    //去除LicensesClear.licx的只读属性 偷师大神代码
    static class Program
    {
        //添加外部工具时参数可选为解决方案目录
        static void Main(string[] args)
        {
            if (args == null || args.Length <= 0)
            {
                //LicensesClear(new DirectoryInfo(FilePathHelper.GetDirectoryName(FilePathHelper.GetAbsolutePath(string.Empty))));
            }
            else
            {
                foreach (string path in args)
                    if (path != null && Directory.Exists(path))
                        LicensesClear(new DirectoryInfo(path));
            }

        }

        //递归取消licenses.licx文件的只读属性
        private static void LicensesClear(DirectoryInfo directoryInfo)
        {
            DirectoryInfo subDirInfo;
            FileInfo subFileInfo;
            foreach (FileSystemInfo sysInfo in directoryInfo.GetFileSystemInfos())
            {

                if ((subDirInfo = sysInfo as DirectoryInfo) != null)//存在子级文件
                {
                    LicensesClear(subDirInfo);
                }//设置文件只读
                else if ((subFileInfo = sysInfo as FileInfo) != null && subFileInfo.Name.ToLower().Equals("licenses.licx"))
                {
                    subFileInfo.IsReadOnly = false;//去掉只读
                    if (subFileInfo.Length > 0)
                        using (FileStream fs = subFileInfo.OpenWrite())
                        {
                            fs.Seek(0, SeekOrigin.Begin);
                            fs.SetLength(0);
                        }
                    Console.WriteLine(string.Format("已清理：{0}", subFileInfo.FullName));
                }


            }
        }
    }




}
