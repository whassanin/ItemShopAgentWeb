<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewCategoryPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.CategoryPages.NewCategoryPage1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <table>
        <tbody>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Id:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="Idtxt" runat="server" Width="300px" ReadOnly="true"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Name:"></asp:Label></td>
                <td>
                    <asp:TextBox ID="nametxt" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <label>Is main Category</label>
                </td>
                <td>
                    <input type="checkbox" runat="server" id="isMainCB"  title="Is main category"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Sub Category Name:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="subCategoryNameDDL" runat="server" Width="310px" Height="40px"></asp:DropDownList></td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                    <asp:Button runat="server" text="Save" ID="savebtn" Width="450px" Height="40px" OnClick="savebtn_Click"/>
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>


