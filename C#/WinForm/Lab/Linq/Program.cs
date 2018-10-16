//#define DEBUG
//#undef DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace WindowsFormsApplication1
{
    static class Program
    {


        private readonly static string dataPath = Path.GetFullPath(Path.Combine(Application.StartupPath, @"..\..\Data\"));

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //nullAbleTest();
            //#if TRACE
            //            MessageBox.Show("", "!DEBUG");
            //#elif DEBUG
            //            MessageBox.Show("","!DEBUG");
            //#endif
#if DEBUG
            //test();
#else
             MessageBox.Show("","!DEBUG");
#endif
        }

        //可空的数据类型
        private static void nullAbleTest()
        {
            #region  初解   可以是包括 struct 在内的任何值类型；但不能是引用类型
            int? i = 10;
            double? d1 = 3.14;
            bool? flag = null;
            char? letter = 'a';
            int?[] arr = new int?[10];
            //string? str = null;//错误	1	类型“string”必须是不可以为 null 值的类型才能用作泛型类型或方法


            int? num = null;//Nullable<int> num = null;
            if (num.HasValue)
                Console.WriteLine("num = {0}", num.Value);
            else
                Console.WriteLine(string.Format("num = {0}", "Null"));

            int? y = num ?? 255;// ?? 算符分配默认值
            Console.WriteLine(string.Format("y = {0}", y));

            y = num.GetValueOrDefault();

            try
            {
                //y = num.Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            #endregion

            #region null值的运算,其中一个为null,结果为null
            int? a = 10;
            int? b = null;
            a++;
            try
            {
                a = a * b; //null
                a = a + b; //null
                a = b / a;  //null
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            bool? boolisNull = null;
            bool? boolnotNull = false;
            object boxNull = boolisNull as object;
            //if (boolisNull) { }//错误	1	无法将类型“bool?”隐式转换为“bool”。

            if (boolisNull.HasValue)
            {
                Console.WriteLine("boolisNull has value");
            }
            else
            {
                Console.WriteLine("boolisNull has not value");
            }

            Console.ReadLine();
            #endregion
            

        }

        private static void test()
        {

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            Console.WriteLine("001");
            var lowNumbs = from num in numbers where num < 3 select num;
            foreach (var num in lowNumbs)
                Console.WriteLine(num);


            string[] strings = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Console.WriteLine("002");
            var varAnony = from annoy in numbers where annoy % 2 == 0 select new { Digit = strings[annoy], Even = annoy };
            foreach (var Annoy in varAnony)
                Console.WriteLine(Annoy);

            Console.WriteLine("numb==index?");

            var IndexEqualsNumb = numbers.Select((numb, isPlace) => new { num = numb, isPlace = (numb == isPlace) });
            foreach (var n in IndexEqualsNumb)
                Console.WriteLine("{0}: {1}", n.num, n.isPlace);

            Console.WriteLine("froms");
            int[] numbersB = { 1, 3, 5 };
            var froms = from a in numbers from b in numbersB where a < b select new { a, b };
            foreach (var from in froms)
                Console.WriteLine(from.a + " is less than " + from.b);
            Console.WriteLine("ReadXml");
            GetDataFromXml();
            Console.ReadLine();
        }

        private static void GetDataFromXml()
        {
            string customerListPath = Path.GetFullPath(Path.Combine(dataPath, "customers.xml"));
            List<Customer> customerList;
            customerList = (
                from e in XDocument.Load(customerListPath).
                    Root.Elements("customer")
                select new Customer
                {
                    CustomerID = (string)e.Element("id"),
                    CompanyName = (string)e.Element("name"),
                    Address = (string)e.Element("address"),
                    City = (string)e.Element("city"),
                    Region = (string)e.Element("region"),
                    PostalCode = (string)e.Element("postalcode"),
                    Country = (string)e.Element("country"),
                    Phone = (string)e.Element("phone"),
                    Fax = (string)e.Element("fax"),
                    Orders = (from o in e.Elements("orders").Elements("orders")
                              select new Order
                              {
                                  OrderID = (int)o.Element("id"),
                                  OrderDate = (DateTime)o.Element("orderdate"),
                                  Total = (decimal)o.Element("total")
                              })
                                  .ToArray()
                })
                .ToList();

            if (customerList == null)
                return;

            //var 
        }

        public class Customer
        {
            public string CustomerID { get; set; }
            public string CompanyName { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Region { get; set; }
            public string PostalCode { get; set; }
            public string Country { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public Order[] Orders { get; set; }
        }
        public class Order
        {
            public int OrderID { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal Total { get; set; }
        }
    }
}
