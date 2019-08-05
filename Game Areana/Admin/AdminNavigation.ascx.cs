using System;
using System.Web.Security;

namespace Game_Areana.Admin
{
  public partial class AdminNavigation : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbSignIn_Click(object sender, EventArgs e)
    {
      FormsAuthentication.SignOut();
      Response.Redirect("~/Sign In.aspx");
    }
  }
}