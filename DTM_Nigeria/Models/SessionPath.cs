using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class SessionPath
    {
        iomdtmEntities _entity = new iomdtmEntities();

        public int b1f_profile { get; set; }
        public string lga { get; set; }
        public int? b2f_profile { get; set; }
        public string ward { get; set; }
        public int? inf_id { get; set; }
        public int? org_id { get; set; }
        public int? winf_id { get; set; }
        public int? worg_id { get; set; }
        public int? location_id { get; set; }

        //added 08 march
        public int phase { get; set;}

        //added 15 march
       // public int? b3f_profile { get; set; }

        public SessionPath()
        { }

        public void setSession(SessionPath s)
        {
            if (s == null)
                throw new Exception();

            b1f_profile = s.b1f_profile;
            lga = s.lga;
            b2f_profile = s.b2f_profile;
            ward = s.ward;
            this.inf_id = s.inf_id;
            this.org_id = s.org_id;
            this.winf_id = s.winf_id;
            this.worg_id = s.worg_id;
            this.location_id = s.location_id;
        }

        public void setSession(int profile, string lga, int? wprofile, string ward, int? inf_id, int? org_id, int? winf_id, int? location_id)
        {
            b1f_profile = profile;
            this.lga = lga;
            b2f_profile = wprofile;
            this.ward = ward;
            this.inf_id = inf_id;
            this.org_id = org_id;
            this.winf_id = winf_id;
            this.worg_id = worg_id;
            this.location_id = location_id;
        }

        public string getLgaInfo()
        {
            var lga_ = (from c in _entity.lkp_Lga
                        where c.lga_code.Equals(this.lga)
                        select c).ToList().FirstOrDefault();
            if (lga_ == null) return null;
            return "- State: "+lga_.lkp_State.state_name+", Lga: "+lga_.lga_name;
        }

        public string getWardInfo()
        {
            var ward_ = (from c in _entity.lkp_Ward
                        where c.ward_code.Equals(this.ward)
                        select c).ToList().FirstOrDefault();
            if (ward_ == null) return null;
            return "- State: " + ward_.lkp_Lga.lkp_State.state_name + ", Lga: " + ward_.lkp_Lga.lga_name+", Ward: "+ward_.ward_name;
        }

    }
}