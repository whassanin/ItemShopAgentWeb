<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditCustomerAddressPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.Address.EditCustomerAddressDetailPage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table id="addresstable" runat="server">
        <tr>
            <td>
                <label>
                Number:</label></td>
            <td>
                <asp:TextBox ID="numbertxt" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                Street:</label></td>
            <td>
                <asp:TextBox ID="streettxt" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                District:</label></td>
            <td>
                <asp:TextBox ID="Districttxt" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                Country:</label></td>
            <td>
                <asp:DropDownList ID="CountryDDL" runat="server" AutoPostBack="True" Height="40px" OnSelectedIndexChanged="CountryDDL_SelectedIndexChanged" Width="350px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                City:</label></td>
            <td>
                <asp:DropDownList ID="CityDDL" runat="server" Height="40px" Width="350px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                ZipCode:</label></td>
            <td>
                <asp:TextBox ID="ZipCode" runat="server" Width="350px"></asp:TextBox>
            </td>
        </tr>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button ID="Deletebtn" runat="server" Text="Delete" Width="350px"/>
                    <asp:Button ID="Savebtn" runat="server" Text="Save" Width="350px"/>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>
