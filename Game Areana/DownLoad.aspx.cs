using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI;

namespace Game_Areana
{
  public partial class DownLoad : Page
  {
    public static string pages { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        NameValueCollection nvc = Request.QueryString;
        if (!string.IsNullOrEmpty(nvc["Game"]))
        {
          string GameName = nvc["Game"];
          Games_Arena_DB_Context dbcontext = new Games_Arena_DB_Context();
          int fileExsist = dbcontext.Specifications_Technical.Where(x => x.Game_File_Name == GameName).Count();
          if (fileExsist == 0)
            Response.Redirect("~/Category.aspx");
        }
        else
        {
          Response.Redirect("~/Category.aspx");
        }
      }
    }
    protected void btnDownload_Click(object sender, EventArgs e)
    {
      NameValueCollection nvc = Request.QueryString;
      if (!string.IsNullOrEmpty(nvc["Game"]))
      {
        string GameName = nvc["Game"];
        Games_Arena_DB_Context dbcontext = new Games_Arena_DB_Context();
        int fileExsist = dbcontext.Specifications_Technical.Where(x => x.Game_File_Name == GameName).Count();
        if (fileExsist > 0)
        {
          Response.Clear();
          Response.ContentType = "application/octect-stream";
          Response.AppendHeader("content-disposition", "filename=" + GameName);
          Response.TransmitFile(Server.MapPath("~/Games/") + GameName);
        }
      }
    }
  }
}