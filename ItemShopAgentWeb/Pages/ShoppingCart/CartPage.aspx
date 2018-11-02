<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CartPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.CartPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="ShoppingCartBookGV" runat="server" DataKeyNames="Id,BookId,Quantity,Price" AutoGenerateColumns="False" Width="961px" OnRowCommand="ShoppingCartBookGV_RowCommand" OnRowDeleting="ShoppingCartBookGV_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
            <asp:BoundField HeaderText="Book" DataField="Title" />
            <asp:BoundField HeaderText="BookId" DataField="BookId" Visible="false" />
            <asp:BoundField HeaderText="ShoppingCartId" DataField="ShoppingCartId" Visible="false" />
            <asp:BoundField HeaderText="Quantity" DataField="Quantity" HeaderStyle-Width="100px">
                <HeaderStyle Width="100px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Price" DataField="Price" />
            <asp:BoundField HeaderText="Amount" DataField="Amount" Visible="false" />
            <asp:BoundField HeaderText="Total" DataField="Total" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:ButtonField CommandName="Inc" Text="Inc." />
            <asp:ButtonField CommandName="Dec" Text="Dec." />
        </Columns>
    </asp:GridView>
    <br />
    <table>
        <tbody>
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server">Total:</asp:Label>
                    <asp:Label ID="totaltxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ContinueShoppingbtn" Text="Continue Shopping" runat="server" OnClick="ContinueShoppingbtn_Click"></asp:Button>
                </td>
                <td>
                    <asp:Button ID="ArrangeDeliverybtn" Text="Arrange Delivery" runat="server" OnClick="ArrangeDeliverybtn_Click"></asp:Button>
                </td>
            </tr>
        </tbody>
    </table>


</asp:Content>


