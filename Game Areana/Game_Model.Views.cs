//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: System.Data.Mapping.EntityViewGenerationAttribute(typeof(Edm_EntityMappingGeneratedViews.ViewsForBaseEntitySets3AEEA19D1182AF8A7C955E825E4AFB037CCD18EB9C39952434D02822D52A5CCF))]

namespace Edm_EntityMappingGeneratedViews
{
    
    
    /// <Summary>
    /// The type contains views for EntitySets and AssociationSets that were generated at design time.
    /// </Summary>
    public sealed class ViewsForBaseEntitySets3AEEA19D1182AF8A7C955E825E4AFB037CCD18EB9C39952434D02822D52A5CCF : System.Data.Mapping.EntityViewContainer
    {
        
        /// <Summary>
        /// The constructor stores the views for the extents and also the hash values generated based on the metadata and mapping closure and views.
        /// </Summary>
        public ViewsForBaseEntitySets3AEEA19D1182AF8A7C955E825E4AFB037CCD18EB9C39952434D02822D52A5CCF()
        {
            this.EdmEntityContainerName = "Game_Arena_DB_Context";
            this.StoreEntityContainerName = "Game_ModelStoreContainer";
            this.HashOverMappingClosure = "2aed61d6eec8b337e9c53475ca48c8a1a18c13c38217ce492bcd93ce26450e80";
            this.HashOverAllExtentViews = "baeb79e98c8d492ce15c0f84f1ce0deb1b45d6e778d2ed9aface0f5e545167bb";
            this.ViewCount = 8;
        }
        
        /// <Summary>
        /// The method returns the view for the index given.
        /// </Summary>
        protected override System.Collections.Generic.KeyValuePair<string, string> GetViewAt(int index)
        {
            if ((index == 0))
            {
                return GetView0();
            }
            if ((index == 1))
            {
                return GetView1();
            }
            if ((index == 2))
            {
                return GetView2();
            }
            if ((index == 3))
            {
                return GetView3();
            }
            if ((index == 4))
            {
                return GetView4();
            }
            if ((index == 5))
            {
                return GetView5();
            }
            if ((index == 6))
            {
                return GetView6();
            }
            if ((index == 7))
            {
                return GetView7();
            }
            throw new System.IndexOutOfRangeException();
        }
        
