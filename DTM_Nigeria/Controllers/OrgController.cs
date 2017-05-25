using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Web.Script.Serialization;

namespace DTM_Nigeria.Controllers
{
    public class OrgController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        public int profile_id;
        //public string lga;

        SessionPath sesspath = new SessionPath();

        //
        // GET: /Org/

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


            var orgs = from c in _entity.iom_b1f_organizations_assisting
                       where c.profile_id == profile_id
                       orderby c.created_by descending
                       select c;


            return View(orgs);

        }

        public void setSession(int id, string lga)
        {
            //sesspath.setSession((SessionPath)Session["SessionPath"]);
            sesspath.setSession(id, lga, null, null, null, null, null, null);
            //sesspath.b1f_profile = id;

            ViewBag.LgaInfo = sesspath.getLgaInfo();

           // Session["SessionPath"] = sesspath;

            string sesspath_serial = new JavaScriptSerializer().Serialize(sesspath);

            var cookie = new HttpCookie("SessionPath", sesspath_serial);
            HttpContext.Response.Cookies.Add(cookie);
            
            //to be removed-- already in sessionpath session
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
                //lga = sesspath.lga;

                ViewBag.LgaInfo = sesspath.getLgaInfo();
            }

           // profile_id = sesspath.b1f_profile;

           // ViewBag.LgaInfo = sesspath.getLgaInfo();

            //to be removed-- already in sessionpath session
            //profile_id = (int)Session["profile_id"];
        }

        //
        // GET: /Org/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "B1F";

            var org = (from c in _entity.iom_b1f_organizations_assisting
                        where c.id == id
                        select c).FirstOrDefault();
            return View(org);

        }


        public void setViewBags()
        {
            getSession();
            ViewBag.OrgType = new SelectList(_entity.lkp_Organization, "id", "organization");
            ViewBag.AssType = new SelectList(_entity.lkp_assistance_type, "id", "assistance_type");
        }

        public iom_organizations findOrgB1F(iom_organizations org)
        {
            iom_organizations org_ = _entity.iom_organizations.Where(x => x.name.Equals(org.name)).FirstOrDefault();

            return org_ == null ? org : org_;
        }


        [HttpPost]
        public JsonResult GetOrgType(string o_name)
        {
            //var r_tel = new SelectList( _entity.iom_researchers.Where(x => x.researcher_name.Equals(r_name)), "researcher_tel", "researcher_tel").FirstOrDefault();

            var o_type = _entity.iom_organizations.Where(x => x.name.Equals(o_name)).Select(y => y.type).FirstOrDefault();


            return Json(o_type, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOrgsNames(string term)
        {
            List<string> orgs;

            orgs = _entity.iom_organizations.Where(x => x.name.Contains(term))
                .Select(y => y.name).ToList();

            return Json(orgs, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Org/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Active = "B1F";

            setViewBags();
            OrgB1F porg = new OrgB1F();
            return View(porg);
        } 

        //
        // POST: /Org/Create
        [HttpPost]
        public ActionResult Create(OrgB1F my_org)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            if (ModelState.IsValid)
            {
                try
                {
                    // TODO: Add insert logic here
                    iom_b1f_organizations_assisting org_ = my_org.porg;

                    org_.iom_organizations = findOrgB1F(my_org.org);
                    org_.iom_organizations.type = my_org.org.type;

                    org_.profile_id = profile_id;

                    org_.created_by = User.Identity.Name;
                    org_.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    org_.create_time = tmp;
                    org_.update_time = tmp;

                    _entity.iom_b1f_organizations_assisting.AddObject(org_);// Add(org_);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(my_org);
                }
            }

            return View(my_org);
        }

        //[HttpPost]
        //public ActionResult Create(iom_organizations_assisting org)
        //{
        //    setViewBags();

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // TODO: Add insert logic here
        //            iom_organizations_assisting org_ = org;

        //            org_.profile_id = profile_id;

        //            org_.created_by = User.Identity.Name;
        //            org_.updated_by = User.Identity.Name;

        //            DateTime tmp = DateTime.Now;
        //            org_.create_time = tmp;
        //            org_.update_time = tmp;

        //            _entity.AddObject("iom_organizations_assisting", org_);
        //            _entity.SaveChanges();

        //            return RedirectToAction("Index");
        //        }
        //        catch
        //        {
        //            ViewBag.Exception = "* Operation failed!";

        //            return View(org);
        //        }
        //    }

        //    return View(org);
        //}
        
        //
        // GET: /Org/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            var org = (from c in _entity.iom_b1f_organizations_assisting
                       where c.id == id
                       select c).FirstOrDefault();

            return View(new OrgB1F(org));
        }

        //
        // POST: /Org/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, OrgB1F my_org)
        {
            ViewBag.Active = "B1F";

            setViewBags();

            var org = (from c in _entity.iom_b1f_organizations_assisting
                       where c.id == id
                       select c).FirstOrDefault();

            if (org != null)
            {
                try
                {
                    // TODO: Add update logic here
                    DateTime tmp = DateTime.Now;
                    org.update_time = tmp;
                    org.updated_by = User.Identity.Name;

                    org.iom_organizations = findOrgB1F(my_org.org);

                    org.iom_organizations.type = my_org.org.type;

                    org.contact_person = my_org.porg.contact_person;

                    org.assistance_type = my_org.porg.assistance_type;

                    UpdateModel(org);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(my_org);
                }
            }

            return View(my_org);
        }

        //
        // GET: /Org/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "B1F";

            var org = (from c in _entity.iom_b1f_organizations_assisting
                       where c.id == id
                       select c).FirstOrDefault();

            if (org != null)
            {
                return View(org);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /Org/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "B1F";

            var org = (from c in _entity.iom_b1f_organizations_assisting
                       where c.id == id
                       select c).FirstOrDefault();

            if (org != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_b1f_organizations_assisting.DeleteObject(org);// Remove(org);

                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(org);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
