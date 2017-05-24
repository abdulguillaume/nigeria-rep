using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DTM_Nigeria.Models;

using PagedList;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

using ClosedXML.Excel;
using System.Data;

namespace DTM_Nigeria.Controllers
{
    public class B1FController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();

        int? last_page = 1;
        int? phase_ = -1;
        string state_;

        //
        // GET: /B1F/

        public ActionResult Index(int? page)
        {

            ViewBag.Active = "B1F";
           
            //to add search functionnality

           // if (page == null)
                getSession();
           // else
                setSession(page ?? (last_page??1),phase_??-1,state_);

            var b1fs = from c in _entity.iom_profile where (phase_==-1 || c.phase==phase_) && 
                       (string.IsNullOrEmpty(state_) || c.lkp_Lga.state_code.Equals(state_))
                       orderby c.create_time descending
                       select c;


            ViewBag.Phase = new SelectList(_entity.iom_dtm_phase, "phase", "description");
            ViewBag.SelectedPhase = phase_;
            ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");
            ViewBag.SelectedState = state_;


            //return View(fichas);
            int pageSize = 15;
            int pageNumber = last_page ?? 1;



            return View(b1fs.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Index(int? page, int? phase, string state)
        {
            ViewBag.Active = "B1F";

            //to add search functionnality

            //if (page == null)
            //    getSession();
            //else
                setSession(1, phase ?? -1, state);

            var b1fs = from c in _entity.iom_profile where (phase_ == -1 || c.phase == phase_) &&
                       (string.IsNullOrEmpty(state_) || c.lkp_Lga.state_code.Equals(state_))
                       orderby c.create_time descending
                       select c;


            ViewBag.Phase = new SelectList(_entity.iom_dtm_phase, "phase", "description");
            ViewBag.SelectedPhase = phase_;
            ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");
            ViewBag.SelectedState = state_;


            //return View(fichas);
            int pageSize = 15;
            int pageNumber = last_page ?? 1;



            return View(b1fs.ToPagedList(pageNumber, pageSize));
        }

        //
        // GET: /B1F/Details/5

        public ActionResult Details(int id)
        {
            //ExportExcel();

            ViewBag.Active = "B1F";

            var b1f = (from c in _entity.iom_profile
                       where c.id==id
                       select c).FirstOrDefault();

            setViewBags(null, b1f.phase.ToString());
          //  ViewBag.
            return View(b1f);
        }

        public void getSession()
        {
            if (Session["last_page"] != null)
            {
                last_page = (int)Session["last_page"];
                phase_ = (int)Session["phase_"];
                state_ = (string)Session["state_"];
            }

        }

        public void setSession(int id, int phase, string state)
        {
            Session["last_page"] = id;
            last_page = id;
            Session["phase_"] = phase;
            phase_ = phase;
            Session["state_"] = state;
            state_ = state;
        }

        //
        // GET: /B1F/Create

        public void setViewBags(string def, string phase)
        {

            ViewBag.DefStateCode = def;

            ViewBag.Settlement = new SelectList(_entity.lkp_Settlement, "id", "settlement");

            ViewBag.Phase = new SelectList(_entity.iom_dtm_phase, "phase", "description");

                ViewBag.StatesList = new SelectList(_entity.lkp_State, "state_code", "state_name");

                ViewBag.LGA = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(def==null?"-1":def)), "lga_code", "lga_name");




            ViewBag.LocationsList = new SelectList(_entity.lkp_Location, "id", "location");
            ViewBag.NotRetLocation = new SelectList(_entity.lkp_NotReturnLocation, "id", "location");

            //string period_txt = "C"+(_entity.iom_dtm_phase.Max(x => x.phase)).ToString();

            ViewBag.Periods = new SelectList(_entity.lkp_Period2.Where(x=>x.phase.Equals(phase)), "id", "label" );

           // ViewBag.Period1 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(phase)), "id", "label");

            string str_phase = phase.Equals("1") ? "1_1" : phase;

            ViewBag.Period2 = new SelectList(_entity.lkp_Period2.Where(x => x.phase.Equals(str_phase)), "id", "label");
        }


