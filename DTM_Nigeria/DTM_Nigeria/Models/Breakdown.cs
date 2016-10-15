using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class Breakdown
    {
        public List<iom_ward_households_breakdown> hh_ages { get; set; }

        public Breakdown()
        {
            hh_ages = new List<iom_ward_households_breakdown>(20);
        }


        public Breakdown(List<iom_ward_households_breakdown> ages)
        {
            hh_ages = ages;

        }
    }
}