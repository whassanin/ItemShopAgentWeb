<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewBookPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.BookPages.NewBookPage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table>
        <thead>
            <tr>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="idtxt" Width="350px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="ISBN"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ISBNtxt" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="titletxt" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Edition Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="editionNumbertxt" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Copy Right"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="copyRighttxt" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Amounttxt" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Price" ></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="pricetxt" runat="server" Width="350px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Category"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="categoryDDL" runat="server" Height="40px" Width="350px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="savebtn" Text="Save" Width="350px" OnClick="savebtn_Click"/>
                </td>
            </tr>
        </tbody>
        <tfoot>
        </tfoot>
    </table>
</asp:Content>

