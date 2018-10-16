using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using BaseExtensions;

namespace Finder
{
    /// <summary>
    /// 字符串扩展
    /// </summary>
    public static class StringEx
    {
        //单词分隔符集合
        private static readonly ReadOnlyCollection<char> m_WordBreakCollection = new ReadOnlyCollection<char>(new char[] { ' ', '\t', '\r', '\n', '{', '}', '[', ']', '(', ')', '.', ',', ':', ';', '+', '-', '*', '/', '%', '&', '|', '^', '!', '~', '=', '<', '>', '?', '@', '#', '\'', '"', '\\' }); //单词结束符号
        /// <summary>
        /// 获取单词分隔符集合
        /// </summary>
        public static ReadOnlyCollection<char> WordBreakCollection
        {
            get
            {
                return m_WordBreakCollection;
            }
        }


        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的所有匹配项的索引。参数指定当前字符串中的起始搜索位置、要搜索的当前字符串中的字符数量，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="start">搜索起始位置。</param>
        /// <param name="count">要检查的字符位置数。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>枚举所有匹配项的索引。</returns>
        private static IEnumerable<int> EnumerateIndexOf(this string value, string word, string banprefix, string bansuffix, int start, int count, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            //条件判断
            if (value.IsNullOrEmpty() || word.IsNullOrEmpty())
                yield break;

            //顺序查找
            int wordPrev;
            int wordNext;
            int valueBeginIndex = 0;
            int valueLength = value.Length;
            int wordLength = word.Length;
            int searchEnd = start + count;
            int index;
            int banprefixLength = banprefix == null ? 0 : banprefix.Length;
            int bansuffixLength = bansuffix == null ? 0 : bansuffix.Length;
            while ((index = value.IndexOf(word, start, count, comparisonType)) >= 0)
            {
                try
                {
                    //判断禁用前缀
                    if (!banprefix.IsNullOrEmpty() && (wordPrev = index - banprefixLength) >= valueBeginIndex && value.Substring(wordPrev, banprefixLength) == banprefix)
                        continue;

                    wordNext = index + wordLength;
                    //判断禁用后缀
                    if (!bansuffix.IsNullOrEmpty() && (wordNext + bansuffixLength) < valueLength && value.Substring(wordNext, bansuffixLength) == bansuffix)
                        continue;

                    yield return index;
                }
                finally
                {
                    start = index + wordLength;
                    count = searchEnd - start;
                }
            }
        }

        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的第一个全字匹配项的索引。参数指定要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果找到该字符串，则为第一个全字匹配项的索引；否则为 -1。</returns>
        public static int IndexOf(this string value, string word, string banprefix, string bansuffix, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return EnumerateIndexOf(value, word, banprefix, bansuffix, 0, value == null ? 0 : value.Length, comparisonType).FirstOrDefault(-1);
        }

        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的第一个全字匹配项的索引。参数指定当前字符串中的起始搜索位置，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="start">搜索起始位置。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果找到该字符串，则为第一个全字匹配项的索引；否则为 -1。</returns>
        public static int IndexOf(this string value, string word, string banprefix, string bansuffix, int start, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return EnumerateIndexOf(value, word, banprefix, bansuffix, start, (value == null ? 0 : value.Length) - start, comparisonType).FirstOrDefault(-1);
        }

        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的第一个全字匹配项的索引。参数指定当前字符串中的起始搜索位置、要搜索的当前字符串中的字符数量，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="start">搜索起始位置。</param>
        /// <param name="count">要检查的字符位置数。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果找到该字符串，则为第一个全字匹配项的索引；否则为 -1。</returns>
        public static int IndexOf(this string value, string word, string banprefix, string bansuffix, int start, int count, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return EnumerateIndexOf(value, word, banprefix, bansuffix, start, count, comparisonType).FirstOrDefault(-1);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。参数指定要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中替换。</param>
        /// <param name="word">要被替换的字符串。</param>
        /// <param name="replacement">要替换出现的所有 word 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>与当前字符串等效的一个字符串，但其中 word 的所有实例都替换为 replacement。</returns>
        public static string Replace(this string value, string word, string replacement, string banprefix, string bansuffix, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return Replace(value, word, replacement, banprefix, bansuffix, 0, value == null ? 0 : value.Length, comparisonType);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。参数指定当前字符串中的起始替换位置，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中替换。</param>
        /// <param name="word">要被替换的字符串。</param>
        /// <param name="replacement">要替换出现的所有 word 的字符串。</param>
        /// <param name="start">替换起始位置。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>与当前字符串等效的一个字符串，但其中 word 的所有实例都替换为 replacement。</returns>
        public static string Replace(this string value, string word, string replacement, string banprefix, string bansuffix, int start, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return Replace(value, word, replacement, banprefix, bansuffix, start, (value == null ? 0 : value.Length) - start, comparisonType);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都替换为另一个指定的字符串。参数指定当前字符串中的起始替换位置、要替换的当前字符串中的字符数量，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中替换。</param>
        /// <param name="word">要被替换的字符串。</param>
        /// <param name="replacement">要替换出现的所有 word 的字符串。</param>
        /// <param name="start">替换起始位置。</param>
        /// <param name="count">要检查的字符位置数。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>与当前字符串等效的一个字符串，但其中 word 的所有实例都替换为 replacement。</returns>
        public static string Replace(this string value, string word, string replacement, string banprefix, string bansuffix, int start, int count, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            //查询索引
            List<int> indexes = EnumerateIndexOf(value, word, banprefix, bansuffix, start, count, comparisonType).ToList();
            if (indexes.Count <= 0)
                return value;

            //移除添加
            int wordLength = word.Length;
            StringBuilder sbValue = new StringBuilder(value);
            for (int i = indexes.Count - 1, index; i >= 0; i--)
            {
                index = indexes[i];
                sbValue.Remove(index, wordLength);
                sbValue.Insert(index, replacement.ToStringEx());
            }
            return sbValue.ToStringEx();
        }


        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的所有全字匹配项的索引。参数指定当前字符串中的起始搜索位置、要搜索的当前字符串中的字符数量，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="start">搜索起始位置。</param>
        /// <param name="count">要检查的字符位置数。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>枚举所有全字匹配项的索引。</returns>
        private static IEnumerable<int> EnumerateIndexOfWord(this string value, string word, string banprefix, string bansuffix, int start, int count, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            //条件判断
            if (value.IsNullOrEmpty() || word.IsNullOrEmpty())
                yield break;

            //顺序查找
            int wordPrev;
            int wordNext;
            int wordLength = word.Length;
            int valueBeginIndex = 0;
            int valueLength = value.Length;
            int searchEnd = start + count;
            int index;

            int banprefixLength = banprefix == null ? 0 : banprefix.Length;
            int bansuffixLength = bansuffix == null ? 0 : bansuffix.Length;
            while ((index = value.IndexOf(word, start, count, comparisonType)) >= 0)
            {
                try
                {
                    //判断前一个字符
                    if ((wordPrev = index - 1) >= valueBeginIndex)
                    {
                        if (!m_WordBreakCollection.Contains(value[wordPrev]))
                            continue;
                    }

                    //判断禁用前缀
                    if (!banprefix.IsNullOrEmpty() && (wordPrev = index - banprefixLength) >= valueBeginIndex && value.Substring(wordPrev, banprefixLength) == banprefix)
                        continue;

                    //判断后一个字符
                    if ((wordNext = index + wordLength) < valueLength)
                    {
                        if (!m_WordBreakCollection.Contains(value[wordNext]))
                            continue;
                    }

                    //判断禁用后缀
                    if (!bansuffix.IsNullOrEmpty() && (wordNext + bansuffixLength) < valueLength && value.Substring(wordNext, bansuffixLength) == bansuffix)
                        continue;

                    //返回
                    yield return index;
                }
                finally
                {
                    start = index + wordLength;
                    count = searchEnd - start;
                }
            }
        }

        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的第一个全字匹配项的索引。参数指定要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果找到该字符串，则为第一个全字匹配项的索引；否则为 -1。</returns>
        public static int IndexOfWord(this string value, string word, string banprefix, string bansuffix, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return EnumerateIndexOfWord(value, word, banprefix, bansuffix, 0, value == null ? 0 : value.Length, comparisonType).FirstOrDefault(-1);
        }

        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的第一个全字匹配项的索引。参数指定当前字符串中的起始搜索位置，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="start">搜索起始位置。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果找到该字符串，则为第一个全字匹配项的索引；否则为 -1。</returns>
        public static int IndexOfWord(this string value, string word, string banprefix, string bansuffix, int start, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return EnumerateIndexOfWord(value, word, banprefix, bansuffix, start, (value == null ? 0 : value.Length) - start, comparisonType).FirstOrDefault(-1);
        }

        /// <summary>
        /// 报告指定的字符串在当前 System.String 对象中的第一个全字匹配项的索引。参数指定当前字符串中的起始搜索位置、要搜索的当前字符串中的字符数量，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中搜寻。</param>
        /// <param name="word">要搜寻的字符串。</param>
        /// <param name="start">搜索起始位置。</param>
        /// <param name="count">要检查的字符位置数。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>如果找到该字符串，则为第一个全字匹配项的索引；否则为 -1。</returns>
        public static int IndexOfWord(this string value, string word, string banprefix, string bansuffix, int start, int count, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return EnumerateIndexOfWord(value, word, banprefix, bansuffix, start, count, comparisonType).FirstOrDefault(-1);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都全字替换为另一个指定的字符串。参数指定要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中替换。</param>
        /// <param name="word">要被替换的字符串。</param>
        /// <param name="replacement">要替换出现的所有 word 的字符串。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>与当前字符串等效的一个字符串，但其中 word 的所有实例都替换为 replacement。</returns>
        public static string ReplaceWord(this string value, string word, string replacement, string banprefix, string bansuffix, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return ReplaceWord(value, word, replacement, banprefix, bansuffix, 0, value == null ? 0 : value.Length, comparisonType);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都全字替换为另一个指定的字符串。参数指定当前字符串中的起始替换位置，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中替换。</param>
        /// <param name="word">要被替换的字符串。</param>
        /// <param name="replacement">要替换出现的所有 word 的字符串。</param>
        /// <param name="start">替换起始位置。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>与当前字符串等效的一个字符串，但其中 word 的所有实例都替换为 replacement。</returns>
        public static string ReplaceWord(this string value, string word, string replacement, string banprefix, string bansuffix, int start, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            return ReplaceWord(value, word, replacement, banprefix, bansuffix, start, (value == null ? 0 : value.Length) - start, comparisonType);
        }

        /// <summary>
        /// 返回一个新字符串，其中当前实例中出现的所有指定字符串都全字替换为另一个指定的字符串。参数指定当前字符串中的起始替换位置、要替换的当前字符串中的字符数量，以及要用于指定字符串的搜索类型。
        /// </summary>
        /// <param name="value">从该字符串中替换。</param>
        /// <param name="word">要被替换的字符串。</param>
        /// <param name="replacement">要替换出现的所有 word 的字符串。</param>
        /// <param name="start">替换起始位置。</param>
        /// <param name="count">要检查的字符位置数。</param>
        /// <param name="comparisonType">指定搜索规则的枚举值之一。</param>
        /// <returns>与当前字符串等效的一个字符串，但其中 word 的所有实例都替换为 replacement。</returns>
        public static string ReplaceWord(this string value, string word, string replacement, string banprefix, string bansuffix, int start, int count, StringComparison comparisonType = StringComparison.CurrentCulture)
        {
            //查询索引
            List<int> indexes = EnumerateIndexOfWord(value, word, banprefix, bansuffix, start, count, comparisonType).ToList();
            if (indexes.Count <= 0)
                return value;

            //移除添加
            int wordLength = word.Length;
            StringBuilder sbValue = new StringBuilder(value);
            for (int i = indexes.Count - 1, index; i >= 0; i--)
            {
                index = indexes[i];
                sbValue.Remove(index, wordLength);
                sbValue.Insert(index, replacement.ToStringEx());
            }
            return sbValue.ToStringEx();
        }
    }
}
