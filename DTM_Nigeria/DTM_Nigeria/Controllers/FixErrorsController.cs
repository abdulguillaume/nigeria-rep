using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DTM_Nigeria.Models;

namespace DTM_Nigeria.Controllers
{
    public class FixErrorsController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();

        int? phase_ = -1;
        //
        // GET: /FixErrors/



        public ActionResult Index(int? phase)
        {
            ViewBag.Active = "Errors";
            ViewBag.Phase = new SelectList(_entity.iom_dtm_phase, "phase", "description");

            Errors errors_;

            if (phase != null)
            {
                Session["phase_2"] = phase;
                phase_ = phase;
            }
            else if (Session["phase_2"] != null)
            {
                phase_ = (int)Session["phase_2"];
            }
            else {
                phase_ = -1;
            }
           
            errors_ = new Errors(phase_ ?? -1);

            ViewBag.SelectedPhase = phase_;

            return View(errors_);
        }

        //
        // GET: /FixErrors/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /FixErrors/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /FixErrors/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /FixErrors/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /FixErrors/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /FixErrors/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /FixErrors/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
