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
    public partial class lkp_Organization
    {
        public lkp_Organization()
        {
            this.iom_organizations = new HashSet<iom_organizations>();
        }
    
        public int id { get; set; }
        public string organization { get; set; }
    
        public virtual ICollection<iom_organizations> iom_organizations { get; set; }
    }
    
}
