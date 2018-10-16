using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleAppTest
{
    //声明委托
    public delegate void DelegateEventHandler(object sender, string status);

    //事件测试 发布器类
    public class EventTest
    {
        //声明事件
        public event DelegateEventHandler DelegateEvent;

        //调用事件
        public void DelegateEventTest(string status)
        {
            if (DelegateEvent != null)
                DelegateEvent(this, status);
        }
    }

    //订阅器类
    public class Subscriber
    {
        static void infoLogger(object obj, string status)
        {
            Console.WriteLine("info : status is {0}", status);
        }
        static void errorLogger(object obj, string status)
        {
            Console.WriteLine("error : status is {0}", status);
        }

        //public static void Main(string[] args)
        //{
        //    EventTest eventTest = new EventTest();//订阅器类实例化

        //    //注册事件 注册顺序决定方法执行顺序
        //    eventTest.DelegateEvent += delegate(object sender, string status)
        //    {
        //        Console.WriteLine("delegate : status is {0}", status);
        //    };
        //    eventTest.DelegateEvent += new DelegateEventHandler(infoLogger);
        //    eventTest.DelegateEvent += new DelegateEventHandler(errorLogger);

        //    eventTest.DelegateEventTest("2016.7.13");
        //    Console.ReadKey();
        //    //delegate : status is 2016.7.13
        //    //info : status is 2016.7.13
        //    //error : status is 2016.7.13
        //}


    }
}
