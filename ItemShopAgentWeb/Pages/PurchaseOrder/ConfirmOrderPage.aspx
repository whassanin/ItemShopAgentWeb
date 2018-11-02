<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ConfirmOrderPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.ConfirmOrderPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table class="auto-style1">
        <thead>
            <tr>
                <th colspan="2"><strong>Address</strong></th>
                <th colspan="2"><strong>Delivery Method</strong></th>
            </tr>
        </thead>
        <tbody class="auto-style1">
            <tr class="auto-style1">
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server">Number:</asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="numbertxt" runat="server"></asp:Label></td>

                <td class="auto-style1">
                    <asp:Label ID="Label13" runat="server">Method:</asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="Methodtxt" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1"> 
                    <asp:Label ID="Label3" runat="server">Street:</asp:Label></td>
                <td>
                    <asp:Label ID="streettxt" runat="server"></asp:Label></td>

                <td class="auto-style1">
                    <asp:Label ID="Label15" runat="server">Cost:</asp:Label></td>
                <td>
                    <asp:Label ID="costtxt" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server">District:</asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="Districttxt" runat="server"></asp:Label></td>

                <td class="auto-style1">
                    <asp:Label ID="Label17" runat="server">Cost Per Item:</asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="peritemCosttxt" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server">Country</asp:Label>
                    ,
                    <asp:Label ID="Label9" runat="server">City</asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="countrytxt" runat="server"></asp:Label>
                    , 
                    <asp:Label ID="citytxt" runat="server"></asp:Label></td>

                <td class="auto-style1">
                    <asp:Label ID="Label19" runat="server">Min Delivery Time:</asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="MinDeliveryTimetxt" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label11" runat="server">ZipCode:</asp:Label></td>
                <td>
                    <asp:Label ID="zipCodetxt" runat="server"></asp:Label></td>

                <td class="auto-style1">
                    <asp:Label ID="Label21" runat="server">Max Delivery Time:</asp:Label></td>
                <td class="auto-style1">
                    <asp:Label ID="MaxDeliveryTimetxt" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style1" colspan="4"><strong>Items</strong></td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style1">
                    <asp:GridView ID="ShoppingCartBookGV" runat="server" AutoGenerateColumns="False" Width="961px">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
                            <asp:BoundField HeaderText="Book" DataField="Title" />
                            <asp:BoundField HeaderText="BookId" DataField="BookId" Visible="false" />
                            <asp:BoundField HeaderText="ShoppingCartId" DataField="ShoppingCartId" Visible="false" />
                            <asp:BoundField HeaderText="Quantity" DataField="Quantity" HeaderStyle-Width="100px" />
                            <asp:BoundField HeaderText="Price" DataField="Price" />
                            <asp:BoundField HeaderText="Amount" DataField="Amount" Visible="false" />
                            <asp:BoundField HeaderText="Total" DataField="Total" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style1">
                    <label><strong>Total</strong></label>
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style1">
                    <asp:Label runat="server" ID="lable" Text="Total cost of items:" />
                    <asp:Label runat="server" ID="totalCostItemstxt" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style1">
                    <asp:Label runat="server" ID="Label2" Text="Total cost of Delivery:" />
                    <asp:Label runat="server" ID="totalCostOfDeliverytxt" />
                </td>
            </tr>
            <tr>
                <td colspan="4" class="auto-style1">
                    <asp:Label runat="server" ID="Label4" Text="Total:" />
                    <asp:Label runat="server" ID="Totaltxt" />
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="4">
                    <asp:Button ID="gobackbtn" runat="server" Text="Go Back" OnClick="gobackbtn_Click" />
                    <asp:Button ID="confirmbtn" runat="server" Text="Confirm" OnClick="confirmbtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
            border-style:groove;
            border-width:thin;
            border-color:black
        }
    </style>
</asp:Content>



