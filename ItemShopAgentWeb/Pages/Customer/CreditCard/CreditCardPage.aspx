<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CreditCardPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.CreditCardPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <asp:GridView ID="CreditCardGV" runat="server" AutoGenerateColumns="False" Width="788px" OnRowCommand="CreditCardGV_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" Visible="False"  DataField="Id"/>
            <asp:BoundField HeaderText="CCNumber"  DataField="CCNumber"/>
            <asp:BoundField HeaderText="Name"  DataField="Name"/>
            <asp:BoundField HeaderText="CardType"  DataField="CardType"/>
            <asp:BoundField HeaderText="ExpirationMonth"  DataField="ExpirationMonth"/>
            <asp:BoundField HeaderText="ExpirationYear" DataField="ExpirationYear"/>
            <asp:BoundField HeaderText="CustomerId" Visible="False" DataField="CustomerId" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>

    <asp:Button runat="server" ID="Addbtn" Text="Add Another CreditCard" OnClick="Addbtn_Click" />

    <table runat="server" id="CreditCardtable" visible="false">
        <tbody>
            <tr>
                <td>
                    Credit Card Number:</td>
                <td>
                    <asp:TextBox runat="server" ID="CCNumbertxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Name:</td>
                <td>
                    <asp:TextBox runat="server" ID="nametxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    CardType:</td>
                <td>
                    <asp:DropDownList runat="server" ID="cardTypeDDL" Height="16px" Width="318px" >
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Master Card</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    Expiration Month:</td>
                <td class="auto-style1"><asp:TextBox runat="server" ID="ExpirationMonthtxt"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    Expiration Year:</td>
                <td><asp:TextBox runat="server" ID="ExpirationYeartxt"></asp:TextBox></td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" ID="Savebtn" Text="Save Credit Card" OnClick="Savebtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 47px;
        }
    </style>
</asp:Content>



