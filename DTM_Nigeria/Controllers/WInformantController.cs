using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class WInformantController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        public int ward_profile_id;

        SessionPath sesspath = new SessionPath();
        //
        // GET: /WInformant/

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


            var infs = from c in _entity.iom_b2f_informants
                       where c.ward_profile_id == ward_profile_id
                       orderby c.created_by descending
                       select c;


            return View(infs);
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
            //sesspath.setSession((SessionPath)Session["SessionPath"]);
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                ward_profile_id = sesspath.b2f_profile ?? 0;

                ViewBag.WardInfo = sesspath.getWardInfo();
                //   ward_profile_id = (int)Session["ward_p
            }

            //ward_profile_id = sesspath.b2f_profile ?? 0;

            //ViewBag.WardInfo = sesspath.getWardInfo();
            ////   ward_profile_id = (int)Session["ward_profile_id"];


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
        // GET: /WInformant/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            var inf = (from c in _entity.iom_b2f_informants
                       where c.id == id
                       select c).FirstOrDefault();
            return View(inf);
        }

        public void setViewBags()
        {
            getSession();
            ViewBag.InformantType = new SelectList(_entity.lkp_Informant_Type, "id", "informant");
        }

        public iom_informants findInfB2F(iom_informants inf)
        {
            iom_informants inf_ = _entity.iom_informants.Where(x => x.name.Equals(inf.name) && x.sex.Equals(inf.sex) && x.type == inf.type).FirstOrDefault();
            if (inf_ != null) inf_.notEmpty = true;
            return inf_ == null ? inf : inf_;
        }


        public JsonResult GetInfsNames(string term)
        {
            List<string> infs;

            infs = _entity.iom_informants.Where(x => x.name.Contains(term))
                .Select(y => y.name).Distinct().ToList();

            return Json(infs, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /WInformant/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            setViewBags();
            InfB2F inf = new InfB2F();
            return View(inf);
        } 

        //
        // POST: /WInformant/Create

        [HttpPost]
        public ActionResult Create(InfB2F informant)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here

                    iom_b2f_informants inf = informant.pinf;

                    inf.iom_informants = findInfB2F(informant.inf);

                    inf.ward_profile_id = ward_profile_id;

                    inf.created_by = User.Identity.Name;
                    inf.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    inf.create_time = tmp;
                    inf.update_time = tmp;

                    _entity.iom_b2f_informants.Add(inf);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(informant);
                }
            }

            return View(informant);
        }
        
        //
        // GET: /WInformant/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            var inf = (from c in _entity.iom_b2f_informants
                       where c.id == id
                       select c).FirstOrDefault();

            return View(new InfB2F(inf));
        }

        //
        // POST: /WInformant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, InfB2F informant)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            var inf = (from c in _entity.iom_b2f_informants
                       where c.id == id
                       select c).FirstOrDefault();

            if (inf != null)
            {
                try
                {
                    // TODO: Add update logic here
                    DateTime tmp = DateTime.Now;

                    inf.update_time = tmp;
                    inf.updated_by = User.Identity.Name;

                    inf.iom_informants = findInfB2F(informant.inf);

                    inf.contact_details = informant.pinf.contact_details;

                    UpdateModel(inf);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(informant);
                }
            }

            return View(informant);
        }

        //
        // GET: /WInformant/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var inf = (from c in _entity.iom_b2f_informants
                       where c.id == id
                       select c).FirstOrDefault();

            if (inf != null)
            {
                return View(inf);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /WInformant/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            var inf = (from c in _entity.iom_b2f_informants
                       where c.id == id
                       select c).FirstOrDefault();

            if (inf != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_b2f_informants.Remove(inf);

                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(inf);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
