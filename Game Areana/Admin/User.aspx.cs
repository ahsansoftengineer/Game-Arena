using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

namespace Game_Areana.Admin
{
  public partial class LogIn : System.Web.UI.Page
  {
    private static string EncryptedPassword(string Passwords)
    {
      return FormsAuthentication.HashPasswordForStoringInConfigFile(Passwords, "SHA1");
    }
    private void showHideControls(bool showHide)
    {
      btnCAAccount.Visible = showHide;
      btnCAADelete.Visible = showHide;
      txtCAEmail.Enabled = showHide;
      divSearchID.Visible = showHide;
    }
    private string CurrentUserEmail()
    {
      HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
      FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
      return authTicket.Name;
    }
    private void AssigningValuesToControls(User user)
    {
      if (user != null)
      {
        txtUserID.Text = user.User_ID.ToString();
        txtCAEmail.Text = user.Email_Address;
        txtCAFirstName.Text = user.First_Name;
        txtCALastName.Text = user.Last_Name;
        txtCAGmailAddress.Text = user.Gmail;
        user.LockedDateTime = null;
        user.Retry_Attempts = 0;
        txtCAPassword.Text = user.Password;
        ddlCASecretQuestion.SelectedItem.Value = user.Secret_Question;
        txtCASecretAnswer.Text = user.Secret_Answer;
      }
    }
    private bool RecivingValuesFromControls(User users)
    {
      bool kamiyab = false;
      string gmail = txtCAGmailAddress.Text;
      if (txtCAPassword.Text == txtCAReTypePassword.Text && txtCAPassword.Text.Length > 7)
      {
        if (gmail.Substring(gmail.IndexOf("@".ToCharArray().First()), gmail.Length - gmail.IndexOf("@".ToCharArray().First())) == "@gmail.com")
        {
          users.First_Name = txtCAFirstName.Text;
          users.Last_Name = txtCALastName.Text;
          users.Gmail = txtCAGmailAddress.Text;
          users.IsLocked = false;
          users.LockedDateTime = null;
          users.Password = EncryptedPassword(txtCAPassword.Text);
          users.Retry_Attempts = 0;
          users.Secret_Question = ddlCASecretQuestion.Text;
          users.Secret_Answer = EncryptedPassword(txtCASecretAnswer.Text);
          kamiyab = true;
          ErrorMessageCreateAccount("Data has been Saved", true);
        }
        else
          ErrorMessageCreateAccount("Gmail Address is not Valid", true);
      }
      else ErrorMessageCreateAccount("Password Doesn't Match / Password must contains 8 character", true);
      return kamiyab;
    }
    //Create New Account
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        string currentuser = CurrentUserEmail();
        Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
        User user = dbContext.Users.FirstOrDefault(x => x.Email_Address == currentuser);
        if (currentuser == "Administrator")
          showHideControls(true);
        else
          showHideControls(false);
        AssigningValuesToControls(user);
      }
    }
    private void ErrorMessageCreateAccount(string Message, bool show)
    {
      if (show)
        divAlertCreateAccount.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
      else
        divAlertCreateAccount.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
      lblCAMessage.Text = Message;
    }
    protected void btnCAAccount_Click(object sender, EventArgs e)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      User user = dbContext.Users.FirstOrDefault(x => x.Email_Address == txtCAEmail.Text);
      if (user == null)
      {
        User newUser = new User();
        if (RecivingValuesFromControls(newUser))
        {
          newUser.Email_Address = txtCAEmail.Text;
          dbContext.Users.Add(newUser);
          dbContext.SaveChanges();
        }
      }
      else
        ErrorMessageCreateAccount("Email Address already Exsist, Please try another", true);
    }
    protected void btnCAAUpdateAccount_Click(object sender, EventArgs e)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
        string currentuser = CurrentUserEmail();
      User user = null;
      if (currentuser == "Administrator")
        user = dbContext.Users.FirstOrDefault(x => x.Email_Address == txtCAEmail.Text);
      else
        user = dbContext.Users.FirstOrDefault(x => x.Email_Address == currentuser);
      if (user != null)
      {
        if (RecivingValuesFromControls(user))
          dbContext.SaveChanges();
      }
    }
    protected void btnSearchID_Click(object sender, EventArgs e)
    {
      ErrorMessageCreateAccount("", false);
      int id = 0;
      if (int.TryParse(txtUserID.Text, out id))
      {
        Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
        User user = dbContext.Users.FirstOrDefault(x => x.User_ID == id);
        if (user != null)
          AssigningValuesToControls(user);
        else
          ErrorMessageCreateAccount(txtUserID.Text + " ID not Found", true);
      }
      else
      {
        ErrorMessageCreateAccount(txtUserID.Text + " is not Valid", true);
      }
    }
    protected void btnCAADelete_Click(object sender, EventArgs e)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      User user = dbContext.Users.FirstOrDefault(x => x.Email_Address == txtCAEmail.Text);
      if (user != null)
      {
        dbContext.Users.Remove(user);
        dbContext.SaveChanges();
        ErrorMessageCreateAccount(user.Email_Address + " has Deleted", true);
      }
      else
        ErrorMessageCreateAccount("No User is Deleted", true);
    }
  }
}