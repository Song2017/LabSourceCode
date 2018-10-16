namespace ConsoleApp
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class BasicMath<T>
    {
        // Operator '+' cannot be applied to operands of type 'T' and 'T'	 
        //public T Add(T a1, T a2) => a1 + a2;
    }
}