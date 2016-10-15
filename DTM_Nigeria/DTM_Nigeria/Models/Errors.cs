using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class Errors
    {
        iomdtmEntities _entity = new iomdtmEntities();

        public List<view_error_check_Numbers_Ward_vs_B2F> err_cnt_ward_b2f_ { get; set; }

        public List<view_error_check_HC_vs_Camp> err_create_camp_ { get; set; }

        public List<view_error_check_Sum_Numbers_Camp_vs_B2F> err_sum_camp_b2f_ { get; set; }

        public List<view_error_check_B2F_toFix> err_cnt_b2f_ { get; set; }

        public List<view_error_check_Camp_with_No_Figues_In_B2F> err_camp_nfig_b2f_ { get; set; }


        

        public Errors()
        {
            //err_cnt_ward_b2f_ = new List<view_error_check_Numbers_Ward_vs_B2F>();
            //err_create_camp_ = new List<view_error_check_HC_vs_Camp>();
            //err_sum_camp_b2f_ = new List<view_error_check_Sum_Numbers_Camp_vs_B2F>();
            //err_cnt_b2f_ = new List<view_error_check_B2F_toFix>();
           // init_Lists();
            
        }

        public Errors(int phase)
        {
            //if (phase == -1)
            //{

            //    init_Lists();
            //    //this.err_cnt_ward_b2f_ = _entity.view_error_check_Numbers_Ward_vs_B2F.ToList();
            //    //this.err_create_camp_ = _entity.view_error_check_HC_vs_Camp.ToList();
            //    //this.err_sum_camp_b2f_ = _entity.view_error_check_Sum_Numbers_Camp_vs_B2F.ToList();
            //    //this.err_cnt_b2f_ = _entity.view_error_check_B2F_toFix.ToList();
            //    //return;
            //}
            //else
            //{
            //    //err_cnt_ward_b2f_ = new List<view_error_check_Numbers_Ward_vs_B2F>();
            //    //err_create_camp_ = new List<view_error_check_HC_vs_Camp>();
            //    //err_sum_camp_b2f_ = new List<view_error_check_Sum_Numbers_Camp_vs_B2F>();
            //    //err_cnt_b2f_ = new List<view_error_check_B2F_toFix>();

                err_cnt_ward_b2f_ = _entity.view_error_check_Numbers_Ward_vs_B2F.Where(x => x.phase == phase || phase==-1).ToList();
                err_create_camp_ = _entity.view_error_check_HC_vs_Camp.Where(x => x.phase == phase || phase == -1).ToList();
                err_sum_camp_b2f_ = _entity.view_error_check_Sum_Numbers_Camp_vs_B2F.Where(x => x.phase == phase || phase == -1).ToList();
                err_cnt_b2f_ = _entity.view_error_check_B2F_toFix.Where(x => x.phase == phase || phase == -1).ToList();
                err_camp_nfig_b2f_ = _entity.view_error_check_Camp_with_No_Figues_In_B2F.Where(x => x.phase == phase || phase == -1).ToList();
            //}
        }

        public bool canGenerateReport()
        {
            if (err_cnt_ward_b2f_.Count() == 0 && err_create_camp_.Count() == 0
                && err_sum_camp_b2f_.Count() == 0 && err_cnt_b2f_.Count() == 0 && err_camp_nfig_b2f_.Count()==0)
                return true;


                return false;

        }

    }
}