<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewOrderInDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Order.OrderIn.NewOrderInDetailPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:label runat="server"><strong>Full Name:</strong></asp:label>
                    
                </td>
                <td>
                    <asp:Label runat="server" ID="supplierNamelbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="SelectedBookInGV" runat="server" AutoGenerateColumns="False" Width="462px">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                            <asp:BoundField HeaderText="Title" DataField="Title" />
                            <asp:BoundField HeaderText="Price" DataField="BookPrice" DataFormatString="{0:0.00}" />
                            <asp:BoundField HeaderText="Quantity" DataField="Quantity"/>
                            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:0.00}" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label runat="server" ID="totallbl"></asp:Label>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="CancelOrderbtn" Text="Cancel Order" OnClick="CancelOrderbtn_Click" />
                    <asp:Button runat="server" ID="saveOrderbtn" Text="Create Order" OnClick="saveOrderbtn_Click"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label runat="server" ID="orderNumberlbl" Visible="true"></asp:Label>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>

