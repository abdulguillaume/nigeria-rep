using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;

namespace DTM_Nigeria.Controllers
{
    public class ApiController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();
        //
        // GET: /Api/

        [HttpGet]
        public ActionResult GetAllLocationsList(int id) //phase id
        {
            List<spGetLocationsList_Result> locations =  _entity.spGetLocationsList(id.ToString()).ToList();

            return Json(locations, JsonRequestBehavior.AllowGet);

            //var locations = from e in _entity.iom_ward_presence_per_location
            //            where e.iom_ward_profile.iom_presence_wards.ward_code == id
            //            select new LocationSA()
            //            {
            //                ward_code = id,
            //                ward_profile = e.iom_ward_profile.id,
            //                location_name = e.location_name,
            //                location_type = e.location_type,
            //                inds = e.estimate_ind,
            //                lon = e.coord_lon ?? 0,
            //                lat = e.coord_lat ?? 0
            //            };
                

           // return Json(locations, JsonRequestBehavior.AllowGet);
           // return View();
        }

        [HttpPost]
        public JsonResult setLocationToEntered(string id) //location id
        {
            try
            {
                 iom_ward_presence_per_location location = _entity.iom_ward_presence_per_location.Find(int.Parse(id));
                 location.entered_in_SA = true;

                 _entity.SaveChanges();

                 return Json(new { Result = "OK" }, JsonRequestBehavior.AllowGet);

            }
            catch {
                return Json(new { Result = "NOK" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
