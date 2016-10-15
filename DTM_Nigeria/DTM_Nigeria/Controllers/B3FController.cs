using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;
using System.Data.Objects.SqlClient;
using DTM_Nigeria.Helpers;

namespace DTM_Nigeria.Controllers
{
    public class B3FController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        //
        // GET: /B3F/

        SessionPath sesspath = new SessionPath();

        public int b2f_profile;

        public string ward, lga;

        public int phase;

        [HttpPost]
        public JsonResult GetResearcherTels(string r_name)
        {
            //var r_tel = new SelectList( _entity.iom_researchers.Where(x => x.researcher_name.Equals(r_name)), "researcher_tel", "researcher_tel").FirstOrDefault();

            var r_tel = _entity.iom_researchers.Where(x => x.researcher_name.Equals(r_name)).Select(y=>y.researcher_tel).FirstOrDefault();


            return Json(r_tel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetResearchersNames(string term)
        {
            List<string> researchers;

            researchers = _entity.iom_researchers.Where(x => x.researcher_name.Contains(term))
                .Select(y => y.researcher_name).ToList();

            return Json(researchers, JsonRequestBehavior.AllowGet);
        }


        public iom_researchers findResearcher(iom_researchers researcher)
        {
            iom_researchers researcher_ = _entity.iom_researchers.Where(x => x.researcher_name.Equals(researcher.researcher_name)).FirstOrDefault();

            return researcher_ == null ? researcher : researcher_;
        }

        [HttpPost]
        public JsonResult GetInfInfo(string i_name)
        {
            //var r_tel = new SelectList( _entity.iom_researchers.Where(x => x.researcher_name.Equals(r_name)), "researcher_tel", "researcher_tel").FirstOrDefault();

            var r_info = _entity.iom_informants.Where(x => x.name.Equals(i_name)).Select(y => new { 
                name= y.name,
                sex =  y.sex,
                type = y.type,
                desc = y.details
            }).ToList().FirstOrDefault();



            return Json(r_info /*new { a = "bar", b = "Blech" }*/,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetInfsNames(string term)
        {
            List<string> infs;

            infs = _entity.iom_informants.Where(x => x.name.Contains(term))
                .Select(y => y.name).Distinct().ToList();

            return Json(infs, JsonRequestBehavior.AllowGet);
        }

        public iom_informants findInf(iom_informants inf)
        {
            iom_informants inf_ = _entity.iom_informants.Where(x => x.name.Equals(inf.name) && x.sex.Equals(inf.sex) && x.type == inf.type).FirstOrDefault();

            return inf_ == null ? inf : inf_;
        }

        //public double ConvertDMSToDouble(string dms)
        //{
        //    int i_d = dms.IndexOf('d');
        //    int i_m = dms.IndexOf('m');
        //    int i_s = dms.IndexOf('s');


        //    double degrees = double.Parse(string.IsNullOrEmpty(dms.Substring(0, i_d)) ? "0" : dms.Substring(0, i_d));
        //    double minutes = double.Parse(i_m==-1?"0":(string.IsNullOrEmpty(dms.Substring(i_d+1, i_m-i_d-1)) ? "0" : dms.Substring(i_d+1, i_m-i_d-1)));
        //    double seconds = double.Parse(i_s==-1?"0":(string.IsNullOrEmpty(dms.Substring(i_m+1, i_s-i_m-1)) ? "0" : dms.Substring(i_m+1, i_s-i_m-1)));


        //    //if (degrees == 0 && minutes == 0 && seconds == 0) return null;

        //    return degrees + (minutes / 60) + (seconds / 3600);
        //}

        //public string ConvertDoubletoDMS(double coord)
        //{
        //    int sec = (int)Math.Round(coord * 3600);
        //    int deg = sec / 3600;
        //    sec = Math.Abs(sec % 3600);
        //    int min = sec / 60;
        //    sec %= 60;

        //    return deg + "d" + min + "m" + sec + "s";

        //}

        public void setSession(int id)
        {
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                sesspath.b2f_profile = id;

                ViewBag.WardInfo = sesspath.getWardInfo();

                string sesspath_serial = new JavaScriptSerializer().Serialize(sesspath);

                var cookie = new HttpCookie("SessionPath", sesspath_serial);
                HttpContext.Response.Cookies.Add(cookie);
            }
        }

        public void getSession()
        {
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                b2f_profile = sesspath.b2f_profile ?? 0;
                ward = sesspath.ward;
                lga = sesspath.lga;
                phase = sesspath.phase;

                ViewBag.WardInfo = sesspath.getWardInfo();
            }
        }


        public List<lkp_Lga> lga_orig(string lga)
        {
            string state = _entity.lkp_Lga.Where(x => x.lga_code.Equals(lga)).Select(y=>y.state_code).FirstOrDefault();

            if (state == null) return null;

            return _entity.lkp_Lga.Where(x => x.state_code.Equals(state)).ToList();
            
           // return null;
        }

        [HttpPost]
        public JsonResult getLgaList(string id)
        {
            var lgas = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(id)), "lga_code", "lga_name").ToList();
            return Json(lgas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult getWardList(string id)
        {
            var wards = new SelectList(_entity.lkp_Ward.Where(x => x.lga_code.Equals(id)), "ward_code", "ward_name").ToList();
            return Json(wards, JsonRequestBehavior.AllowGet);
        }

        public List<lkp_Ward> ward_orig(string lga)
        {
            return _entity.lkp_Ward.Where(x => x.lga_code.Equals(lga)).ToList();

            // return null;
        }



        public void getWardInfo(string w)
        {
            var ward_ = (from c in _entity.lkp_Ward
                         where c.ward_code.Equals(w)
                         select c).FirstOrDefault();

            ViewBag.StateName = ward_.lkp_Lga.lkp_State.state_name;
            ViewBag.LGA = ward_.lkp_Lga.lga_name;
            ViewBag.Ward = ward_.ward_name;
        }

        public string findStateCode(string lga)
        {
            var lga_ = (from c in _entity.lkp_Lga
                        where c.lga_code == lga
                        select c).FirstOrDefault();


            if (lga_ != null)
            {
                return lga_.state_code;
            }
            return null;
        }

        public void setViewBags(string def, string def2, string phase)
        {
            if (ward != null)
                getWardInfo(ward);

            ViewBag.DefStateCode = def;

            ViewBag.RelationshipType = new SelectList(_entity.lkp_Relationship_Type, "id", "value");

            ViewBag.HealthProblem = new SelectList(_entity.lkp_HealthProblem, "id", "value");

           // ViewBag.LgaList = new SelectList(lga_orig(lga), "lga_code", "lga_name");

            ViewBag.LgaList = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(def == null ? "-1" : def)), "lga_code", "lga_name");

           // ViewBag.WARD_ = new SelectList(_entity.lkp_Ward.Where(x => x.lga_code.Equals(def == null ? "-1" : def)), "ward_code", "ward_name");

            ViewBag.WardList = new SelectList(ward_orig(def2 == null ? "-1" : def2), "ward_code", "ward_name");

            ViewBag.Shelter = new SelectList(_entity.lkp_Shelter, "id", "value");

            ViewBag.ReasonOfDisp = new SelectList(_entity.lkp_ReasonOfDisp, "id", "value");

            ViewBag.Ethnicity = new SelectList(_entity.lkp_Ethnicity, "id", "value");

            ViewBag.Religion = new SelectList(_entity.lkp_Religion, "id", "value");

            ViewBag.Informant = new SelectList(_entity.lkp_Informant_Type, "id", "informant");

            ViewBag.Intention = new SelectList(_entity.lkp_Intention, "id", "value");

            ViewBag.Periods = new SelectList(_entity.lkp_Period2.Where(x=>x.phase.Equals(phase) || x.phase.Equals("x") ), "id", "label");

            ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");//, (def == null ? "-1" : def));

            ViewBag.YesNo = new SelectList(_entity.lkp_YesNo, "id", "value");
            ViewBag.YesNo2 = new SelectList(_entity.lkp_YesNo.Where(x=>x.id<4), "id", "value");

            ViewBag.Incidents = new SelectList(_entity.lkp_Incident, "id", "incident");
            ViewBag.GBVs = new SelectList(_entity.lkp_GBV, "id", "gbv");
            ViewBag.CPIncidents = new SelectList(_entity.lkp_ChildProIncident, "id", "incident");
            ViewBag.TravelLocations = new SelectList(_entity.lkp_TravelLocation, "id", "location");
            ViewBag.Opportunities = new SelectList(_entity.lkp_Opportunity, "id", "opportunity");
            ViewBag.NFIs = new SelectList(_entity.lkp_NeededNFI, "id", "nfi");
        }

