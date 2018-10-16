using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ConsoleAppTest
{
  
    public class Indexer //: IEnumerable
    {
        static public int size = 10;
        private string[] indexerList = new string[size];
        public static int Size
        {
            get { return Indexer.size; }
            set { Indexer.size = value; }
        }
        //构造函数赋初值
        public Indexer()
        {
            for (int i = 0; i < indexerList.Length; i++)
                indexerList[i] = "DefaultValue";
        }

        //c# 索引器
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

        //实现foreach枚举
        public IEnumerator GetEnumerator()
        {
            return this.indexerList.GetEnumerator();
        }

    }
}
