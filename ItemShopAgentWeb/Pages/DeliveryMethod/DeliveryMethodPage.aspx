<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DeliveryMethodPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.DeliveryMethodPage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
    <asp:GridView ID="DeliveryGV" runat="server" AutoGenerateColumns="False" Width="935px" OnRowCommand="DeliveryGV_RowCommand">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" />
            <asp:BoundField HeaderText="Method" DataField="Method" />
            <asp:BoundField HeaderText="Cost" DataField="Cost" />
            <asp:BoundField HeaderText="CostPerItem" DataField="PerItemCost" />
            <asp:BoundField HeaderText="MaxDeliveryTime" DataField="MaxDeliveryTime" />
            <asp:BoundField HeaderText="MinDeliveryTime"  DataField="MinDeliveryTime"/>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button runat="server" ID="backbtn" Text="Back" OnClick="backbtn_Click" />
</asp:Content>

