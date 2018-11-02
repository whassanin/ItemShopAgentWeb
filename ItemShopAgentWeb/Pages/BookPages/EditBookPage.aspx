<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditBookPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.BookPages.EditBookPage" %>

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
                    <asp:Label ID="bookPagesTop" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextTopbtn" Text="Next" OnClick="nextTopbtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastTopbtn" Text="Last" OnClick="lastTopbtn_Click" /></td>
            </tr>
        </tbody>
    </table>

    <asp:GridView ID="BookGV" runat="server" AutoGenerateColumns="False" Height="150px" Width="1000px" OnRowCommand="BookGV_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" Visible="False" />
            <asp:BoundField DataField="Title" HeaderText="Title" Visible="true" HeaderStyle-Width="500px" />
            <asp:BoundField DataField="EditionNumber" HeaderText="Edition" Visible="False" />
            <asp:BoundField DataField="CopyRight" HeaderText="CopyRight" Visible="False" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" Visible="False" />
            <asp:BoundField DataField="OriginalPrice" HeaderText="OriginalPrice" Visible="False" />
            <asp:BoundField DataField="DiscountRate" HeaderText="Discount" Visible="false" />
            <asp:BoundField DataField="NumOfVisits" HeaderText="NumOf Visits" Visible="false" />
            <asp:ButtonField Text="View Detail" CommandName="ViewDetail" HeaderStyle-Width="200px"/>
            <asp:ButtonField Text="Add to Order Out" CommandName="AddOrderOut" HeaderStyle-Width="200px" />
            <asp:ButtonField Text="Add to Order In" CommandName="AddOrderIn" HeaderStyle-Width="200px"/>
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
                    <asp:Label ID="bookPagesbottom" runat="server"></asp:Label></td>
                <td>
                    <asp:Button runat="server" ID="nextBottombtn" Text="Next" OnClick="nextBottombtn_Click" /></td>
                <td>
                    <asp:Button runat="server" ID="lastBottombtn" Text="Last" OnClick="lastBottombtn_Click" /></td>
            </tr>
        </tbody>
    </table>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>



<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="FeaturedContent">
</asp:Content>




