<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditBookDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.BookPages.EditBookDetailPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table class="auto-style1">
        <tbody>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox runat="server" ID="idtxt" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label2" runat="server" Text="ISBN"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="ISBNtxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="titletxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label5" runat="server" Text="Edition Number"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="editionNumbertxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label7" runat="server" Text="Copy Right"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="copyRighttxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="Amounttxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label6" runat="server" Text="Price"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="pricetxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label9" runat="server" Text="Discount Rate"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:TextBox ID="discountRatetxt" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label10" runat="server" Text="Category"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:DropDownList ID="categoryDDL" runat="server" Width="300px" Height="40px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    <label>Order Out</label>
                    <asp:GridView runat="server" ID="OrderOutGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="OrderOutId" HeaderText="OrderOutId" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    <label>Order In</label>
                    <asp:GridView runat="server" ID="OrderInGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="OrderInId" HeaderText="OrderInId" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    <label>Shopping Cart by book</label>
                    <asp:GridView runat="server" ID="shoppingCartBookGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="Id" DataField="Id" />
                            <asp:BoundField DataField="ShoppingCartId" HeaderText="ShoppingCartId" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="Price" HeaderText="Price" />
                            <asp:BoundField DataField="Total" HeaderText="Total" />
                            <asp:BoundField DataField="Status" HeaderText="Status" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    <label>Wish List by Book</label>
                    <asp:GridView runat="server" ID="WishListByBookGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="CustomerId" DataField="CustomerId" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    <label>Reviews</label>
                    <asp:GridView runat="server" ID="CommentGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="CustomerId" DataField="CustomerId" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" />
                            <asp:BoundField DataField="Review" HeaderText="Review" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style1">
                    <label>Rate</label>
                    <asp:GridView runat="server" ID="RateGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="CustomerId" DataField="CustomerId" />
                            <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                            <asp:BoundField DataField="LastName" HeaderText="LastName" />
                            <asp:BoundField DataField="MiddleName" HeaderText="MiddleName" />
                            <asp:BoundField DataField="Rate" HeaderText="Rate" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label8" runat="server" Text="Rate"></asp:Label>
                </td>
                <td class="auto-style1">
                    <asp:Label ID="ratelbl" runat="server"></asp:Label>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button ID="addorderInbtn" runat="server" Text="Add to Order In" Width="225px" Height="40px" />
                    <asp:Button ID="addorderOutbtn" runat="server" Text="Add to Order Out" Width="225px" Height="40px" />
                    <asp:Button ID="deletebtn" runat="server" Text="Delete" Width="225px" Height="40px" OnClick="deletebtn_Click" />
                    <asp:Button ID="savebtn" runat="server" Text="Save" Width="225px" Height="40px" OnClick="savebtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .auto-style1 {
            height: 23px;
            border-style: groove;
            border-width: thin;
            border-color: black;
        }
    </style>
</asp:Content>
