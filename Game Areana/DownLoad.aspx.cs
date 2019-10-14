using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web.UI;

namespace Game_Areana
{
    public partial class DownLoad : Page
    {
        public static string pages { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            bool IsgameExsist = false;
            if (!IsPostBack)
            {
                NameValueCollection nvc = Request.QueryString;
                if (!string.IsNullOrEmpty(nvc["Game_ID"]))
                {
                    int Game_ID = 0;
                    if (int.TryParse(nvc["Game_ID"], out Game_ID))
                    {
                        Games_Arena_DB_Context dbcontext = new Games_Arena_DB_Context();
                        int fileExsist = dbcontext.Games.Where(x => x.Game_ID == Game_ID).Count();
                        if (fileExsist == 0)
                            IsgameExsist = true;
                    }
                }
            }
            if(IsgameExsist)
                Response.Redirect("~/Category.aspx");
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            NameValueCollection nvc = Request.QueryString;
            if (!string.IsNullOrEmpty(nvc["Game_ID"]))
            {
                int Game_ID = 0;
                if (int.TryParse(nvc["Game_ID"], out Game_ID))
                {
                    Games_Arena_DB_Context dbcontext = new Games_Arena_DB_Context();
                    Game game = dbcontext.Games.FirstOrDefault(x => x.Game_ID == Game_ID);
                    if (game != null)
                    {
                        Response.Clear();
                        Response.ContentType = "application/octect-stream";
                        Response.AppendHeader("content-disposition", "filename=" + game.Game_Full_Name);
                        Response.TransmitFile("freeocr.exe");
                    }
                }
                else
                    Response.Redirect("~/Category.aspx");

            }
        }
    }
}