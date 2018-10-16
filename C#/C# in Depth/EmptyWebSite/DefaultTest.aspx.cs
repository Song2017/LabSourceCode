using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AppCode appCode = new AppCode();

        ControlsMethod();
        Cache.Count.ToString();
        Cache["key"] = "value";
        ClientTarget.ToString();
        Page.IsPostBack.ToString();
        Page.IsCallback.ToString();
        Request.Browser.Type.ToString();
        Request.Form.ToString();
        Request.QueryString.ToString();

        Button1.BackColor = Color.Cyan;
        System.Web.UI.WebControls.WebControl webControl = new System.Web.UI.WebControls.WebControl(HtmlTextWriterTag.Base);
    }

    private void ControlsMethod()
    {
        string strTemp = string.Empty;
        foreach (Control c in Panel1.Controls)
            if (ReferenceEquals(c.GetType(), typeof(Label)))
            {
                Label label = c as Label;
                strTemp += $"contrl name is {label.Text.ToString()};";
            }

        TextBox1.Text = strTemp;
    }

    protected void Page_Error(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Write("the page you requested is not exists..");
        Response.Write($"{ Server.GetLastError().ToString()}");
        //Server.ClearError();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable t = new DataTable("test");
        t.Columns.Add("ID");
        t.Columns.Add("Name");
        DataRow dataRow = t.NewRow();
        dataRow[0] = 1;
        dataRow[1] = "jack";
        t.Rows.Add(dataRow);
        DataRow dataRow2 = t.NewRow();
        dataRow2[0] = 2;
        dataRow2[1] = "marray";
        t.Rows.Add(dataRow2);

        gv.DataSource = t;
        gv.DataBind();

        Response.Write("this is write by response");
        //Response.Redirect("http://www.baidu.com");
        Response.Output.ToString();
    }

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Button1.ForeColor = Color.OrangeRed;
    }
}