using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Inventory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dataTable = new DataTable("default");
        dataTable.Columns.Add("id");
        dataTable.Columns.Add("name");
        dataTable.Rows.Add(new object[] { 1, "name1" });
        dataTable.Rows.Add(new object[] { 2, "name2" });
        GridView1.DataSource = dataTable;
        GridView1.DataBind();

    }
}