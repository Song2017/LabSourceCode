using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseExtensions;
using Finder.Properties;
using Finder.Translators;
using SharpCompress.Archive;
using SharpCompress.Common;

namespace Finder
{
    //查找替换核心类
    public static class FindReplace
    {
        //断言
        private static bool Assert(SearchConfig searchConfig, StringBuilder result)
        {
            if (searchConfig == null)
            {
                result.AppendLine("查找配置不能为空.");
                return false;
            }

            if (searchConfig.Find == null || searchConfig.Find.Count <= 0)
            {
                result.AppendLine("查找内容不能为空.");
                return false;
            }

            if (!Directory.Exists(searchConfig.Config.WorkDir))
            {
                result.AppendLine("工作目录不存在.");
                return false;
            }
            return true;
        }

        //查找
        public static int Find(IWin32Window owner, SearchConfig searchConfig, StringBuilder result)
        {
            if (!Assert(searchConfig, result))
                return 0;

            int count = 0;
            List<string> affects = new List<string>();
            using (FrmBatch<FileInfo> dialog = new FrmBatch<FileInfo>(10))
            {
                dialog.Text = "正在执行查找操作";
                //工作
                dialog.Work += delegate(object sender, EventArgs<FileInfo> e)
                {
                    FileInfo fileInfo = e.Argument;
                    if (fileInfo == null)
                        return;

                    string fullName;
                    string text = File.ReadAllText(fullName = fileInfo.FullName, Encoding.UTF8);
                    StringComparison comparison = searchConfig.CaseMatch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;//大小写
                    if (searchConfig.WordMatch
                        ? searchConfig.Find.Keys.Any(word => text.IndexOfWord(word, comparison) >= 0)//全字
                        : searchConfig.Find.Keys.Any(word => text.IndexOf(word, comparison) >= 0))//非全字
                    {
                        lock (affects)
                            affects.Add(fullName);
                        dialog.WriteLog("查找 {0}", fullName);
                    }
                };

                //全部完成,统计
                dialog.AllWorkComplete += delegate(object sender, EventArgs e)
                {
                    count = affects.Count;
                    affects.OrderBy(fullName => fullName).ForEach(fullName => result.AppendLine(fullName));
                };

                //入队
                foreach (FileInfo fileInfo in new DirectoryInfo(searchConfig.Config.WorkDir).VisitFilesByShortPattern(searchConfig.FileUseWildcard ? searchConfig.FileWildcard : null))//通配符
                    dialog.Enqueue(fileInfo);

                //显示
                dialog.ShowDialog(owner);
            }
            return count;
        }

