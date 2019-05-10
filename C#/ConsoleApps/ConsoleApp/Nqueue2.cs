using System;

namespace ConsoleApp
{
    class Nqueue2
    {
        static int n;    //皇后个数
        static int[] x;  //当前解
        static long sum; //当前已找到的可行方案数
        public static long nQueen2(int nn)
        {
            n = nn;
            sum = 0;
            x = new int[n + 1];
            for (int i = 0; i <= n; i++)
                x[i] = 0;
            backtrack();
            return sum;
        }
        private static bool place(int t)
        {
            for (int i = 1; i < t; i++)
                if ((Math.Abs(t - i) == Math.Abs(x[t] - x[i])) || (x[i] == x[t]))
                    return false;
            return true;
        }
        private static void backtrack()
        {
            int k = 1; //第一行
            while (k > 0)
            {
                //若出现第一个可行解,即此时k=n,
                //需要把最后一行确定的列坐标+1,避免出现一个解就死循环当前解
                x[k] += 1;
                while ((x[k] <= n) && (!place(k)))
                    x[k] += 1;  //列数+1
                if (x[k] <= n)
                {
                    if (k == n)
                        sum++;
                    else
                    {
                        k++;       //向下一行扫描
                        x[k] = 0;  //下一行的确定列初始为"0"
                    }
                }
                else
                    k--; //回溯到上一行,排列树中则回溯到父节点
            }
        }
    }
}
