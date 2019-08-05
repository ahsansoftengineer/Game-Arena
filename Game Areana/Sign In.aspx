<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign In.aspx.cs" Inherits="Game_Areana.Sign_In" %>

<%@ Register Src="~/Admin/AdminNavigation.ascx" TagPrefix="uc1" TagName="AdminNavigation" %>


<!DOCTYPE html>
<html>
<head runat="server">
  <title>Log In</title>
  <link href="CSS/bootstrap.min.css" rel="stylesheet" />
  <link href="CSS/Custome.css" rel="stylesheet" />
</head>
<body style="background: #fff">
  <form id="form1" runat="server">
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-3 col-sm-2"></div>
        <div class="col-md-9 col-sm-10">
          <uc1:AdminNavigation runat="server" ID="AdminNavigation" />
        </div>
      </div>
      <div class="row" style="margin-top: 5px;">
        <%-- Log In --%>
        <div class="col-md-3 col-sm-2"></div>
        <asp:Panel ID="upLogIn" class="col-md-6 col-sm-8 col-lg-5 col-xl-4" runat="server">
          <div class="row">
            <div class="col-12 pb-4">
              <h5 id="GameInfos">Log In</h5>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">User Name</span>
                </div>
                <asp:TextBox ID="txtLIUserName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-3">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Password </span>
                </div>
                <asp:TextBox ID="txtLIPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-2 pb-2">
              <div class="input-group">
                <div class="btn-group">
                  <asp:Button ID="btnLogIn" CssClass="btn btn-primary" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </div>
              </div>
            </div>
            <div class="pt-8 pt-2 col-10">
              <asp:LinkButton ID="lbForgetPassword" Style="float: right" OnClick="lbForgetPassword_Click" runat="server">Forget Password</asp:LinkButton>
            </div>
            <div class="col-12 pb-2">
              <div id="divAlertLogInMessage" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
                <strong>Message</strong>
                <asp:Label ID="lblLIMessage" ForeColor="Red" runat="server"></asp:Label>
              </div>
            </div>
          </div>
        </asp:Panel>
        <%-- Forget Passwor d --%>
        <asp:Panel ID="upForgetPassword" class="col-md-6 col-sm-8 col-lg-5 col-xl-4" runat="server">
          <div class="row">
            <div class="col-12 pb-4">
              <h5>Forget Password</h5>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">User Name</span>
                </div>
                <asp:TextBox ID="txtFPUserName" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Secret Question</span>
                </div>
                <asp:DropDownList ID="ddlFPSecretQuestion" CssClass="form-control" runat="server">
                  <asp:ListItem>Select Option</asp:ListItem>
                  <asp:ListItem>Color</asp:ListItem>
                  <asp:ListItem>Sports</asp:ListItem>
                  <asp:ListItem>Any Name</asp:ListItem>
                  <asp:ListItem>Birth Date</asp:ListItem>
                </asp:DropDownList>
              </div>
            </div>
            <div class="col-12 pb-3">
              <div class="input-group ">
                <div class="input-group-prepend">
                  <span class="input-group-text">Secret Answer</span>
                </div>
                <asp:TextBox ID="txtFPSecretAnswer" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            </div>
            <div class="col-12 pb-2">
              <div class="input-group">
                <div class="btn-group">
                  <asp:Button ID="btnFPVerify" CssClass="btn btn-primary" runat="server" Text="Verify / Send Mail" OnClick="btnFPVerify_Click" />
                </div>
              </div>
              <div id="divAlertForgetPassword" runat="server" class="alert alert-danger alert-dismissible fade mt-3 position-absolute" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
                <strong>Message</strong>
                <asp:Label ID="lblFPMessage" ForeColor="Red" runat="server" Text="Message Game Info"></asp:Label>
              </div>
            </div>
          </div>
        </asp:Panel>
      </div>
      <div class="col-md-3 col-sm-2"></div>
    </div>
  </form>
</body>
<script src="JS/jquery-3.3.1.min.js"></script>
<script src="JS/bootstrap.min.js"></script>
</html>

