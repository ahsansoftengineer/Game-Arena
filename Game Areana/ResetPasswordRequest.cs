//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Game_Areana
{
    using System;
    using System.Collections.Generic;
    
    public partial class ResetPasswordRequest
    {
        public System.Guid ID { get; set; }
        public int User_ID { get; set; }
        public Nullable<System.DateTime> RestRequestDateTime { get; set; }
    
        public virtual User User { get; set; }
    }
}
