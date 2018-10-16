using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class TestBoxingandUnboxing
    {
        public void test()
        {
            //The concept of boxing and unboxing underlies the C# unified view of the type system 
            //in which a value of any type can be treated as an object

            //Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type. 
            //int=> object
            Console.WriteLine("Boxing");
            int i = 123;
            object o = i;//Boxing is implicit
            o = 1;
            Console.WriteLine(i.ToString());//123
            Console.WriteLine(o.ToString());//1
            Console.ReadKey();


            //Unboxing extracts the value type from the object
            //object=> int
            Console.WriteLine("UnBoxing");
            object uo = 123;
            int ui = (int)uo;//unboxing is explicit
            int ui2 = ui;
            ui = 1;
            Console.WriteLine(ui.ToString());//1
            Console.WriteLine(ui2.ToString());//123
            Console.WriteLine(uo.ToString());//123
            Console.ReadKey();
        }

    }
}
