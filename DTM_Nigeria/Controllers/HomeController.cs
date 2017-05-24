using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTM_Nigeria.Models;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.IO;

using ClosedXML.Excel;
using System.Data;

using DTM_Nigeria.Controllers;
using System.Globalization;

namespace DTM_Nigeria.Controllers
{
    public class HomeController : Controller
    {
        iomdtmEntities _entity = new iomdtmEntities();

        public ActionResult Index()
        {
            ViewBag.Active = "Home";

            ViewBag.Message = "Data Entry software - Displacement Tracking Matrix (DTM)";

            //var culture = System.Globalization.CultureInfo.CurrentCulture;

            //DateTime tmp = DateTime.Parse("04/16/2015");

            //CultureInfo ci = new CultureInfo("en-US");
            //CultureInfo ci = new CultureInfo("en-GB");

            //ViewBag.Message = tmp.ToString("d", ci);


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Active = "About";

            //SelectList phases = new SelectList(new SelectList(_entity.iom_dtm_phase.Where(x=>x.closed_YesNo==1), "phase", "description"));

           List<SelectListItem> phases = new List<SelectListItem>();

           phases.Add(new SelectListItem { Value = "", Text = "[Select phase]", Selected = true });

           //Errors errors_ =

           foreach (iom_dtm_phase dtm_ in _entity.iom_dtm_phase.Where(x => x.closed_YesNo == 1))
           {
               if( new Errors(dtm_.phase).canGenerateReport()){
               phases.Add(new SelectListItem { Value=dtm_.phase.ToString(),Text=dtm_.description});
               }
           }

            ViewBag.Phase = phases;
       //     new SelectList(_entity.iom_dtm_phase.Where(x=>x.closed_YesNo==1), "phase", "description");
            return View();
        }

       // [HttpPost]
        public ActionResult ExportExcel(int phaseId,string tokenId)
        {
            //Guid parameter, 
            string path = HttpContext.Server.MapPath("~/ReportXlsx/Draft_Analysis_Empty.xlsx");
            var workbook = new XLWorkbook(path);

            var ws = workbook.Worksheet(1);
            var ws2 = workbook.Worksheet(2);
            var ws3 = workbook.Worksheet(3);
            var ws4 = workbook.Worksheet(4);

            // Change the background color of the headers
            //var rngHeaders = ws.Range("A1:AB1");
            // rngHeaders.Style.Fill.BackgroundColor = XLColor.LightSalmon;

            // workbook.
            //workbook
            //workbook.SaveAs("C:\\Users\\Abdul Guillaume\\Desktop\\Draft_Analysis_23.xlsx");
            //workbook.Dispose();

            int? i=-1;
            
            i = _entity.view_estimate_hhs_Inds_per_Wards.Where(y => y.phase == phaseId).Count();


            ws.Cell(2, 1).InsertData(

            _entity.view_estimate_hhs_Inds_per_Wards.Where(y=>y.phase==phaseId).Select(x => new
            {
                x.state_code,
                x.state_name,
                x.lga_code,
                x.lga_name,
                x.ward_code,
                x.ward_name,
                x.id,
                x.estimate_hh_Ward,
                x.estimate_Ind_Ward,
                x.location_type,
                x.Year,
                x.idp_category,
                x.majority_stateoforigin,
                x.state_orig,
                x.majority_lgaoforigin,
                x.lga_orig,
                x.reason_insurgency_YesNo,
                x.reason_insurg_hh,
                x.reason_insurg_ind,
                x.reason_clash_YesNo,
                x.reason_clash_hh,
                x.reason_clash_ind,
                x.reason_disaster_YesNo,
                x.reason_disaster_hh,
                x.reason_disaster_ind,
                x.reason_others_YesNo,
                x.reason_others_hh,
                x.reason_others_ind
            }));

            ws2.Cell(2, 1).InsertData(
            _entity.view_estimate_hhs_Inds_per_Reason_for_Diplacement.Where(y => y.phase == phaseId).Select(x => new
            {
                x.state_code,
                x.state_name,
                x.lga_code,
                x.lga_name,
                x.ward_code,
                x.ward_name,
                x.reason,
                x.inds

            }));

            ws3.Cell(2, 1).InsertData(
                _entity.view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival.Where(y => y.phase == phaseId).Select(x => new
                {
                    x.state_code,
                    x.state_name,
                    x.lga_code,
                    x.lga_name,
                    x.ward_code,
                    x.ward_name,
                    x.id,
                    x.estimate_hh_Ward,
                    x.estimate_Ind_Ward,
                    x.year_arrival,
                    x.hh,
                    x.ind
                }));


            ws4.Cell(2, 1).InsertData(
                _entity.view_estimate_hhs_Inds_Age_Breakdown.Where(y => y.phase == phaseId).Select(x => new
                {
                    x.state_code,
                    x.state_name,
                    x.lga_code,
                    x.lga_name,
                    x.ward_code,
                    x.ward_name,
                    x.estimate_hh_Ward,
                    x.estimate_Ind_Ward,
                    x.id,
                    x.sex,
                    x.Age_group,
                    x.inds,
                    x.hhs
                }));


            String date = DateTime.Now.ToShortDateString();

            date = date.Replace("/", "");

            if (date.Length == 7)
                date = "0" + date;


            String ReportName = "Draft_Analysis";
            string myName = Server.UrlEncode(ReportName + "_" + date + ".xlsx");
            // string myName = Server.UrlEncode(ReportName + ".xlsx");
            MemoryStream stream = new MemoryStream();
            GetStream(workbook).CopyTo(stream);

            byte[] byteArray = stream.ToArray();

            workbook.Dispose();

            Response.Clear();

            var cookie = new HttpCookie("fileDownloadToken", tokenId);
            Response.AppendCookie(cookie);

            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=" + myName);
            Response.ContentType = "application/vnd.ms-excel";
            Response.BinaryWrite(stream.ToArray());
            Response.End();

            Response.Flush();

            
            return File(byteArray,"application/vnd.ms-excel",myName);
        }


        public Stream GetStream(XLWorkbook excelWorkbook)
        {
            Stream fs = new MemoryStream();
            excelWorkbook.SaveAs(fs);
            fs.Position = 0;
            return fs;
        }

    }
}
