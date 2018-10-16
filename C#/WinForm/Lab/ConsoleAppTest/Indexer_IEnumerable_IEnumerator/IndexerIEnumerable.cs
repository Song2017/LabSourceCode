using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleAppTest
{
    public class IndexerIEnumerable : IEnumerable<string>
    {
        static public int size = 10;
        private string[] indexerList = new string[size];

        //索引器
        public string this[int index]
        {
            get
            {
                if (index < 0 || index > size)
                    return "";

                return indexerList[index] == null ? string.Empty : indexerList[index].ToString();
            }
            set
            {
                if (index < 0 || index > size)
                    throw new Exception("超出索引范围: 0~9");
                indexerList[index] = value;
            }
        }

        //实现接口IEnumerable枚举器
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // 实现接口IEnumerable<out T>的枚举器
        public IEnumerator<string> GetEnumerator()
        {
            foreach (string strTmp in indexerList)
                yield return strTmp;
            yield break;
        }

    }
}