        //替换
        public static int Replace(IWin32Window owner, SearchConfig searchConfig, StringBuilder result)
        {
            if (!Assert(searchConfig, result))
                return 0;

            int count = 0;
            List<string> affects = new List<string>();
            using (FrmBatch<FileInfo> dialog = new FrmBatch<FileInfo>(10))
            {
                dialog.Text = "正在执行查找替换操作";
                //工作
                dialog.Work += delegate(object sender, EventArgs<FileInfo> e)
                {
                    FileInfo fileInfo = e.Argument;
                    if (fileInfo == null)
                        return;

                    string fullName;
                    string oldText = File.ReadAllText(fullName = fileInfo.FullName, Encoding.UTF8);
                    string newText = oldText;
                    StringComparison comparison = searchConfig.CaseMatch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;//大小写
                    if (searchConfig.WordMatch)//全字
                        searchConfig.Find.ForEach(find => newText = newText.ReplaceWord(find.Key, find.Value, comparison));
                    else
                        searchConfig.Find.ForEach(find => newText = newText.Replace(find.Key, find.Value, comparison));
                    if (newText != oldText)
                    {
                        searchConfig.Config.CheckOut(fileInfo);
                        fileInfo.IsReadOnly = false;//去掉只读属性
                        File.WriteAllText(fullName, newText, Encoding.UTF8);
                        lock (affects)
                            affects.Add(fullName);
                        dialog.WriteLog("替换 {0}", fullName);
                    }
                };

                //全部完成,统计
                dialog.AllWorkComplete += delegate(object sender, EventArgs e)
                {
                    count = affects.Count;
                    affects.OrderBy(fullName => fullName).ForEach(fullName => result.AppendLine(fullName));
                };

                //入队
                foreach (FileInfo fileInfo in new DirectoryInfo(searchConfig.Config.WorkDir).VisitFilesByShortPattern(searchConfig.FileUseWildcard ? searchConfig.FileWildcard : null))//通配符
                    dialog.Enqueue(fileInfo);

                //显示
                dialog.ShowDialog(owner);
            }
            return count;
        }
        //签出
        public static int CheckOut(IWin32Window owner, SearchConfig searchConfig, StringBuilder result)
        {
            if (!Assert(searchConfig, result))
                return 0;

            int count = 0;
            List<string> affects = new List<string>();
            using (FrmBatch<FileInfo> dialog = new FrmBatch<FileInfo>(10))
            {
                dialog.Text = "正在执行签出操作";
                //工作
                dialog.Work += delegate(object sender, EventArgs<FileInfo> e)
                {
                    FileInfo fileInfo = e.Argument;
                    if (fileInfo == null)
                        return;

                    //string fullName;
                    //string oldText = File.ReadAllText(fullName = fileInfo.FullName, Encoding.UTF8);
                    //string newText = oldText;
                    //StringComparison comparison = searchConfig.CaseMatch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;//大小写
                    //if (searchConfig.WordMatch)//全字
                    //    searchConfig.Find.ForEach(find => newText = newText.ReplaceWord(find.Key, find.Value, comparison));
                    //else
                    //    searchConfig.Find.ForEach(find => newText = newText.Replace(find.Key, find.Value, comparison));
                    //if (newText != oldText)
                    //{
                        searchConfig.Config.CheckOut(fileInfo);
                        fileInfo.IsReadOnly = false;//去掉只读属性
                    //    File.WriteAllText(fullName, newText, Encoding.UTF8);
                    //    lock (affects)
                    //        affects.Add(fullName);
                    //    dialog.WriteLog("替换 {0}", fullName);
                    //}
                };

                //全部完成,统计
                dialog.AllWorkComplete += delegate(object sender, EventArgs e)
                {
                    count = affects.Count;
                    affects.OrderBy(fullName => fullName).ForEach(fullName => result.AppendLine(fullName));
                };

                //入队
                foreach (FileInfo fileInfo in new DirectoryInfo(searchConfig.Config.WorkDir).VisitFilesByShortPattern(searchConfig.FileUseWildcard ? searchConfig.FileWildcard : null))//通配符
                    dialog.Enqueue(fileInfo);

                //显示
                dialog.ShowDialog(owner);
            }
            return count;
        }


        //翻译器编码
        private static readonly Encoding UTF8_NO_BOM = new UTF8Encoding(false);

        //翻译器断言
        private static bool TranslatorAssert(TranslatorConfig config, StringBuilder result)
        {
            if (config == null)
            {
                result.AppendLine("配置为null.");
                return false;
            }

            if (config.WorkFolder.IsNullOrEmpty())
            {
                result.AppendLine("工作目录为空.");
                return false;
            }

            if (!Directory.Exists(config.WorkFolder))
            {
                result.AppendLine("工作目录不存在.");
                return false;
            }
            return true;
        }

        //翻译器-遍历文件
        private static IEnumerable<string> TranslatorVisitFiles(TranslatorConfig config, string[] patterns)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(config.WorkFolder);
            if (!dirInfo.Exists)
                yield break;

            if (config.ExceptTopFile)
            {
                foreach (DirectoryInfo subDir in dirInfo.EnumerateDirectories())
                {
                    if (subDir.Name.StartsWith("."))
                        continue;

                    foreach (FileInfo subFileInfo in subDir.VisitFilesByRelativePattern(dirInfo, patterns))
                        yield return subFileInfo.FullName;
                }
            }
            else
            {
                foreach (FileInfo fileInfo in dirInfo.VisitFilesByRelativePattern(dirInfo, patterns))
                    yield return fileInfo.FullName;
            }
        }

