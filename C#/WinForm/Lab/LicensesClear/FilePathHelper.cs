using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace testLicensesClear
{
    /// <summary>
    /// 获取文件路径,静态调用
    /// </summary>
     static class FilePathHelper
    {
         //静态方法


         //获取文件绝对路径
        internal static string GetAbsolutePath(string relPath)
        {
            string absPath = string.Empty;
            string basePath =  AppDomain.CurrentDomain.BaseDirectory;
            return FilePathHelper.GetAbsolutePath(relPath, basePath, ref absPath)
                ? absPath : string.Empty;
        }

        private static bool GetAbsolutePath(string relPath, string basePath, ref string absPath)
        {
            try
            {
                absPath = Path.Combine(basePath,relPath).Replace('/','\\');
            }
            catch { return false; }
            return true;
        }

         //获取绝对路径目录
        internal static string GetDirectoryName(string absPath)
        {
            string directory;
            return FilePathHelper.GetDirectoryName(absPath, out directory) ?
                directory : string.Empty;
        }

        private static bool GetDirectoryName(string absPath, out string directory)
        {
            directory = string.Empty;
            try 
            {
                directory = Path.GetDirectoryName(absPath);
            }
            catch { return false; } 
            return true;
        }
    }
}
