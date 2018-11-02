<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewOrderOutDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Order.OrderOut.NewOrderOutDetialPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td colspan="2">
                    <label><strong>Customer Information</strong></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>First Name:</label>
                </td>
                <td>
                    <asp:Label runat="server" ID="firstNamelbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Last Name:</label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lastNamelbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Middle Name:</label>
                </td>
                <td>
                    <asp:Label runat="server" ID="MiddleNamelbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label><strong>Selected Books</strong></label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="SelectedBookOutGV" runat="server" AutoGenerateColumns="False" Width="611px">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                            <asp:BoundField HeaderText="Title" DataField="Title" />
                            <asp:BoundField HeaderText="Quantity" DataField="Quantity" HeaderStyle-Width="100px">
                                <HeaderStyle Width="100px"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Price" DataField="BookPrice" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount" Visible="false" />
                            <asp:BoundField HeaderText="Total" DataField="Total" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <strong>
                        <asp:Label runat="server" Text="Total: " ID="totallbl"></asp:Label></strong>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="cancelOrderbtn" Text="Cancel Order" OnClick="cancelOrderbtn_Click" />
                    <asp:Button runat="server" ID="continueOrderbtn" Text="Continue Order" OnClick="continueOrderbtn_Click" />
                    <asp:Button runat="server" ID="ConfirmOrderbtn" Text="Save Order" OnClick="ConfirmOrderbtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


