using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Temp
{

    public class Person
    {
        public static int stint;
        public const int coint = 3;
        public readonly int reint;

        public string name;

        public Person(string p)
        {
            reint = 9;
            this.name = p;

        }
        public Person()
        {
            reint = 9;
            stint = 8;
            reint = 19;

            this.name = "no one";

        }

        public void count()
        { 
            stint = 10;

            int cnt = 0;
            Console.WriteLine(cnt);
        }
    }
}
