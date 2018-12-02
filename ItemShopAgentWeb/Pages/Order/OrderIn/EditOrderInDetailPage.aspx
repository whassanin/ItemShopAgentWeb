<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditOrderInDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Order.OrderIn.EditOrderInDetailPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <label><strong>Order In Id:</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="OrderInlbl"></asp:Label>
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
                    <label><strong>Supplier Name:</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="SupplierNamelbl"></asp:Label>
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
    <asp:GridView runat="server" ID="OrderDetailGV" AutoGenerateColumns="False" Width="600px" OnRowCommand="OrderDetailGV_RowCommand" OnRowDataBound="OrderDetailGV_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" HeaderStyle-Width="50px">
                <HeaderStyle Width="50px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="BookId" DataField="BookId" Visible="false" HeaderStyle-Width="50px">
                <HeaderStyle Width="50px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Title" DataField="Title" HeaderStyle-Width="250px">
                <HeaderStyle Width="250px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Price" DataField="Price" HeaderStyle-Width="50px" DataFormatString="{0:0.00}">
                <HeaderStyle Width="50px"></HeaderStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label runat="server" ID="Quantitylbl" Text='<%#Eval("Quantity") %>' Visible="false"></asp:Label>
                    <asp:DropDownList runat="server" ID="QuantityDDL" AutoPostBack="true" OnSelectedIndexChanged="QuantityDDL_SelectedIndexChanged">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Total" DataField="Total" HeaderStyle-Width="100px" DataFormatString="{0:0.00}">
                <HeaderStyle Width="100px"></HeaderStyle>
            </asp:BoundField>
            <asp:ButtonField Text="Delete" CommandName="Delete" />
            <asp:ButtonField Text="Update" CommandName="Update" />
        </Columns>
    </asp:GridView>
    <br />
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


