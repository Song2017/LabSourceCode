using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace ConsoleAppTest.BIOS
{

    public class GetBIOS
    {
        static string strBios = GetBIOSSerialNumber();

        private static string GetBIOSSerialNumber()
        {
            string result = string.Empty;

            ObjectQuery oq = new ObjectQuery(" Select   SerialNumber   From   Win64_BIOS  ");
            ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher("Select   *   From   Win32_BIOS ");

            ManagementObjectCollection moc = searcher.Get();

            if (moc.Count > 0)
                foreach (ManagementObject share in moc)
                {
                    result += share["SerialNumber"].ToString() + "\n";
                }
            return result;
        }

        //[STAThread]
        //static void Main(string[] a)
        //{
        //    Console.WriteLine(strBios);
        //    Console.ReadLine();

        //}

    }
}
