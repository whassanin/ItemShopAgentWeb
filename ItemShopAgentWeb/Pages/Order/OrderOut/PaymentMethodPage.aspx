<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="PaymentMethodPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Order.OrderOut.PaymentMethodPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Payment Method"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="PaymentMethodDDl" AutoPostBack="true" OnSelectedIndexChanged="PaymentMethodDDl_SelectedIndexChanged">
                        <asp:ListItem Text="Cash" Value="Cash" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Credit Card" Value="CreditCard"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label><strong>Total:</strong></label>
                </td>
                <td>
                    <asp:Label runat="server" ID="totallbl"></asp:Label>
                </td>
            </tr>
            <tr id="cashRow" runat="server">
                <td colspan="2">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Paid"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="paidtxt" OnTextChanged="paidtxt_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Change"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox runat="server" ID="changetxt" ReadOnly="true" OnTextChanged="changetxt_TextChanged"></asp:TextBox>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr id="ccGridViewRow" runat="server">
                <td colspan="2">
                    <asp:GridView ID="CreditCardGV" runat="server" AutoGenerateColumns="False" Width="300px" OnRowCommand="CreditCardGV_RowCommand">
                        <Columns>
                            <asp:BoundField HeaderText="Id" Visible="False" DataField="Id" />
                            <asp:BoundField HeaderText="CCNumber" DataField="CCNumber" />
                            <asp:BoundField HeaderText="Name" DataField="Name" />
                            <asp:BoundField HeaderText="CardType" DataField="CardType" />
                            <asp:BoundField HeaderText="ExpirationMonth" DataField="ExpirationMonth" />
                            <asp:BoundField HeaderText="ExpirationYear" DataField="ExpirationYear" />
                            <asp:BoundField HeaderText="CustomerId" Visible="False" DataField="CustomerId" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr id="ccDetail" runat="server">
                <td colspan="2">
                    <table>
                        <tbody>
                            <tr>
                                <td>
                                    <label><strong>Id</strong></label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="idlbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label><strong>Credit Card Number</strong></label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="CCNumberlbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label><strong>Name</strong></label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="Namelbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label><strong>Card Type</strong></label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="CardTypelbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label><strong>Expiration Month</strong></label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="ExpirationMonthlbl"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label><strong>Expiration Year</strong></label>
                                </td>
                                <td>
                                    <asp:Label runat="server" ID="ExpirationYearlbl"></asp:Label>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button ID="savebtn" Text="Apply" runat="server" OnClick="savebtn_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <strong>
                        <asp:Label runat="server" ID="orderNumberlbl"></asp:Label>
                    </strong>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


