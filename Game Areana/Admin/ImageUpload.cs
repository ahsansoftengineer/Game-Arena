using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace Game_Areana.Admin
{
  public partial class Admin2
  {
    private void ErrorMessageImageUploads(string Message, bool show)
    {
      if (show)
      {
        ImagesMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
        lblImagesMessage.Text = Message;
      }
      else
      {
        ImagesMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
      }

    }
    private string ConvertBytesToImage(byte[] bytes)
    {
      return "data:Image/j pg;base64," + Convert.ToBase64String(bytes);
    }
    private void GameImages_Select(int Game_ID)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      Game_Images game_Images = dbContext.Game_Images.FirstOrDefault(x => x.Game_ID == Game_ID);
      if (game_Images != null)
      {
        Image1.ImageUrl = "";
        Image2.ImageUrl = "";
        Image3.ImageUrl = "";
        Image4.ImageUrl = "";
        Image5.ImageUrl = "";
        if (game_Images.Large_Image_1 != null)
          Image1.ImageUrl = ConvertBytesToImage(game_Images.Large_Image_1);
        if (game_Images.Large_Image_2 != null)
          Image2.ImageUrl = ConvertBytesToImage(game_Images.Large_Image_2);
        if (game_Images.Large_Image_3 != null)
          Image3.ImageUrl = ConvertBytesToImage(game_Images.Large_Image_3);
        if (game_Images.Large_Image_4 != null)
          Image4.ImageUrl = ConvertBytesToImage(game_Images.Large_Image_4);
        if (game_Images.Small_Image != null)
          Image5.ImageUrl = ConvertBytesToImage(game_Images.Small_Image);
        ErrorMessageImageUploads("", false);
      }
      else ErrorMessageImageUploads("ID = " + Game_ID + " Does not Exsist !", true);
    }
    private byte[] ConvertImageToByte(HttpPostedFile postedFile)
    {
      Stream stream = postedFile.InputStream;
      BinaryReader binaryReader = new BinaryReader(stream);
      return binaryReader.ReadBytes((int)stream.Length);
    }
    private bool ValidateFileUpload(HttpPostedFile postedFile, out string ErrorMessage)
    {
      bool validation = false;
      ErrorMessage = "";
      if (postedFile != null)
      {
        string fileName = Path.GetFileName(postedFile.FileName);
        string fileExtension = Path.GetExtension(fileName);
        int fileSize = postedFile.ContentLength;
        fileExtension = fileExtension.ToLower();
        string[] imagetype = new string[] { ".jpg", ".jpeg", ".png" };
        if (imagetype.Contains(fileExtension))
        {
          if (fileSize < 1048576)
            validation = true;
          else
            ErrorMessage += postedFile.ContentLength + " = File Size is Greater than 1048576 bytes (1 MB) <br />";
        }
        else
          ErrorMessage += Path.GetExtension(postedFile.FileName) + " = File Type is not .jpg | .jpeg | .png <br />";
      }
      return validation;
    }
    protected void btnImgUpdate_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtGameID.Text, out ID))
      {
        Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
        StringBuilder errorMessage = new StringBuilder();
        string message;
        Game_Images game_Images = null;
        try
        {
          game_Images = dbContext.Game_Images.FirstOrDefault(x => x.Game_ID == ID);
          if (ValidateFileUpload(fu_Game_Images_1.PostedFile, out message))
            game_Images.Large_Image_1 = ConvertImageToByte(fu_Game_Images_1.PostedFile);
          errorMessage.Append(message);
          if (ValidateFileUpload(fu_Game_Images_2.PostedFile, out message))
            game_Images.Large_Image_2 = ConvertImageToByte(fu_Game_Images_2.PostedFile);
          errorMessage.Append(message);
          if (ValidateFileUpload(fu_Game_Images_3.PostedFile, out message))
            game_Images.Large_Image_3 = ConvertImageToByte(fu_Game_Images_3.PostedFile);
          errorMessage.Append(message);
          if (ValidateFileUpload(fu_Game_Images_4.PostedFile, out message))
            game_Images.Large_Image_4 = ConvertImageToByte(fu_Game_Images_4.PostedFile);
          errorMessage.Append(message);
          if (ValidateFileUpload(fu_Game_Images_5.PostedFile, out message))
            game_Images.Small_Image = ConvertImageToByte(fu_Game_Images_5.PostedFile);
          errorMessage.Append(message);
          dbContext.SaveChanges();
          if (errorMessage.Length > 10)
            ErrorMessageImageUploads(errorMessage.ToString(), true);
          else
            ErrorMessageImageUploads("", false);
          GameImages_Select(ID);
        }
        catch (Exception ex)
        {
          ErrorMessageImageUploads(ex.Message, true);
        }
      }
      else
        ErrorMessageImageUploads("ID = " + txtGameID.Text + " Does not Exsist !", true);
    }
  }
}