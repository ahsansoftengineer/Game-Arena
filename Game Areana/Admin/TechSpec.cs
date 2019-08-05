using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Game_Areana.Admin
{
  public partial class Admin2
  {
    private void ErrorMessageTechSpc(string Message, bool show)
    {
      if (show)
        TechSpcMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
      else
        TechSpcMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
      lblTechSpcMessage.Text = Message;
    }
    private void TechSpc_Select(int Game_ID)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      Specifications_Technical Tech_spc = dbContext.Specifications_Technical.FirstOrDefault(x => x.Game_ID == Game_ID);
      if (Tech_spc != null)
      {
        txtTSAudioLanguage.Text = Tech_spc.Audio_Language;
        txtTSGameSize.Text = Tech_spc.Game_Download_Size;
        txtTSGameVersion.Text = Tech_spc.Game_Version;
        txtTSInterfaceLanguage.Text = Tech_spc.Interface_Language;
        txtTSMDSSUM.Text = Tech_spc.MDSSUM;
        txtTSUploader.Text = Tech_spc.Uploader;
        ErrorMessageTechSpc("", false);
      }
      else ErrorMessageTechSpc("ID = " + Game_ID + " Does not Exsist !", true);
    }
    private string ComputeFileSize(long fileSize)
    {
      if (fileSize < 1024)
        return (fileSize) + " Byte";
      else if (fileSize < (1024 * 1024))
        return (fileSize / 1024) + " KB";
      else if (fileSize < (1024 * 1024 * 1024))
        return ((fileSize / 1024) / 1024) + " MB";
      else
        return ((((fileSize / 1024) / 1024) / 1024)) + " GB";
    }
    protected void btnTechSpcUpdate_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtGameID.Text, out ID))
      {
        Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
        Specifications_Technical Tech_spc = null;
        try
        {
          //File Size must be Less than 5 GB
          if (fuGameFileName.FileContent.Length < 5368709120)
          {
            Tech_spc = dbContext.Specifications_Technical.FirstOrDefault(x => x.Game_ID == ID);
            if (fuGameFileName.HasFile)
            {
              string extension = Path.GetExtension(fuGameFileName.FileName);
              Tech_spc.Game_Download_Size = ComputeFileSize(fuGameFileName.FileContent.Length);
              fuGameFileName.SaveAs(Server.MapPath("~/Games/" + txtGameID.Text + " - " + txtGameShortName.Text + extension));
              Tech_spc.Game_File_Name = txtGameID.Text + " - " + txtGameShortName.Text + extension;
            }
            Tech_spc.Audio_Language = txtTSAudioLanguage.Text;
            Tech_spc.Game_Version = txtTSGameVersion.Text;
            Tech_spc.Interface_Language = txtTSInterfaceLanguage.Text;
            Tech_spc.MDSSUM = txtTSMDSSUM.Text;
            Tech_spc.Uploader = txtTSUploader.Text;
            dbContext.SaveChanges();
            TechSpc_Select(ID);
            ErrorMessageTechSpc("", false);
          }
        }
        catch (Exception ex)
        {
          ErrorMessageTechSpc(ex.Message, true);
        }
      }
      else ErrorMessageTechSpc("ID = " + txtGameID.Text + " Does not Exsist !", true);
    }
  }
}
