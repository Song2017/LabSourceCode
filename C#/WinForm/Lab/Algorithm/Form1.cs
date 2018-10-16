using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            List<int> liOut;
            //数组移位
            this.btnShift.Click += delegate
            {
                int[] aryInput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                int intShift = int.Parse(txtOffset.Text.ToString());
                liOut = ArrayShift(aryInput, intShift > 0 ? true : false, Math.Abs(intShift));
                if (liOut != null)
                    txtShiftOut.Text = GetStringFromList(liOut);
            };


            //字符串取数 
            this.btnGetNum.Click += delegate
            {
                string str = this.txtInput.Text.ToString();
                liOut = GetIntArrayFromString(str);

                if (liOut != null)
                    txtOutput.Text = GetStringFromList(liOut);
            };

            //testPointer();
        }

        //数组移位
        private List<int> ArrayShift(int[] aryInput, bool? isPt, int intShift)
        {
            int[] aryOut = new int[9];
            if (aryInput == null || isPt == null || intShift > aryInput.Length)
                return aryOut.ToList();  

            if (isPt??true)
                for (int i = 0; i < aryOut.Length - intShift; i++)
                    aryOut[intShift + i] = aryInput[i];
            else//反向取数
                for (int i = 0; i < aryOut.Length - intShift; i++)
                    aryOut[aryOut.Length - intShift - i - 1] = aryInput[aryOut.Length - i - 1];


            return aryOut.ToList();
        }

        //队列拼串
        private string GetStringFromList(List<int> liOut)
        {
            string strOut = string.Empty;
            if (liOut == null)
                return strOut;

            foreach (int i in liOut)
                strOut += i.ToString() + ',';

            return strOut.Length > 1 ? strOut.TrimEnd(',') : strOut;
        }

        //字符串中取数字
        private List<int> GetIntArrayFromString(string strSource)
        {
            if (strSource == null || strSource.Length <= 0)
                return null;

            char[] arySource = strSource.ToArray();
            List<int> list = new List<int>();

            string tmp = string.Empty;
            for (int i = 0; i < arySource.Length; i++)
            {
                //数字进行拼串
                if (char.IsDigit(arySource[i]))
                {
                    tmp = tmp + arySource[i].ToString();
                    if (i == arySource.Length - 1)
                        list.Add(int.Parse(tmp));
                }//非数字且前一位为数字添加List
                else if (i - 1 > 0 && char.IsDigit(arySource[i - 1]))
                {
                    list.Add(int.Parse(tmp));
                    tmp = string.Empty;
                }
            }
            //list.ToArray();
            return list;
        }


        private unsafe void testPointer()
        {
            int i = 10;
            int* ptr = &i;
        }
    }
}
