<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditOrderOutPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.EditOrderOutPage" %>

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
    <asp:GridView ID="OrderOutGV" runat="server" AutoGenerateColumns="False" Height="150px" Width="700px" OnRowCommand="OrderOutGV_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="OrderDate" HeaderText="Date" />
            <asp:BoundField DataField="Total" HeaderText="Total" />
            <asp:BoundField DataField="Paid" HeaderText="Paid" />
            <asp:BoundField DataField="Change" HeaderText="Change" />
            <asp:ButtonField Text="View Detail" CommandName="ViewDetail"/>
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
    </table>
</asp:Content>

