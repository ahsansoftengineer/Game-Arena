using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Security;

namespace Game_Areana
{
    public partial class Sign_In : System.Web.UI.Page
    {
        private static string EncryptedPassword(string Passwords)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Passwords, "SHA1");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                upForgetPassword.Visible = false;
            }
        }
        //LogIn
        protected void btnCreateAccount_Click(object sender, EventArgs e)
        {
            upForgetPassword.Visible = false;
            upLogIn.Visible = false;
        }
        private void ErrorMessageLogIn(string Message, bool show)
        {
            if (show)
                divAlertLogInMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
            else
                divAlertLogInMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
            lblLIMessage.Text = Message;
        }
        private void UnlockedTheUser(User user)
        {
            user.Retry_Attempts = 0;
            user.IsLocked = false;
            user.LockedDateTime = null;
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
            User user = dbContext.Users.FirstOrDefault(x => x.Email_Address == txtLIUserName.Text);
            if (user != null)
            {
                if (user.LockedDateTime <= DateTime.Now)
                {
                    UnlockedTheUser(user);
                }
                if (user.IsLocked == false)
                {
                    if (user.Password == EncryptedPassword(txtLIPassword.Text))
                    {
                        UnlockedTheUser(user);
                        //Authenticate User and redirect to admin Page
                        FormsAuthentication.RedirectFromLoginPage(user.Email_Address, false);
                        ErrorMessageLogIn("Welcome", true);
                    }
                    else
                    {
                        if (user.Retry_Attempts == 3)
                        {
                            user.IsLocked = true;
                            user.Retry_Attempts = 0;
                            user.LockedDateTime = DateTime.Now.AddMinutes(1);
                            ErrorMessageLogIn("You have been locked by Admin till " + user.LockedDateTime, true);
                        }
                        else
                            ErrorMessageLogIn("Password Doesn't Match You have left (0" + (3 - user.Retry_Attempts) + ") Attempt(s)", true);
                        user.Retry_Attempts += 1;
                    }
                }
                else
                    ErrorMessageLogIn("You have been locked by Admin till " + user.LockedDateTime, true);
            }
            else
                ErrorMessageLogIn("User Name / Password Doesn't Match", true);
            dbContext.SaveChanges();
        }
        //Forget Password
        private static string SendRestPasswordEmails(string ToEmail, string UserName, string UniqueID)
        {

            //Mail Message class is present in System.Net.Mail;

            StringBuilder sb = new StringBuilder();
            sb.Append("<h1>Dear " + UserName + " </h1><br/><br/>");
            sb.Append("<i>Please Click on the following link to reset your password</i>");
            sb.Append("<br/>");
            sb.Append("<a href=http://localhost/Forms%20Authentication/Registration/ChangePassword.aspx?GUID=" + UniqueID + "> Goto Change Password + </a>");
            sb.Append("<br/><br/>");
            sb.Append("<h2>Game Arena</h2>");

            //Providing the Credential of User  but we don't have Access to Inter Net then we are only gonna send him to next page.
            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("ahsansoftengineer@gmail.com", "ahsan786@aam"),
            };
            // Composing Mail
            MailMessage mailMessage = new MailMessage("ahsansoftengineer@gmail.com", ToEmail)
            {
                IsBodyHtml = true,
                Subject = "Reset Your Password in Game Arena",
                Body = sb.ToString()
            };
            smtpClient.Send(mailMessage);
            return sb.ToString();
        }
        private void ErrorMessageForgetPassword(string Message, bool show)
        {
            if (show)
                divAlertForgetPassword.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
            else
                divAlertForgetPassword.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
            lblFPMessage.Text = Message;
        }
        protected void btnFPVerify_Click(object sender, EventArgs e)
        {
            Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
            User user = dbContext.Users.FirstOrDefault(x => x.Email_Address == txtFPUserName.Text);
            if (user != null)
            {
                if (user.LockedDateTime <= DateTime.Now)
                {
                    UnlockedTheUser(user);
                }
                if (user.IsLocked == false)
                {
                    if (ddlFPSecretQuestion.SelectedValue == "Select Option")
                    {
                        SendRestPasswordEmails(user.Gmail, user.First_Name + " " + user.Last_Name, user.User_ID.ToString());
                        ErrorMessageForgetPassword("The Email has been Sent to your Email Address", true);
                    }
                    else
                    {
                        if (user.Secret_Question == ddlFPSecretQuestion.SelectedValue && user.Secret_Answer == EncryptedPassword(txtFPSecretAnswer.Text))
                        {
                            Random random = new Random();
                            int randomNumber = random.Next(DateTime.Now.Second);
                            user.Password = EncryptedPassword(randomNumber + " Pakistan");
                            ErrorMessageForgetPassword("Your New Password is \"" + randomNumber + " Pakistan\"", true);
                            dbContext.SaveChanges();
                        }
                        else
                            ErrorMessageForgetPassword("Email and Secret Question / Answer Doesn't Match", true);
                    }
                }
                else
                    ErrorMessageForgetPassword("You have been locked by Admin till " + user.LockedDateTime, true);
            }
            else
                ErrorMessageForgetPassword("Email and Secret Question / Answer Doesn't Match", true);
        }
        protected void lbForgetPassword_Click(object sender, EventArgs e)
        {
            Games_Arena_DB_Context gameArena = new Games_Arena_DB_Context();
            User user = gameArena.Users.FirstOrDefault(x => x.Email_Address == txtLIUserName.Text);
            if (user != null)
            {
                lblLIMessage.Text = "";
                upForgetPassword.Visible = true;
                txtFPUserName.Text = txtLIUserName.Text;
                upLogIn.Visible = false;
            }
            else
            {
                lblLIMessage.Text = "Please Enter you correct user Name for change New Password";
            }

        }
    }
}