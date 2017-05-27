using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class B2FController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        //
        // GET: /B2F/

        public int wid;
        public string ward;

        SessionPath sesspath = new SessionPath();

        public ActionResult Index(int? id, string ward)
        {
            ViewBag.Active = "B1F";

            if (id != null)
            {
                setSession(id??0,ward);
                wid = id ?? 0;
            }
            else
                getSession();

            var b2f = (from c in _entity.iom_ward_profile
                       where c.id == wid
                       select c).FirstOrDefault();


            return View(b2f);
        }

        //
        // GET: /B2F/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            var b2f = (from c in _entity.iom_ward_profile
                       where c.id == id
                       select c).FirstOrDefault();
            setViewBags(null, b2f.iom_presence_wards.iom_profile.phase.ToString());
            //getSession();
            //ViewBag.ProfileID=w

            return View(b2f);
        }

        public void getSession()
        {

            //sesspath.setSession((SessionPath)Session["SessionPath"]);
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                ward = sesspath.ward;
                wid = sesspath.b2f_profile ?? 0;

                ViewBag.LgaInfo = sesspath.getLgaInfo();
            }

            //ward = sesspath.ward;
            //wid = sesspath.b2f_profile??0;

            //ViewBag.LgaInfo = sesspath.getLgaInfo();
           // ViewBag.WardInfo = sesspath.getWardInfo();

            //ward = (string)Session["ward"];
            //wid = (int)Session["id"];
        }

        public void setSession(int id, string ward)
        {
            //sesspath.setSession((SessionPath)Session["SessionPath"]);

            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                sesspath.ward = ward;
                sesspath.b2f_profile = id;

                ViewBag.LgaInfo = sesspath.getLgaInfo();

                string sesspath_serial = new JavaScriptSerializer().Serialize(sesspath);

                var cookie = new HttpCookie("SessionPath", sesspath_serial);
                HttpContext.Response.Cookies.Add(cookie);
            }

            //sesspath.ward = ward;
            //sesspath.b2f_profile = id;

            //ViewBag.LgaInfo = sesspath.getLgaInfo();
           // ViewBag.WardInfo = sesspath.getWardInfo();
            

            //Session["SessionPath"] = sesspath;

            //Session["ward"] = ward;
            //Session["id"] = id;
        }

        public void getWardInfo(string w)
        {
            var ward_ = (from c in _entity.lkp_Ward
                          where c.ward_code.Equals(w)
                          select c).FirstOrDefault();

            ViewBag.StateName = ward_.lkp_Lga.lkp_State.state_name;
            ViewBag.LGA = ward_.lkp_Lga.lga_name;
            ViewBag.Ward = ward_.ward_name;
            ViewBag.Wpcode = w;
        }

        public void setViewBags(string[] def, string phase)
        {
            if(ward!=null)
                getWardInfo(ward);

            ViewBag.Settlement = new SelectList(_entity.lkp_Settlement, "id", "settlement");

            ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");

            string st_1, st_2, st_3; //for section F.
            string st_4, st_5;//for section G.
            st_1 = st_2 = st_3 = "-1";
            st_4 = st_5 = "-1";

            if (def != null)
            {
                st_1 = def[0];
                st_2 = def[1];
                st_3 = def[2];
                st_4 = def[3];
                st_5 = def[4];
            }

            //edit on May 27, 2017 to allow dropdown only when select state
            ViewBag.LgasList1 = new SelectList(_entity.lkp_Lga.Where(x => x.state_code == st_1), "lga_code", "lga_name");
            ViewBag.LgasList2 = new SelectList(_entity.lkp_Lga.Where(x => x.state_code == st_2), "lga_code", "lga_name");
            ViewBag.LgasList3 = new SelectList(_entity.lkp_Lga.Where(x => x.state_code == st_3), "lga_code", "lga_name");

            ViewBag.LgasList4 = new SelectList(_entity.lkp_Lga.Where(x => x.state_code == st_4), "lga_code", "lga_name");
            ViewBag.LgasList5 = new SelectList(_entity.lkp_Lga.Where(x => x.state_code == st_5), "lga_code", "lga_name");

            //ViewBag.WardsList = new SelectList(_entity.lkp_Ward, "ward_code", "ward_name");

            ViewBag.LocationsList = new SelectList(_entity.lkp_Location, "id", "location");
            ViewBag.NotRetLocation = new SelectList(_entity.lkp_NotReturnLocation, "id", "location");

            ViewBag.Periods = new SelectList(_entity.lkp_Period2.Where(x=>x.phase.Equals(phase)), "id", "label");

           // ViewBag.Period1 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");

            string str_phase = phase.Equals("1") ? "1_1" : phase;

            ViewBag.Period2 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(str_phase)), "id", "label");
            ViewBag.YesNo_ = new SelectList(_entity.lkp_YesNo.Where(x => x.id<=2), "id", "value");
           // ViewBag.Period2 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");
        }

        public void setViewBags2(string phase)
        {
            if (ward != null)
                getWardInfo(ward);

            ViewBag.Settlement = new SelectList(_entity.lkp_Settlement, "id", "settlement");

            ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");

            ViewBag.LgasList = new SelectList(_entity.lkp_Lga, "lga_code", "lga_name");

            ViewBag.WardsList = new SelectList(_entity.lkp_Ward, "ward_code", "ward_name");

            ViewBag.LocationsList = new SelectList(_entity.lkp_Location, "id", "location");
            ViewBag.NotRetLocation = new SelectList(_entity.lkp_NotReturnLocation, "id", "location");

            ViewBag.Periods = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");

            // ViewBag.Period1 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");

            string str_phase = phase.Equals("1") ? "1_1" : phase;

            ViewBag.Period2 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(str_phase)), "id", "label");
            ViewBag.YesNo_ = new SelectList(_entity.lkp_YesNo.Where(x => x.id <= 2), "id", "value");
            // ViewBag.Period2 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");
        }

        [HttpPost]
        public JsonResult GetResearcherTels(string r_name)
        {
            //var r_tel = new SelectList( _entity.iom_researchers.Where(x => x.researcher_name.Equals(r_name)), "researcher_tel", "researcher_tel").FirstOrDefault();

            var r_tel = _entity.iom_researchers.Where(x => x.researcher_name.Equals(r_name)).Select(y => y.researcher_tel).FirstOrDefault();


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

        //new adding 14.APR.17
        //Json
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

        //
        // GET: /B2F/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            getSession();

            string period_txt = (_entity.iom_dtm_phase.Where(y=>y.closed_YesNo==2).Max(x => x.phase)).ToString();

            var ward_=_entity.iom_presence_wards.Where(x => x.id == wid).FirstOrDefault();
            
            setViewBags(null, period_txt);

           /* getSession();
            */
            B2F b2f = new B2F();
            b2f.profile.number_hh = ward_.estimate_hh;
            b2f.profile.number_ind=ward_.estimate_ind;
            b2f.profile.displaced_hh_ind_YesNo = 1;

            return View(b2f);

            //return View();
        } 

        //
        // POST: /B2F/Create

        [HttpPost]
        [Authorize]
        public ActionResult Create(B2F b2f)
        {
            ViewBag.Active = "B1F";

            // var errors = ModelState.Values.SelectMany(v => v.Errors);
            string period_txt = (_entity.iom_dtm_phase.Where(y=>y.closed_YesNo==2).Max(x => x.phase)).ToString();

            getSession();

            var states_def = new string[5]{
                b2f.profile.disp_2T_state,
                b2f.profile.disp_3T_state,
                b2f.profile.disp_3Tp_state,
                b2f.profile.state_prev_disp_LargestGrp1,
                b2f.profile.state_prev_disp_LargestGrp2
            };

            setViewBags(states_def, period_txt);
            //findStateCode(b1f.profile.lga)

            iom_ward_profile profile = new iom_ward_profile();

            if (ModelState.IsValid)
            {


                try
                {
                    // TODO: Add insert logic here

                    profile = b2f.profile;

                    profile.id = wid;

                    profile.iom_presence_wards = _entity.iom_presence_wards.Where(
                        x => x.id == profile.id
                        ).ToList().FirstOrDefault();

                    
                    profile.created_by = User.Identity.Name;
                    profile.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    profile.create_time = tmp;
                    profile.update_time = tmp;

                    profile.iom_researchers = findResearcher(b2f.researcher);

                    profile.iom_researchers.researcher_tel = b2f.researcher.researcher_tel;


                    for (int i = 0; i < b2f.arrivals.Count(); i++)
                    {


                        iom_ward_idp_arrival arrival = b2f.arrivals[i];

                      /*  switch (i)
                        {
                            case 0: arrival.year = "2011"; break;
                            case 1: arrival.year = "2012"; break;
                            case 2: arrival.year = "2013"; break;
                            case 3: arrival.year = "2014"; break;
                            default: arrival.year = "2011"; break;

                        }*/

                        arrival.created_by = User.Identity.Name;
                        arrival.create_time = tmp;

                        arrival.updated_by = User.Identity.Name;
                        arrival.update_time = tmp;

                        profile.iom_ward_idp_arrival.Add(arrival);
                    }

                    new VerifForm(new B2F(profile));

                    _entity.iom_ward_profile.AddObject(profile);// Add(profile);
                    _entity.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(new B2F(profile));
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;

                    if (msg.Contains("B2F"))
                    {
                        ViewBag.Exception = "* " + msg;

                        return View(b2f);
                    }

                    ViewBag.Exception = "* Operation failed!";

                    return View(b2f);
                }
            }

            return View(b2f);
        }
        
        //
        // GET: /B2F/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            var b2f = (from c in _entity.iom_ward_profile
                       where c.id == id
                       select c).FirstOrDefault();

            var ward_ = _entity.iom_presence_wards.Where(x => x.id == id).FirstOrDefault();

         //   b2f.number_hh = ward_.estimate_hh;
         //   b2f.number_ind = ward_.estimate_ind;
          //  b2f.displaced_hh_ind_YesNo = 1;

            getSession();

            var states_def = new string[5]{
                b2f.disp_2T_state,
                b2f.disp_3T_state,
                b2f.disp_3Tp_state,
                b2f.state_prev_disp_LargestGrp1,
                b2f.state_prev_disp_LargestGrp2
            };

            setViewBags(states_def, b2f.iom_presence_wards.iom_profile.phase.ToString());
            //setViewBags(b2f.iom_presence_wards.iom_profile.phase.ToString());

            return View(new B2F(b2f));
        }

        //
        // POST: /B2F/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, B2F prof)
        {
            ViewBag.Active = "B1F";

            var b2f = (from c in _entity.iom_ward_profile
                       where c.id == id
                       select c).FirstOrDefault();

            getSession();
            var states_def = new string[5]{
                prof.profile.disp_2T_state,
                prof.profile.disp_3T_state,
                prof.profile.disp_3Tp_state,
                prof.profile.state_prev_disp_LargestGrp1,
                prof.profile.state_prev_disp_LargestGrp2
            };

            setViewBags(states_def, b2f.iom_presence_wards.iom_profile.phase.ToString());

            if (b2f != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        // TODO: Add update logic here

                        int i = 0;

                        DateTime tmp = DateTime.Now;


                        foreach (iom_ward_idp_arrival item in b2f.iom_ward_idp_arrival)
                        {
                            iom_ward_idp_arrival tem = item;
                            tem.hh = prof.arrivals[i].hh;
                            tem.ind = prof.arrivals[i].ind;
                            //tem.percentage = prof.arrivals[i].percentage;
                            tem.state_type = prof.arrivals[i].state_type;
                            tem.location = prof.arrivals[i].location;

                            tem.update_time = tmp;
                            tem.updated_by = User.Identity.Name;

                            i++;
                        }

                        b2f.iom_researchers = findResearcher(prof.researcher);

                        b2f.iom_researchers.researcher_tel = prof.researcher.researcher_tel;

                        b2f.date = prof.profile.date;

                        //b2f.lga = prof.profile.prof.profile.lga;
                        b2f.settlement = prof.profile.settlement;
                        b2f.settlement_type = prof.profile.settlement_type;
                        b2f.displaced_hh_ind_YesNo = prof.profile.displaced_hh_ind_YesNo;
                        b2f.number_hh = prof.profile.number_hh;
                        b2f.number_ind = prof.profile.number_ind;
                        b2f.nr_YesNo = prof.profile.nr_YesNo;
                        b2f.nr_location = prof.profile.nr_location;
                        b2f.nr_state1 = prof.profile.nr_state1;
                        b2f.nr_state2 = prof.profile.nr_state2;
                        b2f.nr_period = prof.profile.nr_period;

                        b2f.reason_insurgency_YesNo = prof.profile.reason_insurgency_YesNo;
                        b2f.reason_insurg_hh = prof.profile.reason_insurg_hh;
                        b2f.reason_insurg_ind = prof.profile.reason_insurg_ind;
                        b2f.reason_insurg_year = prof.profile.reason_insurg_year;

                        b2f.reason_clash_YesNo = prof.profile.reason_clash_YesNo;
                        b2f.reason_clash_hh = prof.profile.reason_clash_hh;
                        b2f.reason_clash_ind = prof.profile.reason_clash_ind;
                        b2f.reason_clash_year = prof.profile.reason_clash_year;


                        b2f.reason_disaster_YesNo = prof.profile.reason_disaster_YesNo;
                        b2f.reason_disaster_hh = prof.profile.reason_disaster_hh;
                        b2f.reason_disaster_ind = prof.profile.reason_disaster_ind;
                        b2f.reason_disaster_year = prof.profile.reason_disaster_year;

                        b2f.reason_others_YesNo = prof.profile.reason_others_YesNo;
                        b2f.reason_others_name = prof.profile.reason_others_name;
                        b2f.reason_others_hh = prof.profile.reason_others_hh;
                        b2f.reason_others_ind = prof.profile.reason_others_ind;
                        b2f.reason_others_year = prof.profile.reason_others_year;


                        b2f.temporary_settlement_type_camp_YesNo = prof.profile.temporary_settlement_type_camp_YesNo;
                        b2f.temporary_settlement_hh_camp = prof.profile.temporary_settlement_hh_camp;
                        b2f.temporary_settlement_ind_camp = prof.profile.temporary_settlement_ind_camp;
                        //b2f.temporary_settlement_locations_camp = prof.profile.temporary_settlement_locations_camp;

                        b2f.temporary_settlement_type_hc_YesNo = prof.profile.temporary_settlement_type_hc_YesNo;
                        b2f.temporary_settlement_hh_hc = prof.profile.temporary_settlement_hh_hc;
                        b2f.temporary_settlement_ind_hc = prof.profile.temporary_settlement_ind_hc;
                        //b2f.temporary_settlement_locations_hc = prof.profile.temporary_settlement_locations_hc;


                        //Adding new fields Section I
                        b2f.housing_shelter = prof.profile.housing_shelter;
                        b2f.drinking_water = prof.profile.drinking_water;
                        b2f.food = prof.profile.food;
                        b2f.medical_care = prof.profile.medical_care;
                        b2f.access_edu = prof.profile.access_edu;
                        b2f.hygiene_kits = prof.profile.hygiene_kits;
                        b2f.sewage_disp = prof.profile.sewage_disp;

                        //Adding new fields Section J
                        b2f.hospitality_extent = prof.profile.hospitality_extent;
                        b2f.diff_cause_issues = prof.profile.diff_cause_issues;
                        b2f.tensions_idp_hc = prof.profile.tensions_idp_hc;
                        b2f.collabo_idp_hc = prof.profile.collabo_idp_hc;
                        b2f.res_shr_idp_hc = prof.profile.res_shr_idp_hc;

                        b2f.stigma_toward1 = prof.profile.stigma_toward1;
                        b2f.stigma_toward2 = prof.profile.stigma_toward2;
                        b2f.stigma_toward3 = prof.profile.stigma_toward3;

                        b2f.trust_ppl1 = prof.profile.trust_ppl1;
                        b2f.trust_ppl2 = prof.profile.trust_ppl2;
                        b2f.trust_ppl3 = prof.profile.trust_ppl3;

                        //start adding new fields - 06.OCT.16
                        b2f.NbHH_makeshift = prof.profile.NbHH_makeshift;
                        b2f.NbHH_overcrowded_houses = prof.profile.NbHH_overcrowded_houses;
                        b2f.NbHH_damaged_houses = prof.profile.NbHH_damaged_houses;
                        b2f.NbHH_living_outdoors = prof.profile.NbHH_living_outdoors;
                        b2f.NbHH_need_NFI = prof.profile.NbHH_need_NFI;
                        b2f.NbHH_need_KitchenSet = prof.profile.NbHH_need_KitchenSet;
                        b2f.NbHH_need_Full_kits = prof.profile.NbHH_need_Full_kits;
                        //end adding new fields - 06.OCT.16

                        //start adding new fields - 15.APR.17
                        b2f.disp_1T_yn = prof.profile.disp_1T_yn;
                        b2f.disp_2T_yn = prof.profile.disp_2T_yn;
                        b2f.disp_3T_yn = prof.profile.disp_3T_yn;
                        b2f.disp_3Tp_yn = prof.profile.disp_3Tp_yn;

                        b2f.disp_1T_perc = prof.profile.disp_1T_perc;
                        b2f.disp_2T_perc = prof.profile.disp_2T_perc;
                        b2f.disp_3T_perc = prof.profile.disp_3T_perc;
                        b2f.disp_3Tp_perc = prof.profile.disp_3Tp_perc;

                        b2f.disp_2T_state = prof.profile.disp_2T_state;
                        b2f.disp_3T_state = prof.profile.disp_3T_state;
                        b2f.disp_3Tp_state = prof.profile.disp_3Tp_state;

                        b2f.disp_2T_lga = prof.profile.disp_2T_lga;
                        b2f.disp_3T_lga = prof.profile.disp_3T_lga;
                        b2f.disp_3Tp_lga = prof.profile.disp_3Tp_lga;

                        //--not used - not in the B2F form
                        //b2f.disp_2T_ward = prof.profile.disp_2T_ward;
                        //b2f.disp_3T_ward = prof.profile.disp_3T_ward;
                        //b2f.disp_3Tp_ward = prof.profile.disp_3Tp_ward;

                        //Added by Abdul on May 25, 2017 (disp_1T_dispDate)
                        //b2f.disp_1T_dispDate = prof.profile.disp_1T_dispDate;

                        b2f.disp_1T_dispDate = prof.profile.disp_1T_dispDate;
                        b2f.disp_2T_dispDate = prof.profile.disp_2T_dispDate;
                        b2f.disp_3T_dispDate = prof.profile.disp_3T_dispDate;
                        b2f.disp_3Tp_dispDate = prof.profile.disp_3Tp_dispDate;

                        b2f.idps_fromLGA_dispInWard = prof.profile.idps_fromLGA_dispInWard;
                        b2f.NbHH_dispInWard = prof.profile.NbHH_dispInWard;
                        b2f.NbIND_dispInWard = prof.profile.NbIND_dispInWard;

                        b2f.state_prev_disp_LargestGrp1 = prof.profile.state_prev_disp_LargestGrp1;
                        b2f.lga_prev_disp_LargestGrp1 = prof.profile.lga_prev_disp_LargestGrp1;
                        b2f.NbHH_LargestGrp1 = prof.profile.NbHH_LargestGrp1;
                        b2f.NbIND_LargestGrp1 = prof.profile.NbIND_LargestGrp1;
                        b2f.date_arriv_LGA_LargestGrp1 = prof.profile.date_arriv_LGA_LargestGrp1;

                        b2f.state_prev_disp_LargestGrp2 = prof.profile.state_prev_disp_LargestGrp2;
                        b2f.lga_prev_disp_LargestGrp2 = prof.profile.lga_prev_disp_LargestGrp2;
                        b2f.NbHH_LargestGrp2 = prof.profile.NbHH_LargestGrp2;
                        b2f.NbIND_LargestGrp2 = prof.profile.NbIND_LargestGrp2;
                        b2f.date_arriv_LGA_LargestGrp2 = prof.profile.date_arriv_LGA_LargestGrp2;

                        //end adding new fields - 15.APR.17
                        b2f.update_time = tmp;

                        b2f.updated_by = User.Identity.Name;

                        new VerifForm(new B2F(b2f));

                        //UpdateModel(b2f);
                        //_entity
                        _entity.SaveChanges();


                        return RedirectToAction("Index");
                    }
                    catch (MyException e)
                    {
                        ViewBag.Exception = e.Message;
                        return View(new B2F(b2f));
                    }
                    catch
                    {
                        ViewBag.Exception = "* Operation failed!";

                        return View(new B2F(b2f));

                        //return View();
                    }
                }
                return View(new B2F(b2f));

            }
            return View(prof);
        }

        //
        // GET: /B2F/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var b2f = (from c in _entity.iom_ward_profile
                       where c.id == id
                       select c).FirstOrDefault();

            setViewBags(null, b2f.iom_presence_wards.iom_profile.phase.ToString());

            if (b2f != null)
            {
                return View(b2f);
            }

            return RedirectToAction("Index");

        }

        //
        // POST: /B2F/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            var b2f = (from c in _entity.iom_ward_profile
                       where c.id == id
                       select c).FirstOrDefault();

            setViewBags(null, b2f.iom_presence_wards.iom_profile.phase.ToString());

            if (b2f != null)
            {

                try
                {
                    // TODO: Add delete logic here

                    _entity.iom_ward_profile.DeleteObject(b2f);// Remove(b2f);

                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(b2f);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
