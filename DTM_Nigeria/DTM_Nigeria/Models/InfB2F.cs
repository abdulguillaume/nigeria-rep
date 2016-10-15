using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class InfB2F
    {
         public iom_b2f_informants pinf { get; set; }
        
        public iom_ward_profile profile { get; set; }

        public iom_informants inf { get; set; }

        public InfB2F() {
            pinf = new iom_b2f_informants();
            profile = new iom_ward_profile();
            inf = new iom_informants();
            inf.notEmpty = true;
            inf.details = "n/a";
        }

        public InfB2F(iom_b2f_informants inf_)
        {
            pinf = inf_;
            profile = inf_.iom_ward_profile;
            inf = inf_.iom_informants;
            inf.notEmpty = true;
            inf.details = "n/a";
        }
    }
}