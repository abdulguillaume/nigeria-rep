using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class BreakdownController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        public int ward_profile_id;

        SessionPath sesspath = new SessionPath();
        //
        // GET: /Breakdown/

        public ActionResult Index(int? id)
        {
            ViewBag.Active = "B1F";

            if (id != null)
            {
                setSession(id ?? 0);
                ward_profile_id = id ?? 0;
            }
            else
                getSession();


            var orgs = from c in _entity.iom_ward_households_breakdown
                       where c.ward_profile_id == ward_profile_id
                       orderby c.created_by descending
                       select c;


            return View(orgs);
        }

        public void setSession(int id)
        {
            //sesspath.setSession((SessionPath)Session["SessionPath"]);
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                sesspath.b2f_profile = id;

                //ViewBag.LgaInfo = sesspath.getLgaInfo();
                ViewBag.WardInfo = sesspath.getWardInfo();

                string sesspath_serial = new JavaScriptSerializer().Serialize(sesspath);

                var cookie = new HttpCookie("SessionPath", sesspath_serial);
                HttpContext.Response.Cookies.Add(cookie);
            }

            //sesspath.b2f_profile = id;
            //Session["SessionPath"] = sesspath;

            //Session["ward_profile_id"] = id;
        }

        public void getSession()
        {
           // sesspath.setSession((SessionPath)Session["SessionPath"]);
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                ward_profile_id = sesspath.b2f_profile ?? 0;

                ViewBag.WardInfo = sesspath.getWardInfo();
                //   ward_profile_id = (int)Session["ward_p
            }

           // ward_profile_id = sesspath.b2f_profile ?? 0;
            //   ward_profile_id = (int)Session["ward_profile_id"];


        }

        //public void setSession(int id)
        //{
        //    Session["ward_profile_id"] = id;
        //}

        //public void getSession()
        //{
        //    ward_profile_id = (int)Session["ward_profile_id"];


        //}

        //
        // GET: /Breakdown/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            return View();
        }

        //
        // GET: /Breakdown/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            return View();
        } 

        //
        // POST: /Breakdown/Create

        [HttpPost]
        public ActionResult Create(Breakdown hhbd)
        {
            ViewBag.Active = "B1F";

            getSession();

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here

                    DateTime tmp = DateTime.Now;
                    int i = 0;
                    foreach (var hhage in  hhbd.hh_ages)
                    {
                        i++;
                        iom_ward_households_breakdown bd = hhage;

                        bd.hhs = i;
                        bd.ward_profile_id = ward_profile_id;

                        bd.created_by = User.Identity.Name;
                        bd.create_time = tmp;

                        bd.updated_by = User.Identity.Name;
                        bd.update_time = tmp;

                        //set value to zero
                        if (bd.m_lt1 == null) bd.m_lt1 = 0;
                        if (bd.f_lt1 == null) bd.f_lt1 = 0;
                        if (bd.m_1_5 == null) bd.m_1_5 = 0;
                        if (bd.f_1_5 == null) bd.f_1_5 = 0;
                        if (bd.m_6_17 == null) bd.m_6_17 = 0;
                        if (bd.f_6_17 == null) bd.f_6_17 = 0;
                        if (bd.m_18_59 == null) bd.m_18_59 = 0;
                        if (bd.f_18_59 == null) bd.f_18_59 = 0;
                        if (bd.m_60p == null) bd.m_60p = 0;
                        if (bd.f_60p == null) bd.f_60p = 0;



                        _entity.iom_ward_households_breakdown.AddObject(bd);// Add(bd);
                        _entity.SaveChanges();
                    }
                    
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(hhbd);
                }
            }

            return View(hhbd);
        }

        
        
        //
        // GET: /Breakdown/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            getSession();

            var hhbd = (from c in _entity.iom_ward_households_breakdown
                       where c.ward_profile_id == ward_profile_id
                       select c).ToList();

            return View(new Breakdown(hhbd));
        }

        //
        // POST: /Breakdown/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, Breakdown hhbd)
        {
            ViewBag.Active = "B1F";

            getSession();

            var ages = (from c in _entity.iom_ward_households_breakdown
                        where c.ward_profile_id == ward_profile_id
                        select c).ToList();

            if (ages != null)
            {
                Breakdown hhbd_ = new Breakdown(ages);

                try
                {
                    // TODO: Add update logic here

                    DateTime tmp = DateTime.Now;
                    int i = 0;

                    foreach (var hhage in hhbd_.hh_ages)
                    {
                        //i++;
                        iom_ward_households_breakdown bd = hhage;

                        bd.updated_by = User.Identity.Name;
                        bd.update_time = tmp;


                       // bd.total = hhbd.hh_ages[i].total;
                        bd.m_lt1 = hhbd.hh_ages[i].m_lt1;
                        bd.f_lt1 = hhbd.hh_ages[i].f_lt1;
                        bd.m_1_5 = hhbd.hh_ages[i].m_1_5;
                        bd.f_1_5 = hhbd.hh_ages[i].f_1_5;
                        bd.m_6_17 = hhbd.hh_ages[i].m_6_17;
                        bd.f_6_17 = hhbd.hh_ages[i].f_6_17;
                        bd.m_18_59 = hhbd.hh_ages[i].m_18_59;
                        bd.f_18_59 = hhbd.hh_ages[i].f_18_59;
                        bd.m_60p = hhbd.hh_ages[i].m_60p;
                        bd.f_60p = hhbd.hh_ages[i].f_60p;
                       // bd.total_m = hhbd.hh_ages[i].total_m;
                        //bd.total_f = hhbd.hh_ages[i].total_f;

                        //set value to zero
                        if (hhbd.hh_ages[i].m_lt1 == null) bd.m_lt1 = 0;
                        if (hhbd.hh_ages[i].f_lt1 == null) bd.f_lt1 = 0;
                        if (hhbd.hh_ages[i].m_1_5 == null) bd.m_1_5 = 0;
                        if (hhbd.hh_ages[i].f_1_5 == null) bd.f_1_5 = 0;
                        if (hhbd.hh_ages[i].m_6_17 == null) bd.m_6_17 = 0;
                        if (hhbd.hh_ages[i].f_6_17 == null) bd.f_6_17 = 0;
                        if (hhbd.hh_ages[i].m_18_59 == null) bd.m_18_59 = 0;
                        if (hhbd.hh_ages[i].f_18_59 == null) bd.f_18_59 = 0;
                        if (hhbd.hh_ages[i].m_60p == null) bd.m_60p = 0;
                        if (hhbd.hh_ages[i].f_60p == null) bd.f_60p = 0;


                        UpdateModel(bd);
                        //_entity.SaveChanges();

                        i++;
                    }

                    _entity.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(hhbd);
                }
            }

            return View(hhbd);

        }

        //
        // GET: /Breakdown/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            getSession();

            var hhbd = (from c in _entity.iom_ward_households_breakdown
                        where c.ward_profile_id == ward_profile_id
                        select c).ToList();

            return View(hhbd);

           // return View();
        }

        //
        // POST: /Breakdown/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            getSession();

            var ages = (from c in _entity.iom_ward_households_breakdown
                        where c.ward_profile_id == ward_profile_id
                        select c).ToList();

            if (ages != null)
            {
                //Breakdown hhbd_ = new Breakdown(ages);

                try
                {
                    // TODO: Add update logic here
                    foreach (var hhage in ages)
                    {
                        //iom_ward_households_breakdown bd=hhage
                        _entity.iom_ward_households_breakdown.DeleteObject(hhage);// Remove(hhage);
                        _entity.SaveChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(ages.ToList());
                }
            }

            return View(ages.ToList());
        }
    }
}
