<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="OrderNumberPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.OrderNumberPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:Repeater runat="server" ID="repeatertxt">
        <HeaderTemplate>
            <table>
                <tr>
                    <th>Title
                    </th>
                    <th>Rate
                    </th>
                    <th>Comment
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label runat="server" ID="Bookidlbl" Text='<%# Eval("BookId") %>' Visible="true"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="titletxt" Text='<%# Eval("Title") %>'></asp:Label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="rateDDL">
                        <asp:ListItem Text="1" Value="1">

                        </asp:ListItem>
                        <asp:ListItem Text="2" Value="2">

                        </asp:ListItem>
                        <asp:ListItem Text="3" Value="3">

                        </asp:ListItem>
                        <asp:ListItem Text="4" Value="4">

                        </asp:ListItem>
                        <asp:ListItem Text="5" Value="5">

                        </asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="commenttxt" />
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <asp:Button runat="server" ID="Savebtn" OnClick="Savebtn_Click" Text="Save rate" />
    <asp:Button runat="server" ID="skipbtn" OnClick="skipbtn_Click" Text="Skip" />
</asp:Content>


