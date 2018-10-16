using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BuildCar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        string _temp;
        _temp = $"{TextBox1.Text.ToString()},{ListBox1.SelectedValue.ToString()},{TextBox2.Text.ToString()}" +
            $",{Calendar1.SelectedDate.ToLongTimeString()}";
        LabelOrder.Text = _temp;
    }
}