        /// <Summary>
        /// return view for Game_ModelStoreContainer.Game_Images
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView0()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_ModelStoreContainer.Game_Images", @"
    SELECT VALUE -- Constructing Game_Images
        [Game_Model.Store.Game_Images](T1.[Game_Images.Game_ID], T1.[Game_Images.Large_Image_1], T1.[Game_Images.Large_Image_2], T1.[Game_Images.Large_Image_3], T1.[Game_Images.Large_Image_4], T1.[Game_Images.Small_Image])
    FROM (
        SELECT 
            T.Game_ID AS [Game_Images.Game_ID], 
            T.Large_Image_1 AS [Game_Images.Large_Image_1], 
            T.Large_Image_2 AS [Game_Images.Large_Image_2], 
            T.Large_Image_3 AS [Game_Images.Large_Image_3], 
            T.Large_Image_4 AS [Game_Images.Large_Image_4], 
            T.Small_Image AS [Game_Images.Small_Image], 
            True AS _from0
        FROM Game_Arena_DB_Context.Game_Images AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_ModelStoreContainer.Games
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView1()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_ModelStoreContainer.Games", @"
    SELECT VALUE -- Constructing Games
        [Game_Model.Store.Games](T1.[Games.Game_ID], T1.[Games.Game_Full_Name], T1.[Games.Game_Short_Name], T1.[Games.Release_Date], T1.Games_Company, T1.[Games.Upload_Date], T1.[Games.Game_Type], T1.[Games.Min_Spc_ID], T1.[Games.Rec_Spc_ID], T1.[Games.Primary_Comment], T1.Games_Warnings, T1.[Games.Developer_Comment_1], T1.[Games.Developer_Comment_2])
    FROM (
        SELECT 
            T.Game_ID AS [Games.Game_ID], 
            T.Game_Full_Name AS [Games.Game_Full_Name], 
            T.Game_Short_Name AS [Games.Game_Short_Name], 
            T.Release_Date AS [Games.Release_Date], 
            T.Company AS Games_Company, 
            T.Upload_Date AS [Games.Upload_Date], 
            T.Game_Type AS [Games.Game_Type], 
            T.Min_Spc_ID AS [Games.Min_Spc_ID], 
            T.Rec_Spc_ID AS [Games.Rec_Spc_ID], 
            T.Primary_Comment AS [Games.Primary_Comment], 
            T.Warnings AS Games_Warnings, 
            T.Developer_Comment_1 AS [Games.Developer_Comment_1], 
            T.Developer_Comment_2 AS [Games.Developer_Comment_2], 
            True AS _from0
        FROM Game_Arena_DB_Context.Games AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_ModelStoreContainer.Specifications
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView2()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_ModelStoreContainer.Specifications", @"
    SELECT VALUE -- Constructing Specifications
        [Game_Model.Store.Specifications](T1.[Specifications.Specification_ID], T1.Specifications_OS, T1.Specifications_Processor, T1.Specifications_Memory, T1.Specifications_Graphics, T1.Specifications_DirectX, T1.Specifications_Storage, T1.[Specifications.Sound_Card])
    FROM (
        SELECT 
            T.Specification_ID AS [Specifications.Specification_ID], 
            T.OS AS Specifications_OS, 
            T.Processor AS Specifications_Processor, 
            T.Memory AS Specifications_Memory, 
            T.Graphics AS Specifications_Graphics, 
            T.DirectX AS Specifications_DirectX, 
            T.Storage AS Specifications_Storage, 
            T.Sound_Card AS [Specifications.Sound_Card], 
            True AS _from0
        FROM Game_Arena_DB_Context.Specifications AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_ModelStoreContainer.Specifications_Technical
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView3()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_ModelStoreContainer.Specifications_Technical", @"
    SELECT VALUE -- Constructing Specifications_Technical
        [Game_Model.Store.Specifications_Technical](T1.[Specifications_Technical.Game_ID], T1.[Specifications_Technical.Game_Version], T1.[Specifications_Technical.Interface_Language], T1.[Specifications_Technical.Audio_Language], T1.[Specifications_Technical.Uploader], T1.[Specifications_Technical.Game_File_Name], T1.[Specifications_Technical.Game_Download_Size], T1.[Specifications_Technical.MDSSUM])
    FROM (
        SELECT 
            T.Game_ID AS [Specifications_Technical.Game_ID], 
            T.Game_Version AS [Specifications_Technical.Game_Version], 
            T.Interface_Language AS [Specifications_Technical.Interface_Language], 
            T.Audio_Language AS [Specifications_Technical.Audio_Language], 
            T.Uploader AS [Specifications_Technical.Uploader], 
            T.Game_File_Name AS [Specifications_Technical.Game_File_Name], 
            T.Game_Download_Size AS [Specifications_Technical.Game_Download_Size], 
            T.MDSSUM AS [Specifications_Technical.MDSSUM], 
            True AS _from0
        FROM Game_Arena_DB_Context.Specifications_Technical AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_Arena_DB_Context.Game_Images
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView4()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_Arena_DB_Context.Game_Images", @"
    SELECT VALUE -- Constructing Game_Images
        [Game_Model.Game_Images](T1.[Game_Images.Game_ID], T1.[Game_Images.Large_Image_1], T1.[Game_Images.Large_Image_2], T1.[Game_Images.Large_Image_3], T1.[Game_Images.Large_Image_4], T1.[Game_Images.Small_Image])
    FROM (
        SELECT 
            T.Game_ID AS [Game_Images.Game_ID], 
            T.Large_Image_1 AS [Game_Images.Large_Image_1], 
            T.Large_Image_2 AS [Game_Images.Large_Image_2], 
            T.Large_Image_3 AS [Game_Images.Large_Image_3], 
            T.Large_Image_4 AS [Game_Images.Large_Image_4], 
            T.Small_Image AS [Game_Images.Small_Image], 
            True AS _from0
        FROM Game_ModelStoreContainer.Game_Images AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_Arena_DB_Context.Games
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView5()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_Arena_DB_Context.Games", @"
    SELECT VALUE -- Constructing Games
        [Game_Model.Game](T1.[Game.Game_ID], T1.[Game.Game_Full_Name], T1.[Game.Game_Short_Name], T1.[Game.Release_Date], T1.Game_Company, T1.[Game.Upload_Date], T1.[Game.Game_Type], T1.[Game.Min_Spc_ID], T1.[Game.Rec_Spc_ID], T1.[Game.Primary_Comment], T1.Game_Warnings, T1.[Game.Developer_Comment_1], T1.[Game.Developer_Comment_2])
    FROM (
        SELECT 
            T.Game_ID AS [Game.Game_ID], 
            T.Game_Full_Name AS [Game.Game_Full_Name], 
            T.Game_Short_Name AS [Game.Game_Short_Name], 
            T.Release_Date AS [Game.Release_Date], 
            T.Company AS Game_Company, 
            T.Upload_Date AS [Game.Upload_Date], 
            T.Game_Type AS [Game.Game_Type], 
            T.Min_Spc_ID AS [Game.Min_Spc_ID], 
            T.Rec_Spc_ID AS [Game.Rec_Spc_ID], 
            T.Primary_Comment AS [Game.Primary_Comment], 
            T.Warnings AS Game_Warnings, 
            T.Developer_Comment_1 AS [Game.Developer_Comment_1], 
            T.Developer_Comment_2 AS [Game.Developer_Comment_2], 
            True AS _from0
        FROM Game_ModelStoreContainer.Games AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_Arena_DB_Context.Specifications
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView6()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_Arena_DB_Context.Specifications", @"
    SELECT VALUE -- Constructing Specifications
        [Game_Model.Specification](T1.[Specification.Specification_ID], T1.Specification_OS, T1.Specification_Processor, T1.Specification_Memory, T1.Specification_Graphics, T1.Specification_DirectX, T1.Specification_Storage, T1.[Specification.Sound_Card])
    FROM (
        SELECT 
            T.Specification_ID AS [Specification.Specification_ID], 
            T.OS AS Specification_OS, 
            T.Processor AS Specification_Processor, 
            T.Memory AS Specification_Memory, 
            T.Graphics AS Specification_Graphics, 
            T.DirectX AS Specification_DirectX, 
            T.Storage AS Specification_Storage, 
            T.Sound_Card AS [Specification.Sound_Card], 
            True AS _from0
        FROM Game_ModelStoreContainer.Specifications AS T
    ) AS T1");
        }
        
        /// <Summary>
        /// return view for Game_Arena_DB_Context.Specifications_Technical
        /// </Summary>
        private System.Collections.Generic.KeyValuePair<string, string> GetView7()
        {
            return new System.Collections.Generic.KeyValuePair<string, string>("Game_Arena_DB_Context.Specifications_Technical", @"
    SELECT VALUE -- Constructing Specifications_Technical
        [Game_Model.Specifications_Technical](T1.[Specifications_Technical.Game_Version], T1.[Specifications_Technical.Interface_Language], T1.[Specifications_Technical.Audio_Language], T1.[Specifications_Technical.Uploader], T1.[Specifications_Technical.Game_File_Name], T1.[Specifications_Technical.Game_Download_Size], T1.[Specifications_Technical.MDSSUM], T1.[Specifications_Technical.Game_ID])
    FROM (
        SELECT 
            T.Game_Version AS [Specifications_Technical.Game_Version], 
            T.Interface_Language AS [Specifications_Technical.Interface_Language], 
            T.Audio_Language AS [Specifications_Technical.Audio_Language], 
            T.Uploader AS [Specifications_Technical.Uploader], 
            T.Game_File_Name AS [Specifications_Technical.Game_File_Name], 
            T.Game_Download_Size AS [Specifications_Technical.Game_Download_Size], 
            T.MDSSUM AS [Specifications_Technical.MDSSUM], 
            T.Game_ID AS [Specifications_Technical.Game_ID], 
            True AS _from0
        FROM Game_ModelStoreContainer.Specifications_Technical AS T
    ) AS T1");
        }
    }
}
