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
    public partial class lkp_Shelter
    {
        public lkp_Shelter()
        {
            this.iom_group_assessment_1 = new HashSet<iom_group_assessment_1>();
        }
    
        public int id { get; set; }
        public string value { get; set; }
    
        public virtual ICollection<iom_group_assessment_1> iom_group_assessment_1 { get; set; }
    }
    
}
