using System.Windows.Forms;

namespace ConsoleApp
{
    public delegate int BinaryOP(int x, int y);

    public delegate string MyDelegate(out bool a, ref bool b, int c);


    public class DelegateClass
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public static int Add2(int x, int y)
        {
            return x + y;
        }

        public void Add3(int x, int y)
        {
            MessageBox.Show(string.Format(x + " + " + y + " = " + (x + y)));
        }

        public DelegateClass() { }
    }
}