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
    public partial class lkp_NotReturnLocation
    {
        public lkp_NotReturnLocation()
        {
            this.iom_profile = new HashSet<iom_profile>();
            this.iom_ward_profile = new HashSet<iom_ward_profile>();
        }
    
        public string id { get; set; }
        public string location { get; set; }
    
        public virtual ICollection<iom_profile> iom_profile { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile { get; set; }
    }
    
}
