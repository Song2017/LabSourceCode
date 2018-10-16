using System;

namespace ConsoleApp
{
    struct Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle(int v1, int v2) : this()
        {
            this.Width = v1;
            this.Height = v2;
        }

        public void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }
        }
        public static implicit operator Rectangle(Square square)
        {
            return new Rectangle { Height = square.Length, Width = 2 * square.Length };
        }
    }

 
    struct Square
    {
        public int Length { get; set; }

        public Square(int v1, int v2) : this()
        {
            this.Length = v1;
        }
        public void Draw()
        {
            for (int i = 0; i < Length; i++)
            {
                for (int j = 0; j < Length; j++)
                    Console.Write("* ");
                Console.WriteLine();
            }
        }

        public static explicit operator Square(Rectangle rectangle)
        {
            Square square = new Square { Length = rectangle.Width < rectangle.Height ? rectangle.Width : rectangle.Height };
            return square;
        }
        public static explicit operator int(Square square)
        {
            return square.Length;
        }
    }
}