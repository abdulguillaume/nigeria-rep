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
            setViewBags(b2f.iom_presence_wards.iom_profile.phase.ToString());
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

        public void setViewBags(string phase)
        {
            if(ward!=null)
                getWardInfo(ward);

            ViewBag.Settlement = new SelectList(_entity.lkp_Settlement, "id", "settlement");

            ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");


            ViewBag.LocationsList = new SelectList(_entity.lkp_Location, "id", "location");
            ViewBag.NotRetLocation = new SelectList(_entity.lkp_NotReturnLocation, "id", "location");

            ViewBag.Periods = new SelectList(_entity.lkp_Period2.Where(x=>x.phase.Equals(phase)), "id", "label");

           // ViewBag.Period1 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");

            string str_phase = phase.Equals("1") ? "1_1" : phase;

            ViewBag.Period2 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(str_phase)), "id", "label");
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
        //
        // GET: /B2F/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            getSession();

            string period_txt = (_entity.iom_dtm_phase.Where(y=>y.closed_YesNo==2).Max(x => x.phase)).ToString();

            var ward_=_entity.iom_presence_wards.Where(x => x.id == wid).FirstOrDefault();
            
            setViewBags(period_txt);

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
            setViewBags(period_txt);


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

                    _entity.AddObject("iom_ward_profile", profile);
                    _entity.SaveChanges();


                    return RedirectToAction("Index");
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(new B2F(profile));
                }
                catch(Exception ex)
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
            setViewBags(b2f.iom_presence_wards.iom_profile.phase.ToString());

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
            setViewBags(b2f.iom_presence_wards.iom_profile.phase.ToString());

            if (b2f != null)
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


                    b2f.update_time = tmp;

                    b2f.updated_by = User.Identity.Name;

                    new VerifForm(new B2F(b2f));

                    UpdateModel(b2f);
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

            setViewBags(b2f.iom_presence_wards.iom_profile.phase.ToString());

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

            setViewBags(b2f.iom_presence_wards.iom_profile.phase.ToString());

            if (b2f != null)
            {

                try
                {
                    // TODO: Add delete logic here

                    _entity.iom_ward_profile.DeleteObject(b2f);

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
