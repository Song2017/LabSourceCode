using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ConsoleAppTest.Attribute_Reflection
{
    public class ReflectionTest
    {
        //program 注掉
        //[STAThread]
        //static void Main(string[] args)
        //{

        //    AttributeClass ac = new AttributeClass(2, 3);
        //    ac.Display();
        //    Console.ReadKey();

        //    //遍历AtrributeClass类的属性
        //    Type type = typeof(AttributeClass);
        //    foreach (object attribute in type.GetCustomAttributes(false))
        //    {
        //        AttributeTest at = (AttributeTest)attribute;
        //        if (null == at)
        //            return;
        //        Console.WriteLine("Bug no: {0}", at.BugNo);
        //        Console.WriteLine("Developer: {0}", at.Developer);
        //        Console.WriteLine("Last Reviewed: {0}", at.LastReview);
        //        Console.WriteLine("Remarks: {0}", at.Message);
        //    }

        //    Console.ReadKey();
        //    //遍历方法属性
        //    //会查出基类的方法,位屏蔽也不好用 
        //    foreach (MethodInfo mi in type.GetMethods())
        //    {
        //        foreach (object attribute in mi.GetCustomAttributes(true))
        //        {
        //            AttributeTest at;
        //            try
        //            {
        //                at = (AttributeTest)attribute;
        //            }
        //            catch
        //            {
        //                at = null;
        //            }

        //            if (null != at)
        //            {
        //                Console.WriteLine("Bug no: {0}", at.BugNo);
        //                Console.WriteLine("Developer: {0}", at.Developer);
        //                Console.WriteLine("Last Reviewed: {0}", at.LastReview);
        //                Console.WriteLine("Remarks: {0}", at.Message);
        //            }
        //        }
        //    }


        //    Console.ReadKey();
        //}

        object obj = new object();
        int i = new int();

    }
}
