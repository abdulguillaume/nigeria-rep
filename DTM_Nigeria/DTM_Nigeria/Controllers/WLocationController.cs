using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class WLocationController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        public int ward_profile_id;

        SessionPath sesspath = new SessionPath();
        //public string ward;
        //
        // GET: /WLocation/

        public ActionResult Index(int? id, string ward)
        {
            ViewBag.Active = "B1F";

            if (id != null)
            {
                setSession(id ?? 0);//, ward);
                ward_profile_id = id ?? 0;
            }
            else
                getSession();


            var wards = from c in _entity.iom_ward_presence_per_location
                        where c.ward_profile_id == ward_profile_id
                        orderby c.created_by ascending
                        select c;


            return View(wards);
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

            //ViewBag.WardInfo = sesspath.getWardInfo();

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
            //ward_profile_id = sesspath.b2f_profile??0;


            //ViewBag.WardInfo = sesspath.getWardInfo();
         //   ward_profile_id = (int)Session["ward_profile_id"];


        }
        //public void setSession(int id)//, string lga)
        //{
        //    Session["ward_profile_id"] = id;
        //    //Session["ward"] = ward;
        //}

        //public void getSession()
        //{
        //    ward_profile_id = (int)Session["ward_profile_id"];
        //   // ward = (string)Session["ward"];


       // }

        [HttpPost]
        public JsonResult getLgaList(string id)
        {
            var lgas = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(id)), "lga_code", "lga_name").ToList();
            return Json(lgas, JsonRequestBehavior.AllowGet);
        }


        public void setViewBags(string def)
        {
            getSession();
            ViewBag.State = new SelectList(_entity.lkp_State, "state_code", "state_name");
   //         ViewBag.LGA = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals("-1")), "lga_code", "lga_name");
            ViewBag.LGA = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(def == null ? "-1" : def)), "lga_code", "lga_name");


           // ViewBag.Ward = new SelectList(_entity.lkp_Ward.Where(x => x.lga_code.Equals(lga)), "ward_code", "ward_name");
            ViewBag.Residence = new SelectList(_entity.lkp_TypeOfResidence, "id", "residence");
            ViewBag.Category = new SelectList(_entity.lkp_IDP_Category, "id", "category");
        }
        //
        // GET: /WLocation/Details/5

        public ActionResult Details(int id){

            ViewBag.Active = "B1F";

            var loc = (from c in _entity.iom_ward_presence_per_location
                        where c.id == id
                        select c).FirstOrDefault();
            return View(loc);
        }

        //
        // GET: /WLocation/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            setViewBags(null);
            return View();
        } 

        //
        // POST: /WLocation/Create

        [HttpPost]
        public ActionResult Create(iom_ward_presence_per_location location)
        {
            ViewBag.Active = "B1F";

            setViewBags(location.majority_stateoforigin);

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    iom_ward_presence_per_location location_ = location;

                   // location_.estimate_hh = 0; //not used

                    location_.ward_profile_id = ward_profile_id;
                    location_.created_by = User.Identity.Name;
                    location_.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    location_.create_time = tmp;
                    location_.update_time = tmp;

                    _entity.AddObject("iom_ward_presence_per_location", location_);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(location);
                }
            }

            return View(location);
        }
        
        //
        // GET: /WLocation/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            var loc = (from c in _entity.iom_ward_presence_per_location
                        where c.id == id
                        select c).FirstOrDefault();

            setViewBags(loc.majority_stateoforigin);

            return View(loc);
        }

        //
        // POST: /WLocation/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, iom_ward_presence_per_location presence)
        {
            ViewBag.Active = "B1F";

            var loc = (from c in _entity.iom_ward_presence_per_location
                        where c.id == id
                        select c).FirstOrDefault();

            setViewBags(presence.majority_stateoforigin);

            if (loc != null)
            {
                try
                {
                    // TODO: Add update logic here
                    int i = 0;

                    DateTime tmp = DateTime.Now;

                    loc.update_time = tmp;

                    loc.updated_by = User.Identity.Name;

                    loc.ward_profile_id = ward_profile_id;

                    loc.location_type = presence.location_type;
                    loc.idp_category = presence.idp_category;
                    loc.location_name = presence.location_name;
                    loc.idp_registered_list_YesNo = presence.idp_registered_list_YesNo;

                    //loc.estimate_hh = 0; //not used
                    loc.estimate_ind = presence.estimate_ind;

                    loc.majority_lgaoforigin = presence.majority_lgaoforigin;
                    loc.majority_stateoforigin = presence.majority_stateoforigin;

                    loc.registered_by = presence.registered_by;
                    

                    UpdateModel(loc);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(loc);
                }
            }


            return View(presence);
        }


        //
        // GET: /WLocation/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var loc = (from c in _entity.iom_ward_presence_per_location
                        where c.id == id
                        select c).FirstOrDefault();

            if (loc != null)
            {
                return View(loc);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /WLocation/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            var loc = (from c in _entity.iom_ward_presence_per_location
                        where c.id == id
                        select c).FirstOrDefault();

            if (loc != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_ward_presence_per_location.DeleteObject(loc);

                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(loc);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
