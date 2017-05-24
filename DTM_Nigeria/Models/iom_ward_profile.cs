//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DTM_Nigeria.Validation;

namespace DTM_Nigeria.Models
{
    public partial class iom_ward_profile
    {
        public iom_ward_profile()
        {
            this.iom_b2f_informants = new HashSet<iom_b2f_informants>();
            this.iom_b2f_organizations_assisting = new HashSet<iom_b2f_organizations_assisting>();
            this.iom_group_assessment_1 = new HashSet<iom_group_assessment_1>();
            this.iom_ward_households_breakdown = new HashSet<iom_ward_households_breakdown>();
            this.iom_ward_idp_arrival = new HashSet<iom_ward_idp_arrival>();
            this.iom_ward_presence_per_location = new HashSet<iom_ward_presence_per_location>();
        }
    
        public int id { get; set; }

        [Required(ErrorMessage = "*")]
        public string date { get; set; }

        public int researcher_id { get; set; }

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string settlement { get; set; }

        [Required(ErrorMessage = "*")]
        public string settlement_type { get; set; }

        [Required(ErrorMessage = "*")]
        public int displaced_hh_ind_YesNo { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> number_hh { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> number_ind { get; set; }

        [Required(ErrorMessage = "*")]
        public int nr_YesNo { get; set; }


        public string nr_location { get; set; }
        public string nr_state1 { get; set; }
        public string nr_state2 { get; set; }
        public Nullable<int> nr_period { get; set; }

        [Required(ErrorMessage = "*")]
        public int reason_insurgency_YesNo { get; set; }

        public Nullable<int> reason_insurg_year { get; set; }

        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_insurg_hh { get; set; }

        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_insurg_ind { get; set; }

        [Required(ErrorMessage = "*")]
        public int reason_clash_YesNo { get; set; }


        public Nullable<int> reason_clash_year { get; set; }

        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_clash_hh { get; set; }

        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_clash_ind { get; set; }

        [Required(ErrorMessage = "*")]
        public int reason_disaster_YesNo { get; set; }


        public Nullable<int> reason_disaster_year { get; set; }

        [RequiredIf("reason_disaster_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_disaster_hh { get; set; }

        [RequiredIf("reason_disaster_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_disaster_ind { get; set; }

        [Required(ErrorMessage = "*")]
        public int reason_others_YesNo { get; set; }

        [RequiredIf("reason_others_YesNo", 1, "*")]
        public string reason_others_name { get; set; }


        public Nullable<int> reason_others_year { get; set; }

        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_others_hh { get; set; }

        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_others_ind { get; set; }

        [Required(ErrorMessage = "*")]
        public int temporary_settlement_type_camp_YesNo { get; set; }

        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_hh_camp { get; set; }

        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_ind_camp { get; set; }

        [Required(ErrorMessage = "*")]
        public int temporary_settlement_type_hc_YesNo { get; set; }

        [RequiredIf("temporary_settlement_type_hc_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_hh_hc { get; set; }

        [RequiredIf("temporary_settlement_type_hc_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_ind_hc { get; set; }


        public Nullable<int> housing_shelter { get; set; }
        public Nullable<int> drinking_water { get; set; }
        public Nullable<int> food { get; set; }
        public Nullable<int> medical_care { get; set; }
        public Nullable<int> access_edu { get; set; }
        public Nullable<int> hygiene_kits { get; set; }
        public Nullable<int> sewage_disp { get; set; }
        public Nullable<int> hospitality_extent { get; set; }
        public Nullable<int> diff_cause_issues { get; set; }
        public Nullable<int> tensions_idp_hc { get; set; }
        public Nullable<int> collabo_idp_hc { get; set; }
        public Nullable<int> res_shr_idp_hc { get; set; }
        public Nullable<int> stigma_toward1 { get; set; }
        public Nullable<int> stigma_toward2 { get; set; }
        public Nullable<int> stigma_toward3 { get; set; }
        public Nullable<int> trust_ppl1 { get; set; }
        public Nullable<int> trust_ppl2 { get; set; }
        public Nullable<int> trust_ppl3 { get; set; }

        //start new adding 14.APR.17
        //Displaced 1T
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_1T_yn { get; set; }

        [RequiredIf("disp_1T_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_1T_perc { get; set; }

        //Displaced 2T
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_2T_yn { get; set; }

        [RequiredIf("disp_2T_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_2T_perc { get; set; }

        [RequiredIf("disp_2T_yn", 1, "*")]
        public string disp_2T_state { get; set; }

        [RequiredIf("disp_2T_yn", 1, "*")]
        public string disp_2T_lga { get; set; }

        [RequiredIf("disp_2T_yn", 1, "*")]
        public string disp_2T_ward { get; set; }

        [RequiredIf("disp_2T_yn", 1, "*")]
        public Nullable<int> disp_2T_dispDate { get; set; }

        //Displaced 2T

        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_3T_yn { get; set; }

        [RequiredIf("disp_3T_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_3T_perc { get; set; }

        [RequiredIf("disp_3T_yn", 1, "*")]
        public string disp_3T_state { get; set; }

        [RequiredIf("disp_3T_yn", 1, "*")]
        public string disp_3T_lga { get; set; }

        [RequiredIf("disp_3T_yn", 1, "*")]
        public string disp_3T_ward { get; set; }

        [RequiredIf("disp_3T_yn", 1, "*")]
        public Nullable<int> disp_3T_dispDate { get; set; }

        //Displaced 3Tp

        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_3Tp_yn { get; set; }

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_3Tp_perc { get; set; }

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public string disp_3Tp_state { get; set; }

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public string disp_3Tp_lga { get; set; }

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public string disp_3Tp_ward { get; set; }

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public Nullable<int> disp_3Tp_dispDate { get; set; }

        //Section G
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> idps_fromLGA_dispInWard { get; set; }

        [RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbHH_dispInWard { get; set; }

        [RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbIND_dispInWard { get; set; }

        //1st largest group

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public string state_prev_disp_LargestGrp1 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public string lga_prev_disp_LargestGrp1 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public string date_arriv_LGA_LargestGrp1 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbHH_LargestGrp1 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbIND_LargestGrp1 { get; set; }

        //1st largest group

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public string state_prev_disp_LargestGrp2 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public string lga_prev_disp_LargestGrp2 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public string date_arriv_LGA_LargestGrp2 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbHH_LargestGrp2 { get; set; }

        //[RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbIND_LargestGrp2 { get; set; }

        //end new adding 14.APR.17

        //start new adding 06.OCT.16

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_makeshift { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_overcrowded_houses { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_damaged_houses { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_living_outdoors { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_need_NFI { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_need_KitchenSet { get; set; }

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_need_Full_kits { get; set; }
        //end new adding 06.OCT.16

        public Nullable<System.DateTime> create_time { get; set; }
        public Nullable<System.DateTime> update_time { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
    
        public virtual ICollection<iom_b2f_informants> iom_b2f_informants { get; set; }
        public virtual ICollection<iom_b2f_organizations_assisting> iom_b2f_organizations_assisting { get; set; }
        public virtual ICollection<iom_group_assessment_1> iom_group_assessment_1 { get; set; }
        public virtual iom_presence_wards iom_presence_wards { get; set; }
        public virtual iom_researchers iom_researchers { get; set; }
        public virtual ICollection<iom_ward_households_breakdown> iom_ward_households_breakdown { get; set; }
        public virtual ICollection<iom_ward_idp_arrival> iom_ward_idp_arrival { get; set; }
        public virtual ICollection<iom_ward_presence_per_location> iom_ward_presence_per_location { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc1 { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc2 { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc3 { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc4 { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc5 { get; set; }
        public virtual lkp_cmp_idp_hc lkp_cmp_idp_hc6 { get; set; }
        public virtual lkp_collabo lkp_collabo { get; set; }
        public virtual lkp_collabo lkp_collabo1 { get; set; }
        public virtual lkp_hospitality lkp_hospitality { get; set; }
        public virtual lkp_Lga lkp_Lga { get; set; }
        public virtual lkp_Lga lkp_Lga1 { get; set; }
        public virtual lkp_Lga lkp_Lga2 { get; set; }
        public virtual lkp_Lga lkp_Lga3 { get; set; }
        public virtual lkp_Lga lkp_Lga4 { get; set; }
        public virtual lkp_NotReturnLocation lkp_NotReturnLocation { get; set; }
        public virtual lkp_Period2 lkp_Period2 { get; set; }
        public virtual lkp_Period2 lkp_Period21 { get; set; }
        public virtual lkp_Period2 lkp_Period22 { get; set; }
        public virtual lkp_Period2 lkp_Period23 { get; set; }
        public virtual lkp_Period2 lkp_Period24 { get; set; }
        public virtual lkp_Period2 lkp_Period25 { get; set; }
        public virtual lkp_Period2 lkp_Period26 { get; set; }
        public virtual lkp_Period2 lkp_Period27 { get; set; }
        public virtual lkp_Settlement lkp_Settlement { get; set; }
        public virtual lkp_State lkp_State { get; set; }
        public virtual lkp_State lkp_State1 { get; set; }
        public virtual lkp_State lkp_State2 { get; set; }
        public virtual lkp_State lkp_State3 { get; set; }
        public virtual lkp_State lkp_State4 { get; set; }
        public virtual lkp_State lkp_State5 { get; set; }
        public virtual lkp_State lkp_State6 { get; set; }
        public virtual lkp_stigma_toward lkp_stigma_toward { get; set; }
        public virtual lkp_stigma_toward lkp_stigma_toward1 { get; set; }
        public virtual lkp_stigma_toward lkp_stigma_toward2 { get; set; }
        public virtual lkp_tensions lkp_tensions { get; set; }
        public virtual lkp_trust_ppl_degree lkp_trust_ppl_degree { get; set; }
        public virtual lkp_trust_ppl_degree lkp_trust_ppl_degree1 { get; set; }
        public virtual lkp_trust_ppl_degree lkp_trust_ppl_degree2 { get; set; }
        public virtual lkp_Ward lkp_Ward { get; set; }
        public virtual lkp_Ward lkp_Ward1 { get; set; }
        public virtual lkp_Ward lkp_Ward2 { get; set; }
        public virtual lkp_YesNo lkp_YesNo { get; set; }
        public virtual lkp_YesNo lkp_YesNo1 { get; set; }
        public virtual lkp_YesNo lkp_YesNo2 { get; set; }
        public virtual lkp_YesNo lkp_YesNo3 { get; set; }
        public virtual lkp_YesNo lkp_YesNo4 { get; set; }
        public virtual lkp_YesNo lkp_YesNo5 { get; set; }
    }
    
}
