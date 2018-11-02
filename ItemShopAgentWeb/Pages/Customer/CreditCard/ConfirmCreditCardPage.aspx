<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConfirmCreditCardPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.ConfirmDeliveryPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <thead>
            <tr>
                <th></th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td colspan="2"><strong>Credit Card</strong></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label13" runat="server">Number</asp:Label></td>
                <td>
                    <asp:Label ID="Numberlbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label15" runat="server">Name</asp:Label></td>
                <td>
                    <asp:Label ID="namelbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label17" runat="server">Card Type</asp:Label></td>
                <td>
                    <asp:Label ID="CardTypelbl" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label19" runat="server">Expiration Month</asp:Label></td>
                <td>
                    <asp:Label ID="ExpirationMonthlbl" runat="server"></asp:Label>
                    <asp:TextBox ID="ExpirationMonthtxt" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label21" runat="server">Expiration Year</asp:Label></td>
                <td>
                    <asp:Label ID="ExpirationYearlbl" runat="server"></asp:Label>
                    <asp:TextBox ID="ExpirationYeartxt" runat="server" Visible="false"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td>
                    <asp:Button ID="gobackbtn" runat="server" Text="Go Back" OnClick="gobackbtn_Click" />
                </td>
                <td>
                    <asp:Button ID="confirmbtn" runat="server" Text="Confirm" OnClick="confirmbtn_Click" Visible="false" />
                    <asp:Button ID="updatebtn" runat="server" Text="Update" OnClick="updatebtn_Click" Visible="false" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>

