using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using CommonSnappableTypes;

namespace CSharpSnapIn
{

    [CompanyInfoAttribute(CompanyName ="My Company", CompanyUrl = "www.mycompany.com")]
    public class CSharpSnapIn : IAppFunctionality
    {
        public void DoIt()
        {
            MessageBox.Show("you have just the c# snap-in !");
        }
    }
}
