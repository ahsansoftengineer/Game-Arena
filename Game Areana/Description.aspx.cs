using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Game_Areana
{
    public partial class Description : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!initializeFields())
            {
                Response.Redirect("~/Category.aspx");
            }
        }
        public bool initializeFields()
        {
            bool result = false;
            try
            {
                NameValueCollection nameValueCollection = Request.QueryString;
                if (!string.IsNullOrEmpty(nameValueCollection["Game_ID"]))
                {
                    int ID = 0;
                    if (int.TryParse(nameValueCollection["Game_ID"], out ID))
                    {
                        Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
                        Game game = dbContext.Games.FirstOrDefault(x => x.Game_ID == ID);
                        if (game != null)
                        {
                            litGameName1.Text = game.Game_Full_Name;
                            litGameName2.Text = game.Game_Short_Name;
                            litGameName3.Text = game.Game_Full_Name;
                            litGameName4.Text = game.Game_Full_Name;
                            litGameName5.Text = game.Game_Short_Name;
                            litGameName6.Text = game.Game_Full_Name;
                            litGameName7.Text = game.Game_Short_Name;
                            litGameYear.Text = game.Release_Date.Value.ToString("yyyy");
                            litPrimaryComment.Text = game.Primary_Comment;
                            litDevComment1.Text = game.Developer_Comment_1;
                            litDevComment2.Text = game.Developer_Comment_2;
                            litWarning.Text = game.Warnings;
                            //Tech Specification
                            litTechGameVersion.Text = game.Tech_Spc.Game_Version;
                            litTechInterfaceLanguage.Text = game.Tech_Spc.Interface_Language;
                            litTechAudioLanguage.Text = game.Tech_Spc.Audio_Language;
                            litTechUploader.Text = game.Tech_Spc.Uploader;
                            litTechGameFileName.Text = game.Tech_Spc.Game_File_Name;
                            btnDownload.PostBackUrl = "~/DownLoad.aspx?Game=" + game.Tech_Spc.Game_File_Name;
                            litTechGameSize.Text = game.Tech_Spc.Game_Download_Size;
                            litTechMDSSUM.Text = game.Tech_Spc.MDSSUM;
                            //Minimum Specificaiton
                            litMinOS.Text = game.Min_Spc.OS;
                            litMinProcessor.Text = game.Min_Spc.Processor;
                            litMinMemory.Text = game.Min_Spc.Memory;
                            litMinGraphics.Text = game.Min_Spc.Graphics;
                            litMinDirectX.Text = game.Min_Spc.DirectX;
                            litMinStorage.Text = game.Min_Spc.Storage;
                            litMinSoundCard.Text = game.Min_Spc.Sound_Card;
                            //Recomended Specificaiton
                            litRecOS.Text = game.Rec_Spc.OS;
                            litRecProcessor.Text = game.Rec_Spc.Processor;
                            litRecMemory.Text = game.Rec_Spc.Memory;
                            litRecGraphics.Text = game.Rec_Spc.Graphics;
                            litRecDirectX.Text = game.Rec_Spc.DirectX;
                            litRecStorage.Text = game.Rec_Spc.Storage;
                            litRecSoundCard.Text = game.Rec_Spc.Sound_Card;
                            //Images
                            if (game.Game_Images.Large_Image_1 != null)
                                ImgCurrentGame1.ImageUrl = "data:Image/jpg;base64," + Convert.ToBase64String(game.Game_Images.Large_Image_1);
                            if (game.Game_Images.Large_Image_2 != null)
                                ImgCurrentGame2.ImageUrl = "data:Image/jpg;base64," + Convert.ToBase64String(game.Game_Images.Large_Image_2);
                            if (game.Game_Images.Large_Image_3 != null)
                                imgCurrentGame3.ImageUrl = "data:Image/jpg;base64," + Convert.ToBase64String(game.Game_Images.Large_Image_3);
                            if (game.Game_Images.Small_Image != null)
                                imgCurrentGame4.ImageUrl = "data:Image/jpg;base64," + Convert.ToBase64String(game.Game_Images.Large_Image_4);
                            //Related Links
                            string currentType = game.Game_Type.Split(",".ToCharArray().First()).First();
                            ViewState["CurrentType"] = currentType;
                            IQueryable<Game> relatedgame = dbContext.Games.Where(x => x.Game_Type.Contains(currentType)).Take(6);
                            rptrRelatedLinks.DataSource = relatedgame.ToList();
                            rptrRelatedLinks.DataBind();
                            result = true;
                        }
                    }
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }
        protected void rptrRelatedLinks_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Game game = (Game)e.Item.DataItem;
            ImageButton categoryImage = ((ImageButton)e.Item.FindControl("imgRelatedLink"));
            LinkButton lbCategoryPage = ((LinkButton)e.Item.FindControl("lbCategoryPage"));

            if (game.Game_Images.Small_Image != null)
                categoryImage.ImageUrl = "data:Image/jpg;base64," + Convert.ToBase64String(game.Game_Images.Small_Image);
            categoryImage.PostBackUrl = "~/Category.aspx?Page=" + ViewState["CurrentType"].ToString();
            lbCategoryPage.PostBackUrl = "~/Category.aspx?Page=" + ViewState["CurrentType"].ToString();
            lbCategoryPage.Text = game.Game_Full_Name;
        }
    }
}