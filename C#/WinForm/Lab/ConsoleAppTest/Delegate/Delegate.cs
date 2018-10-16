using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTest.Delegate
{
    public delegate int NumberCalculator(int n);
    public class Delegate
    {
        static int num = 10;
        public static int Add(int p)
        {
            num += p;
            return num;
        }
        public static int Mul(int p)
        {
            num *= p;
            return num;
        }
        public static int Display()
        {
            return num;
        }

        //static void Main(string[] args)
        //{

        //    NumberCalculator nc;
        //    NumberCalculator ncAdd = new NumberCalculator(Add);
        //    NumberCalculator ncMul = new NumberCalculator(Mul);
        //    nc = ncMul;
        //    nc += ncAdd;

        //    nc(5);
        //    Console.WriteLine(Delegate.Display());
        //    Console.ReadKey();
        //}
    }



}
