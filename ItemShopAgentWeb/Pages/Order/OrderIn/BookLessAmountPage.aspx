<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="BookLessAmountPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Order.OrderIn.BookLessAmountPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Button runat="server" ID="firstTopbtn" Text="First" OnClick="firstTopbtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="previousTopbtn" Text="Previous" OnClick="previousTopbtn_Click" /></td>
                <td>
                    <asp:Label runat="server" ID="indexToplbl"></asp:Label></td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="of"></asp:Label></td>
                <td>
                    <asp:Label ID="PagesTop" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextTopbtn" Text="Next" OnClick="nextTopbtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastTopbtn" Text="Last" OnClick="lastTopbtn_Click" /></td>
            </tr>
        </tbody>
    </table>
    <asp:GridView ID="SelectedBookInGV" runat="server" AutoGenerateColumns="False" Width="961px" OnRowCommand="SelectedBookInGV_RowCommand" OnRowDeleting="SelectedBookInGV_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
            <asp:BoundField HeaderText="Title" DataField="Title" />
            <asp:BoundField HeaderText="Price" DataField="BookPrice" DataFormatString="{0:0.00}" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Button runat="server" ID="firstBottombtn" Text="First" OnClick="firstBottombtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="previousBottompbtn" Text="Previous" OnClick="previousBottompbtn_Click" /></td>
                <td>
                    <asp:Label runat="server" ID="indexBottomlbl"></asp:Label></td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="of"></asp:Label></td>
                <td>
                    <asp:Label ID="Pagesbottom" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextBottombtn" Text="Next" OnClick="nextBottombtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastBottombtn" Text="Last" OnClick="lastBottombtn_Click" /></td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td>
                    <asp:Button runat="server" Text="Cancel Order" ID="cancelorderbtn" OnClick="cancelorderbtn_Click"/>
                </td>
                <td>
                    <asp:Button runat="server" Text="Create Order" ID="createOrderbtn" OnClick="createOrderbtn_Click"/>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