        [HttpPost]
        public JsonResult getLgaList(string id)
        {
            var lgas = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(id)), "lga_code", "lga_name").ToList();
            return Json(lgas, JsonRequestBehavior.AllowGet);
        }

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

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

           // ViewBag.Exception= DateTime.Now.ToShortDateString().Replace("/","");
            //if ((_entity.iom_dtm_phase.Where(y => y.closed_YesNo == 2).Max(x => x.phase)) == null)
            //    string phase_="";
            //else
            string phase_ = (_entity.iom_dtm_phase.Where(y => y.closed_YesNo == 2).Max(x => x.phase)).ToString();

            setViewBags(null, phase_);
            B1F b1f = new B1F();
            return View(b1f);

           // try
            //{
                // TODO: Add logic here to catch exception from creating B1F is phase is NULL
            /*var phs = from c in _entity.iom_dtm_phase where (c.phase==2)
                       select c;
            if (phs != null)
            {
                string phase_ = (_entity.iom_dtm_phase.Where(y => y.closed_YesNo == 2).Max(x => x.phase)).ToString();

                setViewBags(null, phase_);
                B1F b1f = new B1F();
                return View(b1f);
            }
            else
            {
                ViewBag.Exception = "* Operation failed, phase is closed!";

                return View();
            }*/



        } 

        
        //
        // POST: /B1F/Create

        [HttpPost]
        public ActionResult Create(B1F b1f)
        {
            ViewBag.Active = "B1F";

           // var errors = ModelState.Values.SelectMany(v => v.Errors);

            iom_profile profile = new iom_profile();

            if (!string.IsNullOrEmpty(b1f.profile.lga))
                setViewBags(findStateCode(b1f.profile.lga), b1f.profile.phase.ToString() );
            else
                setViewBags(null, b1f.profile.phase.ToString());

            if (ModelState.IsValid)
            {

                try
                {
                    // TODO: Add insert logic here
                    profile = b1f.profile;
                    
                    if(b1f.profile.phase==0)
                        profile.phase = _entity.iom_dtm_phase.Max(x => x.phase);

                    profile.iom_dtm_phase = _entity.iom_dtm_phase.Where(
                        x => x.phase == profile.phase
                        ).ToList().FirstOrDefault();

                    profile.created_by = User.Identity.Name;
                    profile.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    profile.create_time = tmp;
                    profile.update_time = tmp;

                    profile.iom_researchers = findResearcher(b1f.researcher);

                    profile.iom_researchers.researcher_tel = b1f.researcher.researcher_tel;

                    for (int i = 0; i < b1f.arrivals.Count(); i++)
                    {
                        iom_idp_arrival arrival = b1f.arrivals[i];

                       // if (arrival.state_type!=null && arrival.state_type.Equals("1"))
                         //   arrival.location = b1f.inSameState(null);

                        arrival.created_by = User.Identity.Name;
                        arrival.create_time = tmp;

                        arrival.updated_by = User.Identity.Name;
                        arrival.update_time = tmp;

                        profile.iom_idp_arrival.Add(arrival);
                    }

                    new VerifForm(new B1F(profile));

                    _entity.iom_profile.Add(profile);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (MyException e) {
                    ViewBag.Exception = e.Message;
                    return View(new B1F(profile));
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(new B1F(profile));
                }
            }

            return View(b1f);
        }

        public string findStateCode(string lga)
        {
            var lga_ = (from c in _entity.lkp_Lga
                       where c.lga_code == lga
                       select c).FirstOrDefault();


            if (lga_ != null) {
                return lga_.state_code;
            }
            return null;
        }

        //
        // GET: /B1F/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            var b1f = (from c in _entity.iom_profile
                       where c.id == id
                       select c).FirstOrDefault();

            setViewBags(b1f.lkp_Lga.state_code, b1f.phase.ToString());

            return View(new B1F(b1f));
        }

        //
        // POST: /B1F/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, B1F prof)
        {
            ViewBag.Active = "B1F";

            var b1f = (from c in _entity.iom_profile
                       where c.id == id
                       select c).ToList().FirstOrDefault();

            setViewBags(findStateCode(prof.profile.lga), prof.profile.phase.ToString());

            if (b1f != null)
            {
                try
                {
                    // TODO: Add update logic here

                    int i = 0;

                    DateTime tmp = DateTime.Now;


                    foreach (iom_idp_arrival item in b1f.iom_idp_arrival)
                    {
                        iom_idp_arrival tem = item;
                        tem.hh = prof.arrivals[i].hh;
                        tem.ind = prof.arrivals[i].ind;
                       // tem.percentage = prof.arrivals[i].percentage;
                        tem.state_type = prof.arrivals[i].state_type;

                        //if (tem.state_type!=null && tem.state_type.Equals("1"))
                        //    tem.location = prof.inSameState(null);
                        //else if (tem.state_type != null && tem.state_type.Equals("2"))
                            tem.location = prof.arrivals[i].location;

                        tem.update_time = tmp;
                        tem.updated_by = User.Identity.Name;

                        i++;
                    }

                    b1f.iom_researchers = findResearcher(prof.researcher);

                    b1f.iom_researchers.researcher_tel = prof.researcher.researcher_tel;

                    b1f.date = prof.profile.date;

                    b1f.lga = prof.profile.lga;
                    b1f.settlement = prof.profile.settlement;
                    b1f.settlement_type = prof.profile.settlement_type;
                    b1f.displaced_hh_ind_YesNo = prof.profile.displaced_hh_ind_YesNo;
                    b1f.number_hh = prof.profile.number_hh;
                    b1f.number_ind = prof.profile.number_ind;
                    b1f.nr_YesNo = prof.profile.nr_YesNo;
                    b1f.nr_location = prof.profile.nr_location;
                    b1f.nr_state1 = prof.profile.nr_state1;
                    b1f.nr_state2 = prof.profile.nr_state2;
                    b1f.nr_period = prof.profile.nr_period;

                    b1f.reason_insurgency_YesNo = prof.profile.reason_insurgency_YesNo;
                    b1f.reason_insurg_hh = prof.profile.reason_insurg_hh;
                    b1f.reason_insurg_ind = prof.profile.reason_insurg_ind;
                    b1f.reason_insurg_year = prof.profile.reason_insurg_year;

                    b1f.reason_clash_YesNo = prof.profile.reason_clash_YesNo;
                    b1f.reason_clash_hh = prof.profile.reason_clash_hh;
                    b1f.reason_clash_ind = prof.profile.reason_clash_ind;
                    b1f.reason_clash_year = prof.profile.reason_clash_year;

                    b1f.reason_disaster_YesNo = prof.profile.reason_disaster_YesNo;
                    b1f.reason_disaster_hh = prof.profile.reason_disaster_hh;
                    b1f.reason_disaster_ind = prof.profile.reason_disaster_ind;
                    b1f.reason_disaster_year = prof.profile.reason_disaster_year;

                    b1f.reason_others_YesNo = prof.profile.reason_others_YesNo;
                    b1f.reason_others_name = prof.profile.reason_others_name;
                    b1f.reason_others_hh = prof.profile.reason_others_hh;
                    b1f.reason_others_ind = prof.profile.reason_others_ind;
                    b1f.reason_others_year = prof.profile.reason_others_year;


                    b1f.temporary_settlement_type_camp_YesNo = prof.profile.temporary_settlement_type_camp_YesNo;
                    b1f.temporary_settlement_hh_camp = prof.profile.temporary_settlement_hh_camp;
                    b1f.temporary_settlement_ind_camp = prof.profile.temporary_settlement_ind_camp;
                    //b1f.temporary_settlement_locations_camp = prof.profile.temporary_settlement_locations_camp;

                    b1f.temporary_settlement_type_hc_YesNo = prof.profile.temporary_settlement_type_hc_YesNo;
                    b1f.temporary_settlement_hh_hc = prof.profile.temporary_settlement_hh_hc;
                    b1f.temporary_settlement_ind_hc = prof.profile.temporary_settlement_ind_hc;
                    //b1f.temporary_settlement_locations_hc = prof.profile.temporary_settlement_locations_hc;

                    b1f.update_time = tmp;

                    b1f.updated_by = User.Identity.Name;


                    new VerifForm(new B1F(b1f));

                    UpdateModel(b1f);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;
                    return View(new B1F(b1f));
                }
                catch(Exception ex)
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(new B1F(b1f));

                    //return View();
                }
            }


            return View(prof);

        }

        //
        // GET: /B1F/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var b1f = (from c in _entity.iom_profile
                         where c.id==id
                         select c).FirstOrDefault();

            setViewBags(null, b1f.phase.ToString());

            if (b1f != null)
            {
                return View(b1f);
            }

            return RedirectToAction("Index");

           // return View();
        }

        //
        // POST: /B1F/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

           var b1f = (from c in _entity.iom_profile
                         where c.id==id
                         select c).FirstOrDefault();

           setViewBags(null, b1f.phase.ToString());

           if (b1f != null)
           {

               try
               {
                   // TODO: Add delete logic here

                   foreach (iom_presence_wards wards in b1f.iom_presence_wards) {

                       if (wards.iom_ward_profile!=null) throw new Exception();               
                   
                   }

                   _entity.iom_profile.Remove(b1f);

                   _entity.SaveChanges();

                   return RedirectToAction("Index");
               }
               catch
               {
                   ViewBag.Exception = "* Operation failed!";

                   return View(b1f);
               }
           }

           return RedirectToAction("Index");
        }
    }
}
