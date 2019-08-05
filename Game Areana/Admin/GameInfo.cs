using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Linq;
using System.Collections.Generic;

namespace Game_Areana.Admin
{
  public partial class Admin2
  {
    private enum Operation
    {
      Delete,
      Insert,
      Update
    }
    //Game Information Specification
    private void GameInfo_Select(int Game_ID)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      Game game = dbContext.Games.FirstOrDefault(x => x.Game_ID == Game_ID);
      if (game != null)
      {
        txtGameFullName.Text = game.Game_Full_Name;
        txtGameShortName.Text = game.Game_Short_Name;
        txtGameCompany.Text = game.Company;
        dateRelease.Value = Convert.ToDateTime(game.Release_Date).ToString("yyyy-MM-dd");
        dateUploaded.Value = Convert.ToDateTime(game.Upload_Date).ToString("yyyy-MM-dd");
        txtGameMinSpecID.Text = game.Min_Spc_ID.ToString();
        txtGameRecSpecID.Text = game.Rec_Spc.Specification_ID.ToString();
        txtGamePrimaryComment.Text = game.Primary_Comment;
        txtGameWarning.Text = game.Warnings;
        txtGameComment1.Text = game.Developer_Comment_1;
        txtGameComment2.Text = game.Developer_Comment_2;
        string[] gamesTypes = game.Game_Type.Split(",".ToCharArray().FirstOrDefault());
        SettingRepeaterControl(gamesTypes);
        ErrorMessageGameInfo("", false);
      }
      else ErrorMessageGameInfo("ID = " + Game_ID + " Does not Exsist !", true);
    }
    //This Method is Selecting the Repeater Control
    private void SettingRepeaterControl(string[] gamesTypes)
    {
      foreach (RepeaterItem item in rptrPages.Items)
      {
        CheckBox ckb = (CheckBox)item.FindControl("ckbPages");
        if (gamesTypes.Contains(ckb.Text))
        {
          ckb.Checked = true;
          ckb.CssClass = "btn btn-primary btn-sm active";
        }
        else
        {
          ckb.Checked = false;
          ckb.CssClass = "btn btn-primary btn-sm";
        }
      }
    }
    //This Method Converting the Selected Items is Single String from Repeater Control for Inserting Updating in Database
    private void ErrorMessageGameInfo(string Message, bool show)
    {
      if (show)
        GameInfoMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
      else
        GameInfoMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
      lblGameInfoMessage.Text = Message;
    }
    private string ConvertListOfPagestoString(RepeaterItemCollection repeaterItemCollection)
    {
      List<string> pages = new List<string>();
      foreach (RepeaterItem item in repeaterItemCollection)
      {
        CheckBox ckb = (CheckBox)item.FindControl("ckbPages");
        if (ckb.Checked)
        {
          pages.Add(ckb.Text);
        }
      }
      return pages.Aggregate((x, y) => x + "," + y);
    }
    private void GameInfo_InsertUpdateDelete(int Game_ID, Operation operation)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      Game game = new Game();
      try
      {
        if (operation.ToString() == "Update" || operation.ToString() == "Delete")
          game = dbContext.Games.FirstOrDefault(x => x.Game_ID == Game_ID);
        if (operation.ToString() == "Update" || operation.ToString() == "Insert")
        {
          game.Game_Full_Name = txtGameFullName.Text;
          game.Game_Short_Name = txtGameShortName.Text;
          game.Company = txtGameCompany.Text;
          game.Release_Date = Convert.ToDateTime(dateRelease.Value);
          game.Upload_Date = DateTime.Now;
          game.Min_Spc_ID = Convert.ToInt32(txtGameMinSpecID.Text);
          game.Rec_Spc_ID = Convert.ToInt32(txtGameRecSpecID.Text);
          game.Primary_Comment = txtGamePrimaryComment.Text;
          game.Warnings = txtGameWarning.Text;
          game.Developer_Comment_1 = txtGameComment1.Text;
          game.Developer_Comment_2 = txtGameComment2.Text;
          game.Game_Type = ConvertListOfPagestoString(rptrPages.Items);
        }
        if (operation.ToString() == "Insert")
        {
          dbContext.Games.Add(game);
          dbContext.SaveChanges();
          txtGameID.Text = dbContext.Games.OrderByDescending(x => x.Game_ID).Select(x => x.Game_ID).FirstOrDefault().ToString();
        }
        else if (operation.ToString() == "Delete")
          dbContext.Games.Remove(game);

        dbContext.SaveChanges();
        ErrorMessageGameInfo("", false);
      }
      catch (Exception ex)
      {
        ErrorMessageGameInfo(ex.Message, true);
      }
    }
    private void BindNavigation()
    {
      DataSet navigation = new DataSet();
      navigation.ReadXml(Server.MapPath("~/XML Files/Navigation.xml"));
      rptrPages.DataSource = navigation.Tables["Nav"];
      rptrPages.DataBind();
    }
    protected void rptrNaviation_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      DataRow dr = ((DataRowView)e.Item.DataItem).Row;
      if (dr != null)
      {
        CheckBox ckb = ((CheckBox)e.Item.FindControl("ckbPages"));
        string group = dr["Group"].ToString();
        ckb.Text = dr["PageName"].ToString();
        ckb.CssClass = "btn btn-info btn-sm";
      }
    }
    protected void rptrPages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
      CheckBox ckb = (CheckBox)e.Item.FindControl("ckbPages");
      if (ckb.Enabled)
      {
        ckb.Enabled = false;
        ckb.CssClass = "btn btn-info btn-sm";
      }
      else
      {
        ckb.Enabled = true;
        ckb.CssClass = "btn btn-info btn-sm active";
      }
    }
    protected void btnGameID_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtGameID.Text, out ID))
      {
        TechSpc_Select(ID);
        GameImages_Select(ID);
        GameInfo_Select(ID);
      }
      else
      {
        ErrorMessageGameInfo("ID = " + txtGameID.Text + " Does not Exsist !", true);
        ErrorMessageImageUploads("ID = " + txtGameID.Text + " Does not Exsist !", true);
        ErrorMessageTechSpc("ID = " + txtGameID.Text + " Does not Exsist !", true);
      }
    }
    protected void btnGameInfoInsert_Click(object sender, EventArgs e)
    {
      GameInfo_InsertUpdateDelete(1, Operation.Insert);
    }
    protected void btnGameInfoUpdate_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtGameID.Text, out ID))
      {
        GameInfo_InsertUpdateDelete(ID, Operation.Update);
      }
      else ErrorMessageGameInfo("ID = " + txtGameID.Text + " Does not Exsist !", true);
    }
    protected void btnGameInfoDelete_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtGameID.Text, out ID))
      {
        GameInfo_InsertUpdateDelete(ID, Operation.Delete);
      }
      else ErrorMessageGameInfo("ID = " + txtGameID.Text + " Does not Exsist !", true);
    }
  }
}