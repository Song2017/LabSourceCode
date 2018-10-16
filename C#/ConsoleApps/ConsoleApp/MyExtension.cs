using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    static class MyExtension
    {
        public static int ReverseDigits(this int i)
        {
            char[] digits = i.ToString().ToCharArray();

            int begin = 0;
            int end = digits.Length - 1;
            char flag;

            while (begin < end)
            {
                flag = digits[end];
                digits[end] = digits[begin];
                digits[begin] = flag;
                begin++;
                end--;
            }

            return Int32.Parse(new string(digits));
        }

        public static string ReverseDigits(this string i)
        {


            char[] digits = i.ToCharArray();

            int begin = 0;
            int end = digits.Length - 1;
            char flag;

            while (begin < end)
            {
                flag = digits[end];
                digits[end] = digits[begin];
                digits[begin] = flag;
                begin++;
                end--;
            }

            return new string(digits);

        }

        public static char[] ReverseDigits(this char[] digits)
        {
            //char[] digits = i;

            int begin = 0;
            int end = digits.Length - 1;
            char flag;

            while (begin < end)
            {
                flag = digits[end];
                digits[end] = digits[begin];
                digits[begin] = flag;
                begin++;
                end--;
            }

            return digits;



        }


        public static string ToStringEx(this char[] digits)
        {
            string str = string.Empty;
            if (digits == null)
                return str;

            foreach (char digit in digits)
                str += digit;

            return str;
        }

        public static string ToStringEx<T>(this T digits)
        {
            string str = string.Empty;
            if (digits == null)
                return str; 
             
            return str;

        }
    }
}
