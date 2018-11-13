<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditOrderOutDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.EditOrderOutDetailPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <label><strong>Order out Id:</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="OrderOutlbl"></asp:Label>
                </td>
                <td>
                    <label><strong>Order Date:</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="OrderDatalbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label><strong>Total:</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Totallbl"></asp:Label>
                </td>
                <td>
                    <label><strong>Paid:</strong><asp:Label runat="server" ID="Paidlbl"></asp:Label></label>
                </td>
                <td>
                    <label><strong>Change:</strong><asp:Label runat="server" ID="Changelbl"></asp:Label></label>
                </td>
            </tr>
            <tr>
                <td>
                    <label><strong>Credit Card Number</strong></label>
                </td>
                <td colspan="3">
                    <asp:Label runat="server" ID="CreditCardNumberlbl"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label><strong>Holder</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="Holderlbl"></asp:Label>
                </td>
                <td>
                    <label><strong>Payment Type</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="PaymentType"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <label><strong>First Name:</strong><asp:Label runat="server" ID="FirstNamelbl"></asp:Label></label>
                </td>
                <td>
                    <label><strong>Last Name:</strong><asp:Label runat="server" ID="LastNamelbl"></asp:Label></label>
                </td>
                <td>
                    <label><strong>Middle Name:</strong><asp:Label runat="server" ID="MiddleNamelbl"></asp:Label></label>
                </td>
            </tr>
        </tbody>
    </table>
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
    <asp:GridView runat="server" ID="OrderDetailGV" AutoGenerateColumns="False" Width="1000px" OnRowCommand="OrderDetailGV_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-Width="50px" />
            <asp:BoundField HeaderText="BookId" DataField="BookId" Visible="false" HeaderStyle-Width="50px" />
            <asp:BoundField HeaderText="Title" DataField="Title" HeaderStyle-Width="500px" />
            <asp:BoundField HeaderText="Price" DataField="Price" HeaderStyle-Width="50px" DataFormatString="{0:0.00}" />
            <asp:BoundField HeaderText="Quantity" DataField="Quantity" HeaderStyle-Width="100px" />
            <asp:BoundField HeaderText="Total" DataField="Total" HeaderStyle-Width="100px" DataFormatString="{0:0.00}"/>
            <asp:BoundField HeaderText="Return" DataField="Return" HeaderStyle-Width="100px" />
            <asp:ButtonField Text="Inc" CommandName="Inc" Visible="false" HeaderStyle-Width="100px"/>
            <asp:ButtonField Text="Dec" CommandName="Dec" Visible="false" HeaderStyle-Width="100px"/>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button runat="server" ID="ReturnItembtn" Text="Return Item"  OnClick="ReturnItembtn_Click"/>
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
    </table>
</asp:Content>

