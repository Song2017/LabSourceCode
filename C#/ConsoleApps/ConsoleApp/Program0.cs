using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program0
    {
        //test: force push after merge PR
        static void Main0(string[] args)
        {
            Console.ReadLine();
            TestValueTypeandReferenceType test = new TestValueTypeandReferenceType();
            test.Test();

            TestBoxingandUnboxing test2 = new TestBoxingandUnboxing();
            test2.test();

        }
    }
}
