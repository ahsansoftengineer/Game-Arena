using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Areana.Admin
{
  public partial class Admin2 : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindNavigation();
      }
      ScriptManager1.RegisterPostBackControl(btnImgUpdate);
      ScriptManager1.RegisterPostBackControl(btnTechSpcUpdate);
    }
  }
}