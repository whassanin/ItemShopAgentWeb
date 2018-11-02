<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditCustomerCreditCardPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.CreditCard.EditCustomerCreditCardDetailPage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <table runat="server" id="CreditCardtable">
        <tbody>
            <tr>
                <td>
                    Credit Card Number:</td>
                <td>
                    <asp:TextBox runat="server" ID="CCNumbertxt" Width="350px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="nametxt" Width="350px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    CardType:</td>
                <td>
                    <asp:DropDownList runat="server" ID="cardTypeDDL" Height="16px" Width="350px" >
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Master Card</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Expiration Month:</td>
                <td class="auto-style1"><asp:TextBox runat="server" ID="ExpirationMonthtxt" Width="350px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Expiration Year:</td>
                <td><asp:TextBox runat="server" ID="ExpirationYeartxt" Width="350px"></asp:TextBox></td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="Savebtn" Text="Save" Width="250px" />
                    <asp:Button runat="server" ID="Deletebtn" Text="Delete" Width="250px" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>
