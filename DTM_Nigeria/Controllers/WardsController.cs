using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class WardsController : Controller
    {

        iomdtmEntities _entity = new iomdtmEntities();
        public int profile_id;
        public string lga;

        SessionPath sesspath = new SessionPath();

        //
        // GET: /Wards/

        public ActionResult Index(int? id, string lga, int? phase)
        {
            ViewBag.Active = "B1F";

            if (id != null)
            { 
                setSession(id ?? 0, lga, phase??0);
                profile_id = id??0;
            }
            else
                getSession();


            var wards = from c in _entity.iom_presence_wards
                          where c.profile_id==profile_id
                          orderby c.created_by ascending
                          select c;


            return View(wards);

           // return View();
        }

        public void setSession(int id,string lga, int phase)
        {
           
            sesspath.setSession(id, lga, null,null, null, null, null, null);
            sesspath.phase = phase;


            ViewBag.LgaInfo = sesspath.getLgaInfo();


            string sesspath_serial = new JavaScriptSerializer().Serialize(sesspath);

            var cookie = new HttpCookie("SessionPath", sesspath_serial);
            HttpContext.Response.Cookies.Add(cookie);
           // Session["SessionPath"] = sesspath;

            //to remove-duplicated-already in sessionpath session
           // Session["profile_id"] = id;
           // Session["lga"] = lga;
        }

        public void getSession()
        {
            
          //  sesspath.setSession((SessionPath)Session["SessionPath"]);
             HttpCookie aCookie = Request.Cookies["SessionPath"];
             
            if(aCookie!=null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                profile_id = sesspath.b1f_profile;
                lga = sesspath.lga;

                ViewBag.LgaInfo = sesspath.getLgaInfo();
            }
           // profile_id = (int)Session["profile_id"];
            //lga = (string)Session["lga"];


        }


        [HttpPost]
        public JsonResult getLgaList(string id)
        {
            var lgas = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(id)), "lga_code", "lga_name").ToList();
            return Json(lgas, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Wards/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            var ward = (from c in _entity.iom_presence_wards
                          where c.id==id
                          select c).FirstOrDefault();
            return View(ward);
        }

        //
        // GET: /Wards/Create

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            setViewBags(null);

            return View();
        } 

        //
        // POST: /Wards/Create

        [HttpPost]
        public ActionResult Create(iom_presence_wards ward)
        {
            ViewBag.Active = "B1F";

           // var errors = ModelState.Values.SelectMany(v => v.Errors);

            setViewBags(ward.majority_stateoforigin);

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    iom_presence_wards ward_ = ward;

                    ward_.profile_id = profile_id;
                    ward_.created_by = User.Identity.Name;
                    ward_.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    ward_.create_time = tmp;
                    ward_.update_time = tmp;

                    _entity.iom_presence_wards.Add(ward_);// Add(ward_);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {

                    ViewBag.Exception = "* Operation failed!";

                    return View(ward);
                }
            }

            return View(ward);
        }


        public void setViewBags(string def)
        {
            getSession();
            ViewBag.State = new SelectList(_entity.lkp_State, "state_code", "state_name");
            ViewBag.LGA = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals(def == null ? "-1" : def)), "lga_code", "lga_name");

           // ViewBag.LGA = new SelectList(_entity.lkp_Lga.Where(x => x.state_code.Equals("-1")), "lga_code", "lga_name");
            ViewBag.Ward = new SelectList(_entity.lkp_Ward.Where(x => x.lga_code.Equals(lga)), "ward_code", "ward_name");
            ViewBag.Residence = new SelectList(_entity.lkp_TypeOfResidence.Where(x=>x.id.Equals("x")==false), "id", "residence");
            ViewBag.Category = new SelectList(_entity.lkp_IDP_Category, "id", "category"); 
        }
        //
        // GET: /Wards/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            var ward = (from c in _entity.iom_presence_wards
                       where c.id == id
                       select c).FirstOrDefault();

            setViewBags(ward.majority_stateoforigin);

            return View(ward);
        }

        //
        // POST: /Wards/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, iom_presence_wards presence)
        {
            ViewBag.Active = "B1F";

            var ward = (from c in _entity.iom_presence_wards
                        where c.id == id
                        select c).FirstOrDefault();

            setViewBags(presence.majority_stateoforigin);

            if (ward != null)
            {
                try
                {
                    // TODO: Add update logic here
                    int i = 0;

                    DateTime tmp = DateTime.Now;

                    ward.update_time = tmp;

                    ward.updated_by = User.Identity.Name;

                    ward.ward_code = presence.ward_code;
                    ward.location_type = presence.location_type;
                    ward.idp_category = presence.idp_category;
                    ward.location_name = presence.location_name;
                    ward.estimate_hh = presence.estimate_hh;
                    ward.estimate_ind = presence.estimate_ind;
                    ward.majority_lgaoforigin = presence.majority_lgaoforigin;
                    ward.majority_stateoforigin = presence.majority_stateoforigin;
                    ward.coord_lon = presence.coord_lon;
                    ward.coord_lat = presence.coord_lat;

                    UpdateModel(ward);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    string msg = ex.Message;

                    if (msg.Contains("B2F"))
                    {
                        ViewBag.Exception = "* " + msg;

                        return View(ward);
                    }

                    ViewBag.Exception = "* Operation failed!";

                    return View(ward);
                }
            }


            return View(presence);
        }

        //
        // GET: /Wards/Delete/5
    [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var ward = (from c in _entity.iom_presence_wards
                        where c.id == id
                        select c).FirstOrDefault();

            if (ward != null)
            {
                return View(ward);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Wards/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            var ward = (from c in _entity.iom_presence_wards
                        where c.id == id
                        select c).FirstOrDefault();

            if (ward != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_presence_wards.Remove(ward);// Remove(ward);

                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(ward);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
