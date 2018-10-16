using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using BaseExtensions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Finder
{
    /// <summary>
    /// 文件系统扩展
    /// </summary>
    public static class DirectoryInfoEx
    {
        //按通配符遍历文件,排除以.开头的文件夹和文件 相对模式,通配符匹配相对路径
        public static IEnumerable<FileInfo> VisitFilesByRelativePattern(this DirectoryInfo dirInfo, DirectoryInfo baseDir, params string[] searchPatterns)
        {
            Debug.Assert(dirInfo != null);

            return dirInfo.VisitFiles(
                folder => !folder.Name.StartsWith("."),
                file => !file.Name.StartsWith(".") && (searchPatterns == null || searchPatterns.Length == 0 || searchPatterns.Select(pattern => pattern.IsNullOrEmpty() ? "*" : pattern).Distinct().Any(pattern => LikeOperator.LikeString(FilePathHelper.GetRelativePath(file.FullName, baseDir.FullName + (baseDir.FullName.EndsWith("\\") ? string.Empty : "\\")), pattern.Replace("/", "\\"), CompareMethod.Text))));
        }

        //按通配符遍历文件,排除以.开头的文件夹和文件 普通模式,通配符匹配短文件名
        public static IEnumerable<FileInfo> VisitFilesByShortPattern(this DirectoryInfo dirInfo, params string[] searchPatterns)
        {
            Debug.Assert(dirInfo != null);

            return dirInfo.VisitFiles(
                folder => !folder.Name.StartsWith("."),
                file => !file.Name.StartsWith(".") && (searchPatterns == null || searchPatterns.Length == 0 || searchPatterns.Select(pattern => pattern.IsNullOrEmpty() ? "*" : pattern).Distinct().Any(pattern => LikeOperator.LikeString(file.Name, pattern, CompareMethod.Text))));
        }

        //遍历文件
        private static IEnumerable<FileInfo> VisitFiles(this DirectoryInfo dirInfo, Func<DirectoryInfo, bool> folderPredicate, Func<FileInfo, bool> filePredicate)
        {
            Debug.Assert(dirInfo != null);

            DirectoryInfo subDirInfo;
            FileInfo subFileInfo;
            foreach (FileSystemInfo subSysInfo in dirInfo.EnumerateFileSystemInfos())
            {
                if ((subDirInfo = subSysInfo as DirectoryInfo) != null)
                {
                    if (folderPredicate == null || folderPredicate(subDirInfo))
                        foreach (FileInfo subSubFileInfo in subDirInfo.VisitFiles(folderPredicate, filePredicate))
                            yield return subSubFileInfo;
                }
                else if ((subFileInfo = subSysInfo as FileInfo) != null)
                {
                    if (filePredicate == null || filePredicate(subFileInfo))
                        yield return subFileInfo;
                }
            }
        }

        //复制文件夹
        public static void Copy(this DirectoryInfo source, DirectoryInfo target, Action<FileInfo> callback = null)
        {
            if (source == null || !source.Exists)
                return;

            if (!target.Exists)
                target.Create();

            DirectoryInfo subDirInfo;
            FileInfo subFileInfo;
            foreach (FileSystemInfo sysInfo in source.GetFileSystemInfos())
            {
                if ((subDirInfo = sysInfo as DirectoryInfo) != null)
                    Copy(subDirInfo, new DirectoryInfo(FilePathHelper.GetAbsolutePath(subDirInfo.Name, target.FullName)), callback);
                else if ((subFileInfo = sysInfo as FileInfo) != null)
                    try { subFileInfo.CopyTo(FilePathHelper.GetAbsolutePath(subFileInfo.Name, target.FullName), true); if (callback != null) callback(subFileInfo); }
                    catch (Exception exp) { Console.WriteLine(exp.Message); }
            }
        }
    }
}
