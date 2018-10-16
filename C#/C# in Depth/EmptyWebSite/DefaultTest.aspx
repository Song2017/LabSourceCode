<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DefaultTest.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Click button Fill Grid add data"></asp:Label>
        </div>
        <asp:GridView ID="gv" runat="server" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:Panel ID="Panel1" runat="server" Height="217px">
            <asp:Calendar ID="Calendar1" runat="server" Height="56px" Width="262px"></asp:Calendar>
            <asp:Label ID="Label2" runat="server" Text="label 1"></asp:Label>
            &nbsp;
            <asp:Label ID="Label3" runat="server" Text="label 2"></asp:Label>
            <input id="Button2" type="button" value="button" />
        </asp:Panel>
        <br />


        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true" Width="1127px"></asp:TextBox>


        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Fill Grid" />
    </form>
</body>
</html>
