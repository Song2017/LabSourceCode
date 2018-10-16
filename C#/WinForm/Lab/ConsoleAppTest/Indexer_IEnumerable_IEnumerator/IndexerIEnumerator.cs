using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleAppTest
{
    public class IndexerIEnumerator : IEnumerator
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

        //索引器枚举时对应的 键值
        private int position = -1;
        //实现IEnumerator的方法
        public object Current
        {
            get
            {
                try
                {
                    return indexerList[position];
                }
                catch
                {
                    return null;
                }
            }
        }

        public bool MoveNext()
        {
            position++;
            return position < indexerList.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        //实现枚举
        public IEnumerator GetEnumerator()
        {
            foreach (string strTmp in indexerList)
                yield return strTmp;
            yield break;
        }
    }
}
