<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SearchPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.SearchPages.SearchPage" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <label><strong>Search:</strong></label>
        <asp:TextBox runat="server" ID="searchtxt" />
        <asp:Button runat="server" ID="searchbtn" Text="Apply Search" OnClick="searchbtn_Click" />
    </div>
    <br />
    <div>
        <asp:Button runat="server" ID="topfirstbtn" Text="First" Width="100px" OnClick="firstbtn_Click" />
        <asp:Button runat="server" ID="toppreviousbtn" Text="Previous" Width="100px" OnClick="previousbtn_Click" />
        <asp:Button runat="server" ID="topnextbtn" Text="Next" Width="100px" OnClick="nextbtn_Click" />
        <asp:Button runat="server" ID="toplastbtn" Text="Last" Width="100px" OnClick="lastbtn_Click" />
    </div>
    <asp:Label runat="server" Text="" ID="totalRecordslbl" Visible="false" />
    <asp:GridView ID="BookGV" runat="server" AutoGenerateColumns="False" DataKeyNames="Id,Title,Price,Amount" AllowPaging="true" Height="153px" Width="823px" OnRowCommand="BookGV_RowCommand" OnPageIndexChanging="BookGV_PageIndexChanging" PageSize="1000">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" Visible="true" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" Visible="false" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="EditionNumber" HeaderText="Edition" Visible="False" />
            <asp:BoundField DataField="CopyRight" HeaderText="CopyRight" Visible="false" />
            <asp:BoundField DataField="Amount" HeaderText="Amount" />
            <asp:BoundField DataField="Price" HeaderText="Price" Visible="false" />
            <asp:BoundField DataField="OriginalPrice" HeaderText="OriginalPrice" Visible="False" />
            <asp:BoundField DataField="DiscountRate" HeaderText="Discount" Visible="false" />
            <asp:BoundField DataField="NumOfVisits" HeaderText="NumOf Visits" Visible="false" />
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <div>
        <asp:Button runat="server" ID="bottomfirstbtn" Text="First" Width="100px" OnClick="firstbtn_Click" />
        <asp:Button runat="server" ID="bottompreviousbtn" Text="Previous" Width="100px" OnClick="previousbtn_Click" />
        <asp:Button runat="server" ID="bottomnextbtn" Text="Next" Width="100px" OnClick="nextbtn_Click" />
        <asp:Button runat="server" ID="bottomlastbtn" Text="Last" Width="100px" OnClick="lastbtn_Click" />
    </div>
</asp:Content>
