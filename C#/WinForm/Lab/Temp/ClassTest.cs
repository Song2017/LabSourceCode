using System;

namespace Temp
{
    public class ClassTest
    {
        private int testcount = Person.coint + Person.stint;
        private Person teseperson = new Person();

        public int itest;

        int yield = 90;

        public void test()
        {
            Person.stint = 15;
            //Person.coint = 12;

            Person p = new Person();
            p = new Person("asdf");
            p.count();

            Console.WriteLine(p.reint);
            Console.WriteLine(Person.coint);
            Console.WriteLine(Person.stint);
        }

        public System.Collections.Generic.IEnumerable<int> showEnum()
        {
            Console.WriteLine("yield return");
            for (int i = 0; i < 5; i++)
                yield return i;

            yield return 11;
            yield return 12;

        }

        public int showNum()
        {

            Console.WriteLine("return");
            for (int i = 0; i < 5; i++)
                return i;

            return 0;
        }
    }





}
