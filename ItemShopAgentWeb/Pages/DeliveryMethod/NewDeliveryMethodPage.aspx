<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewDeliveryMethodPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.DeliveryMethod.NewDeliveryMethodPage" %>

<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label runat="server" text="Id:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="idtxt" Width="250px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Method:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="methodtxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Cost:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="costtxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Cost per Item:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="perItemCosttxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Min Delivery Time:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="minDeliveryTimetxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Max Delivery Time:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="maxDeliveryTimetxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="savebtn" Text="Save" Width="398px" OnClick="savebtn_Click"/>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


