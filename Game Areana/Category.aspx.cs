using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Data.Objects;
using System.Windows.Forms;

namespace Game_Areana
{
  public partial class Category : Page
  {
    public static string Pages { get; set; }
    public static string Search { get; set; }
    public static bool PageNowClick { get; set; }
    public static bool BindPagings { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        Master.pnlAdvertisements.CssClass = "col-xs-12 col-sm-12 col-md-4 col-lg-4";
        Master.pnlAdvertisements.Visible = true;
        Master.pnlContent.CssClass = "col-xs-12 col-sm-12 col-md-8 col-lg-8";
        NameValueCollection nvc = Request.QueryString;
        Pages = "";
        Search = "";
        BindPagings = true;
        PageNowClick = false;
        if (nvc["Page"] != null)
        {
          Pages = nvc["Page"];
        }
        InitializeCategory(1, 1, true);
      }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
      if (BindPagings)
      {
        if (Pages != "" || Search != "")
          InitializeCategory(1, 1, true);
      }
    }
    public void InitializeCategory(int PageNo, int GroupNo, bool bindingPagingIsRequired)
    {
      List<CategoryClass> category = new List<CategoryClass>();
      int totalRows = 0;
      int PageSize = 10;
      int.TryParse(ConfigurationManager.AppSettings["PageSize"], out PageSize);

      if (Pages != "")
      {
        category = CategoryClass.Categories(Search, Pages, PageNo, PageSize, out totalRows);
        litSearchResult.Text = "(" + totalRows + ") Games Available in <b style=\"color:LimeGreen;\">\"" + Pages + "\"</b>";
        if (PageNowClick)
        {
          lbNext.CommandArgument = "1";
          lbPrevious.CommandArgument = "1";
          PageNowClick = false;
        }
      }
      else if (Search != "")
      {
        category = CategoryClass.Categories(Search, Pages, PageNo, PageSize, out totalRows);
        litSearchResult.Text = "(" + totalRows + ") Games Found for <b style=\"color:Red;\">\"" + Search + "\"</b>";
      }
      else
      {
        category = CategoryClass.Categories(Search, Pages, PageNo, PageSize, out totalRows);
        litSearchResult.Text = "";
      }
      //Binding Paging
      if (bindingPagingIsRequired)
      {
        BindPaging(totalRows, GroupNo);
        foreach (RepeaterItem cc in rptrPaging.Controls)
        {
          HtmlControl lisControl = (HtmlControl)cc.FindControl("li_paging");
          lisControl.Attributes["class"] = "page-item active";
          break;
        }
      }
      rptrCategory.DataSource = category.ToList();
      rptrCategory.DataBind();
    }
    //Related Games
    protected void rptrCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      CategoryClass category = (CategoryClass)e.Item.DataItem;
      ImageButton categoryImage = ((ImageButton)e.Item.FindControl("ImgSmallImage"));
      if (category.Small_Image != null)
        categoryImage.ImageUrl = "data:Image/jpg;base64," + Convert.ToBase64String(category.Small_Image);
      categoryImage.PostBackUrl = "~/Description.aspx?Game_ID=" + category.Game_ID;
      LinkButton lbGameHeading = ((LinkButton)e.Item.FindControl("lbGameName"));
      lbGameHeading.Text = category.Game_Full_Name;
      lbGameHeading.PostBackUrl = "~/Description.aspx?Game_ID=" + category.Game_ID;
      ((Literal)e.Item.FindControl("litUploadDate")).Text = CalculatedDuration(category.Upload_Date);
      ((Literal)e.Item.FindControl("litPrimaryComment")).Text = category.Primary_Comment;
      Repeater rptr = ((Repeater)e.Item.FindControl("rptrType"));
      rptr.DataSource = category.Game_Type.Split(",".ToCharArray().First());
      rptr.DataBind();
    }
    protected void rptrType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      string type = ((string)e.Item.DataItem);
      LinkButton lbtype = ((LinkButton)e.Item.FindControl("lbType"));
      lbtype.Text = type;
    }
    private string CalculatedDuration(DateTime uploadDate)
    {
      string Duration = "";
      if (DateTime.Now > uploadDate.AddMonths(12))
        Duration = Convert.ToInt32((DateTime.Now.Year - uploadDate.Year).ToString()) + " Year Ago";
      else if (DateTime.Now > uploadDate.AddMonths(1))
        Duration = Convert.ToInt32((DateTime.Now - uploadDate).TotalDays / 30).ToString() + " Months Ago";
      else if (DateTime.Now > uploadDate.AddDays(7))
        Duration = Convert.ToInt32((DateTime.Now - uploadDate).Days / 7).ToString() + " Weeks Ago";
      else if (DateTime.Now > uploadDate.AddHours(24))
        Duration = Convert.ToInt32((DateTime.Now - uploadDate).Days).ToString() + " Days Ago";
      else if (DateTime.Now > uploadDate.AddMinutes(60))
        Duration = Convert.ToInt32((DateTime.Now - uploadDate).Hours).ToString() + " Hours Ago";
      else if (DateTime.Now > uploadDate.AddSeconds(60))
        Duration = Convert.ToInt32((DateTime.Now - uploadDate).Minutes).ToString() + " Minutes Ago";
      else
        Duration = "Just Now";
      return Duration;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
      Search = txtSearch.Text;
      Pages = "";
      BindPagings = true;
      lbPrevious.CommandArgument = "1";
      lbNext.CommandArgument = "1";
    }
    //Paging
    private void BindPaging(int TotalRows, int GroupNo)
    {
      int PageSize = 10;
      int GroupSize = 10;
      int.TryParse(ConfigurationManager.AppSettings["PageSize"], out PageSize);
      int.TryParse(ConfigurationManager.AppSettings["GroupSize"], out GroupSize);
      List<int> PageItem = new List<int>();
      int Pages = (TotalRows / PageSize);
      if (TotalRows % PageSize != 0)
        Pages++;
      int startingGroupIndex = ((GroupNo - 1) * GroupSize) + 1;
      int count = 1;
      for (int i = startingGroupIndex; i <= Pages; i++)
      {
        if (count <= GroupSize)
        {
          PageItem.Add(i);
          if (i == Pages)
            Next.Attributes["class"] = "page-item disabled";
        }
        else
        {
          Next.Attributes["class"] = "page-item";
          break;
        }
        count++;
      }
      if (startingGroupIndex > 1)
        Previous.Attributes["class"] = "page-item";
      else
        Previous.Attributes["class"] = "page-item disabled";

      rptrPaging.DataSource = PageItem;
      rptrPaging.DataBind();
    }
    protected void rptrPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      int PageNo = ((int)e.Item.DataItem);
      LinkButton lbPageNo = ((LinkButton)e.Item.FindControl("lbPageNo"));
      lbPageNo.Text = PageNo.ToString();
    }
    protected void rptrPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      foreach (RepeaterItem cc in rptrPaging.Controls)
      {
        HtmlControl lisControl = (HtmlControl)cc.FindControl("li_paging");
        lisControl.Attributes["class"] = "page-item";
      }
      LinkButton lb = ((LinkButton)e.Item.FindControl("lbPageNo"));
      HtmlControl liControl = (HtmlControl)e.Item.FindControl("li_paging");
      liControl.Attributes["class"] = "page-item active";
      int PageNo = Convert.ToInt32(lb.Text);
      int groupNo = Convert.ToInt32(lbPrevious.CommandArgument);
      InitializeCategory(PageNo, groupNo, false);
      BindPagings = false;
    }
    protected void lbPreviousNext_Command(object sender, CommandEventArgs e)
    {
      LinkButton lbpreviousNext = ((LinkButton)sender);
      int GroupNo = Convert.ToInt32(lbpreviousNext.CommandArgument);
      int pageSize = Convert.ToInt32(ConfigurationManager.AppSettings["PageSize"]);
      int GroupSize = Convert.ToInt32(ConfigurationManager.AppSettings["GroupSize"]);
      if (lbpreviousNext == lbPrevious)
        GroupNo--;
      else
        GroupNo++;
      lbPrevious.CommandArgument = GroupNo.ToString();
      lbNext.CommandArgument = GroupNo.ToString();
      int pageNo = ((GroupNo - 1) * GroupSize) + 1;
      BindPagings = false;
      InitializeCategory(pageNo, GroupNo, true);
    }
    protected void lbType_Click(object sender, EventArgs e)
    {
      Pages = ((LinkButton)sender).Text;
      InitializeCategory(1, 1, true);
    }
  }
}