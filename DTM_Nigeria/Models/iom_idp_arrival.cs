//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DTM_Nigeria.Models
{
    public partial class iom_idp_arrival
    {
        public int id { get; set; }
        public int profile_id { get; set; }
        public int year { get; set; }
        public Nullable<int> hh { get; set; }
        public Nullable<int> ind { get; set; }
        public string state_type { get; set; }
        public string location { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> create_time { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> update_time { get; set; }
    
        public virtual iom_profile iom_profile { get; set; }
        public virtual lkp_Location lkp_Location { get; set; }
        public virtual lkp_Period2 lkp_Period2 { get; set; }
        public virtual lkp_State lkp_State { get; set; }
    }
    
}
