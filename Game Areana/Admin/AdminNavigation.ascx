<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminNavigation.ascx.cs" Inherits="Game_Areana.Admin.AdminNavigation" %>
<style>
  td {
    padding-top: 10px;
    padding-bottom: 10px;
    padding-right: 10px;
  }
</style>
<table>
  <tr>
    <td>
      <asp:LinkButton ID="lbSignIn" OnClick="lbSignIn_Click" runat="server">Sign In / Out</asp:LinkButton>
    </td>
    <td>
      <asp:LinkButton ID="lbAdmin" PostBackUrl="~/Admin/Admin.aspx" runat="server">Admin</asp:LinkButton>
    </td>
    <td>
      <asp:LinkButton ID="lbUser" PostBackUrl="~/Admin/User.aspx" runat="server">Settings</asp:LinkButton>
    </td>
    <td>
      <asp:LinkButton ID="lbCategory" PostBackUrl="~/Category.aspx" runat="server">Game Arena</asp:LinkButton>
    </td>
  </tr>
</table>
