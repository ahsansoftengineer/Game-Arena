using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Game_Areana
{
  public class CategoryClass
  {
    public int Game_ID { get; set; }
    public string Game_Full_Name { get; set; }
    public string Game_Short_Name { get; set; }
    public DateTime Upload_Date { get; set; }
    public string Game_Type { get; set; }
    public string Primary_Comment { get; set; }
    public byte[] Small_Image { get; set; }
    public static List<CategoryClass> Categories(string Search, string Page, int PageNo, int PageSize, out int TotalRows)
    {
      int totolrows = 0;
      List<CategoryClass> cats = new List<CategoryClass>();
      string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
      using (SqlConnection con = new SqlConnection(cs))
      {
        SqlCommand cmd = new SqlCommand("Sp_Vw_Category", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Search", Search);
        cmd.Parameters.AddWithValue("@Page", Page);
        cmd.Parameters.AddWithValue("@PageNo", PageNo);
        cmd.Parameters.AddWithValue("@PageSize", PageSize);
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        con.Open();
        SqlDataReader rdr = cmd.ExecuteReader();
        while (rdr.Read())
        {
          CategoryClass cc = new CategoryClass()
          {
            Game_ID = Convert.ToInt32(rdr["Game_ID"]),
            Game_Full_Name = rdr["Game_Full_Name"].ToString(),
            Game_Short_Name = rdr["Game_Short_Name"].ToString(),
            Upload_Date = Convert.ToDateTime(rdr["Upload_Date"]),
            Game_Type = rdr["Game_Type"].ToString(),
            Primary_Comment = rdr["Primary_Comment"].ToString(),
          };
          if(rdr["Small_Image"].ToString().Length > 0)
          {
            cc.Small_Image = (byte[])rdr["Small_Image"];
          }
          cats.Add(cc);
        }
        totolrows = (int)ds.Tables[1].Rows[0].ItemArray[0];
      }
      TotalRows = totolrows;
      return cats;
    }
  }
}