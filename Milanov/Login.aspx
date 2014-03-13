<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Milanov.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:Label ID="lbl_CheckLogin" runat="server" Text="Login Status"></asp:Label>
    <br />
    <br />



    <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
    <br />
    <asp:TextBox ID="txt_Username" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_Username" runat="server" ForeColor="Red" Text="*Username required" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
    <br />
    <asp:TextBox ID="txt_Password" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="lbl_Password" runat="server" ForeColor="Red" Text="*Password required" Visible="False"></asp:Label>
    <br />
    <asp:Label ID="lbl_UsernamePassword" runat="server" ForeColor="Red" Text="*Invalid username or password"></asp:Label>
    <br />
    <br />
    <asp:Button ID="btn_Login" runat="server" Text="Login" Width="90px" OnClick="btn_Login_Click" />
    <asp:Button ID="btn_Register" runat="server" Text="Register" Width="90px" />
    <br />

    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

</asp:Content>
