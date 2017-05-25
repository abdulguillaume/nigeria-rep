using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;
using System.Threading;

namespace DTM_Nigeria.Controllers
{
    public class DTMPhaseController : Controller
    {
        private static Mutex mutex = new Mutex();

        iomdtmEntities _entity = new iomdtmEntities();
        //
        // GET: /DTMPhase/

        public ActionResult Index()
        {
            ViewBag.Active = "DTM-Phase";

            var dtm_ = from c in _entity.iom_dtm_phase
                       orderby c.create_date ascending
                       select c;

            return View(dtm_);
        }

        //
        // GET: /DTMPhase/Details/5

        public ActionResult Details(int id)
        {
            ViewBag.Active = "DTM-Phase";

            var dtm_ = (from c in _entity.iom_dtm_phase
                        where c.phase == id
                        select c).FirstOrDefault();
            
            return View(dtm_);
        }

        //
        // GET: /DTMPhase/Create
         [Authorize(Roles="Admin")]
        public ActionResult Create()
        {
            ViewBag.Active = "DTM-Phase";

            iom_dtm_phase dtm_ = new iom_dtm_phase();

            dtm_.phase = _entity.iom_dtm_phase.Max(x => x.phase) + 1;
            dtm_.closed_YesNo = 2;

            return View(dtm_);
        } 

        //
        // POST: /DTMPhase/Create


        [HttpPost]
        public ActionResult Create(iom_dtm_phase dtm_)
        {
            ViewBag.Active = "DTM-Phase";

            mutex.WaitOne();

            if (ModelState.IsValid)
            {
                try
                {
                    if (_entity.iom_dtm_phase.Max(x => x.closed_YesNo) == 2)
                        throw new MyException("* Need to close all opening DTM phases first!");

                    // TODO: Add insert logic here
                    dtm_.closed_YesNo = 2;

                    dtm_.created_by = User.Identity.Name;
                    dtm_.updated_by = User.Identity.Name;

                    DateTime tmp = DateTime.Now;
                    dtm_.create_date = tmp;
                    dtm_.update_date = tmp;

                    _entity.iom_dtm_phase.AddObject(dtm_);// Add(dtm_);
                    _entity.SaveChanges();

                    mutex.ReleaseMutex();

                    return RedirectToAction("Index");
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;

                    mutex.ReleaseMutex();

                    return View(dtm_);
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    mutex.ReleaseMutex();

                    return View(dtm_);
                }
            }

            mutex.ReleaseMutex();

            return View(dtm_); 
        }
        
        //
        // GET: /DTMPhase/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Active = "DTM-Phase";

            var dtm_ = (from c in _entity.iom_dtm_phase
                        where c.phase == id
                        select c).FirstOrDefault();

            return View(dtm_);
        }

        //
        // POST: /DTMPhase/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, iom_dtm_phase dtm)
        {
            mutex.WaitOne();
            ViewBag.Active = "DTM-Phase";

            var dtm_ = (from c in _entity.iom_dtm_phase
                        where c.phase == id
                        select c).FirstOrDefault();

            if (dtm_ != null)
            {
                try
                {

                    int check1 = _entity.iom_dtm_phase.Where(y=>y.phase!=dtm.phase).Any() ? _entity.iom_dtm_phase.Where(y=>y.phase!=dtm.phase).Max(x => x.closed_YesNo) : 1;

                   // check1 = check1 ?? 0;

                    if (check1==2 && check1==dtm.phase)
                        throw new MyException("* Two (2) DTM phases cannot be opened at the same time!");

                    // TODO: Add update logic here
                    dtm_.phase = dtm.phase;
                    dtm_.field_start_date=dtm.field_start_date;
                    dtm_.field_end_date=dtm.field_end_date;
                    dtm_.description = dtm.description;
                    dtm_.closed_YesNo=dtm.closed_YesNo;

                    dtm_.updated_by = User.Identity.Name;
                    DateTime tmp = DateTime.Now;
                    dtm_.update_date = tmp;

                    UpdateModel(dtm_);
                    _entity.SaveChanges();


                    mutex.ReleaseMutex();

                    return RedirectToAction("Index");
                }
                catch (MyException e)
                {
                    ViewBag.Exception = e.Message;

                    mutex.ReleaseMutex();

                    return View(dtm);
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    mutex.ReleaseMutex();

                    return View(dtm);
                }
            }

            mutex.ReleaseMutex();

            return View(dtm_);
        }

        //
        // GET: /DTMPhase/Delete/5

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            ViewBag.Active = "DTM-Phase";

            var dtm_ = (from c in _entity.iom_dtm_phase
                        where c.phase == id
                        select c).FirstOrDefault();


            if (dtm_ != null)
            {
                return View(dtm_);
            }

            return RedirectToAction("Index");
        }

        //
        // POST: /DTMPhase/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            ViewBag.Active = "DTM-Phase";

            var dtm_ = (from c in _entity.iom_dtm_phase
                        where c.phase == id
                        select c).FirstOrDefault();


            if (dtm_ != null)
            {
                try
                {
                    // TODO: Add delete logic here
                    _entity.iom_dtm_phase.DeleteObject(dtm_);// Remove(dtm_);
                    _entity.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Exception = "* Operation failed!";

                    return View(dtm_);
                }
            }

            return RedirectToAction("Index");
        }
    }
}
