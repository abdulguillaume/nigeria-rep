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
    public partial class lkp_Location
    {
        public lkp_Location()
        {
            this.iom_idp_arrival = new HashSet<iom_idp_arrival>();
            this.iom_ward_idp_arrival = new HashSet<iom_ward_idp_arrival>();
        }
    
        public string id { get; set; }
        public string location { get; set; }
    
        public virtual ICollection<iom_idp_arrival> iom_idp_arrival { get; set; }
        public virtual ICollection<iom_ward_idp_arrival> iom_ward_idp_arrival { get; set; }
    }
    
}
