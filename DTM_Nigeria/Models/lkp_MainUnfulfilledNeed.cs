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
    public partial class lkp_MainUnfulfilledNeed
    {
        public lkp_MainUnfulfilledNeed()
        {
            this.iom_ward_presence_per_location = new HashSet<iom_ward_presence_per_location>();
        }
    
        public int id { get; set; }
        public string value { get; set; }
    
        public virtual ICollection<iom_ward_presence_per_location> iom_ward_presence_per_location { get; set; }
    }
    
}