﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DTM_Nigeria.Models
{
    public partial class iomdtmEntities : DbContext
    {
        public iomdtmEntities()
            : base("name=iomdtmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<iom_b1f_informants> iom_b1f_informants { get; set; }
        public DbSet<iom_b1f_organizations_assisting> iom_b1f_organizations_assisting { get; set; }
        public DbSet<iom_b2f_informants> iom_b2f_informants { get; set; }
        public DbSet<iom_b2f_organizations_assisting> iom_b2f_organizations_assisting { get; set; }
        public DbSet<iom_dtm_phase> iom_dtm_phase { get; set; }
        public DbSet<iom_ga_gender_age_sample> iom_ga_gender_age_sample { get; set; }
        public DbSet<iom_ga_idp_population> iom_ga_idp_population { get; set; }
        public DbSet<iom_ga_informants> iom_ga_informants { get; set; }
        public DbSet<iom_ga_site_information> iom_ga_site_information { get; set; }
        public DbSet<iom_group_assessment_1> iom_group_assessment_1 { get; set; }
        public DbSet<iom_group_assessment_2> iom_group_assessment_2 { get; set; }
        public DbSet<iom_idp_arrival> iom_idp_arrival { get; set; }
        public DbSet<iom_informants> iom_informants { get; set; }
        public DbSet<iom_organizations> iom_organizations { get; set; }
        public DbSet<iom_presence_wards> iom_presence_wards { get; set; }
        public DbSet<iom_profile> iom_profile { get; set; }
        public DbSet<iom_researchers> iom_researchers { get; set; }
        public DbSet<iom_ward_households_breakdown> iom_ward_households_breakdown { get; set; }
        public DbSet<iom_ward_idp_arrival> iom_ward_idp_arrival { get; set; }
        public DbSet<iom_ward_presence_per_location> iom_ward_presence_per_location { get; set; }
        public DbSet<iom_ward_profile> iom_ward_profile { get; set; }
        public DbSet<lkp_assistance_type> lkp_assistance_type { get; set; }
        public DbSet<lkp_ChildProIncident> lkp_ChildProIncident { get; set; }
        public DbSet<lkp_cmp_idp_hc> lkp_cmp_idp_hc { get; set; }
        public DbSet<lkp_collabo> lkp_collabo { get; set; }
        public DbSet<lkp_Ethnicity> lkp_Ethnicity { get; set; }
        public DbSet<lkp_GBV> lkp_GBV { get; set; }
        public DbSet<lkp_HealthProblem> lkp_HealthProblem { get; set; }
        public DbSet<lkp_hospitality> lkp_hospitality { get; set; }
        public DbSet<lkp_IDP_Category> lkp_IDP_Category { get; set; }
        public DbSet<lkp_Incident> lkp_Incident { get; set; }
        public DbSet<lkp_Informant_Type> lkp_Informant_Type { get; set; }
        public DbSet<lkp_Intention> lkp_Intention { get; set; }
        public DbSet<lkp_Lga> lkp_Lga { get; set; }
        public DbSet<lkp_Location> lkp_Location { get; set; }
        public DbSet<lkp_MainUnfulfilledNeed> lkp_MainUnfulfilledNeed { get; set; }
        public DbSet<lkp_NeededNFI> lkp_NeededNFI { get; set; }
        public DbSet<lkp_NotReturnLocation> lkp_NotReturnLocation { get; set; }
        public DbSet<lkp_Opportunity> lkp_Opportunity { get; set; }
        public DbSet<lkp_Organization> lkp_Organization { get; set; }
        public DbSet<lkp_Period> lkp_Period { get; set; }
        public DbSet<lkp_Period2> lkp_Period2 { get; set; }
        public DbSet<lkp_ReasonOfDisp> lkp_ReasonOfDisp { get; set; }
        public DbSet<lkp_Relationship_Type> lkp_Relationship_Type { get; set; }
        public DbSet<lkp_Religion> lkp_Religion { get; set; }
        public DbSet<lkp_Settlement> lkp_Settlement { get; set; }
        public DbSet<lkp_Sex> lkp_Sex { get; set; }
        public DbSet<lkp_Shelter> lkp_Shelter { get; set; }
        public DbSet<lkp_State> lkp_State { get; set; }
        public DbSet<lkp_stigma_toward> lkp_stigma_toward { get; set; }
        public DbSet<lkp_tensions> lkp_tensions { get; set; }
        public DbSet<lkp_TravelLocation> lkp_TravelLocation { get; set; }
        public DbSet<lkp_trust_ppl_degree> lkp_trust_ppl_degree { get; set; }
        public DbSet<lkp_TypeOfResidence> lkp_TypeOfResidence { get; set; }
        public DbSet<lkp_Ward> lkp_Ward { get; set; }
        public DbSet<lkp_YesNo> lkp_YesNo { get; set; }
        public DbSet<view_error_check_B2F_Full> view_error_check_B2F_Full { get; set; }
        public DbSet<view_error_check_B2F_toFix> view_error_check_B2F_toFix { get; set; }
        public DbSet<view_error_check_Camp_with_No_Figues_In_B2F> view_error_check_Camp_with_No_Figues_In_B2F { get; set; }
        public DbSet<view_error_check_HC_vs_Camp> view_error_check_HC_vs_Camp { get; set; }
        public DbSet<view_error_check_Numbers_Ward_vs_B2F> view_error_check_Numbers_Ward_vs_B2F { get; set; }
        public DbSet<view_error_check_Sum_Numbers_Camp_vs_B2F> view_error_check_Sum_Numbers_Camp_vs_B2F { get; set; }
        public DbSet<view_estimate_hhs_Inds_Age_Breakdown> view_estimate_hhs_Inds_Age_Breakdown { get; set; }
        public DbSet<view_estimate_hhs_Inds_per_Reason_for_Diplacement> view_estimate_hhs_Inds_per_Reason_for_Diplacement { get; set; }
        public DbSet<view_estimate_hhs_Inds_per_Wards> view_estimate_hhs_Inds_per_Wards { get; set; }
        public DbSet<view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival> view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival { get; set; }
        public DbSet<vw_error_ck_B2F_vs_LocA> vw_error_ck_B2F_vs_LocA { get; set; }
        public DbSet<vw_error_ck_B2F_vs_LocA_pop_no_match> vw_error_ck_B2F_vs_LocA_pop_no_match { get; set; }
    }
}