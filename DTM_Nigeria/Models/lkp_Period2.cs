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
    public partial class lkp_Period2
    {
        public lkp_Period2()
        {
            this.iom_group_assessment_1 = new HashSet<iom_group_assessment_1>();
            this.iom_idp_arrival = new HashSet<iom_idp_arrival>();
            this.iom_profile = new HashSet<iom_profile>();
            this.iom_profile1 = new HashSet<iom_profile>();
            this.iom_profile2 = new HashSet<iom_profile>();
            this.iom_profile3 = new HashSet<iom_profile>();
            this.iom_profile4 = new HashSet<iom_profile>();
            this.iom_ward_idp_arrival = new HashSet<iom_ward_idp_arrival>();
            this.iom_ward_profile = new HashSet<iom_ward_profile>();
            this.iom_ward_profile1 = new HashSet<iom_ward_profile>();
            this.iom_ward_profile2 = new HashSet<iom_ward_profile>();
            this.iom_ward_profile3 = new HashSet<iom_ward_profile>();
            this.iom_ward_profile4 = new HashSet<iom_ward_profile>();
            this.iom_ward_profile5 = new HashSet<iom_ward_profile>();
            this.iom_ward_profile6 = new HashSet<iom_ward_profile>();
            this.iom_ward_profile7 = new HashSet<iom_ward_profile>();
        }

        public int id { get; set; }
        public string phase { get; set; }
        public string label { get; set; }
        public string tmp { get; set; }

        public virtual ICollection<iom_group_assessment_1> iom_group_assessment_1 { get; set; }
        public virtual ICollection<iom_idp_arrival> iom_idp_arrival { get; set; }
        public virtual ICollection<iom_profile> iom_profile { get; set; }
        public virtual ICollection<iom_profile> iom_profile1 { get; set; }
        public virtual ICollection<iom_profile> iom_profile2 { get; set; }
        public virtual ICollection<iom_profile> iom_profile3 { get; set; }
        public virtual ICollection<iom_profile> iom_profile4 { get; set; }
        public virtual ICollection<iom_ward_idp_arrival> iom_ward_idp_arrival { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile1 { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile2 { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile3 { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile4 { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile5 { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile6 { get; set; }
        public virtual ICollection<iom_ward_profile> iom_ward_profile7 { get; set; }
    }

}
