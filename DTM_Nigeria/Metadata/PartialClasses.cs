using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using DTM_Nigeria;
using DTM_Nigeria.Validation;
using DTM_Nigeria.Metadata;

namespace DTM_Nigeria.Models
{
    [MetadataType(typeof(iom_profile_MD))]
    public partial class iom_profile
    {
        [Required(ErrorMessage = "*")]
        public string state { get; set; }
    }

    [MetadataType(typeof(iom_ward_profile_MD))]
    public partial class iom_ward_profile
    {
        public bool state_LargestGrp1_selected
        { 
            get { return string.IsNullOrEmpty(state_prev_disp_LargestGrp1)==false; }  
        }

        public bool state_LargestGrp2_selected
        {
            get { return string.IsNullOrEmpty(state_prev_disp_LargestGrp2) == false; }
        }
    }

    [MetadataType(typeof(iom_informants_MD))]
    public partial class iom_informants
    {
        [Required]
        public virtual bool notEmpty { get; set; }

    }



    [MetadataType(typeof(iom_idp_arrival_MD))]
    public partial class iom_idp_arrival
    {

    }

    [MetadataType(typeof(iom_ward_idp_arrival_MD))]
    public partial class iom_ward_idp_arrival
    {

    }

    [MetadataType(typeof(iom_b1f_informants_MD))]
    public partial class iom_b1f_informants
    {

    }

    [MetadataType(typeof(iom_b2f_informants_MD))]
    public partial class iom_b2f_informants
    {

    }

    [MetadataType(typeof(iom_b1f_organizations_assisting_MD))]
    public partial class iom_b1f_organizations_assisting
    {

    }

    [MetadataType(typeof(iom_b2f_organizations_assisting_MD))]
    public partial class iom_b2f_organizations_assisting
    {

    }

    [MetadataType(typeof(iom_dtm_phase_MD))]
    public partial class iom_dtm_phase
    {

    }


    [MetadataType(typeof(iom_ward_presence_per_location_MD))]
    public partial class iom_ward_presence_per_location
    {
    }

    [MetadataType(typeof(iom_ward_households_breakdown_MD))]
    public partial class iom_ward_households_breakdown
    {
    }

    [MetadataType(typeof(iom_researchers_MD))]
    public partial class iom_researchers
    {
    }

    [MetadataType(typeof(iom_organizations_MD))]
    public partial class iom_organizations
    {
    }

    [MetadataType(typeof(iom_presence_wards_MD))]
    public partial class iom_presence_wards_MD
    {
    }

    [MetadataType(typeof(iom_group_assessment_1_MD))]
    public partial class iom_group_assessment_1
    {
        [Required(ErrorMessage = "*")]
        public string state { get; set; }
    }

    public partial class iom_group_assessment_2
    {
        [RequiredIf("member_disp_p1_YesNo", 1, "*")]
        public string state { get; set; }

        public bool b_need_other { get { return need_other > 0; } set { if (value)need_other = null; } }
        public bool b_need_other2 { get { return (!string.IsNullOrEmpty(need_specify)); } set { if (value)need_specify = null; } }
    }

    [MetadataType(typeof(iom_ga_site_information_MD))]
    public partial class iom_ga_site_information
    {
        [Required]
        public virtual bool notEmpty { get; set; }

    }

    [MetadataType(typeof(iom_ga_idp_population_MD))]
    public partial class iom_ga_idp_population
    {
        [Required(ErrorMessage = "*")]
        public bool notEmpty { get; set; }


    }
}