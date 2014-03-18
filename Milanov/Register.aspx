<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Milanov.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
    <asp:Label ID="Label3" runat="server" Text="Retype Password:"></asp:Label>
    <br />
    <asp:TextBox ID="txt_PasswordCheck" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <asp:Label ID="Label4" runat="server" ForeColor="Red" Text="*Password required" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:Button ID="txt_Register" runat="server" Text="Register" Width="90px" OnClick="txt_Register_Click" />
    
</asp:Content>
