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
    public partial class view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival
    {
        public int phase { get; set; }
        public string state_code { get; set; }
        public string state_name { get; set; }
        public string lga_code { get; set; }
        public string lga_name { get; set; }
        public string ward_code { get; set; }
        public string ward_name { get; set; }
        public int id { get; set; }
        public Nullable<int> estimate_hh_Ward { get; set; }
        public Nullable<int> estimate_Ind_Ward { get; set; }
        public string year_arrival { get; set; }
        public Nullable<int> hh { get; set; }
        public Nullable<int> ind { get; set; }
    }
    
}
