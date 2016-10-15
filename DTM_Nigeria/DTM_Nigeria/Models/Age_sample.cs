using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class Age_sample
    {
        public List<iom_ga_gender_age_sample> hh_ages { get; set; }

        public Age_sample()
        {
            hh_ages = new List<iom_ga_gender_age_sample>(20);
            for (int i = 0; i < 20; i++)
            {
                iom_ga_gender_age_sample a = new iom_ga_gender_age_sample();
                hh_ages.Add(a);
            }
        }


        public Age_sample(iom_group_assessment_1 p1)
        {
            
            if (p1.iom_ga_gender_age_sample.Count()>0)
            {
                hh_ages = p1.iom_ga_gender_age_sample.ToList();

            }
            else
            {

                hh_ages = new List<iom_ga_gender_age_sample>(20);
                for (int i = 0; i < 20; i++)
                {
                    iom_ga_gender_age_sample a = new iom_ga_gender_age_sample();
                    a.ga_id = p1.id;
                    hh_ages.Add(a);
                }

            }
        }
    }
}