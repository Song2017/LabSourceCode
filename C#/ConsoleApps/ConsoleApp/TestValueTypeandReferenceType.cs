using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
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
    public class TestValueTypeandReferenceType
    {
        public void Test()
        {
            //public struct Int32
            int intori = 1;
            int intcopy = intori;
            intcopy = 2;
            //int: intori = 1, intcopy = 2
            Console.WriteLine("int: intori = {0}, intcopy = {1}", intori, intcopy);
            Console.ReadKey();

            //string is a class, but simulating value semantic in all aspects
            //public sealed class String
            string strori = "original string";
            string strcopy = strori;
            strcopy = "copy string";
            //string: strori = original string, strcopy = copy string
            Console.WriteLine("string: strori = {0}, strcopy = {1}", strori, strcopy);
            Console.ReadKey();

            //all array are reference type
            int[] aryori = new int[3] { 1, 2, 3 };
            int[] arycopy = aryori;
            arycopy[0] = 4;
            //array: aryori[0]=4, arycopy[0]=4
            Console.WriteLine("array: aryori[0] = {0}, arycopy[0] = {1}", aryori[0], arycopy[0]);
            Console.ReadKey();

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
            Console.ReadKey();



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
    }
}