        //翻译器-查找
        public static StringBuilder TranslatorFind(IWin32Window owner, TranslatorConfig config, Translator translator)
        {
            StringBuilder result = new StringBuilder(1024);
            if (!TranslatorAssert(config, result))
                return result;

            IEnumerable<string> includefiles = TranslatorVisitFiles(config, translator.IncludeFile);
            IEnumerable<string> exceludefiles = (translator.ExcludeFile == null || translator.ExcludeFile.Length == 0) ? new string[] { } : TranslatorVisitFiles(config, translator.ExcludeFile);

            int count = 0;
            List<string> affects = new List<string>();
            using (FrmBatch<string> dialog = new FrmBatch<string>(10, true))
            {
                dialog.Work += delegate(object sender, EventArgs<string> e)
                {
                    string fullName = e.Argument;

                    string text = File.ReadAllText(fullName, UTF8_NO_BOM);
                    bool isWindowsText = text.IndexOf("\r\n") >= 0;//windows换行
                    StringComparison comparison = translator.CaseMatch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;//大小写
                    bool find = false;
                    if (isWindowsText)
                    {
                        find = translator.WordMatch
                            ? (text.IndexOfWord(translator.Find.Replace("\r\n", "\n").Replace("\n", "\r\n"), translator.BanPrefix, translator.BanSuffix, comparison) >= 0)//全字
                            : (text.IndexOf(translator.Find.Replace("\r\n", "\n").Replace("\n", "\r\n"), translator.BanPrefix, translator.BanSuffix, comparison) >= 0);//非全字
                    }
                    else
                    {
                        find = translator.WordMatch
                            ? (text.IndexOfWord(translator.Find.Replace("\r\n", "\n"), translator.BanPrefix, translator.BanSuffix, comparison) >= 0)//全字
                            : (text.IndexOf(translator.Find.Replace("\r\n", "\n"), translator.BanPrefix, translator.BanSuffix, comparison) >= 0);//非全字
                    }

                    if (find)
                    {
                        lock (affects)
                            affects.Add(fullName);
                        dialog.WriteLog("{0} 查找 {1}", translator.Find, fullName);
                    }
                };

                //全部完成,统计
                dialog.AllWorkComplete += delegate(object sender, EventArgs e)
                {
                    count = affects.Count;
                    affects.OrderBy(fullName => fullName).ForEach(fullName => result.AppendLine(fullName));
                };

                foreach (string fullname in includefiles.Except(exceludefiles))
                    dialog.Enqueue(fullname);

                dialog.ShowDialog(owner);
            }
            result.Insert(0, string.Format("{0} 查找到以下文件,共 {1} 个\r\n", translator.Find, count));
            return result;
        }

        //翻译器-替换
        public static StringBuilder TranslatorReplace(IWin32Window owner, TranslatorConfig config, Translator translator, string comment)
        {
            StringBuilder result = new StringBuilder(1024);
            if (!TranslatorAssert(config, result))
                return result;

            IEnumerable<string> includefiles = TranslatorVisitFiles(config, translator.IncludeFile);
            IEnumerable<string> exceludefiles = (translator.ExcludeFile == null || translator.ExcludeFile.Length == 0) ? new string[] { } : TranslatorVisitFiles(config, translator.ExcludeFile);

            int count = 0;
            List<string> affects = new List<string>();
            using (FrmBatch<string> dialog = new FrmBatch<string>(10, true))
            {
                dialog.Work += delegate(object sender, EventArgs<string> e)
                {
                    string fullName = e.Argument;

                    string oldText = File.ReadAllText(fullName, UTF8_NO_BOM);
                    string newText = oldText;
                    StringComparison comparison = translator.CaseMatch ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;//大小写
                    bool isWindowsText = oldText.IndexOf("\r\n") >= 0;//windows换行

                    if (isWindowsText)
                    {
                        if (translator.WordMatch)//全字
                            newText = newText.ReplaceWord(translator.Find.Replace("\r\n", "\n").Replace("\n", "\r\n"), translator.Replace.Replace("\r\n", "\n").Replace("\n", "\r\n"), translator.BanPrefix, translator.BanSuffix, comparison);
                        else
                            newText = newText.Replace(translator.Find.Replace("\r\n", "\n").Replace("\n", "\r\n"), translator.Replace.Replace("\r\n", "\n").Replace("\n", "\r\n"), translator.BanPrefix, translator.BanSuffix, comparison);
                    }
                    else
                    {
                        if (translator.WordMatch)//全字
                            newText = newText.ReplaceWord(translator.Find.Replace("\r\n", "\n"), translator.Replace.Replace("\r\n", "\n"), translator.BanPrefix, translator.BanSuffix, comparison);
                        else
                            newText = newText.Replace(translator.Find.Replace("\r\n", "\n"), translator.Replace.Replace("\r\n", "\n"), translator.BanPrefix, translator.BanSuffix, comparison);
                    }

                    if (newText != oldText)
                    {
                        File.WriteAllText(fullName, newText, UTF8_NO_BOM);
                        lock (affects)
                            affects.Add(fullName);
                        dialog.WriteLog("{0} 替换 {1}", translator.Find, fullName);
                    }
                };

                //全部完成,统计
                dialog.AllWorkComplete += delegate(object sender, EventArgs e)
                {
                    count = affects.Count;
                    affects.OrderBy(fullName => fullName).ForEach(fullName => result.AppendLine(fullName));
                    GitHelper.GitCommit(config, comment);
                };

                foreach (string fullname in includefiles.Except(exceludefiles))
                    dialog.Enqueue(fullname);

                dialog.ShowDialog(owner);
            }
            result.Insert(0, string.Format("{0} 替换以下文件,共 {1} 个\r\n", translator.Find, count));
            return result;
        }

