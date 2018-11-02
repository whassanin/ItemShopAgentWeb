<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="EditDeliveryMethodPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.DeliveryMethod.EditDeliveryMethodPage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <asp:GridView ID="DeliveryMethodGV" runat="server" AutoGenerateColumns="False" OnRowCommand="DeliveryMethodGV_RowCommand">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" />
            <asp:BoundField DataField="Method" HeaderText="Method" />
            <asp:CommandField SelectText="Detail" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
</asp:Content>

