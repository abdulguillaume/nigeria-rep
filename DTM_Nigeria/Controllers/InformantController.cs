using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class InformantController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        public int profile_id;

        SessionPath sesspath = new SessionPath();

        //
        // GET: /Informant/

        public ActionResult Index(int? id, string lga)
        {
            ViewBag.Active = "B1F";

            if (id != null)
            {
                setSession(id ?? 0, lga);
                profile_id = id ?? 0;
            }
            else
                getSession();


            var infs = from c in _entity.iom_b1f_informants
                        where c.profile_id == profile_id
                        orderby c.created_by descending
                        select c;


            return View(infs);

        }


        public void setSession(int id, string lga)
        {
            //sesspath.setSession((SessionPath)Session["SessionPath"]);
            sesspath.setSession(id, lga, null, null, null, null, null, null);
            //sesspath.b1f_profile = id;
            ViewBag.LgaInfo = sesspath.getLgaInfo();

            string sesspath_serial = new JavaScriptSerializer().Serialize(sesspath);

            var cookie = new HttpCookie("SessionPath", sesspath_serial);
            HttpContext.Response.Cookies.Add(cookie);

            //Session["SessionPath"] = sesspath;

            //Session["profile_id"] = id;
        }

        public void getSession()
        {
           // sesspath.setSession((SessionPath)Session["SessionPath"]);
            HttpCookie aCookie = Request.Cookies["SessionPath"];

            if (aCookie != null)
            {
                SessionPath sesspath = (SessionPath)(new JavaScriptSerializer().Deserialize(aCookie.Value, typeof(SessionPath)));

                profile_id = sesspath.b1f_profile;
               // lga = sesspath.lga;

                ViewBag.LgaInfo = sesspath.getLgaInfo();
            }

           // profile_id = sesspath.b1f_profile;
           // ViewBag.LgaInfo = sesspath.getLgaInfo();

            //to be removed--already in sessionpath session
            //profile_id = (int)Session["profile_id"];
        }
        //
        // GET: /Informant/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            var inf = (from c in _entity.iom_b1f_informants
                        where c.id == id
                        select c).FirstOrDefault();
            //return View(new InfB1F(inf));
            return View(inf);
        }

        public void setViewBags()
        {
            getSession();
            ViewBag.InformantType = new SelectList(_entity.lkp_Informant_Type, "id", "informant");
        }

        public iom_informants findInfB1F(iom_informants inf)
        {
            iom_informants inf_ = _entity.iom_informants.Where(x => x.name.Equals(inf.name) && x.sex.Equals(inf.sex) && x.type==inf.type).FirstOrDefault();
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
        // GET: /Informant/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            setViewBags();
            InfB1F inf = new InfB1F();
            return View(inf);
        } 

        //
        // POST: /Informant/Create

        [HttpPost]
        public ActionResult Create(InfB1F informant)
        {
            //informant.inf.sex = "x";
            //informant.inf.type = 0;
            //informant.inf.details = "n/a";

            ViewBag.Active = "B1F";

            setViewBags();

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here

                    iom_b1f_informants inf = informant.pinf;

                    inf.iom_informants = findInfB1F(informant.inf);

                    inf.profile_id = profile_id;

                    inf.created_by = User.Identity.Name;
                    inf.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    inf.create_time = tmp;
                    inf.update_time = tmp;

                    _entity.iom_b1f_informants.Add(inf);// Add(inf);
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
        // GET: /Informant/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            var inf = (from c in _entity.iom_b1f_informants
                       where c.id == id
                       select c).FirstOrDefault();
            
            return View(new InfB1F(inf));
        }

        //
        // POST: /Informant/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, InfB1F informant)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            var inf = (from c in _entity.iom_b1f_informants
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

                    inf.iom_informants = findInfB1F(informant.inf);

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
        // GET: /Informant/Delete/5
    [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var inf = (from c in _entity.iom_b1f_informants
                        where c.id == id
                        select c).FirstOrDefault();

            if (inf != null)
            {
                return View(inf);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Informant/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            var inf = (from c in _entity.iom_b1f_informants
                        where c.id == id
                        select c).FirstOrDefault();

            if (inf != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_b1f_informants.Remove(inf);// Remove(inf);

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
