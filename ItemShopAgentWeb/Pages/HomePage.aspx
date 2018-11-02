<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="HomePage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.HomePage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Button ID="cartbtn" runat="server" Text="Cart" OnClick="cartbtn_Click" Width="798px" />
    <br />
    <asp:Label ID="Label1" runat="server" Text="Category:"></asp:Label>
    <asp:DropDownList ID="CategoryDDL" runat="server" Height="40px" Width="737px">
    </asp:DropDownList>
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
                    <asp:Label ID="Label2" runat="server" Text="of"></asp:Label></td>
                <td>
                    <asp:Label ID="PagesToplbl" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextTopbtn" Text="Next" OnClick="nextTopbtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastTopbtn" Text="Last" OnClick="lastTopbtn_Click" /></td>
            </tr>
        </tbody>
    </table>
    <asp:GridView ID="BookGV" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,Title,BookPrice,Amount" Height="153px" Width="823px" OnRowCommand="BookGV_RowCommand" PageSize="1000">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" Visible="false" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="EditionNumber" HeaderText="Edition" Visible="False" />
            <asp:BoundField DataField="CopyRight" HeaderText="CopyRight" Visible="false" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />
            <asp:BoundField DataField="BookPrice" HeaderText="Price" Visible="false" />
            <asp:BoundField DataField="CategoryId" HeaderText="CategoryId" Visible="False" />
            <asp:BoundField DataField="NumOfVisits" HeaderText="NumOf Visits" Visible="false" />

            <asp:CommandField SelectText="View Details" ShowSelectButton="True" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:CommandField>
            <asp:CommandField NewText="Buy now" ShowInsertButton="True" ItemStyle-Width="100px">
                <ItemStyle Width="100px"></ItemStyle>
            </asp:CommandField>
        </Columns>
        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" PageButtonCount="4" Visible="False" />
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
                    <asp:Label ID="PagesBottom" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextBottombtn" Text="Next" OnClick="nextBottombtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastBottombtn" Text="Last" OnClick="lastBottombtn_Click" /></td>
            </tr>
        </tbody>
    </table>
</asp:Content>


