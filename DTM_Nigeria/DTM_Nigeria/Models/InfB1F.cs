using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class InfB1F
    {
        public iom_b1f_informants pinf { get; set; }
        
        public iom_profile profile { get; set; }

        public iom_informants inf { get; set; }

        public InfB1F() {
            pinf = new iom_b1f_informants();
            profile = new iom_profile();
            inf = new iom_informants();
            inf.notEmpty = true;
            inf.details = "n/a";

        }

        public InfB1F(iom_b1f_informants inf_)
        {
            pinf = inf_;
            profile = inf_.iom_profile;
            inf = inf_.iom_informants;
            inf.notEmpty = true;
            inf.details = "n/a";
        }

    }
}