using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTM_Nigeria.Helpers;

namespace DTM_Nigeria.Models
{
    public class Site_info
    {
        public List<iom_ga_site_information> sites { get; set; }

        public Site_info()
        {
            sites = new List<iom_ga_site_information>(40);
            for (int i = 0; i < 40; i++)
            {
                sites.Add(new iom_ga_site_information());
            }
        }

        public Site_info(iom_group_assessment_1 p1)
        {
            int b3f_id = p1.id;

            if (p1.iom_ga_site_information.Count()>0)
            {
                sites = p1.iom_ga_site_information.ToList();

                foreach (var a in sites)
                {
                    a.notEmpty = true;

                    //if (a.coord_lat != null)
                    //    a.str_coord_lat = GPSData.ConvertDoubletoDMS(a.coord_lat ?? 0);

                    //if (a.coord_lon != null)
                    //    a.str_coord_lon = GPSData.ConvertDoubletoDMS(a.coord_lon ?? 0);
                }

                int cnt = sites.Count();

                if (cnt < 40)
                {
                    // ga_idp_pop = new List<iom_ga_idp_population>(4 - cnt);
                    for (int i = cnt; i < 40; i++)
                    {
                        iom_ga_site_information a = new iom_ga_site_information();
                        a.notEmpty = false;
                        a.ga_id = b3f_id;
                        sites.Add(a);
                    }
                }
            }
            else
            {

                sites = new List<iom_ga_site_information>(40);
                for (int i = 0; i < 40; i++)
                {
                    iom_ga_site_information a = new iom_ga_site_information();
                    a.notEmpty = false;
                    a.ga_id = b3f_id;
                    sites.Add(a);
                }

            }

        }
    }
}