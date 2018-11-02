<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="NewCustomerPage.aspx.cs" Inherits="ItemShopAgentWeb.Pages.Customer.BasicInformation.NewCustomerPage" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="MainContent">
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
                    <label>First Name:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="firstNametxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Last Name:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="lastNametxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Middle Name:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="MiddleName" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Date of Birth:</label>
                </td>
                <td>
                    <asp:Calendar ID="dateofBirthCld" runat="server" Width="200px" BackColor="White" BorderColor="#999999" CellPadding="4" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="99px">
                        <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#808080" />
                        <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <WeekendDayStyle BackColor="#FFFFCC" />
                    </asp:Calendar>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Email:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="emailtxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Country:</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="countryDDL" Width="292px" Height="40px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>City:</label>
                </td>
                <td>
                    <asp:DropDownList runat="server" ID="cityDDL" Width="292px" Height="40px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Username:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="usernametxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Password:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="password" Width="280px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <label>Confirm Password:</label>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="confirmPasswordtxt" Width="280px"></asp:TextBox>
                </td>
            </tr>
        </tbody>
        <tfoot>
            <tr>
                <td colspan="2">
                   <asp:Button runat="server"  ID="savebtn" Text="Register" Width="650px" Height="40px"/> 
                </td>
            </tr>
        </tfoot>
    </table>
</asp:Content>