        //翻译器-替换官方资源
        public static StringBuilder TranslatorReplaceResourceOrg(TranslatorConfig config)
        {
            StringBuilder result = new StringBuilder();
            if (config.WorkFolder.IsNullOrEmpty())
                return result;

            using (MemoryStream ms = new MemoryStream(Resources.resource))
            {
                using (IArchive archive = ArchiveFactory.Open(ms))
                {
                    //创建临时目录
                    string tempDir = FilePathHelper.GetAbsolutePath(Guid.NewGuid().ToStringEx(), config.WorkFolder);
                    Directory.CreateDirectory(tempDir);
                    //解压到临时目录
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                            entry.WriteToDirectory(tempDir, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                    }
                    //复制wfy 到工作目录
                    new DirectoryInfo(FilePathHelper.GetAbsolutePath(".\\org", tempDir)).Copy(new DirectoryInfo(config.WorkFolder));
                    //删除临时目录
                    try { Directory.Delete(tempDir, true); }
                    catch { }
                }
            }
            //存在显式文件夹则复制
            DirectoryInfo dirInfoOrg = new DirectoryInfo(FilePathHelper.GetAbsolutePath(".\\resources\\org"));
            if (dirInfoOrg.Exists)
                dirInfoOrg.Copy(new DirectoryInfo(config.WorkFolder));
            //根据配置提交
            GitHelper.GitAdd(config);
            GitHelper.GitCommit(config, "【官方资源】替换官方部署后资源,以制作 diff 文件");
            result.AppendLine("已替换官方资源");
            return result;
        }

        //翻译器-替换富友资源
        public static StringBuilder TranslatorReplaceResourceWfy(TranslatorConfig config)
        {
            StringBuilder result = new StringBuilder();
            if (config.WorkFolder.IsNullOrEmpty())
                return result;

            using (MemoryStream ms = new MemoryStream(Resources.resource))
            {
                using (IArchive archive = ArchiveFactory.Open(ms))
                {
                    //创建临时目录
                    string tempDir = FilePathHelper.GetAbsolutePath(Guid.NewGuid().ToStringEx(), config.WorkFolder);
                    Directory.CreateDirectory(tempDir);
                    //解压到临时目录
                    foreach (var entry in archive.Entries)
                    {
                        if (!entry.IsDirectory)
                            entry.WriteToDirectory(tempDir, ExtractOptions.ExtractFullPath | ExtractOptions.Overwrite);
                    }
                    //复制wfy 到工作目录
                    new DirectoryInfo(FilePathHelper.GetAbsolutePath(".\\wfy", tempDir)).Copy(new DirectoryInfo(config.WorkFolder));
                    //删除临时目录
                    try { Directory.Delete(tempDir, true); }
                    catch { }
                }
            }
            //存在显式文件夹则复制
            DirectoryInfo dirInfoWfy = new DirectoryInfo(FilePathHelper.GetAbsolutePath(".\\resources\\wfy"));
            if (dirInfoWfy.Exists)
                dirInfoWfy.Copy(new DirectoryInfo(config.WorkFolder));
            //根据配置提交
            GitHelper.GitAdd(config);
            GitHelper.GitCommit(config, "【富友资源】替换富友资源");
            result.AppendLine("已替换富友资源");
            return result;
        }
    }
}
