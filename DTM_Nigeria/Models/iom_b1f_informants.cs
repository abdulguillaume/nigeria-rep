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
    public partial class iom_b1f_informants
    {
        public int id { get; set; }
        public int informant { get; set; }
        public int profile_id { get; set; }
        public string contact_details { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> create_time { get; set; }
        public string updated_by { get; set; }
        public Nullable<System.DateTime> update_time { get; set; }
    
        public virtual iom_informants iom_informants { get; set; }
        public virtual iom_profile iom_profile { get; set; }
    }
    
}
