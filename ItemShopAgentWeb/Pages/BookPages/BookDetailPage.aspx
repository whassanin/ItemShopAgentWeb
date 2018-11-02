<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookDetailPage.aspx.cs" MasterPageFile="~/Site.Master" Inherits="ItemShopAgentWeb.Pages.BookDetailPage" %>


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
                <td>
                    <asp:Label runat="server" Text="Id"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="idtxt"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="ISBN"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ISBNtxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Title"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="titletxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Edition Number"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="editionNumbertxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Copy Right"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="copyRighttxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Amount"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Amounttxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Price"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="pricetxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Discount Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="discountRatetxt" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Category"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="categorylbl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="ratelbl" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView runat="server" ID="CommentGV" AutoGenerateColumns="False" Width="874px">
                        <Columns>
                            <asp:BoundField HeaderText="Reviews" DataField="Review" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button ID="backbtn" runat="server" Text="Back" Width="200px" OnClick="backbtn_Click" />
                    <asp:Button ID="addtocartbtn" runat="server" Text="Add to Cart" Width="200px" OnClick="addtocartbtn_Click" />
                    <asp:Button ID="addtowishlistbtn" runat="server" Text="add to Wish List" Width="200px" OnClick="addtowishlistbtn_Click" />
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>



