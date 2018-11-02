<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchCustomerByPhonePage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.SearchCustomer.SearchCustomerByPhonePage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
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
                    <label>First Name:</label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="firstNametxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Last Name:</label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="lastNametxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Middle Name:</label>
                </td>
                <td colspan="2">
                    <asp:TextBox runat="server" ID="MiddleName" Width="280px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td>
                    <asp:Button runat="server" ID="backbtn" Text="Back" OnClick="backbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="selectCustomerbtn" runat="server" Text="Select Customer" OnClick="selectCustomerbtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>

