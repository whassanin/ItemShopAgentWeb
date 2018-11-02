<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditDeliveryMethodDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.DeliveryMethod.EditDeliveryMethodDetailPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="idtxt" Width="250px" ReadOnly="true"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Method:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="methodtxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Cost:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="costtxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Cost per Item:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="perItemCosttxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Min Delivery Time:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="minDeliveryTimetxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Max Delivery Time:"></asp:Label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="maxDeliveryTimetxt" Width="250px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="deletebtn" Text="Delete" Width="198px" OnClick="deletebtn_Click" />
                    <asp:Button runat="server" ID="savebtn" Text="Save" Width="198px" OnClick="savebtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


