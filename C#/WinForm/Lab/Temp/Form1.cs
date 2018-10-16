using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Temp
{
    struct PrintedPage
    {
        public string text;
        public int count;
    }
    class WebPage
    {
        public string text;
        public int count;
    } 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //InitTestValueVariable();
            //InitStackHeap();
            InitTest3();
        }

        private void InitTest3()
        {
            //public struct Int32
            int intori = 1;
            int intcopy = intori;
            intcopy = 2;
            //int: intori = 1, intcopy = 2
            Console.WriteLine("int: intori = {0}, intcopy = {1}", intori, intcopy);

            //string is a class, but simulating value semantic in all aspects
            //public sealed class String
            string strori = "original string";
            string strcopy = strori;
            strcopy = "copy string";
            //string: strori = original string, strcopy = copy string
            Console.WriteLine("string: strori = {0}, strcopy = {1}", strori, strcopy);

            //all array are reference type
            int[] aryori = new int[3] { 1, 2, 3 };
            int[] arycopy = aryori;
            arycopy[0] = 4;
            //array: aryori[0]=4, arycopy[0]=4
            Console.WriteLine("array: aryori[0] = {0}, arycopy[0] = {1}", aryori[0], arycopy[0]);

            //value type: struct
            //origPtpg and copyPtpg direct to different block, i.e. origPtpg give value to copyPtpg
            //text is string type, is also 
            PrintedPage origPtpg = new PrintedPage();
            origPtpg.text = "originnal printed page";
            origPtpg.count = 1;
            PrintedPage copyPtpg = origPtpg;
            copyPtpg.text = "changed printed page";
            copyPtpg.count = 2;
            //original printed page : text = originnal printed page; count = 1
            Console.WriteLine("original printed page : text = {0}; count = {1}", origPtpg.text, origPtpg.count);
            //copy printed page : text = changed printed page; count = 2
            Console.WriteLine("copy printed page : text = {0}; count = {1}", copyPtpg.text, copyPtpg.count);



            //reference type
            //although local variable name is different, copyWebpg and oriWebpg direct to the same block
            WebPage oriWebpg = new WebPage();
            oriWebpg.text = "original web page";
            oriWebpg.count = 1;
            WebPage copyWebpg = oriWebpg;
            copyWebpg.text = "changed web page";
            copyWebpg.count = 2;
            //original web page : text = changed web page; count = 2
            Console.WriteLine("original web page : text = {0}; count = {1}", oriWebpg.text, oriWebpg.count);
            //copy web page : text = changed web page; count = 2
            Console.WriteLine("copy web page : text = {0}; count = {1}", copyWebpg.text, copyWebpg.count);

            //new : allocate a new block, there is no directly relationship between copyWebpg and oriWebpg
            //If x is a variable and its type is a reference type, 
            //then changing the value of x is not the same as changing the data in the object which the value of x refers to.
            copyWebpg = new WebPage();
            copyWebpg.text = "copy new web page";
            copyWebpg.count = 3;
            //original web page : text = changed web page; count = 2
            Console.WriteLine("original web page : text = {0}; count = {1}", oriWebpg.text, oriWebpg.count);
            //copy new web page : text = copy new web page; count = 3
            Console.WriteLine("copy new web page : text = {0}; count = {1}", copyWebpg.text, copyWebpg.count);
        }

        private void InitStackHeap()
        {
            int i = 4;
            int j = i;

            i = 5;
            Console.WriteLine("i = {0}; j = {1}.", i, j);
        }


        private void InitTest()
        {
            //因为值类型是存储的是值，而引用类型存储变量的地址。值类型/引用类型与栈/堆没有直接的联系
            //==操作比较的是两个变量的值是否相等，对于引用型变量表示的是两个变量在堆中存储的地址是否相同
            //equals操作表示的两个变量是否是对同一个对象的引用
            //string(public sealed class String)很特别,虽然是引用类型,但是值相同就会指向同一个引用,应该是因为他的密封性.
            //a,b指向同一个引用,当a或b的值修改了,才会重新分配内存
            string a = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            string b = new string(new char[] { 'h', 'e', 'l', 'l', 'o' });
            Console.WriteLine(a == b);
            Console.WriteLine(a.Equals(b));
            //True
            //True

            object g = a;
            object h = b;
            Console.WriteLine(g == h);//栈中存的是a,b本身的地址
            Console.WriteLine(g.Equals(h));//new char[] { 'h', 'e', 'l', 'l', 'o' }
            //False
            //True

            Person p1 = new Person("jia");
            Person p2 = new Person("jia");
            Console.WriteLine(p1 == p2);
            Console.WriteLine(p1.Equals(p2));
            //False
            //False

            Person p3 = new Person("jia");
            Person p4 = p3;
            Console.WriteLine(p3 == p4);
            Console.WriteLine(p3.Equals(p4));
            //True
            //True
            //p4的地址和值里存的地址都和p3一致,
            p4.name = "modified";
            Console.WriteLine(p3.name);
            Console.ReadLine();
            //modified
        }

        private void InitVariable()
        {
            //验证值传递和引用传递
            //值传递 : 传递的实参的值,改变的是形参的值
            //引用传递 : 传递的实参的地址,改变的是形参的值,同时实参的值也发生改变
            int i = 5;
            Console.WriteLine(valueWrite(i));
            Console.WriteLine(i);
            ClassTest ct = new ClassTest();
            ct.itest = 5;
            Console.WriteLine(valueWrite(ct));
            Console.WriteLine(ct.itest);

            /*0
            5
            0
            0*/
        }

        private int valueWrite(ClassTest ct)
        {
            int ilocalVraiable = 0;
            ct.itest = ilocalVraiable;

            return ct.itest;
        }

        private int valueWrite(int iFormal)
        {
            int ilocalVraiable = 0;
            iFormal = ilocalVraiable;

            return iFormal;
        }

        private void Init()
        {
            memoEdit1.KeyPress += delegate (object sender, KeyPressEventArgs e)
            {
                if (e.KeyChar == (char)(13))
                {
                    btn.PerformClick();
                }
            };
            btn.Click += delegate
            {
                MessageBox.Show("按钮单击");
            };


        }


    }
}
