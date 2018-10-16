using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DelegateTest
{
    //委托可以被视为一个更高级的指针，它不仅仅能把地址指向另一个函数，而且还能传递参数，返回值等多个信息
    public class ClassDelegate
    {
        //委托对象绑定单个方法。
        //无返回值
        delegate void MyDelegate1(string message);
        //有返回值
        delegate string MyDelegate2(string message);
        public class Example
        {
            public void Method1(string message)
            {
                MessageBox.Show(message);
            }

            public string Method2(string message)
            {
                return "Hello" + message;
            }
        }

        //委托对象可以绑定多个方法。
        //当输入参数后，每个方法会按顺序进行迭代处理，并返回最后一个方法的计算结果。
        delegate double MyDelegate3(double message);
        public class Price
        {
            public double Ordinary(double price)
            {
                Console.WriteLine("Ordinary Price :" + price);
                return price;
            }

            public double Discount(double price)
            {
                Console.WriteLine("Discount Price :" + price * Convert.ToDouble(Math.Abs(Convert.ToDecimal(0.75))));
                return price * Convert.ToDouble(Math.Abs(Convert.ToDecimal(0.75)));
            }
        }

        //观察者模式 让多个观察者同时关注同一个事物，并作出不同的响应
        public delegate double Handler(double basicWages);
        public class Manager
        {
            public double GetWages(double basicWages)
            {
                double totalWages = 8 * basicWages;
                MessageBox.Show(null, totalWages.ToString(), "经理工资",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return totalWages;
            }
        }
        public class Assistant
        {
            public double GetWages(double basicWages)
            {
                double totalWages = 2 * basicWages;
                MessageBox.Show(null, totalWages.ToString(), "助理工资",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return totalWages;
            }
        }
        public class WageManager
        {
            private Handler wageHandler;

            //加
            public void Attach(Handler wageHandlerAdd)
            {
                wageHandler += wageHandlerAdd;
            }

            //减
            public void Detach(Handler wageHandlerSub)
            {
                wageHandler -= wageHandlerSub;
            }
            //获取多路广播委托列表，如果观察者数量大于0即执行方法
            public void Execute(double basicWages)
            {
                if (wageHandler != null)
                    if (wageHandler.GetInvocationList().Count() != 0)
                        wageHandler(basicWages);
            }

        }

        //委托逆变 
        //object 为参数的委托，可以接受任何 object 子类的对象作为参数
        public delegate void HandlerObj(object obj);
        public static void GetMessage(object message)
        {
            if (message is string)
                MessageBox.Show(null, message.ToString(), "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand);
            else if (message is int)
                MessageBox.Show(null, message.ToString(), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            else
                MessageBox.Show(null, "!string & !int", "", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Warning);
        }

        //泛型委托
        //可以使一个委托绑定多个不同类型参数的方法，而且在方法中不需要使用 is 进行类型判断
        public delegate void HandlerGen<T>(T obj);
        public class Coolpad
        {
            private double price;
            public double Price
            {
                get { return price; }
                set { price = value; }
            }
        }
        public class iPhone
        {
            private double price;
            public double Price
            {
                get { return price; }
                set { price = value; }
            }
        }
        public static void GetCoolpadPrice(Coolpad coolp)
        {
            MessageBox.Show(null, coolp.Price.ToString(), "酷派", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
        }
        public static void GetiPhonePrice(iPhone ip)
        {
            MessageBox.Show(null, ip.Price.ToString(), "iPhone", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
        }

        
        //事件
        public delegate void DelegateTest(string name);
        public class EventTest 
        {
            public event DelegateTest MyEvent;

            public void GetNameEvent(string name)
            {
                if (MyEvent == null)
                    return;
                MyEvent("My Name Is "+name);
            }
        }
        
        //static void Main(string[] arggs)
        //{
        //    #region  单路广播
        //    //Example ex = new Example();
        //    //当建立委托对象时，委托的参数类型必须与委托方法相对应。
        //    //只要向建立委托对象的构造函数中输入方法名称example.Method，委托就会直接绑定此方法
        //    //MyDelegate1 md1 = new MyDelegate1(ex.Method1);
        //    //md1("asdf");
        //    //MyDelegate2 md2 = new MyDelegate2(ex.Method2);
        //    //string strMd2 = md2("asdf");
        //    //MessageBox.Show(null,strMd2,"测试",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        //    #endregion

        //    #region 多路广播
        //    //Price p = new Price();
        //    //MyDelegate3 md4 = new MyDelegate3(p.Ordinary);
        //    //double strMd4 = md4(100);
        //    //MessageBox.Show(null, strMd4.ToString(), "测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //MyDelegate3 md5 = new MyDelegate3(p.Discount);
        //    //double strMd5 = md5(100);
        //    //MessageBox.Show(null, strMd5.ToString(), "测试", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    #endregion

        //    #region Observer 模式，
        //    ////它使用一对多的方式，可以让多个观察者同时关注同一个事物，并作出不同的响应

        //    //WageManager wm = new WageManager();
        //    ////观察者Manager
        //    //Manager m1 = new Manager();//添加经理1
        //    //Handler mh1 = new Handler(m1.GetWages);//创建委托,将方法作为入参
        //    //wm.Attach(mh1);//添加委托方法
        //    //Manager m12 = new Manager();
        //    //Handler mh12 = new Handler(m12.GetWages);
        //    //wm.Attach(mh12);

        //    ////观察者Assistant
        //    //Assistant a1 = new Assistant();
        //    //Handler ah1 = new Handler(a1.GetWages);
        //    //wm.Attach(ah1);
        //    //wm.Detach(mh1);

        //    //wm.Execute(2000);
        //    #endregion

        //    #region 委托逆变，是指委托方法的参数同样可以接收 “继承” 这个传统规则
        //    //4
        //    //委托协变 指委托直接绑定委托方法 自从Framework 2.0 面试以后，委托协变的概念就应运而生
        //    //HandlerObj hobj = GetMessage;
        //    //hobj(12);
        //    //hobj("12");
        //    //hobj(12.23);//1
        //    //HandlerObj hobj = new HandlerObj(GetMessage);
        //    //hobj(12);
        //    //hobj("12");
        //    //hobj(12.23);

        //    //2
        //    //HandlerObj hobj = delegate(object e) 
        //    //{
        //    //    GetMessage(12);
        //    //    GetMessage("12");
        //    //    GetMessage(12.25);
        //    //};
        //    //hobj(";");//没啥用

        //    //3
        //    //HandlerObj hobj = ((object sender) => 
        //    //{
        //    //    GetMessage(12);
        //    //    GetMessage("12啥错");
        //    //    GetMessage(12.25);
        //    //});
        //    //hobj(2);

        //    //5
        //    //Action<object> hobj = ((object sender) =>
        //    // {
        //    //     GetMessage(12);
        //    //     GetMessage("12啥错");
        //    //     GetMessage(12.25);
        //    // });
        //    //hobj(2);
        //    #endregion

        //    #region 泛型委托
        //    //Action<Coolpad> hgcp = ((Coolpad wee) =>
        //    //{
        //    //    wee.Price = 1500;
        //    //    GetCoolpadPrice(wee);
        //    //});
        //    //Coolpad cpa = new Coolpad();
        //    //cpa.Price = 10000;
        //    //hgcp(cpa);

        //    //Action<iPhone> hgip = ((iPhone wee) =>
        //    //{
        //    //    wee.Price = 3500;
        //    //    GetiPhonePrice(wee);
        //    //});
        //    //iPhone ipa = new iPhone();
        //    //ipa.Price = 10000;
        //    //hgip(ipa);

        //    //HandlerGen<Coolpad> cph = new HandlerGen<Coolpad>(GetCoolpadPrice);
        //    //Coolpad cp = new Coolpad();
        //    //cp.Price = 2000;
        //    //cph(cp);

        //    //HandlerGen<iPhone> iph = new HandlerGen<iPhone>(GetiPhonePrice);
        //    //iPhone ip = new iPhone();
        //    //ip.Price = 6000;
        //    //iph(ip);
        //    #endregion

        //    #region 事件测试
        //    //事件:事件（event）可被视作为一种特别的委托，
        //    //它为委托对象隐式地建立起add_XXX、remove_XXX 两个方法，用作注册与注销事件的处理方法
        //    EventTest eTest = new EventTest();

        //    //注册事件
        //    eTest.MyEvent += delegate(string name)
        //    {
        //        MessageBox.Show(name.ToString());
        //    };

        //    //调用
        //    eTest.GetNameEvent("Jack");
            
        //    #endregion
        //}

    }
}
