<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewOrderOutPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.NewOrderOutPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <label><strong>New Order Out</strong></label>
    <br />
    <asp:GridView ID="SelectedBookOutGV" runat="server" AutoGenerateColumns="False" Width="961px" OnRowCommand="SelectedBookOutGV_RowCommand" OnRowDeleting="SelectedBookOutGV_RowDeleting">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
            <asp:BoundField HeaderText="Title" DataField="Title" />
            <asp:BoundField HeaderText="Quantity" DataField="Quantity" HeaderStyle-Width="100px">
                <HeaderStyle Width="100px"></HeaderStyle>
            </asp:BoundField>
            <asp:BoundField HeaderText="Price" DataField="BookPrice" />
            <asp:BoundField HeaderText="Amount" DataField="Amount" Visible="false" />
            <asp:BoundField HeaderText="Total" DataField="Total" />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:ButtonField CommandName="Inc" Text="Inc." />
            <asp:ButtonField CommandName="Dec" Text="Dec." />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label runat="server" Text="Total: " ID="totallbl"></asp:Label>
    <br />
    <br />
    <asp:Button runat="server" ID="cancelOrderbtn" Text="Cancel Order" OnClick="cancelOrderbtn_Click"/>
    <asp:Button runat="server" ID="continueOrderbtn" Text="Continue Order" OnClick="continueOrderbtn_Click"/>
    <asp:Button runat="server" ID="ConfirmOrderbtn"  Text="Confirm Order" OnClick="ConfirmOrderbtn_Click"/>
</asp:Content>


