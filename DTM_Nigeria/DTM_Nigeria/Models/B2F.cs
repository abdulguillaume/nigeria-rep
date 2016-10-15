using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class B2F
    {
        iomdtmEntities _entity = new iomdtmEntities();

        public iom_ward_profile profile { get; set; }

        public iom_researchers researcher { get; set; }

        public List<iom_ward_idp_arrival> arrivals { get; set; }

        public B2F()
        {
            profile = new iom_ward_profile();

            researcher = new iom_researchers();
            arrivals = new List<iom_ward_idp_arrival>(4);

            int phase = _entity.iom_dtm_phase.Where(y=>y.closed_YesNo==2).Max(x => x.phase);
            string phase_ =  phase.ToString();

            foreach (lkp_Period2 p in _entity.lkp_Period2.Where(x=>x.phase.Equals(phase_)))
            {
                iom_ward_idp_arrival y = new iom_ward_idp_arrival();

                y.year = p.id;
                arrivals.Add(y);
                
            }

        }

        public B2F(iom_ward_profile b2f)
        {
            profile = b2f;

            researcher = b2f.iom_researchers;
            arrivals = b2f.iom_ward_idp_arrival.ToList();

        }

        public string inSameState(string state_orig)
        {
           

            string ward_ = _entity.iom_presence_wards.Where(x => x.id == profile.id).Select(y => y.ward_code).FirstOrDefault();

            string state_ = _entity.lkp_Ward.Where(x => x.ward_code.Equals(ward_)).FirstOrDefault().lkp_Lga.state_code;

            if (state_orig == null) return state_;

            return state_orig.Equals(state_)?state_:null;

            // return false;
        }
    }
}