using System;
using System.Web.UI.WebControls;
using System.Data;

namespace Game_Areana
{
  public partial class GameArena : System.Web.UI.MasterPage
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        BindNavigation();
        BindAds();
      }
    }
    public Panel pnlContent
    {
      get { return pnlContentArea; }
      set { pnlContentArea = value; }
    }
    public Panel pnlAdvertisements
    {
      get { return pnlAdvertisement; }
      set { pnlAdvertisement = value; }
    }
    private void BindAds()
    {
      DataSet advertisement = new DataSet();
      advertisement.ReadXml(Server.MapPath("~/XML Files/Advertisement.xml"));
      AdRotator1.DataSource = advertisement.Tables["Ad1"];
      AdRotator1.DataBind();
      AdRotator2.DataSource = advertisement.Tables["Ad2"];
      AdRotator2.DataBind();
      AdRotator3.DataSource = advertisement.Tables["Ad3"];
      AdRotator3.DataBind();
      AdRotator4.DataSource = advertisement.Tables["Ad4"];
      AdRotator4.DataBind();
    }
    public static string currentPage { get; set; }
    private void BindNavigation()
    {
      DataSet navigation = new DataSet();
      navigation.ReadXml(Server.MapPath("~/XML Files/Navigation.xml"));
      rptrNaviation.DataSource = navigation.Tables["Nav"];
      rptrNaviation.DataBind();
      rptrDropDown.DataSource = navigation.Tables["Nav"];
      rptrDropDown.DataBind();
    }
    protected void rptrNaviation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      DataRow dr = ((DataRowView)e.Item.DataItem).Row;
      LinkButton lb = ((LinkButton)e.Item.FindControl("lbNavItem"));
      lb.Text = dr["PageName"].ToString();
      lb.CommandArgument = dr["PageName"].ToString();
      if (dr["Group"].ToString() == "MD")
      {
        lb.CssClass = "d-xl-block d-lg-block d-md-block d-sm-block  nav-link";
      }
      else if (dr["Group"].ToString() == "LG")
      {
        lb.CssClass = "d-xl-block d-lg-block d-md-none d-sm-block  nav-link ";
      }
      else if (dr["Group"].ToString() == "XL")
      {
        lb.CssClass = "d-xl-block d-lg-none d-md-none d-sm-none  nav-link ";
      }
      else
      {
        lb.CssClass = "d-xl-none d-lg-none d-md-none d-sm-none nav-link ";
      }
      if (lb.Text == currentPage)
      {
        lb.CssClass = lb.CssClass + " active";
      }
    }
    protected void rptrDropDown_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      DataRow dr = ((DataRowView)e.Item.DataItem).Row;
      LinkButton lb = ((LinkButton)e.Item.FindControl("lbNavItem"));
      lb.Text = dr["PageName"].ToString();
      lb.CommandArgument = dr["PageName"].ToString();
      if (dr["Group"].ToString() == "MD")
      {
        lb.CssClass = "d-xl-none d-lg-none d-md-none d-sm-none nav-link";
      }
      else if (dr["Group"].ToString() == "LG")
      {
        lb.CssClass = "d-xl-none d-lg-none d-md-block d-sm-none  nav-link";
      }
      else if (dr["Group"].ToString() == "XL")
      {
        lb.CssClass = "d-xl-none d-lg-block d-md-block d-sm-block nav-link";
      }
      else
      {
        lb.CssClass = "d-block nav-link ";
      }
      if (lb.Text == currentPage)
      {
        lb.CssClass = lb.CssClass + " active";
      }
    }
    protected void rptrNaviation_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      LinkButton lb = ((LinkButton)e.Item.FindControl("lbNavItem"));
      currentPage = lb.Text;
      BindNavigation();
      lb.CssClass = lb.CssClass + " active";
      if (Page is Category)
      {
        Category.Pages = lb.Text;
        Category.Search = "";
        Category.BindPagings = true;
        Category.PageNowClick = true;
      }
      else if (Page is Description || Page is DownLoad)
      {
        Response.Redirect("~/Category.aspx?Page=" + lb.Text);
      }

    }

  }
}