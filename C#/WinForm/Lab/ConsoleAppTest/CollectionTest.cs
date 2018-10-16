using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace ConsoleAppTest
{
    public class CollectionTest
    {
        public Hashtable ht;

        public CollectionTest()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col");
            dt.Rows.Add(dt.NewRow());
            dt.Rows.Add("2131");
            //hash
            ht = new Hashtable();
            ht.Add("001", "Zara Ali");
            ht.Add("002", "ceshi");
        }

    }

    static class MainTest
    {
        static void Main(string[] srg)
        {
            #region HashTable
            CollectionTest ht = new CollectionTest();
            foreach (string key in ht.ht.Keys)
                Console.WriteLine(key + ht.ht[key]);
            Console.ReadLine();
            #endregion

            #region Stack
            Stack st = new Stack();
            st.Push("A");
            st.Push("B");

            Console.WriteLine("Push:AB");
            foreach (string key in st)
                Console.WriteLine(key);
            Console.ReadLine();
            st.Push("C");
            st.Push("D");
            Console.WriteLine("Push:CD");
            foreach (string key in st)
                Console.WriteLine(key);
            Console.ReadLine();

            Console.WriteLine("top");
            Console.WriteLine(st.Peek());
            Console.ReadLine();

            Console.WriteLine("pop");
            st.Pop();
            Console.WriteLine(st.Pop());
            Console.WriteLine("current");
            foreach (string key in st)
                Console.WriteLine(key);
            Console.ReadLine();
            #endregion

            #region queue
            Queue q = new Queue();
            Console.WriteLine("Queue : AB");
            q.Enqueue("A");
            q.Enqueue("B");
            foreach (string key in q)
                Console.WriteLine(key);
            Console.ReadLine();

            Console.WriteLine("Queue : AB");
            q.Dequeue();
            foreach (string key in q)
                Console.WriteLine(key);
            Console.ReadLine();

            Console.WriteLine("Queue : CD");
            q.Enqueue("C");
            q.Enqueue("D");
            foreach (string key in q)
                Console.WriteLine(key);
            Console.ReadLine();

            Console.WriteLine(q.Peek());
            Console.ReadLine();
            #endregion




        }
    }



}
