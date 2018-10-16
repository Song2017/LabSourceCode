<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BuildCar.aspx.cs" Inherits="BuildCar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <p>
        <br />
        <asp:Label ID="LabelOrder" runat="server" Text="Build a car"></asp:Label>
    </p>
    <p>
        <asp:Wizard ID="Wizard1" runat="server" Width="669px" OnFinishButtonClick="Wizard1_FinishButtonClick">
            <WizardSteps>
                <asp:WizardStep ID="step1" runat="server" Title="Pick Your Model">
                    <asp:TextBox ID="TextBox1" runat="server">default model</asp:TextBox>
                </asp:WizardStep>
                <asp:WizardStep ID="step2" runat="server" Title="Pick Your Color">
                    <asp:ListBox ID="ListBox1" runat="server" Width="237px">
                        <asp:ListItem>purple</asp:ListItem>
                        <asp:ListItem>green</asp:ListItem>
                        <asp:ListItem>red</asp:ListItem>
                        <asp:ListItem>yellow</asp:ListItem>
                        <asp:ListItem>white</asp:ListItem>
                        <asp:ListItem>black</asp:ListItem>
                    </asp:ListBox>
                </asp:WizardStep>
                <asp:WizardStep ID="step3" runat="server" Title="Name Your Car">
                    <asp:TextBox ID="TextBox2" runat="server">default name</asp:TextBox>
                </asp:WizardStep>
                <asp:WizardStep ID="step4" runat="server" Title="Delivery Date">
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </asp:WizardStep>
            </WizardSteps>
        </asp:Wizard>
    </p>
    <p>
    </p>
    <p>
    </p>
</asp:Content>

