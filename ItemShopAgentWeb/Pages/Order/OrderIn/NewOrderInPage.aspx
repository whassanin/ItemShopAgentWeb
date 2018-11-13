<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewOrderInPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Order.OrderIn.NewOrderInPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <label><strong>New Order In</strong></label>
    <br />
    <asp:GridView ID="SelectedBookInGV" runat="server" AutoGenerateColumns="False" Width="961px" OnRowCommand="SelectedBookInGV_RowCommand" OnRowDeleting="SelectedBookInGV_RowDeleting" OnRowDataBound="SelectedBookInGV_RowDataBound">
        <Columns>
            <asp:BoundField HeaderText="Id" DataField="Id" Visible="false" />
            <asp:BoundField HeaderText="Title" DataField="Title" />
            <asp:BoundField HeaderText="Price" DataField="BookPrice" DataFormatString="{0:0.00}" />
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:Label runat="server" ID="Quantitylbl" Text='<%#Eval("Quantity") %>' Visible="false"></asp:Label>
                    <asp:DropDownList runat="server" ID="QuantityDDL" AutoPostBack="true" OnSelectedIndexChanged="QuantityDDL_SelectedIndexChanged">
                    </asp:DropDownList>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:0.00}" />
            <asp:CommandField ShowDeleteButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label runat="server" Text="Total: " ID="totallbl" DataFormatString="{0:0.00}"></asp:Label>
    <br />
    <br />
    <asp:Button runat="server" ID="cancelOrderbtn" Text="Cancel Order" OnClick="cancelOrderbtn_Click" />
    <asp:Button runat="server" ID="continueOrderbtn" Text="Continue Order" OnClick="continueOrderbtn_Click" />
    <asp:Button runat="server" ID="ConfirmOrderbtn" Text="Confirm Order" OnClick="ConfirmOrderbtn_Click" />
</asp:Content>