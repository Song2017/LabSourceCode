using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("begin test");
            Nqueue2.nQueen2(4);

            //NQueue nQueue = new NQueue();
            //nQueue.solveNQueues(8);
               

            //IndexreMethod();

            //OperatorOverloadMethod();

            //CustomeTypeConverter();

            //ExtensionMethod();

            //AnonymousClassMethod();

            //PointerMethod();

            //LinqMethod();

            //GCMethod();

        }
         

        private static void GCMethod()
        {
            Console.WriteLine("GC GetTotalMemory" + GC.GetTotalMemory(false) + ";");
            Console.WriteLine("GC MaxGeneration" + GC.MaxGeneration + ";");
            GC.Collect();
            GC.WaitForPendingFinalizers();

            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Play();
            mediaPlayer.GetAllTracks();

        }

        private static void LinqMethod()
        {
            string[] currVideos = new string[] { "morrowind", "red", "gone with the wind", "fallout", "modern family" };

            var subset = from g in currVideos
                         where g.Contains(" ")
                         orderby g
                         select g;

            foreach (var v in subset)
                Console.WriteLine(v);


            List<Car> cars = new List<Car>() {
                new Car { Name = "car1",maxSpeed=70},
                new Car { Name = "car2",maxSpeed=130},
                new Car { Name = "car3",maxSpeed=140},
                new Car { Name = "car4",maxSpeed=150}};
            var fastcars = from g in cars where g.maxSpeed > 100 && g.maxSpeed < 143 orderby g.Name select g;
            foreach (var car in fastcars)
                Console.WriteLine(car.Name + car.maxSpeed + ";");

            ArrayList cars2 = new ArrayList() {
                new Car { Name = "car1",maxSpeed=70},
                new Car { Name = "car2",maxSpeed=130},
                new Car { Name = "car3",maxSpeed=140,CurrSpeed=70},
                new Car { Name = "car4",maxSpeed=150,CurrSpeed=70},
                new Car { Name = "car5",maxSpeed=110,CurrSpeed=70},
                new Car { Name = "car6",maxSpeed=120,CurrSpeed=70}};
            var carsEnum = cars2.OfType<Car>();
            var fastcars2 = from f in carsEnum
                            where f.maxSpeed > 10 & f.maxSpeed < 150
                            orderby f.maxSpeed
                            select new { f.Name, f.maxSpeed };//select f;
            var fastcarEnum = carsEnum.Where(f => f.maxSpeed > 10 & f.maxSpeed < 150)
                .OrderByDescending(a => a.maxSpeed)
                .Select(a => new { a.Name, a.maxSpeed });
            foreach (var car in fastcars2)
                Console.WriteLine(car.Name + " " + car.maxSpeed + ";");

            var except = (from g in cars select g).Except(from a in carsEnum select a);
            foreach (var car in except)
                Console.WriteLine("except " + car.Name + " " + car.maxSpeed + ";");

            var intersect = (from g in cars select g).Intersect(from a in carsEnum select a);
            foreach (var car in intersect)
                Console.WriteLine("intersect " + car.Name + " " + car.maxSpeed + ";");


            ArrayList myStuff = new ArrayList();
            myStuff.AddRange(new object[] { 1, 2, 4, 3, "as", "ds", 'w', 'e', new Car() });
            var myInts = myStuff.OfType<int>();
            foreach (int i in myInts)
                Console.WriteLine(" OfType " + i + ";");
            int sum = myInts.Sum();
            Console.WriteLine(" sum " + sum + ";");
        }

        private static void PointerMethod()
        {
            unsafe
            {
                int right = 10;
                int* ptr = &right;
                *ptr = 123;
                Console.WriteLine(right);
            }
        }

        private static void AnonymousClassMethod()
        {
            var car = new { Name = "car", Color = "red" };
            var mycar = new { Name = "car", Color = "red" };

            //same Equals
            //not same ==
            //same GetType<> f__AnonymousType0`2
            if (car.Equals(mycar))
                Console.WriteLine("same Equals");
            else
                Console.WriteLine("not same Equals");

            if (car == mycar)
                Console.WriteLine("same ==");
            else
                Console.WriteLine("not same ==");

            if (car.GetType().Name == (mycar.GetType().Name))
                Console.WriteLine("same GetType " + car.GetType().Name);
            else
                Console.WriteLine("not same GetType");
        }

        private static void ExtensionMethod()
        {
            int i = 234;
            int j = i.ReverseDigits();
            Console.WriteLine("Extension Method int reverse is {0} ", j);

            string str = "234";
            str = str.ReverseDigits();
            Console.WriteLine("Extension Method int reverse is {0} ", str);

            char[] charArray = new char[] { '1', '2', 'e', '5' };
            charArray.ReverseDigits();
            Console.WriteLine("Extension Method int reverse is {0} ", charArray.ToStringEx());
        }

        private static void CustomeTypeConverter()
        {
            Rectangle rectangle = new Rectangle(15, 4);

            Square square = (Square)rectangle;
            square.Draw();
            int sqLength = (int)square;
            Console.WriteLine(sqLength);

            rectangle = square;
            rectangle.Draw();
        }

        private static void OperatorOverloadMethod()
        {
            Point point1 = new Point { X = 1, Y = 1 };
            Point point2 = new Point { X = 2, Y = 2 };

            Console.WriteLine("point1 + point2 is {0}", point1 + point2);
            point1 += point2;
            Console.WriteLine("point1 is {0}", point1);
        }

        private static void IndexreMethod()
        {
            PersonCollection personCollection = new PersonCollection();
            personCollection.AddPerson(new Person { Name = "jack", Age = 18 });
            personCollection.AddPerson(new Person { Name = "john", Age = 18 });

            personCollection[0] = new Person { Name = "mary", Age = 12 };
            personCollection[1] = new Person { Name = "harry", Age = 12 };

            foreach (Person p in personCollection)
                Console.WriteLine(p.Name + " " + p.Age);

            personCollection["mary2"] = new Person { Name = "mary2", Age = 22 };

            Console.WriteLine(personCollection["mary2"].Name + " " + personCollection["mary2"].Age);

        }
    }
}
