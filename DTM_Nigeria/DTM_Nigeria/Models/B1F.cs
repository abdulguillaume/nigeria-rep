using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using DTM_Nigeria.Models;
using System.Data.Objects.SqlClient;

namespace DTM_Nigeria.Models
{
    public class B1F
    {
        iomdtmEntities _entity = new iomdtmEntities();

        public iom_profile profile { get; set; }

        public iom_researchers researcher { get; set; }

        public List<iom_idp_arrival> arrivals { get; set; }

        public B1F()
        {
            profile = new iom_profile();
            profile.phase =  _entity.iom_dtm_phase.Where(y=>y.closed_YesNo==2).Max(x => x.phase);

            string phase_ = profile.phase.ToString();

            researcher = new iom_researchers();
            arrivals = new List<iom_idp_arrival>(4);


            foreach (lkp_Period2 p in _entity.lkp_Period2.Where(
                x => x.phase.Equals(phase_)
                ))
            {
                iom_idp_arrival y = new iom_idp_arrival();
                y.year = p.id;
                arrivals.Add(y);
            }
            
            
        }

        public B1F(iom_profile b1f)
        {
            profile = b1f;

            profile.state = _entity.lkp_Lga.Where(x => x.lga_code.Equals(b1f.lga)).Select(y => y.state_code).FirstOrDefault();
            researcher = b1f.iom_researchers;

            arrivals = b1f.iom_idp_arrival.ToList();

        }

        public string inSameState(string state_orig)
        {

            string state_ = _entity.lkp_Lga.Where(x => x.lga_code.Equals(profile.lga)).Select(y => y.state_code).FirstOrDefault();

            if (state_orig == null) return state_;

            return state_orig.Equals(state_)?state_:null;

        }
    }
}