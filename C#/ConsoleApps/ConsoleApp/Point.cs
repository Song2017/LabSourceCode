namespace ConsoleApp
{
    internal class Point
    {

        public int X { get; set; }
        public int Y { get; set; }

        public Point()
        {
        }

        public T Generator<T>(T t)
        {
            return t;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", X, Y);
        }

        // operator 'Point.operator +(Point, Point)' must be declared static and public  
        public static Point operator +(Point p1, Point p2)
        {
            return new Point { X = p1.X + p2.X, Y = p1.Y + p2.Y };
        }

        public static Point operator -(Point p1, Point p2)
        {
            return new Point { X = p1.X - p2.X, Y = p1.Y - p2.Y };
        }
    }
}