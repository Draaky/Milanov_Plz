<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="Milanov.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                        <table> <!-- of div class="collom" -->
                            <tr> <!--<div class="name"> -->
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
                                <td>URL:</td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_URL" Mode="Insert" />
                                </tr>
                            </tr>
                            <tr>
                                <td>PRODUCT_SMALL_URL:</td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_SMALL_URL" Mode="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td>PRODUCT_WATER_URL:</td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_WATER_URL" Mode="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td>PRODUCT_PRICE:</td>
                                <td>
                                    <asp:DynamicControl runat="server" ValidationGroup="FormViewMessageGroup" DataField="PRODUCT_PRICE" Mode="Insert" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="FormViewMessageGroup" CommandName="Insert" />
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CausesValidation="false" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </InsertItemTemplate>
            </asp:FormView>

            

            <asp:ListView ID="ListViewMessage" runat="server"
                DataKeyNames="PRODUCT_ID"
                ItemType="Milanov.Products"
                SelectMethod="ListViewMessage_GetData"
                UpdateMethod="ListViewMessage_UpdateItem" 
                DeleteMethod="ListViewMessage_DeleteItem"   
            >
                <LayoutTemplate>
                    <table class="listViewTable">
                        <tr>
                            <td>NAME</td>
                            <td>TEXT</td>
                            <td>URL </td>
                            <td>SMALL_URL</td>
                            <td>WATER_URL</td>
                            <td>PRICE</td>
                        </tr>
                        <tr id="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                            
                            <td><%#: Item.PRODUCT_NAME %></td>
                            <td><%#: Item.PRODUCT_TEXT %></td>
                            <td><%#: Item.PRODUCT_URL %></td>
                            <td><%#: Item.PRODUCT_SMALL_URL %></td>
                            <td><%#: Item.PRODUCT_WATER_URL %></td>
                            <td><%#: Item.PRODUCT_PRICE %></td>
                        <td>
                            <asp:Button ID="btnEditMessage" CommandName="Edit" runat="server" Text="Edit" />
                            <asp:Button ID="btnDeleteMessage" CommandName="Delete" runat="server" Text="Delete" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:DynamicControl runat="server" ValidationGroup="listViewMessageGroup" DataField="PRODUCT_NAME" Mode="Insert" />
                        </td>
                        <td>
                            <asp:DynamicControl runat="server" ValidationGroup="listViewMessageGroup" DataField="PRODUCT_TEXT" Mode="Insert" /></td>
                        
                        <td>
                            <asp:DynamicControl runat="server" ValidationGroup="listViewMessageGroup" DataField="PRODUCT_PRICE" Mode="Insert" /></td>
                        <td>
                            <asp:Button ID="Update" CommandName="Update" runat="server" Text="Update" ValidationGroup="listViewMessageGroup" />
                            <asp:Button CommandName="Cancel" Text="Cancel" runat="server" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>

</asp:Content>
