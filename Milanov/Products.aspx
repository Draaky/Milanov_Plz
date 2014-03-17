<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Milanov.Products1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Products</h1>

    <asp:ListView ID="ListViewMessage" runat="server"
    DataKeyNames="PRODUCT_ID"
    ItemType="Milanov.Products"
    SelectMethod="ListViewMessage_GetData" >
                
        <ItemTemplate>
            <div class="product">
                <div class="name"><%#: Item.PRODUCT_NAME %></div>
                <div class="description"><%#: Item.PRODUCT_TEXT %></div>
                <div class="thumbnail"><%#: Item.PRODUCT_SMALL_URL %></div>
                <div class="watermark"><%#: Item.PRODUCT_WATER_URL %></div>
                <div class="price"><%#: Item.PRODUCT_PRICE %></div>
            </div>                
                    
        </ItemTemplate>
    </asp:ListView>
        <div>
            <p>
                Please Select an Image file:    
            <asp:FileUpload ID="FUP_Image" runat="server" />
            </p>

            <p>
            <asp:Button ID="btnUpload" runat="server" Text="Upload Image" onclick="btnUpload_Click" />
            </p>

            <p>
            <asp:Image ID="imgUploadedImage" runat="server" Width="250" 
               Height="250" BorderColor="Black" BorderStyle="Solid" BorderWidth="1" EnableViewState="False" Visible="False" />
            </p>
        </div>
</asp:Content>
