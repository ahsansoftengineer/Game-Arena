<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Game_Areana.Admin.LogIn" %>

<%@ Register Src="~/Admin/AdminNavigation.ascx" TagPrefix="uc1" TagName="AdminNavigation" %>


<!DOCTYPE html>
<html>
<head runat="server">
  <title>Administrator</title>
  <link href="../CSS/bootstrap.min.css" rel="stylesheet" />
  <link href="../CSS/Custome.css" rel="stylesheet" />
</head>
<body style="background: #fff">
  <form id="form1" runat="server">
    <div class="container">
      <div class="row">
        <div class="col-md-3 col-sm-2"></div>
        <%--Create Account--%>
        <asp:Panel ID="upCreateAccount" CssClass="col-md-6 col-sm-8" runat="server">
          <div class="row">
            <div class="col-12">
              <uc1:AdminNavigation runat="server" ID="AdminNavigation" />
            </div>
            <div class="col-12 pb-3">
              <h5>Update Account</h5>
            </div>
            <div id="divSearchID" runat="server" class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">ID</span>
                </div>
                <asp:TextBox ID="txtUserID" CssClass="form-control" runat="server"></asp:TextBox>
                <div class="input-group-append">
                  <asp:Button ID="btnSearchID" CssClass="btn btn-primary" OnClick="btnSearchID_Click" runat="server" Text="Search" />
                </div>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Email Address</span>
                </div>
                <asp:TextBox ID="txtCAEmail" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">First Name</span>
                </div>
                <asp:TextBox ID="txtCAFirstName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Last Name</span>
                </div>
                <asp:TextBox ID="txtCALastName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Secret Question</span>
                </div>
                <asp:DropDownList ID="ddlCASecretQuestion" CssClass="form-control" runat="server">
                  <asp:ListItem>Color</asp:ListItem>
                  <asp:ListItem>Sports</asp:ListItem>
                  <asp:ListItem>Any Name</asp:ListItem>
                  <asp:ListItem>Birth Date</asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Secret Answer</span>
                </div>
                <asp:TextBox ID="txtCASecretAnswer" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Gmail Address</span>
                </div>
                <asp:TextBox ID="txtCAGmailAddress" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Password</span>
                </div>
                <asp:TextBox ID="txtCAPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Re-Type Password</span>
                </div>
                <asp:TextBox ID="txtCAReTypePassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group">
                <div class="btn-group">
                  <asp:Button ID="btnCAAccount" CssClass="btn btn-warning" runat="server" Text="Create" OnClick="btnCAAccount_Click" />
                  <asp:Button ID="btnCAAUpdateAccount" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnCAAUpdateAccount_Click" />
                  <asp:Button ID="btnCAADelete" CssClass="btn btn-danger" OnClientClick="return promth('Do you want to Delete')" runat="server" Text="Delete" OnClick="btnCAADelete_Click" />
                </div>
              </div>
              <div id="divAlertCreateAccount" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
                <strong>Message</strong>
                <asp:Label ID="lblCAMessage" ForeColor="Red" runat="server" Text="Message Game Info"></asp:Label>
              </div>
            </div>
          </div>
        </asp:Panel>
        <div class="col-md-3 col-sm-2"></div>
      </div>
    </div>
  </form>
</body>
<script src="../JS/jquery-3.3.1.min.js"></script>
<script src="../JS/bootstrap.min.js"></script>
</html>
