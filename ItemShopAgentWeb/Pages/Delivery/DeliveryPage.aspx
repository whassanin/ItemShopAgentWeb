<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DeliveryPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.DeliveryPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="AddressGV" runat="server" AutoGenerateColumns="False" Width="894px" OnRowCommand="AddressGV_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="False" />
            <asp:BoundField HeaderText="Number" DataField="Number" />
            <asp:BoundField HeaderText="Street" DataField="Street" />
            <asp:BoundField HeaderText="District" DataField="District" />
            <asp:BoundField HeaderText="Country" DataField="Country" />
            <asp:BoundField HeaderText="City" DataField="City" />
            <asp:BoundField HeaderText="ZipCode" DataField="ZipCode" />
            <asp:BoundField HeaderText="CustomerId" Visible="False" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button runat="server" ID="backbtn" Text="Back" OnClick="backbtn_Click"/>
    <asp:Button runat="server"  ID="Addbtn" Text="Add Another Address" OnClick="Addbtn_Click"/>

    <table runat="server" id="addresstable" visible="false">
        <tbody>
            <tr>
                <td>
                    <label>Number:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="numbertxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label>Street:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="streettxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label>District:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="Districttxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label>Country:</label></td>
                <td>
                    <asp:DropDownList runat="server" ID="CountryDDL" Height="40px" Width="309px" AutoPostBack="True" OnSelectedIndexChanged="CountryDDL_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <label>City:</label></td>
                <td>
                    <asp:DropDownList runat="server" ID="CityDDL" Height="40px" Width="307px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <label>ZipCode:</label></td>
                <td>
                    <asp:TextBox runat="server" ID="ZipCode"></asp:TextBox></td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server"  ID="Savebtn" Text="Save Address" OnClick="Savebtn_Click"/>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


