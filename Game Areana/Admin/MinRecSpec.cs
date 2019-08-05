using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Game_Areana.Admin
{
  public partial class Admin2
  {
    //Min Max Specification
    private void ErrorMessageMinRecSpc(string Message, bool Show)
    {
      if (Show)
      {
        SpcMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade show mt-3";
        lblSpcMessage.Text = Message;
      }
      else
      {
        SpcMessage.Attributes["class"] = "alert alert-danger alert-dismissible fade mt-3 position-absolute";
      }

    }
    private void MinSpc_Select(int Spc_ID)
    {
      Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
      Specification spc = dbContext.Specifications.FirstOrDefault(x => x.Specification_ID == Spc_ID);
      if (spc != null)
      {
        txtMinRecSpcDirectX.Text = spc.DirectX;
        txtMinRecSpcGraphics.Text = spc.Graphics;
        txtMinRecSpcMemory.Text = spc.Memory;
        txtMinRecSpcOS.Text = spc.OS;
        txtMinRecSpcProcessor.Text = spc.Processor;
        txtMinRecSpcSoundCard.Text = spc.Sound_Card;
        txtMinRecSpcStorage.Text = spc.Storage;
        ErrorMessageMinRecSpc("", false);
      }
      else ErrorMessageMinRecSpc("ID = " + Spc_ID + " Does not Exsist !", true);
    }
    private void MinSpc_InsertUpdateDelete(int Spc_ID, Operation operation)
    {
      try
      {
        Games_Arena_DB_Context dbContext = new Games_Arena_DB_Context();
        Specification spc = null;
        if (operation.ToString() == "Update" || operation.ToString() == "Delete")
          spc = dbContext.Specifications.FirstOrDefault(x => x.Specification_ID == Spc_ID);
        else if (operation.ToString() == "Insert")
        {
          spc = new Specification();
        }
        if (operation.ToString() == "Update" || operation.ToString() == "Insert")
        {
          spc.DirectX = txtMinRecSpcDirectX.Text;
          spc.Graphics = txtMinRecSpcGraphics.Text;
          spc.Memory = txtMinRecSpcMemory.Text;
          spc.OS = txtMinRecSpcOS.Text;
          spc.Processor = txtMinRecSpcProcessor.Text;
          spc.Sound_Card = txtMinRecSpcSoundCard.Text;
          spc.Storage = txtMinRecSpcStorage.Text;
        }
        if (operation.ToString() == "Insert")
          dbContext.Specifications.Add(spc);
        else if (operation.ToString() == "Delete")
          dbContext.Specifications.Remove(spc);
        dbContext.SaveChanges();
        ErrorMessageMinRecSpc("", false);
      }
      catch (Exception ex)
      {
        ErrorMessageMinRecSpc(ex.Message, true);
      }
    }
    protected void btnSpecSearch_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtSpcID.Text, out ID))
        MinSpc_Select(ID);
      else ErrorMessageMinRecSpc("ID = " + txtSpcID.Text + " Does not Exsist !", true);
    }
    protected void btnSpcInsert_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtSpcID.Text, out ID))
        MinSpc_InsertUpdateDelete(ID, Operation.Insert);
      else
        ErrorMessageMinRecSpc("ID = " + txtSpcID.Text + " Does not Exsist !", true);
    }
    protected void btnSpcUpdate_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtSpcID.Text, out ID))
        MinSpc_InsertUpdateDelete(ID, Operation.Update);
      else
        ErrorMessageMinRecSpc("ID = " + txtSpcID.Text + " Does not Exsist !", true);
    }
    protected void btnSpcDelete_Click(object sender, EventArgs e)
    {
      int ID = 0;
      if (int.TryParse(txtSpcID.Text, out ID))
        MinSpc_InsertUpdateDelete(ID, Operation.Delete);
      else
        ErrorMessageMinRecSpc("ID = " + txtSpcID.Text + " Does not Exsist !", true);
    }
  }
}