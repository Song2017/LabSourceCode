using System;

namespace ConsoleAppTest.Attribute_Reflection
{
    [AttributeTest(1, "Song", "2016.7.12", Message = "AttributeClass")]
    public class AttributeClass
    {
        protected double length;
        protected double width;
        public AttributeClass(double l, double w)
        {
            this.length = l;
            this.width = w;
        }
        [AttributeTest(2, "Song", "2016.7.12", Message = "GetArea")]
        public double GetArea()
        {
            return length * width;
        }

        [AttributeTest(3, "Song", "2016.7.12", Message = "display")]
        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }
}
