<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchBookPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.BookPages.SearchBookPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Search by:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="searchOptionDDL" Width="100px" Height="40px">
                        <asp:ListItem>Title</asp:ListItem>
                        <asp:ListItem>ISBN</asp:ListItem>
                        <asp:ListItem>EditionNumber</asp:ListItem>
                        <asp:ListItem>CopyRight</asp:ListItem>
                        <asp:ListItem>Price</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Value:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="searchtxt" Width="200px" Height="30px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="searchbtn" Text="Search" Width="200px" Height="40px" OnClick="searchbtn_Click" />
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
                    <asp:Label ID="Label3" runat="server" Text="of"></asp:Label></td>
                <td>
                    <asp:Label ID="bookPagesTop" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextTopbtn" Text="Next" OnClick="nextTopbtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastTopbtn" Text="Last" OnClick="lastTopbtn_Click" /></td>
            </tr>
        </tbody>
    </table>

    <asp:GridView ID="BookGV" runat="server" AutoGenerateColumns="False" Height="153px" Width="823px" OnRowCommand="BookGV_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" Visible="False" />
            <asp:BoundField DataField="Title" HeaderText="Title" Visible="true" />
            <asp:BoundField DataField="EditionNumber" HeaderText="Edition" Visible="False" />
            <asp:BoundField DataField="CopyRight" HeaderText="CopyRight" Visible="False" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" Visible="False" />
            <asp:BoundField DataField="OriginalPrice" HeaderText="OriginalPrice" Visible="False" />
            <asp:BoundField DataField="DiscountRate" HeaderText="Discount" Visible="false" />
            <asp:BoundField DataField="NumOfVisits" HeaderText="NumOf Visits" Visible="false" />

            <asp:CommandField ItemStyle-Width="100px" SelectText="View Detail" ShowSelectButton="True">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:CommandField>
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
                    <asp:Label ID="Label4" runat="server" Text="of"></asp:Label></td>
                <td>
                    <asp:Label ID="bookPagesbottom" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextBottombtn" Text="Next" OnClick="nextBottombtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastBottombtn" Text="Last" OnClick="lastBottombtn_Click" /></td>
            </tr>
        </tbody>
    </table>
</asp:Content>


