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
    public partial class iom_dtm_phase
    {
        public iom_dtm_phase()
        {
            this.iom_profile = new HashSet<iom_profile>();
        }
    
        public int phase { get; set; }
        public string description { get; set; }
        public Nullable<System.DateTime> field_start_date { get; set; }
        public Nullable<System.DateTime> field_end_date { get; set; }
        public int closed_YesNo { get; set; }
        public Nullable<System.DateTime> create_date { get; set; }
        public string created_by { get; set; }
        public Nullable<System.DateTime> update_date { get; set; }
        public string updated_by { get; set; }
    
        public virtual ICollection<iom_profile> iom_profile { get; set; }
    }
    
}
