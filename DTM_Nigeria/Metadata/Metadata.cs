using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DTM_Nigeria.Validation;

namespace DTM_Nigeria.Metadata
{
    //https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/database-first-development/enhancing-data-validation
    
    
    public class iom_profile_MD
    {
        [Required(ErrorMessage = "*")]
        public int phase;

        [Required(ErrorMessage = "*")]
        public  string date;

        [Required(ErrorMessage = "*")]
        public string lga;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string settlement;

            [Required(ErrorMessage = "*")]
        public  string settlement_type;

            [Required(ErrorMessage = "*")]
        public  int displaced_hh_ind_YesNo;

            [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> number_hh;

            [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> number_ind;
            
            [Required(ErrorMessage = "*")]
        public  int nr_YesNo;

            [Required(ErrorMessage = "*")]
        public  int reason_insurgency_YesNo;

            [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_insurg_hh;


        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_insurg_ind;

        [Required(ErrorMessage = "*")]
        public  int reason_clash_YesNo;

            [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_clash_hh;


        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_clash_ind;


        [Required(ErrorMessage = "*")]
        public  int reason_disaster_YesNo;

            [RequiredIf("reason_disaster_YesNo", 1, "*")]
        public  Nullable<int> reason_disaster_hh;

            [RequiredIf("reason_disaster_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_disaster_ind;

        [Required(ErrorMessage = "*")]
        public  int reason_others_YesNo;


            [RequiredIf("reason_others_YesNo", 1, "*")]
        public  string reason_others_name;

            [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_others_hh;

        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> reason_others_ind;

        [Required(ErrorMessage = "*")]
        public  int temporary_settlement_type_camp_YesNo;

            [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> temporary_settlement_hh_camp;

        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> temporary_settlement_ind_camp;

        [Required(ErrorMessage = "*")]
        public  int temporary_settlement_type_hc_YesNo;

            [RequiredIf("temporary_settlement_type_hc_YesNo",1,"*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> temporary_settlement_hh_hc;

         [RequiredIf("temporary_settlement_type_hc_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> temporary_settlement_ind_hc;

    }


    public class iom_ward_profile_MD
    {

        [Required(ErrorMessage = "*")]
        public string date;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string settlement;

        [Required(ErrorMessage = "*")]
        public string settlement_type;

        [Required(ErrorMessage = "*")]
        public int displaced_hh_ind_YesNo;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> number_hh;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> number_ind;

        [Required(ErrorMessage = "*")]
        public int nr_YesNo;

        [Required(ErrorMessage = "*")]
        public int reason_insurgency_YesNo;

        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_insurg_hh;

        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_insurg_ind;

        [Required(ErrorMessage = "*")]
        public int reason_clash_YesNo;

        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_clash_hh;

        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_clash_ind;

        [Required(ErrorMessage = "*")]
        public int reason_disaster_YesNo;


        [RequiredIf("reason_disaster_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_disaster_hh;

        [RequiredIf("reason_disaster_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_disaster_ind;

        [Required(ErrorMessage = "*")]
        public int reason_others_YesNo;

        [RequiredIf("reason_others_YesNo", 1, "*")]
        public string reason_others_name;


        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_others_hh;

        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> reason_others_ind;

        [Required(ErrorMessage = "*")]
        public int temporary_settlement_type_camp_YesNo { get; set; }

        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_hh_camp;

        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_ind_camp;

        [Required(ErrorMessage = "*")]
        public int temporary_settlement_type_hc_YesNo;

        [RequiredIf("temporary_settlement_type_hc_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_hh_hc;

        [RequiredIf("temporary_settlement_type_hc_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> temporary_settlement_ind_hc;


        //start new adding 14.APR.17
        //Displaced 1T
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_1T_yn;

        [RequiredIf("disp_1T_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_1T_perc;

        [RequiredIf("disp_1T_yn", 1, "*")]
        public Nullable<int> disp_1T_dispDate;

        //Displaced 2T
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_2T_yn;

        [RequiredIf("disp_2T_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_2T_perc;

        [RequiredIf("disp_2T_yn", 1, "*")]
        public string disp_2T_state;

        [RequiredIf("disp_2T_yn", 1, "*")]
        public string disp_2T_lga;

        [RequiredIf("disp_2T_yn", 1, "*")]
        public Nullable<int> disp_2T_dispDate;

        //Displaced 3T
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_3T_yn;

        [RequiredIf("disp_3T_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_3T_perc;

        [RequiredIf("disp_3T_yn", 1, "*")]
        public string disp_3T_state;

        [RequiredIf("disp_3T_yn", 1, "*")]
        public string disp_3T_lga;


        [RequiredIf("disp_3T_yn", 1, "*")]
        public Nullable<int> disp_3T_dispDate;

        //Displaced 3Tp

        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> disp_3Tp_yn;

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        [Range(0, 100, ErrorMessage = "Invalid percentage [0 - 100]!")]
        public Nullable<int> disp_3Tp_perc;

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public string disp_3Tp_state;

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public string disp_3Tp_lga;

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public string disp_3Tp_ward;

        [RequiredIf("disp_3Tp_yn", 1, "*")]
        public Nullable<int> disp_3Tp_dispDate;

        //added by Abdul on May 27, 2017
        [RequiredIf("state_LargestGrp1_selected", true, "*")]
        public string lga_prev_disp_LargestGrp1;

        [RequiredIf("state_LargestGrp1_selected", true, "*")]
        public Nullable<int> NbHH_LargestGrp1;

        [RequiredIf("state_LargestGrp1_selected", true, "*")]
        public Nullable<int> NbIND_LargestGrp1;

        [RequiredIf("state_LargestGrp2_selected", true, "*")]
        public string lga_prev_disp_LargestGrp2;

        [RequiredIf("state_LargestGrp2_selected", true, "*")]
        public Nullable<int> NbHH_LargestGrp2;

        [RequiredIf("state_LargestGrp2_selected", true, "*")]
        public Nullable<int> NbIND_LargestGrp2;
        //--end

        //Section G
        [Required(ErrorMessage = "*")]
        [UIHint("YesNo")]
        public Nullable<int> idps_fromLGA_dispInWard;

        [RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbHH_dispInWard;

        [RequiredIf("idps_fromLGA_dispInWard", 1, "*")]
        public Nullable<int> NbIND_dispInWard;

        //end new adding 14.APR.17

        //start new adding 06.OCT.16

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_makeshift;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_overcrowded_houses;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_damaged_houses;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_living_outdoors;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_need_NFI;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_need_KitchenSet;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[0-9]+[0-9]*", ErrorMessage = "number>=0")]
        public Nullable<int> NbHH_need_Full_kits;
        //end new adding 06.OCT.16
    }

    public class iom_informants_MD
    {

        [RequiredIf("notEmpty", true, "*")]
        public string name;

        [RequiredIf("notEmpty", true, "*")]
        public Nullable<int> type;

        [RequiredIf("notEmpty", true, "*")]
        public string sex;
        
    }

    public class iom_ga_site_information_MD
    { 
        
        [RequiredIf("notEmpty", true, "*")]
        public string name_site;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public  Nullable<double> coord_lon;

            [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public  Nullable<double> coord_lat;


    }

    public class iom_group_assessment_2_MD
    { 
        [Required(ErrorMessage = "*")]
        public Nullable<int> member_disp_p1_YesNo;

        [RequiredIf("member_disp_p1_YesNo", 1, "*")]
        public Nullable<int> how_many_time_disp;

        [RequiredIf("member_disp_p1_YesNo", 1, "*")]
        public string if_yes_lga_maj;

        [RequiredIf("member_disp_p1_YesNo", 1, "*")]
        public string if_yes_ward_maj;

        [Required(ErrorMessage = "*")]
        public Nullable<int> intention_of_majority;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_unaccompanied_children;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_separated_children;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_minor_hh;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_female_hh;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_women_at_risk;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_physical_disability;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_mental_disability;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_serious_med_condition;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_other;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_water;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_food;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_health;

        [Range(1, 5, ErrorMessage = "1-5")]
        [RequiredIf("b_need_other2", true, "*")]
        public Nullable<int> need_other;

        [RequiredIf("b_need_other", true, "*")]
        public string need_specify;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_sanitation;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_shelter;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_education;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_access_icome;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_lhelp;

        [Range(1, 5, ErrorMessage = "1-5")]
        public Nullable<int> need_nfi;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_pregnant_women;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_breastfeeding_mother;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> v_male_hh;

        [Required(ErrorMessage = "*")]
        public Nullable<int> protect_people_feel_safe_YesNo;

        [RequiredIf("protect_people_feel_safe_YesNo", 4, "*")]
        public string protect_people_feel_safe_ifNoAns;

        [Required(ErrorMessage = "*")]
        public Nullable<int> protect_common_incident;

        [RequiredIf("protect_common_incident", 9, "*")]
        public string protect_common_in_ifOther;

        [RequiredIf("protect_common_incident", 10, "*")]
        public string protect_common_in_ifNoAns;

        [Required(ErrorMessage = "*")]
        public Nullable<int> protect_common_GBV;

        [RequiredIf("protect_common_GBV", 8, "*")]
        public string protect_common_GBV_ifOther;

        [RequiredIf("protect_common_GBV", 9, "*")]
        public string protect_common_GBV_ifNoAns;

        [Required(ErrorMessage = "*")]
        public Nullable<int> protect_common_child_p_incident;

        [RequiredIf("protect_common_child_p_incident", 11, "*")]
        public string protect_common_child_p_incident_ifOther;

        [Required(ErrorMessage = "*")]
        public Nullable<int> protect_travel_oic_YesNo;

        [RequiredIf("protect_travel_oic_YesNo", 1, "*")]
        public Nullable<int> protect_travel_oic_ifYes_where;

        [RequiredIf("protect_travel_oic_YesNo", 1, "*")]
        public Nullable<int> protect_travel_oic_ifYes_what;

        [Required(ErrorMessage = "*")]
        public Nullable<int> shelter_mn_nfi;

        [RequiredIf("shelter_mn_nfi", 5, "*")]
        public string shelter_mn_other;


    }

    public class iom_group_assessment_1_MD
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string group_id;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string location;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public Nullable<double> coord_lon;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public Nullable<double> coord_lat;

        [Required(ErrorMessage = "*")]
        public Nullable<System.DateTime> interview_date;

        [Required(ErrorMessage = "*")]
        public Nullable<int> shelter_type;

        [RequiredIf("shelter_type", 8, "*")]
        public string sheter_type_other;

        [Required(ErrorMessage = "*")]
        public string lga_orgin;

        [Required(ErrorMessage = "*")]
        public Nullable<int> reason_for_disp;

        [RequiredIf("reason_for_disp", 4, "*")]
        public string reason_other;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public Nullable<int> number_hh;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  Nullable<int> number_ind;

        [Required(ErrorMessage = "*")]
        public  Nullable<int> wave_of_disp;

        [RequiredIf("wave_of_disp", 12, "*")]
        public  string wave_if_other;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> m0_5;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> m5_14;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> m15_24;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> m25_59;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> m60p;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> f0_5;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> f5_14;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f15_24;


        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f25_59;

        [RequiredIf("b_number_hh", true, "*")]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f60p;

        [Required(ErrorMessage = "*")]
        [Range(4, 16, ErrorMessage = "4-16")]
        public Nullable<int> credibility_rating;
    }

    public class iom_ga_idp_population_MD
    {
        [RequiredIf("notEmpty", true, "*")]
        public string ward_orig;

        [RequiredIf("notEmpty", true, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = ">0")]
        public Nullable<int> hh;

        [RequiredIf("notEmpty", true, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = ">0")]
        public Nullable<int> ind;

        [RequiredIf("notEmpty", true, "*")]
        public Nullable<int> ethnicity;

        [RequiredIf("notEmpty", true, "*")]
        public Nullable<int> religion;

        [RequiredIf("ethnicity", 15, "*")]
        public string religion_other;
    }

    public class iom_ga_informants_MD
    { 
        
    }

    public class iom_idp_arrival_MD
    { 
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = ">0")]
        public Nullable<int> hh;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = ">0")]
        public Nullable<int> ind;
    }

    public class iom_ward_idp_arrival_MD
    {
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = ">0")]
        public Nullable<int> hh;

        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = ">0")]
        public Nullable<int> ind;
    }

    public class iom_b1f_informants_MD
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string contact_details;
    }

    public class iom_b2f_informants_MD
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string contact_details;
    }


    public class iom_b1f_organizations_assisting_MD
    {
        [Required(ErrorMessage = "*")]
        public int assistance_type;
        
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string contact_person;
    }


    public class iom_b2f_organizations_assisting_MD
    {
        [Required(ErrorMessage = "*")]
        public int assistance_type;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string contact_person;
    }

    public class iom_dtm_phase_MD
    { 
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public int phase;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string description;
    }

    public class iom_ga_gender_age_sample_MD
    {
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_lt1;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_1_5;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_6_17;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_18_59;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_60p;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_lt1;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_1_5;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_6_17;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_18_59;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> f_60p;
    }

    public class iom_ward_presence_per_location_MD
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string location_name;

        [Required(ErrorMessage = "*")]
        public string location_type;

        [Required(ErrorMessage = "*")]
        public int idp_category;

        [Required(ErrorMessage = "*")]
        public Nullable<int> MainUnfulfilledNeed;

        [Required(ErrorMessage = "*")]
        public int idp_registered_list_YesNo;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public string registered_by;


        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public int estimate_hh;


        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public int estimate_ind;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public Nullable<double> coord_lon;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public Nullable<double> coord_lat;


    }

    public class iom_ward_households_breakdown_MD
    {
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_lt1;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_lt1;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_1_5;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_1_5;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_6_17;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_6_17;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_18_59;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> f_18_59;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public  Nullable<int> m_60p;

        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public Nullable<int> f_60p;
    }

    public class iom_researchers_MD
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string researcher_name;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string researcher_tel;
    }

    public partial class iom_organizations_MD
    {
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string name;

        [Required(ErrorMessage = "*")]
        public Nullable<int> type;
    }

    public class iom_presence_wards_MD
    {
        [Required(ErrorMessage = "*")]
        public  string ward_code;

        [Required(ErrorMessage = "*")]
        public  string location_type;

        [Required(ErrorMessage = "*")]
        public  int idp_category;

        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public  string location_name;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  int estimate_hh;

        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public  int estimate_ind;

        [Required(ErrorMessage = "*")]
        public  string majority_stateoforigin;

        [Required(ErrorMessage = "*")]
        public  string majority_lgaoforigin;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public  Nullable<double> coord_lon;

        [RegularExpression("^[-]?[0-9]+(\\.[0-9]+)?", ErrorMessage = "decimal")]
        public  Nullable<double> coord_lat;

    }



}