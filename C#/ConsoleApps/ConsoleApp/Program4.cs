using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace ConsoleApp
{
    class Program4
    {
        //test: force push after merge PR
        static void Main4(string[] args)
        {
            Console.WriteLine("begin test"); Console.ReadLine();

            CollectionMethods();

            DelegateMethod();

            EventMethod();

            LambdaMethod();
            Console.ReadLine();
        }

        private static void LambdaMethod()
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 12, 3, 4, 5, 7 });

            List<int> evenNumbers = list.FindAll(delegate (int e) { return e % 2 == 0; });
            List<int> evenNumbers2 = list.FindAll(e => e % 2 == 0);

            foreach (int e in evenNumbers2)
                Console.WriteLine(e);
        }

        private static void EventMethod()
        {
            Car car = new Car { CurrSpeed = 10, maxSpeed = 100, carIsDead = false };

            //this.listOfhandlers => OnCarEngineEvent
            car.Exploded += OnCarEngineEvent;
            car.Exploded += OnCarEngineEvent2;
            car.AbouttoBlow += OnCarEngineEvent;

            car.ExplodedEvent += delegate (object sender, CarEventArgs e)
            {
                Console.WriteLine("object is {0}, careventargs is {1}", sender, e.msg);
            };
            car.ExplodedEvent += (sender, e) =>
            {
                Console.WriteLine("object is {0}, careventargs is {1}", sender, e.msg);
                Console.WriteLine("object2 is {0}, car2 eventargs is {1}", sender, e.msg);
            };

            //Accelerate => OnCarEngineEvent
            for (int i = 0; i < 6; i++)
                car.AccelerateEvent(20);
        }
         
        static void OnCarEngineEvent2(string msg)
        {
            Console.WriteLine("Car object say2 : {0}", msg);
        }
        static void OnCarEngineEvent(string msg)
        {
            Console.WriteLine("Car object say : {0}", msg);
        }
        private static void DisplayDelegateInfo(Delegate delobj)
        {
            foreach (Delegate d in delobj.GetInvocationList())
            {
                Console.WriteLine("method name is {0}", d.Method);
                Console.WriteLine("target is {0}", d.Target);
            }
        }

        private static void DelegateMethod()
        {
            DelegateClass dg = new DelegateClass();

            BinaryOP binaryOP = new BinaryOP(dg.Add);
            BinaryOP binaryOP2 = new BinaryOP(DelegateClass.Add2);
            DisplayDelegateInfo(binaryOP);
            DisplayDelegateInfo(binaryOP2);

            Console.WriteLine("the sum is " + binaryOP.Invoke(1, 2));
            Console.WriteLine("the sum is " + binaryOP2(1, 2));
            //public delegate int BinaryOP(int x, int y);

            Car car = new Car { CurrSpeed = 10, maxSpeed = 100, carIsDead = false };

            //this.listOfhandlers => OnCarEngineEvent
            car.RegisterCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));
            car.RegisterCarEngine(OnCarEngineEvent);
            //Accelerate => OnCarEngineEvent
            for (int i = 0; i < 6; i++)
                car.Accelerate(20);

            //action func
            Action<string, string, int> action = new Action<string, string, int>(DisplayAction);
            action(" action", " message", 2);
            //func
            Func<string, string, string> func = new Func<string, string, string>(DisplayFunc);
            Console.WriteLine("func is {0}", func(" func", " message"));
        }

        private static void DisplayAction(string v1, string v2, int v3)
        {
            Console.WriteLine("DisplayAction" + v1 + v2 + v3);
        }

        private static string DisplayFunc(string v1, string v2)
        {
            return "DisplayFunc" + v1 + v2;
        }



        private static void CollectionMethods()
        {
            ObservableCollection<Person> person1 = new ObservableCollection<Person>
            {
                new Person{Name="jack",Age=10 },
                new Person{Name="mary",Age=12 },
            };
            person1.CollectionChanged += delegate (object sender, NotifyCollectionChangedEventArgs e)
            {
                MessageBox.Show("observablecollection changed, {0}" + person1[0].Name);
            };
            person1[0].Name = "jack2";//useless
            person1.Add(new Person { Name = "jeff" });

        }




    }

}
