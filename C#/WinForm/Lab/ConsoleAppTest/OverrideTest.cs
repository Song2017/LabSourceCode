using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTest
{
    //重载运算符 2016.7.11
    public class OverrideTest
    {
        public double length;
        public double width;

        public OverrideTest()
        {

        }

        public OverrideTest(double len, double wid)
        {
            this.length = len;
            this.width = wid;
        }

        public static OverrideTest operator +(OverrideTest a, OverrideTest b)
        {
            OverrideTest test = new OverrideTest();
            test.length = a.length + b.length;
            test.width = a.width + b.width;
            return test;
        }


    }
}
