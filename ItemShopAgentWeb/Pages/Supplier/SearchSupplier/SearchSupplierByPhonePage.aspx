<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchSupplierByPhonePage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Supplier.SearchSupplier.SearchSupplierByPhonePage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <label>Phone</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="phonetxt" Width="280px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button runat="server" ID="Searchbtn" Text="Search" OnClick="Searchbtn_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <label>Full Name:</label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="fullNametxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td>
                    <asp:Button runat="server" ID="backbtn" Text="Back" OnClick="backbtn_Click" />
                </td>
                <td>
                    <asp:Button runat="server" ID="ViewSupplierbtn" Text="View All Supplier" OnClick="ViewSupplierbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="selectSupplierbtn" runat="server" Text="Select Supplier" OnClick="selectSupplierbtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>

