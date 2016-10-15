using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class OrgB1F
    {
        public iom_b1f_organizations_assisting porg { get; set; }

        public iom_profile profile { get; set; }

        public iom_organizations org { get; set; }

        public OrgB1F() {
            porg = new iom_b1f_organizations_assisting();
            profile = new iom_profile();
            org = new iom_organizations();

        //    porg.iom_organizations = org;
        //    porg.iom_profile = profile;
        }

        public OrgB1F(iom_b1f_organizations_assisting org_)
        {
            porg = org_;
            profile = org_.iom_profile;
            org = org_.iom_organizations;
        }
    }
}