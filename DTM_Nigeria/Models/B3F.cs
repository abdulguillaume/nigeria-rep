using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using DTM_Nigeria.Helpers;

namespace DTM_Nigeria.Models
{
    public class B3F
    {
        iomdtmEntities _entity = new iomdtmEntities();

        //main tables
        public iom_group_assessment_1 ga_p1 { get; set; }

        public iom_group_assessment_2 ga_p2 { get; set; }

        public List<iom_ga_gender_age_sample> ga_p4 { get; set; }

        public List<iom_ga_site_information> ga_p3 { get; set; }

        //tables belonging to ga_p1
        public List<iom_ga_idp_population> ga_idp_pop { get; set; }

        public List<iom_ga_informants> ga_info { get; set; }
        public List<iom_informants> informant { get; set; }

        //to search in researcher table
        public iom_researchers researcher { get; set; }


        public B3F()
        {
            ga_p1 = new iom_group_assessment_1();
            ga_p2 = new iom_group_assessment_2();
            ga_p3 = new List<iom_ga_site_information>(10);
            ga_p4 = new List<iom_ga_gender_age_sample>(20);
            researcher = new iom_researchers();

            ga_idp_pop = new List<iom_ga_idp_population>(4);
            for (int i = 0; i < 4; i++)
            {
                ga_idp_pop.Add(new iom_ga_idp_population());
            }

            ga_info = new List<iom_ga_informants>(3);
            for (int i = 0; i < 3; i++)
            {
                ga_info.Add(new iom_ga_informants());
            }
            

        }


        public B3F(iom_group_assessment_1 ga)
        {
            ga_p1 = ga;

            researcher = ga.iom_researchers;

            ga_p1.state = (!string.IsNullOrEmpty(ga.lga_orgin)) ? ga.lkp_Lga.state_code : null;

            if (ga.iom_ga_idp_population != null)
            {
                ga_idp_pop = ga.iom_ga_idp_population.ToList();

                foreach (var a in ga_idp_pop)
                {
                    a.notEmpty = true;
                }
                //addRelationship(ga_idp_pop);
                    
                int cnt = ga_idp_pop.Count();

                if (cnt < 4) 
                {
                   // ga_idp_pop = new List<iom_ga_idp_population>(4 - cnt);
                    for (int i = cnt; i < 4; i++)
                    {
                        ga_idp_pop.Add(new iom_ga_idp_population());
                    }
                }
            }
            else
            {

                ga_idp_pop = new List<iom_ga_idp_population>(4);
                for (int i = 0; i < 4; i++)
                {
                    ga_idp_pop.Add(new iom_ga_idp_population());
                }

            }


            if (ga.iom_ga_informants != null)
            {
                //add today wed march 11 2015
                informant = new List<iom_informants>(3);
                foreach (var a in ga.iom_ga_informants)
                {
                    a.iom_informants.notEmpty = true;   
                    informant.Add(a.iom_informants);
                }
                //
                ga_info = ga.iom_ga_informants.ToList();

                int cnt = ga_info.Count();

                if (cnt < 3)
                {
                    //ga_info = new List<iom_ga_informants>(3 - cnt);
                    for (int i = cnt; i < 3; i++)
                    {
                        ga_info.Add(new iom_ga_informants());
                        
                        //add today wed march 11 2015
                        informant.Add(new iom_informants());
                        //
                    }
                }
            }
            else 
            {
                ga_info = new List<iom_ga_informants>(3);
                for (int i = 0; i < 3; i++)
                {
                    ga_info.Add(new iom_ga_informants());

                    //add today wed march 11 2015
                    informant.Add(new iom_informants());
                    //
                }
            }

            if (ga.iom_group_assessment_2 != null) ga_p2 = ga.iom_group_assessment_2;

            if (ga.iom_ga_site_information != null) ga_p3 = ga.iom_ga_site_information.ToList();

            if (ga.iom_ga_gender_age_sample != null) ga_p4 = ga.iom_ga_gender_age_sample.ToList();




            //profile = b2f;

            //researcher = b2f.iom_researchers;
            //arrivals = b2f.iom_ward_idp_arrival.ToList();
            ////arrivals = new List<iom_ward_idp_arrival>(4);

            ////foreach(var item in b2f.iom_ward_idp_arrival)
            ////{
            ////    arrivals.Add(item);
            ////}

        }

    }
}