        public ActionResult Index(int? id)
        {
            ViewBag.Active = "B1F";

            if (id != null)
            {
                setSession(id ?? 0);
                b2f_profile = id ?? 0;
            }
            else
                getSession();

            var b3f = from c in _entity.iom_group_assessment_1
                      where c.b2f == b2f_profile
                       select c;
            return View(b3f);
        }

        public ActionResult IndexP2(int id)
        {
            //Index for page 2
            ViewBag.Active = "B1F";
            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null,phase.ToString());

            var b3f = (from c in _entity.iom_group_assessment_2
                       where c.id == id
                       select c).FirstOrDefault();
            return View(b3f);
        }

        public ActionResult IndexP3(int id)
        {
            //Index for page 2
            ViewBag.Active = "B1F";
            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            var sites = (from c in _entity.iom_ga_site_information
                      where c.ga_id == id
                      select c).ToList();

            //foreach (var a in sites) {
            //    if (a.coord_lat != null)
            //        a.str_coord_lat = GPSData.ConvertDoubletoDMS(a.coord_lat ?? 0);

            //    if (a.coord_lon != null)
            //        a.str_coord_lon = GPSData.ConvertDoubletoDMS(a.coord_lon ?? 0);
            //}


            return View(sites);
        }


        public ActionResult IndexP4(int id)
        {
            //Index for page 2
            ViewBag.Active = "B1F";
            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            var hhages = from c in _entity.iom_ga_gender_age_sample
                        where c.ga_id == id
                        select c;
            return View(hhages);
        }

        //
        // GET: /B3F/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            //double test = ConvertDMSToDouble("12d35m25.6s");

            getSession();

            setViewBags(null,null,phase.ToString());

            var b3f = (from c in _entity.iom_group_assessment_1
                      where c.id == id
                      select c).FirstOrDefault();
            
            //if (b3f.coord_lat != null)
            //    b3f.str_coord_lat = GPSData.ConvertDoubletoDMS(b3f.coord_lat ?? 0);

            //if (b3f.coord_lon != null)
            //    b3f.str_coord_lon = GPSData.ConvertDoubletoDMS(b3f.coord_lon ?? 0);

            return View(b3f);
        }


        //
        // GET: /B3F/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null,phase.ToString());

            B3F b3f = new B3F();
            return View(b3f);
        }

        //
        // POST: /B3F/Create

        [HttpPost]
        public ActionResult Create(B3F b3f)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(string.IsNullOrEmpty(b3f.ga_p1.state) ? "-1" : b3f.ga_p1.state,
               string.IsNullOrEmpty(b3f.ga_p1.lga_orgin) ? "-1" : b3f.ga_p1.lga_orgin, phase.ToString());

            //if (string.IsNullOrEmpty(b3f.ga_p1.lga_orgin))
            //    setViewBags(null, null,phase.ToString());
            //else {
            //    setViewBags(findStateCode(b3f.ga_p1.lga_orgin), b3f.ga_p1.lga_orgin, phase.ToString());   
            //}

            iom_group_assessment_1 ga_p1 = new iom_group_assessment_1();

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add insert logic here
                    ga_p1 = b3f.ga_p1;

                    //if (!string.IsNullOrEmpty(b3f.ga_p1.str_coord_lat))
                    //    ga_p1.coord_lat = GPSData.ConvertDMSToDouble(b3f.ga_p1.str_coord_lat);

                    //if (!string.IsNullOrEmpty(b3f.ga_p1.str_coord_lon))
                    //    ga_p1.coord_lon = GPSData.ConvertDMSToDouble(b3f.ga_p1.str_coord_lon);

                    ga_p1.b2f = b2f_profile;

                    //ga_p1.iom_researchers= findResearcher(b3f.researcher);

                    DateTime tmp = DateTime.Now;

                    foreach(var a in b3f.ga_idp_pop)
                    {
                        //if(!string.IsNullOrEmpty(a.ward_orig))
                        if (a.notEmpty)
                        {

                            a.create_time = tmp;
                            a.update_time = tmp;

                            a.created_by = User.Identity.Name;
                            a.updated_by = User.Identity.Name;

                            ga_p1.iom_ga_idp_population.Add(a);
                        }
                    }

                    foreach (var a in b3f.ga_info)
                    {
                        //if (!string.IsNullOrEmpty(a.iom_informants.name))
                        if (a.iom_informants.notEmpty)
                        {
                            string str = a.iom_informants.details;

                            a.iom_informants = findInf(a.iom_informants);

                            a.iom_informants.details = str;

                            a.create_time = tmp;
                            a.update_time = tmp;

                            a.created_by = User.Identity.Name;
                            a.updated_by = User.Identity.Name;

                            ga_p1.iom_ga_informants.Add(a);
                        }
                    }

                    
                    
                    ga_p1.create_time = tmp;
                    ga_p1.update_time = tmp;

                    ga_p1.created_by = User.Identity.Name;
                    ga_p1.updated_by = User.Identity.Name;


                    ga_p1.iom_researchers = findResearcher(b3f.researcher);
                    ga_p1.iom_researchers.researcher_tel = b3f.researcher.researcher_tel;

                    new VerifForm(b3f, phase);

                    _entity.AddObject("iom_group_assessment_1", ga_p1);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(b3f);
                }
                catch
                {
                    return View(b3f);
                }
            }

            return View(b3f);
        }

        [Authorize]
        public ActionResult CreateP2(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            iom_group_assessment_2 ga_p2 = new iom_group_assessment_2();

            ga_p2.id = id;

            // B3F b3f = new B3F();
            return View(ga_p2);
        } 


        [HttpPost]
        public ActionResult CreateP2(iom_group_assessment_2 p2)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = p2.id;

            getSession();

            string state = p2.state != null ? p2.state :
                (string.IsNullOrEmpty(p2.if_yes_lga_maj) ? null : p2.lkp_Lga.state_code);

            setViewBags(
                state == null ? "-1" : state
                , state == null ? "-1" : p2.if_yes_lga_maj,
                phase.ToString());

            
            iom_group_assessment_2 ga_p2 = new iom_group_assessment_2();

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add insert logic here

                    DateTime tmp = DateTime.Now;

                    ga_p2.id = p2.id;
                    ga_p2.health_care_service_YesNo = p2.health_care_service_YesNo;
                    ga_p2.health_most_prevalent = p2.health_most_prevalent;
                    ga_p2.how_many_time_disp = p2.how_many_time_disp;
                    ga_p2.if_yes_lga_maj = p2.if_yes_lga_maj;
                    ga_p2.if_yes_ward_maj = p2.if_yes_ward_maj;
                    ga_p2.intention_of_majority = p2.intention_of_majority;
                    ga_p2.member_disp_p1_YesNo = p2.member_disp_p1_YesNo;
                    ga_p2.need_access_icome = p2.need_access_icome;
                    ga_p2.need_education = p2.need_education;
                    ga_p2.need_food = p2.need_food;
                    ga_p2.need_health = p2.need_health;
                    ga_p2.need_lhelp = p2.need_lhelp;
                    ga_p2.need_nfi = p2.need_nfi;
                    ga_p2.need_other = p2.need_other;
                    ga_p2.need_sanitation = p2.need_sanitation;
                    ga_p2.need_shelter = p2.need_shelter;
                    ga_p2.need_specify = p2.need_specify;
                    ga_p2.need_water = p2.need_water;
                    ga_p2.sec_people_feel_safe_YesNo = p2.sec_people_feel_safe_YesNo;
                    ga_p2.sec_relationship_idp_comm = p2.sec_relationship_idp_comm;
                    ga_p2.v_children_at_risk = p2.v_children_at_risk;
                    ga_p2.v_female_hh = p2.v_female_hh;
                    ga_p2.v_mental_disability = p2.v_mental_disability;
                    ga_p2.v_minor_hh = p2.v_minor_hh;
                    ga_p2.v_missing_relatives = p2.v_missing_relatives;
                    ga_p2.v_older_at_risk = p2.v_older_at_risk;
                    ga_p2.v_other = p2.v_other;
                    ga_p2.v_physical_disability = p2.v_physical_disability;
                    ga_p2.v_profile_based_risk = p2.v_profile_based_risk;
                    ga_p2.v_separated_children = p2.v_separated_children;
                    ga_p2.v_serious_med_condition = p2.v_serious_med_condition;
                    ga_p2.v_single_parent = p2.v_single_parent;
                    ga_p2.v_specify = p2.v_specify;
                    ga_p2.v_surviror_at_risk_of_viol = p2.v_surviror_at_risk_of_viol;
                    ga_p2.v_unaccompanied_children = p2.v_unaccompanied_children;
                    ga_p2.v_women_at_risk = p2.v_women_at_risk;

                    //--added on june 3rd after form update
                    //--start part 1
                    ga_p2.v_breastfeeding_mother = p2.v_breastfeeding_mother;
                    ga_p2.v_male_hh = p2.v_male_hh;
                    ga_p2.v_pregnant_women = p2.v_pregnant_women;
                    //--end part 1/start part 2
                    ga_p2.protect_common_child_p_incident = p2.protect_common_child_p_incident;
                    ga_p2.protect_common_child_p_incident_ifOther = p2.protect_common_child_p_incident_ifOther;
                    ga_p2.protect_common_GBV = p2.protect_common_GBV;
                    ga_p2.protect_common_GBV_ifNoAns = p2.protect_common_GBV_ifNoAns;
                    ga_p2.protect_common_GBV_ifOther = p2.protect_common_GBV_ifOther;
                    ga_p2.protect_common_in_ifNoAns = p2.protect_common_in_ifNoAns;
                    ga_p2.protect_common_in_ifOther = p2.protect_common_in_ifOther;
                    ga_p2.protect_common_incident = p2.protect_common_incident;
                    ga_p2.protect_people_feel_safe_ifNoAns = p2.protect_people_feel_safe_ifNoAns;
                    ga_p2.protect_people_feel_safe_YesNo = p2.protect_people_feel_safe_YesNo;
                    ga_p2.protect_travel_oic_ifYes_what = p2.protect_travel_oic_ifYes_what;
                    ga_p2.protect_travel_oic_ifYes_where = p2.protect_travel_oic_ifYes_where;
                    ga_p2.protect_travel_oic_YesNo = p2.protect_travel_oic_YesNo;
                    //--end part 2/start part 3
                    ga_p2.shelter_mn_nfi = p2.shelter_mn_nfi;
                    ga_p2.shelter_mn_other = p2.shelter_mn_other;
                    ga_p2.shelter_num_es = p2.shelter_num_es;
                    ga_p2.shelter_num_hc = p2.shelter_num_hc;
                    ga_p2.shelter_num_ms = p2.shelter_num_ms;
                    ga_p2.shelter_num_people = p2.shelter_num_people;
                    ga_p2.shelter_num_rh = p2.shelter_num_rh;
                    //--end part 3

                    ga_p2.create_time = tmp;
                    ga_p2.update_time = tmp;

                    ga_p2.created_by = User.Identity.Name;
                    ga_p2.updated_by = User.Identity.Name;

                    new VerifForm(p2, phase);

                    _entity.AddObject("iom_group_assessment_2", ga_p2);
                    _entity.SaveChanges();

                    return RedirectToAction("IndexP2", new { id = ga_p2.id });
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(p2);
                }
                catch
                {
                    return View(p2);
                }
            }

            return View(p2);
        }

        [Authorize]
        public ActionResult CreateP3(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());


            iom_group_assessment_1 ga_p1 = 
                (from c in _entity.iom_group_assessment_1
                                           where c.id == id
                                           select c).FirstOrDefault();

            return View(new Site_info(ga_p1));
        }


        [HttpPost]
        public ActionResult CreateP3(Site_info s)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null, phase.ToString());

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add insert logic here

                    DateTime tmp = DateTime.Now;

                    foreach (var a in s.sites)
                    {
                        //if (!string.IsNullOrEmpty(a.name_site))
                        if(a.notEmpty)
                        {
                            iom_ga_site_information site = new iom_ga_site_information();

                            site.notEmpty = a.notEmpty;

                            site.ga_id = a.ga_id;
                            site.name_site = a.name_site;

                            site.coord_lon = a.coord_lon;
                            site.coord_lat = a.coord_lat;

                            //if (!string.IsNullOrEmpty(a.str_coord_lat))
                            //    site.coord_lat = GPSData.ConvertDMSToDouble(a.str_coord_lat);

                            //if (!string.IsNullOrEmpty(a.str_coord_lon))
                            //    site.coord_lon = GPSData.ConvertDMSToDouble(a.str_coord_lon);
                            
                            //site.coord_lon = a.coord_lon;
                            //site.coord_lat = a.coord_lat;

                            site.create_time = tmp;
                            site.update_time = tmp;

                            site.created_by = User.Identity.Name;
                            site.updated_by = User.Identity.Name;

                            _entity.AddObject("iom_ga_site_information", site);
                            //_entity.SaveChanges();
                        }
                    }


                    _entity.SaveChanges();

                    return RedirectToAction("IndexP3", new { id = s.sites.FirstOrDefault().ga_id });
                }
                catch
                {
                    return View(s);
                }
            }

            return View(s);
        }

        [Authorize]
        public ActionResult CreateP4(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());


            iom_group_assessment_1 ga_p1 =
                (from c in _entity.iom_group_assessment_1
                 where c.id == id
                 select c).FirstOrDefault();

            return View(new Age_sample(ga_p1));
        }

        [HttpPost]
        public ActionResult CreateP4(Age_sample s)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null, phase.ToString());

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add insert logic here

                    DateTime tmp = DateTime.Now;
                    int i = 1;
                    foreach (var a in s.hh_ages)
                    {
                        iom_ga_gender_age_sample bd = new iom_ga_gender_age_sample();


                        bd.ga_id = a.ga_id;
                        bd.hhs = i;

                        //set value to zero
                        if (a.m_lt1 == null) bd.m_lt1 = 0; else { bd.m_lt1 = a.m_lt1; }
                        if (a.f_lt1 == null) bd.f_lt1 = 0; else { bd.f_lt1 = a.f_lt1;  }
                        if (a.m_1_5 == null) bd.m_1_5 = 0; else { bd.m_1_5 = a.m_1_5; }
                        if (a.f_1_5 == null) bd.f_1_5 = 0; else { bd.f_1_5 = a.f_1_5; }
                        if (a.m_6_17 == null) bd.m_6_17 = 0; else { bd.m_6_17 = a.m_6_17; }
                        if (a.f_6_17 == null) bd.f_6_17 = 0; else { bd.f_6_17 = a.f_6_17; }
                        if (a.m_18_59 == null) bd.m_18_59 = 0; else { bd.m_18_59 = a.m_18_59; }
                        if (a.f_18_59 == null) bd.f_18_59 = 0; else { bd.f_18_59 = a.f_18_59;  }
                        if (a.m_60p == null) bd.m_60p = 0; else { bd.m_60p = a.m_60p; }
                        if (a.f_60p == null) bd.f_60p = 0; else { bd.f_60p = a.f_60p; }

                        bd.create_time = tmp;
                        bd.update_time = tmp;

                        bd.created_by = User.Identity.Name;
                        bd.updated_by = User.Identity.Name;


                        _entity.AddObject("iom_ga_gender_age_sample", bd);
                        i++;
                        
                    }

                    _entity.SaveChanges();
                    return RedirectToAction("IndexP4", new { id = s.hh_ages.FirstOrDefault().ga_id });
                }
                catch
                {
                    return View(s);
                }
            }

            return View(s);
        }

        //
        // GET: /B3F/Edit/5

        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            getSession();

            var b3f = (from c in _entity.iom_group_assessment_1
                       where c.id == id
                       select c).FirstOrDefault();

            //setViewBags(findStateCode(b3f.lga_orgin), b3f.lga_orgin, phase.ToString());

            b3f.state = string.IsNullOrEmpty(b3f.lga_orgin) ? "-1" : b3f.lkp_Lga.state_code;
            setViewBags( b3f.state,
               string.IsNullOrEmpty(b3f.lga_orgin) ? "-1" : b3f.lga_orgin, phase.ToString());


            return View(new B3F(b3f));
        }

        //
        // POST: /B3F/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, B3F b3f)
        {
            ViewBag.Active = "B1F";

            getSession();

            b3f.ga_p1.state = string.IsNullOrEmpty(b3f.ga_p1.lga_orgin) ? "-1" : findStateCode(b3f.ga_p1.lga_orgin);

            setViewBags( b3f.ga_p1.state,
                string.IsNullOrEmpty(b3f.ga_p1.lga_orgin)? "-1" : b3f.ga_p1.lga_orgin, phase.ToString());

            var ga_p1 = (from c in _entity.iom_group_assessment_1
                       where c.id == id
                       select c).FirstOrDefault();

           // int id2 = ga_p1.id;

            if (ga_p1 != null)
            {
                try
                {
                    // TODO: Add update logic here

                    //ga_p1.iom_researchers = findResearcher(b3f.researcher);

                    DateTime tmp = DateTime.Now;

                    List<iom_informants> x = new List<iom_informants>();

                    List<iom_ga_informants> z = ga_p1.iom_ga_informants.ToList();

                    List<iom_ga_idp_population> w = ga_p1.iom_ga_idp_population.ToList();

                    foreach (var a in b3f.ga_idp_pop)
                    {
                        if (a.notEmpty)
                        {
                            iom_ga_idp_population gap =
                                ga_p1.iom_ga_idp_population.Where(y => y.id==a.id
                                    ).FirstOrDefault();

                            if (gap == null)
                            {
                                gap = new iom_ga_idp_population();

                                gap.ward_orig = a.ward_orig;

                                gap.hh = a.hh;

                                gap.ind = a.ind;

                                gap.ethnicity = a.ethnicity;

                                gap.religion = a.religion;

                                gap.religion_other = a.religion_other;

                                gap.create_time = tmp;
                                gap.update_time = tmp;

                                gap.created_by = User.Identity.Name;
                                gap.updated_by = User.Identity.Name;

                                ga_p1.iom_ga_idp_population.Add(gap);
                            }
                            else
                            {
                                gap.ward_orig = a.ward_orig;
                                gap.hh = a.hh;
                                gap.ind = a.ind;
                                gap.ethnicity = a.ethnicity;
                                gap.religion = a.religion;
                                gap.religion_other = a.religion_other;
                                gap.update_time = tmp;
                                gap.updated_by = User.Identity.Name;
                            }

                        }
                        else if(a.id!=0) {
                            iom_ga_idp_population u = _entity.iom_ga_idp_population.Where(
                                y =>y.id==a.id
                                ).FirstOrDefault();
                            _entity.iom_ga_idp_population.DeleteObject(u);
                        }
                    }

                    //add new or edit old informant
                    foreach (var a in b3f.informant)
                    {
                       // if (!string.IsNullOrEmpty(a.name))
                        if (a.notEmpty)
                        {
                            string str = a.details;
                            iom_informants b = findInf(a);
                            b.details = str;

                            iom_ga_informants gai = ga_p1.iom_ga_informants.Where(y => y.informant == b.id).FirstOrDefault(); ;

                            if (gai == null)
                            {
                                gai = new iom_ga_informants();

                                gai.informant = b.id;
                                gai.create_time = tmp;
                                gai.update_time = tmp;

                                gai.created_by = User.Identity.Name;
                                gai.updated_by = User.Identity.Name;

                                ga_p1.iom_ga_informants.Add(gai);

                            }
                            else
                            {
                                gai.update_time = tmp;
                                gai.updated_by = User.Identity.Name;
                            }

                            x.Add(b);
                        }

                    }

                    //to remove blank or deleted ones in views
                    List<iom_ga_informants> toRemInf = rowToRemoveInf(z, x);
                    //List<iom_ga_idp_population> toRemIdp = rowToRemoveIdpPop(w,b3f.ga_idp_pop);

                    foreach (var a in toRemInf)
                    {
                        iom_ga_informants u = _entity.iom_ga_informants.Where(y => y.informant == a.informant).FirstOrDefault();
                        _entity.iom_ga_informants.DeleteObject(u);
                        
                    }

                    //foreach (var a in toRemIdp)
                    //{
                    //    iom_ga_idp_population u = _entity.iom_ga_idp_population.Where(y => y.ward_orig.Equals(a.ward_orig)).FirstOrDefault();
                    //    _entity.iom_ga_idp_population.DeleteObject(u);

                    //}


                    gaFill(ga_p1, b3f.ga_p1);


                    //if (!string.IsNullOrEmpty(b3f.ga_p1.str_coord_lat))
                    //    ga_p1.coord_lat = GPSData.ConvertDMSToDouble(b3f.ga_p1.str_coord_lat);

                    //if (!string.IsNullOrEmpty(b3f.ga_p1.str_coord_lon))
                    //    ga_p1.coord_lon = GPSData.ConvertDMSToDouble(b3f.ga_p1.str_coord_lon);

                    ga_p1.update_time = tmp;

                    ga_p1.updated_by = User.Identity.Name;


                    new VerifForm(b3f, phase);

                    ga_p1.iom_researchers = findResearcher(b3f.researcher);
                    ga_p1.iom_researchers.researcher_tel = b3f.researcher.researcher_tel;

                    TryUpdateModel(ga_p1);
                    _entity.SaveChanges();

                    return RedirectToAction("Details", new { id = id });
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(b3f);
                }
                catch
                {
                    return View(b3f);
                }
            }

            return View(b3f);
        }

        [Authorize]
        public ActionResult EditP2(int id)
        {
            ViewBag.Active = "B1F";

            getSession();

            var p2 = (from c in _entity.iom_group_assessment_2
                      where c.id == id
                      select c).FirstOrDefault();

            p2.state = string.IsNullOrEmpty(p2.if_yes_lga_maj) ? null : p2.lkp_Lga.state_code;

            setViewBags(
                p2.state==null? "-1" : p2.lkp_Lga.state_code
                , p2.state ==null ? "-1" : p2.if_yes_lga_maj,
                phase.ToString());
            
            return View(p2);
        }

        [HttpPost]
        public ActionResult EditP2(int id, iom_group_assessment_2 p2)
        {
            ViewBag.Active = "B1F";

            getSession();

            string state = p2.state != null ? p2.state :
                (string.IsNullOrEmpty(p2.if_yes_lga_maj) ? null : findStateCode(p2.if_yes_lga_maj));

            setViewBags(
                state==null ? "-1" : state
                , state==null ? "-1" : p2.if_yes_lga_maj,
                phase.ToString());

            var ga_p2 = (from c in _entity.iom_group_assessment_2
                         where c.id == id
                         select c).FirstOrDefault();


            if (ga_p2 != null)
            {
                try
                {
                    // TODO: Add update logic here
                    DateTime tmp = DateTime.Now;

                    ga_p2.health_care_service_YesNo = p2.health_care_service_YesNo;
                    ga_p2.health_most_prevalent = p2.health_most_prevalent;
                    ga_p2.how_many_time_disp = p2.how_many_time_disp;
                    ga_p2.if_yes_lga_maj = p2.if_yes_lga_maj;
                    ga_p2.if_yes_ward_maj = p2.if_yes_ward_maj;
                    ga_p2.intention_of_majority = p2.intention_of_majority;
                    ga_p2.member_disp_p1_YesNo = p2.member_disp_p1_YesNo;
                    ga_p2.need_access_icome = p2.need_access_icome;
                    ga_p2.need_education = p2.need_education;
                    ga_p2.need_food = p2.need_food;
                    ga_p2.need_health = p2.need_health;
                    ga_p2.need_lhelp = p2.need_lhelp;
                    ga_p2.need_nfi = p2.need_nfi;
                    ga_p2.need_other = p2.need_other;
                    ga_p2.need_sanitation = p2.need_sanitation;
                    ga_p2.need_shelter = p2.need_shelter;
                    ga_p2.need_specify = p2.need_specify;
                    ga_p2.need_water = p2.need_water;
                    ga_p2.sec_people_feel_safe_YesNo = p2.sec_people_feel_safe_YesNo;
                    ga_p2.sec_relationship_idp_comm = p2.sec_relationship_idp_comm;
                    ga_p2.v_children_at_risk = p2.v_children_at_risk;
                    ga_p2.v_female_hh = p2.v_female_hh;
                    ga_p2.v_mental_disability = p2.v_mental_disability;
                    ga_p2.v_minor_hh = p2.v_minor_hh;
                    ga_p2.v_missing_relatives = p2.v_missing_relatives;
                    ga_p2.v_older_at_risk = p2.v_older_at_risk;
                    ga_p2.v_other = p2.v_other;
                    ga_p2.v_physical_disability = p2.v_physical_disability;
                    ga_p2.v_profile_based_risk = p2.v_profile_based_risk;
                    ga_p2.v_separated_children = p2.v_separated_children;
                    ga_p2.v_serious_med_condition = p2.v_serious_med_condition;
                    ga_p2.v_single_parent = p2.v_single_parent;
                    ga_p2.v_specify = p2.v_specify;
                    ga_p2.v_surviror_at_risk_of_viol = p2.v_surviror_at_risk_of_viol;
                    ga_p2.v_unaccompanied_children = p2.v_unaccompanied_children;
                    ga_p2.v_women_at_risk = p2.v_women_at_risk;

                    //--added on june 3rd after form update
                    //--start part 1
                    ga_p2.v_breastfeeding_mother = p2.v_breastfeeding_mother;
                    ga_p2.v_male_hh = p2.v_male_hh;
                    ga_p2.v_pregnant_women = p2.v_pregnant_women;
                    //--end part 1/start part 2
                    ga_p2.protect_common_child_p_incident = p2.protect_common_child_p_incident;
                    ga_p2.protect_common_child_p_incident_ifOther = p2.protect_common_child_p_incident_ifOther;
                    ga_p2.protect_common_GBV = p2.protect_common_GBV;
                    ga_p2.protect_common_GBV_ifNoAns = p2.protect_common_GBV_ifNoAns;
                    ga_p2.protect_common_GBV_ifOther = p2.protect_common_GBV_ifOther;
                    ga_p2.protect_common_in_ifNoAns = p2.protect_common_in_ifNoAns;
                    ga_p2.protect_common_in_ifOther = p2.protect_common_in_ifOther;
                    ga_p2.protect_common_incident = p2.protect_common_incident;
                    ga_p2.protect_people_feel_safe_ifNoAns = p2.protect_people_feel_safe_ifNoAns;
                    ga_p2.protect_people_feel_safe_YesNo = p2.protect_people_feel_safe_YesNo;
                    ga_p2.protect_travel_oic_ifYes_what = p2.protect_travel_oic_ifYes_what;
                    ga_p2.protect_travel_oic_ifYes_where = p2.protect_travel_oic_ifYes_where;
                    ga_p2.protect_travel_oic_YesNo = p2.protect_travel_oic_YesNo;
                    //--end part 2/start part 3
                    ga_p2.shelter_mn_nfi = p2.shelter_mn_nfi;
                    ga_p2.shelter_mn_other = p2.shelter_mn_other;
                    ga_p2.shelter_num_es = p2.shelter_num_es;
                    ga_p2.shelter_num_hc = p2.shelter_num_hc;
                    ga_p2.shelter_num_ms = p2.shelter_num_ms;
                    ga_p2.shelter_num_people = p2.shelter_num_people;
                    ga_p2.shelter_num_rh = p2.shelter_num_rh;
                    //--end part 3


                    ga_p2.update_time = tmp;

                    ga_p2.updated_by = User.Identity.Name;

                    new VerifForm(p2,phase);

                    TryUpdateModel(ga_p2);
                    _entity.SaveChanges();

                    return RedirectToAction("IndexP2", new { id = id });
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(p2);
                }
                catch
                {
                    return View(p2);
                }
            }

            return View(p2);
        }

        [Authorize]
        public ActionResult EditP3(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());


            iom_group_assessment_1 ga_p1 =
                (from c in _entity.iom_group_assessment_1
                 where c.id == id
                 select c).FirstOrDefault();

            return View(new Site_info(ga_p1));
        }

        [HttpPost]
        public ActionResult EditP3(int id, Site_info s)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null, phase.ToString());

            iom_group_assessment_1 ga_p1 =
                (from c in _entity.iom_group_assessment_1
                 where c.id == id
                 select c).FirstOrDefault();

            if (ga_p1!=null)
            {

                try
                {
                    // TODO: Add insert logic here

                    DateTime tmp = DateTime.Now;

                    foreach (var a in s.sites)
                    {
                        //if (!string.IsNullOrEmpty(a.name_site) && a.id!=0)
                        if(a.notEmpty && a.id!=0)
                        {
                            //update old ones
                            iom_ga_site_information x = ga_p1.iom_ga_site_information.Where(y => y.id == a.id).FirstOrDefault();

                            x.name_site = a.name_site;
                            x.coord_lat = a.coord_lat;
                            x.coord_lon = a.coord_lon;

                            //if (!string.IsNullOrEmpty(a.str_coord_lat))
                            //    x.coord_lat = GPSData.ConvertDMSToDouble(a.str_coord_lat);

                            //if (!string.IsNullOrEmpty(a.str_coord_lon))
                            //    x.coord_lon = GPSData.ConvertDMSToDouble(a.str_coord_lon);
                            

                            x.update_time = tmp;
                            x.updated_by = User.Identity.Name;

                            //UpdateModel(x);
                        }
                       // else if (!string.IsNullOrEmpty(a.name_site) && a.id == 0)
                        else if(a.notEmpty && a.id == 0)
                        { 
                            //add new ones
                            iom_ga_site_information x = new iom_ga_site_information();

                            x.name_site = a.name_site;
                            //x.coord_lat = a.coord_lat;
                            //x.coord_lon = a.coord_lon;

                            //if (!string.IsNullOrEmpty(a.str_coord_lat))
                            //    x.coord_lat = GPSData.ConvertDMSToDouble(a.str_coord_lat);

                            //if (!string.IsNullOrEmpty(a.str_coord_lon))
                            //    x.coord_lon = GPSData.ConvertDMSToDouble(a.str_coord_lon);
                            

                            x.create_time = tmp;
                            x.update_time = tmp;

                            x.created_by = User.Identity.Name;
                            x.updated_by = User.Identity.Name;

                            ga_p1.iom_ga_site_information.Add(x);
                        }
                        //else if (string.IsNullOrEmpty(a.name_site) && a.id!=0 )
                        else if(!a.notEmpty && a.id!=0)
                        {
                            //delete blank ones
                            iom_ga_site_information x = ga_p1.iom_ga_site_information.Where(y => y.id == a.id).FirstOrDefault();
                            _entity.iom_ga_site_information.DeleteObject(x);
                        }
                    }

                    TryUpdateModel(ga_p1);
                    _entity.SaveChanges();

                    return RedirectToAction("IndexP3", new { id = id });
                }
                catch
                {
                    return View(s);
                }
            }

            return View(s);
        }

        [Authorize]
        public ActionResult EditP4(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());


            iom_group_assessment_1 ga_p1 =
                (from c in _entity.iom_group_assessment_1
                 where c.id == id
                 select c).FirstOrDefault();

            return View(new Age_sample(ga_p1));
        }

        [HttpPost]
        public ActionResult EditP4(int id,Age_sample s)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            iom_group_assessment_1 ga_p1 =
                (from c in _entity.iom_group_assessment_1
                 where c.id == id
                 select c).FirstOrDefault();

            if (ga_p1!=null)
            {
                try
                {
                    // TODO: Add insert logic here

                    DateTime tmp = DateTime.Now;
                    int i = 0;
                    foreach (var b in ga_p1.iom_ga_gender_age_sample)
                    {
                        iom_ga_gender_age_sample bd = b;

                       // bd.ga_id = a.ga_id;
                       // bd.hhs = i;

                        //set value to zero
                        if (s.hh_ages[i].m_lt1 == null) bd.m_lt1 = 0; else { bd.m_lt1 = s.hh_ages[i].m_lt1; }
                        if (s.hh_ages[i].f_lt1 == null) bd.f_lt1 = 0; else { bd.f_lt1 = s.hh_ages[i].f_lt1; }
                        if (s.hh_ages[i].m_1_5 == null) bd.m_1_5 = 0; else { bd.m_1_5 = s.hh_ages[i].m_1_5; }
                        if (s.hh_ages[i].f_1_5 == null) bd.f_1_5 = 0; else { bd.f_1_5 = s.hh_ages[i].f_1_5; }
                        if (s.hh_ages[i].m_6_17 == null) bd.m_6_17 = 0; else { bd.m_6_17 = s.hh_ages[i].m_6_17; }
                        if (s.hh_ages[i].f_6_17 == null) bd.f_6_17 = 0; else { bd.f_6_17 = s.hh_ages[i].f_6_17; }
                        if (s.hh_ages[i].m_18_59 == null) bd.m_18_59 = 0; else { bd.m_18_59 = s.hh_ages[i].m_18_59; }
                        if (s.hh_ages[i].f_18_59 == null) bd.f_18_59 = 0; else { bd.f_18_59 = s.hh_ages[i].f_18_59; }
                        if (s.hh_ages[i].m_60p == null) bd.m_60p = 0; else { bd.m_60p = s.hh_ages[i].m_60p; }
                        if (s.hh_ages[i].f_60p == null) bd.f_60p = 0; else { bd.f_60p = s.hh_ages[i].f_60p; }

                        bd.update_time = tmp;
                        bd.updated_by = User.Identity.Name;

                        UpdateModel(bd);

                        i++;
                    }

                    _entity.SaveChanges();
                    return RedirectToAction("IndexP4", new { id = id });
                }
                catch
                {
                    return View(s);
                }
            }

            return View(s);
        }



        void gaFill(iom_group_assessment_1 ga1, iom_group_assessment_1 ga2)
        {
            ga1.group_id = ga2.group_id;
            //ga2.iom_researchers = ga2.iom_researchers;
            ga1.coord_lat = ga2.coord_lat;
            ga1.coord_lon = ga2.coord_lon;
            // 
            //ga1.str_coord_lat = ga2.str_coord_lat;
            //ga1.str_coord_lon = ga2.str_coord_lon;
            //
            ga1.credibility_rating = ga2.credibility_rating;
            ga1.f0_5 = ga2.f0_5;
            ga1.f15_24 = ga2.f15_24;
            ga1.f25_59 = ga2.f25_59;
            ga1.f5_14 = ga2.f5_14;
            ga1.f60p = ga2.f60p;
            ga1.interview_date = ga2.interview_date;
            ga1.state = ga2.state;
            ga1.lga_orgin = ga2.lga_orgin;
            ga1.location = ga2.location;
            ga1.m0_5 = ga2.m0_5;
            ga1.m15_24 = ga2.m15_24;
            ga1.m25_59 = ga2.m25_59;
            ga1.m5_14 = ga2.m5_14;
            ga1.m60p = ga2.m60p;
            ga1.number_hh = ga2.number_hh;
            ga1.number_ind = ga2.number_ind;
            ga1.reason_for_disp = ga2.reason_for_disp;
            ga1.reason_other = ga2.reason_other;
            ga1.researcher_id = ga2.researcher_id;
            ga1.shelter_type = ga2.shelter_type;
            ga1.sheter_type_other = ga2.sheter_type_other;
            ga1.wave_if_other = ga2.wave_if_other;
            ga1.wave_of_disp = ga2.wave_of_disp;
        }

        List<iom_ga_informants> rowToRemoveInf(List<iom_ga_informants> gai, List<iom_informants> inf)
        {
            List<int> l1 = gai.Select(x => x.informant).ToList();
            List<int> l2 = inf.Select(x => x.id).ToList();

            List<int> temp =  l1.Except(l2).ToList();

            return gai.Where( x=> temp.Contains(x.informant)).ToList();

        }

        List<iom_ga_idp_population> rowToRemoveIdpPop(List<iom_ga_idp_population> gap1, List<iom_ga_idp_population> gap2)
        {
            List<string> l1 = gap1.Select(x => x.ward_orig).ToList();
            List<string> l2 = gap2.Select(x => x.ward_orig).ToList();

            List<string> temp = l1.Except(l2).ToList();

            return gap1.Where(x => temp.Contains(x.ward_orig)).ToList();

        }

        //
        // GET: /B3F/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null,phase.ToString());

            var ga_p1 = (from c in _entity.iom_group_assessment_1
                         where c.id == id
                         select c).FirstOrDefault();

            if (ga_p1 != null)
            {
                //if (ga_p1.coord_lat != null)
                //    ga_p1.str_coord_lat = GPSData.ConvertDoubletoDMS(ga_p1.coord_lat ?? 0);

                //if (ga_p1.coord_lon != null)
                //    ga_p1.str_coord_lon = GPSData.ConvertDoubletoDMS(ga_p1.coord_lon ?? 0);

                return View(ga_p1);
            }


            return RedirectToAction("Index");
        }

        //
        // POST: /B3F/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null,phase.ToString());

            var ga_p1 = (from c in _entity.iom_group_assessment_1
                         where c.id == id
                         select c).FirstOrDefault();

            if (ga_p1 != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_group_assessment_1.DeleteObject(ga_p1);

                    _entity.SaveChanges();
                    
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(ga_p1);
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
         public ActionResult DeleteP2(int id)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null, phase.ToString());

            var ga_p2 = (from c in _entity.iom_group_assessment_2
                         where c.id == id
                         select c).FirstOrDefault();

            if (ga_p2 != null)
            {
                return View(ga_p2);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteP2(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            getSession();

            setViewBags(null,null, phase.ToString());

            var ga_p2 = (from c in _entity.iom_group_assessment_2
                         where c.id == id
                         select c).FirstOrDefault();

            if (ga_p2 != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_group_assessment_2.DeleteObject(ga_p2);

                    _entity.SaveChanges();

                    return RedirectToAction("IndexP2", new { id = id });
                }
                catch
                {
                    return View(ga_p2);
                }
            }

            return RedirectToAction("IndexP2", new { id = id });
        }


        [Authorize]
        public ActionResult DeleteP3(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            var sites = (from c in _entity.iom_ga_site_information
                         where c.ga_id == id
                         select c);

            if (sites != null)
            {
                //foreach (var a in sites)
                //{
                //    if (a.coord_lat != null)
                //        a.str_coord_lat = GPSData.ConvertDoubletoDMS(a.coord_lat ?? 0);

                //    if (a.coord_lon != null)
                //        a.str_coord_lon = GPSData.ConvertDoubletoDMS(a.coord_lon ?? 0);
                //}
                return View(sites);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteP3(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            var sites = (from c in _entity.iom_ga_site_information
                         where c.ga_id == id
                         select c).ToList();

            if (sites != null)
            {
                try
                {
                    // TODO: Add delete logic here

                    foreach (var a in sites)
                    {
                        _entity.iom_ga_site_information.DeleteObject(a);
                        _entity.SaveChanges();
                    }

                    //UpdateModel(ga_p1);


                    return RedirectToAction("IndexP3", new { id = id });
                }
                catch
                {
                    return View(sites);
                }
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult DeleteP4(int id)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            var ages = (from c in _entity.iom_ga_gender_age_sample
                         where c.ga_id == id
                         select c);

            if (ages != null)
            {
                return View(ages);
            }


            return RedirectToAction("IndexP4", new { id = id });
        }

        [HttpPost]
        public ActionResult DeleteP4(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            ViewBag.Page1 = id;

            getSession();

            setViewBags(null,null, phase.ToString());

            var ages = (from c in _entity.iom_ga_gender_age_sample
                         where c.ga_id == id
                         select c).ToList();

            if (ages != null)
            {
                try
                {
                    // TODO: Add delete logic here

                    foreach (var a in ages)
                    {
                        _entity.iom_ga_gender_age_sample.DeleteObject(a);
                        _entity.SaveChanges();
                    }

                    //UpdateModel(ga_p1);


                    return RedirectToAction("IndexP4", new { id = id });
                }
                catch
                {
                    return View(ages);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
