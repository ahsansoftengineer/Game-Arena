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
    
    public partial class User
    {
        public User()
        {
            this.ResetPasswordRequests = new HashSet<ResetPasswordRequest>();
        }
    
        public int User_ID { get; set; }
        public string Email_Address { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Secret_Question { get; set; }
        public string Secret_Answer { get; set; }
        public string Gmail { get; set; }
        public string Password { get; set; }
        public Nullable<int> Retry_Attempts { get; set; }
        public Nullable<bool> IsLocked { get; set; }
        public Nullable<System.DateTime> LockedDateTime { get; set; }
    
        public virtual ICollection<ResetPasswordRequest> ResetPasswordRequests { get; set; }
    }
}