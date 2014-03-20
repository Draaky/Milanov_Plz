<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Milanov.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="js/jquery-1.10.2.min.js"></script>
    <script src="js/lightbox-2.6.min.js"></script>
    <link href="css/lightbox.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FormView ID="FormViewMessage" runat="server"
                ItemType="Milanov.Products"
                DataKeyNames="PRODUCT_ID"
                InsertMethod="FormViewMessage_InsertItem"
                DefaultMode="Insert" EnableModelValidation="true">
                <InsertItemTemplate>
                    <fieldset>
                        <legend>Add Product:</legend>
                        <table>
                            <tr> 
                                <td>NAME:</td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_NAME" Mode="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td>TEXT:    
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_TEXT" Mode="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td>Upload image:</td>
                                <td>
                                    <asp:FileUpload ID="ImageUpload" runat="server" />
                                </tr>
                            </tr>
                            <tr>
                                <td>PRICE:    
                                </td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_PRICE" Mode="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="FormViewMessageGroup" CommandName="Insert" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
                                    <br /> 
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>  
    <br />
    <br />
            <asp:ListView ID="ListViewMessage" runat="server"
                DataKeyNames="PRODUCT_ID"
                ItemType="Milanov.Products"
                SelectMethod="ListViewMessage_GetData"
                UpdateMethod="ListViewMessage_UpdateItem" 
                DeleteMethod="ListViewMessage_DeleteItem"   
            >
                <ItemTemplate>
                   
                    <div class="product">
                            <div class="name"><%#: Item.PRODUCT_NAME %></div>
                            <div class="description"><%#: Item.PRODUCT_TEXT %></div>
                            <div class="link"><%#: Item.PRODUCT_URL %></div>
                            <div class="thumbnail">
                                <a href="<%#: Item.PRODUCT_WATER_URL %>" data-lightbox="image-1" title="<%#: Item.PRODUCT_NAME %>">
                                    <img alt="Thumbnail" src="<%#: Item.PRODUCT_SMALL_URL %>" />
                                </a>
                            </div>
                            <div class="link"><%#: Item.PRODUCT_WATER_URL %></div>
                            <div class="price">Price: &euro; <%#: Item.PRODUCT_PRICE %></div>
                            <div id="buttons">
                                <asp:Button ID="Button1" CommandName="Edit" runat="server" Text="Edit" />
                                <asp:Button ID="Button2" CommandName="Delete" runat="server" Text="Delete" />
                            </div>
                        </div>

                </ItemTemplate>
                <EditItemTemplate>

                    <div class="product">
                            <div class="name">
                                <asp:DynamicControl runat="server" ValidationGroup="listViewMessageGroup" DataField="PRODUCT_NAME" Mode="Insert" />

                            </div>
                            <div class="description">
                                <asp:DynamicControl runat="server" ValidationGroup="listViewMessageGroup" DataField="PRODUCT_TEXT" Mode="Insert" />

                            </div>
                            <div class="link">
                                <%#: Item.PRODUCT_SMALL_URL %>

                            </div>
                            <div class="thumbnail">
                                <img alt="Thumbnail" src="<%#: Item.PRODUCT_SMALL_URL %>" />

                            </div>
                            <div class="watermark">
                                <%#: Item.PRODUCT_WATER_URL %>

                            </div>
                            <div class="price">
                                Price: &euro; <asp:DynamicControl runat="server" ValidationGroup="listViewMessageGroup" DataField="PRODUCT_PRICE" Mode="Insert" /> 

                            </div>
                            <div id="buttons">
                                <asp:Button ID="Button3" CommandName="Update" runat="server" Text="Update" ValidationGroup="listViewMessageGroup" />
                                <asp:Button CommandName="Cancel" Text="Cancel" runat="server" />
                            </div>
                        </div>
                </EditItemTemplate>
            </asp:ListView>


</asp:Content>
