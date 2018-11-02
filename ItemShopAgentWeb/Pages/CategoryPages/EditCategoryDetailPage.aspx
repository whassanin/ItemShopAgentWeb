<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditCategoryDetailPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.CategoryPages.EditCategoryPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label runat="server" Text="Id:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="Idtxt" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="nametxt" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label>Is main Category</label>
                </td>
                <td>
                    <input type="checkbox" runat="server" id="isMainCB" title="Is main category" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Sub Category Name:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="subCategoryNameDDL" runat="server" Width="310px" Height="40px"></asp:DropDownList></td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>Sub Categories</label>
                    <asp:GridView runat="server" AutoGenerateColumns="False" ID="SubCategoryGV" Width="600px">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="Name" HeaderText="Name" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <label>Books</label>
                    <asp:GridView ID="BookGV" runat="server" AutoGenerateColumns="False" Width="600px">
                        <Columns>
                            <asp:BoundField DataField="Id" HeaderText="Id" />
                            <asp:BoundField DataField="Title" HeaderText="Title" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button ID="savebtn" runat="server" Text="Save" Width="300px" Height="40px"/>
                    <asp:Button ID="deletebtn" runat="server" Text="Delete" Width="300px" Height="40px" OnClick="deletebtn_Click"/>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>



