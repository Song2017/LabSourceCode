using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AccountWithSQL
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-Hans");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    if (!login.Result.Equals("OK"))
                        return;
                    Application.Run(new FormAccountSQLite());
                }
            };



        }
    }
}
