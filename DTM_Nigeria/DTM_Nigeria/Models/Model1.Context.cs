//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if 
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.EntityClient;

namespace DTM_Nigeria.Models
{
    public partial class iomdtmEntities : ObjectContext
    {
        public const string ConnectionString = "name=iomdtmEntities";
        public const string ContainerName = "iomdtmEntities";
    
        #region Constructors
    
        public iomdtmEntities()
            : base(ConnectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public iomdtmEntities(string connectionString)
            : base(connectionString, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        public iomdtmEntities(EntityConnection connection)
            : base(connection, ContainerName)
        {
            this.ContextOptions.LazyLoadingEnabled = true;
        }
    
        #endregion
    
        #region ObjectSet Properties
    
        public ObjectSet<iom_b1f_informants> iom_b1f_informants
        {
            get { return _iom_b1f_informants  ?? (_iom_b1f_informants = CreateObjectSet<iom_b1f_informants>("iom_b1f_informants")); }
        }
        private ObjectSet<iom_b1f_informants> _iom_b1f_informants;
    
        public ObjectSet<iom_b1f_organizations_assisting> iom_b1f_organizations_assisting
        {
            get { return _iom_b1f_organizations_assisting  ?? (_iom_b1f_organizations_assisting = CreateObjectSet<iom_b1f_organizations_assisting>("iom_b1f_organizations_assisting")); }
        }
        private ObjectSet<iom_b1f_organizations_assisting> _iom_b1f_organizations_assisting;
    
        public ObjectSet<iom_b2f_informants> iom_b2f_informants
        {
            get { return _iom_b2f_informants  ?? (_iom_b2f_informants = CreateObjectSet<iom_b2f_informants>("iom_b2f_informants")); }
        }
        private ObjectSet<iom_b2f_informants> _iom_b2f_informants;
    
        public ObjectSet<iom_b2f_organizations_assisting> iom_b2f_organizations_assisting
        {
            get { return _iom_b2f_organizations_assisting  ?? (_iom_b2f_organizations_assisting = CreateObjectSet<iom_b2f_organizations_assisting>("iom_b2f_organizations_assisting")); }
        }
        private ObjectSet<iom_b2f_organizations_assisting> _iom_b2f_organizations_assisting;
    
        public ObjectSet<iom_dtm_phase> iom_dtm_phase
        {
            get { return _iom_dtm_phase  ?? (_iom_dtm_phase = CreateObjectSet<iom_dtm_phase>("iom_dtm_phase")); }
        }
        private ObjectSet<iom_dtm_phase> _iom_dtm_phase;
    
        public ObjectSet<iom_informants> iom_informants
        {
            get { return _iom_informants  ?? (_iom_informants = CreateObjectSet<iom_informants>("iom_informants")); }
        }
        private ObjectSet<iom_informants> _iom_informants;
    
        public ObjectSet<iom_organizations> iom_organizations
        {
            get { return _iom_organizations  ?? (_iom_organizations = CreateObjectSet<iom_organizations>("iom_organizations")); }
        }
        private ObjectSet<iom_organizations> _iom_organizations;
    
        public ObjectSet<iom_presence_wards> iom_presence_wards
        {
            get { return _iom_presence_wards  ?? (_iom_presence_wards = CreateObjectSet<iom_presence_wards>("iom_presence_wards")); }
        }
        private ObjectSet<iom_presence_wards> _iom_presence_wards;
    
        public ObjectSet<iom_researchers> iom_researchers
        {
            get { return _iom_researchers  ?? (_iom_researchers = CreateObjectSet<iom_researchers>("iom_researchers")); }
        }
        private ObjectSet<iom_researchers> _iom_researchers;
    
        public ObjectSet<iom_ward_presence_per_location> iom_ward_presence_per_location
        {
            get { return _iom_ward_presence_per_location  ?? (_iom_ward_presence_per_location = CreateObjectSet<iom_ward_presence_per_location>("iom_ward_presence_per_location")); }
        }
        private ObjectSet<iom_ward_presence_per_location> _iom_ward_presence_per_location;
    
        public ObjectSet<lkp_assistance_type> lkp_assistance_type
        {
            get { return _lkp_assistance_type  ?? (_lkp_assistance_type = CreateObjectSet<lkp_assistance_type>("lkp_assistance_type")); }
        }
        private ObjectSet<lkp_assistance_type> _lkp_assistance_type;
    
        public ObjectSet<lkp_IDP_Category> lkp_IDP_Category
        {
            get { return _lkp_IDP_Category  ?? (_lkp_IDP_Category = CreateObjectSet<lkp_IDP_Category>("lkp_IDP_Category")); }
        }
        private ObjectSet<lkp_IDP_Category> _lkp_IDP_Category;
    
        public ObjectSet<lkp_Informant_Type> lkp_Informant_Type
        {
            get { return _lkp_Informant_Type  ?? (_lkp_Informant_Type = CreateObjectSet<lkp_Informant_Type>("lkp_Informant_Type")); }
        }
        private ObjectSet<lkp_Informant_Type> _lkp_Informant_Type;
    
        public ObjectSet<lkp_Lga> lkp_Lga
        {
            get { return _lkp_Lga  ?? (_lkp_Lga = CreateObjectSet<lkp_Lga>("lkp_Lga")); }
        }
        private ObjectSet<lkp_Lga> _lkp_Lga;
    
        public ObjectSet<lkp_Location> lkp_Location
        {
            get { return _lkp_Location  ?? (_lkp_Location = CreateObjectSet<lkp_Location>("lkp_Location")); }
        }
        private ObjectSet<lkp_Location> _lkp_Location;
    
        public ObjectSet<lkp_NotReturnLocation> lkp_NotReturnLocation
        {
            get { return _lkp_NotReturnLocation  ?? (_lkp_NotReturnLocation = CreateObjectSet<lkp_NotReturnLocation>("lkp_NotReturnLocation")); }
        }
        private ObjectSet<lkp_NotReturnLocation> _lkp_NotReturnLocation;
    
        public ObjectSet<lkp_Organization> lkp_Organization
        {
            get { return _lkp_Organization  ?? (_lkp_Organization = CreateObjectSet<lkp_Organization>("lkp_Organization")); }
        }
        private ObjectSet<lkp_Organization> _lkp_Organization;
    
        public ObjectSet<lkp_Settlement> lkp_Settlement
        {
            get { return _lkp_Settlement  ?? (_lkp_Settlement = CreateObjectSet<lkp_Settlement>("lkp_Settlement")); }
        }
        private ObjectSet<lkp_Settlement> _lkp_Settlement;
    
        public ObjectSet<lkp_Sex> lkp_Sex
        {
            get { return _lkp_Sex  ?? (_lkp_Sex = CreateObjectSet<lkp_Sex>("lkp_Sex")); }
        }
        private ObjectSet<lkp_Sex> _lkp_Sex;
    
        public ObjectSet<lkp_State> lkp_State
        {
            get { return _lkp_State  ?? (_lkp_State = CreateObjectSet<lkp_State>("lkp_State")); }
        }
        private ObjectSet<lkp_State> _lkp_State;
    
        public ObjectSet<lkp_TypeOfResidence> lkp_TypeOfResidence
        {
            get { return _lkp_TypeOfResidence  ?? (_lkp_TypeOfResidence = CreateObjectSet<lkp_TypeOfResidence>("lkp_TypeOfResidence")); }
        }
        private ObjectSet<lkp_TypeOfResidence> _lkp_TypeOfResidence;
    
        public ObjectSet<lkp_Ward> lkp_Ward
        {
            get { return _lkp_Ward  ?? (_lkp_Ward = CreateObjectSet<lkp_Ward>("lkp_Ward")); }
        }
        private ObjectSet<lkp_Ward> _lkp_Ward;
    
        public ObjectSet<view_estimate_hhs_Inds_Age_Breakdown> view_estimate_hhs_Inds_Age_Breakdown
        {
            get { return _view_estimate_hhs_Inds_Age_Breakdown  ?? (_view_estimate_hhs_Inds_Age_Breakdown = CreateObjectSet<view_estimate_hhs_Inds_Age_Breakdown>("view_estimate_hhs_Inds_Age_Breakdown")); }
        }
        private ObjectSet<view_estimate_hhs_Inds_Age_Breakdown> _view_estimate_hhs_Inds_Age_Breakdown;
    
        public ObjectSet<view_estimate_hhs_Inds_per_Reason_for_Diplacement> view_estimate_hhs_Inds_per_Reason_for_Diplacement
        {
            get { return _view_estimate_hhs_Inds_per_Reason_for_Diplacement  ?? (_view_estimate_hhs_Inds_per_Reason_for_Diplacement = CreateObjectSet<view_estimate_hhs_Inds_per_Reason_for_Diplacement>("view_estimate_hhs_Inds_per_Reason_for_Diplacement")); }
        }
        private ObjectSet<view_estimate_hhs_Inds_per_Reason_for_Diplacement> _view_estimate_hhs_Inds_per_Reason_for_Diplacement;
    
        public ObjectSet<view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival> view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival
        {
            get { return _view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival  ?? (_view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival = CreateObjectSet<view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival>("view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival")); }
        }
        private ObjectSet<view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival> _view_estimate_hhs_Inds_per_Wards_per_Year_of_Arrival;
    
        public ObjectSet<iom_ward_households_breakdown> iom_ward_households_breakdown
        {
            get { return _iom_ward_households_breakdown  ?? (_iom_ward_households_breakdown = CreateObjectSet<iom_ward_households_breakdown>("iom_ward_households_breakdown")); }
        }
        private ObjectSet<iom_ward_households_breakdown> _iom_ward_households_breakdown;
    
        public ObjectSet<view_estimate_hhs_Inds_per_Wards> view_estimate_hhs_Inds_per_Wards
        {
            get { return _view_estimate_hhs_Inds_per_Wards  ?? (_view_estimate_hhs_Inds_per_Wards = CreateObjectSet<view_estimate_hhs_Inds_per_Wards>("view_estimate_hhs_Inds_per_Wards")); }
        }
        private ObjectSet<view_estimate_hhs_Inds_per_Wards> _view_estimate_hhs_Inds_per_Wards;
    
        public ObjectSet<view_error_check_B2F_Full> view_error_check_B2F_Full
        {
            get { return _view_error_check_B2F_Full  ?? (_view_error_check_B2F_Full = CreateObjectSet<view_error_check_B2F_Full>("view_error_check_B2F_Full")); }
        }
        private ObjectSet<view_error_check_B2F_Full> _view_error_check_B2F_Full;
    
        public ObjectSet<view_error_check_B2F_toFix> view_error_check_B2F_toFix
        {
            get { return _view_error_check_B2F_toFix  ?? (_view_error_check_B2F_toFix = CreateObjectSet<view_error_check_B2F_toFix>("view_error_check_B2F_toFix")); }
        }
        private ObjectSet<view_error_check_B2F_toFix> _view_error_check_B2F_toFix;
    
        public ObjectSet<view_error_check_HC_vs_Camp> view_error_check_HC_vs_Camp
        {
            get { return _view_error_check_HC_vs_Camp  ?? (_view_error_check_HC_vs_Camp = CreateObjectSet<view_error_check_HC_vs_Camp>("view_error_check_HC_vs_Camp")); }
        }
        private ObjectSet<view_error_check_HC_vs_Camp> _view_error_check_HC_vs_Camp;
    
        public ObjectSet<view_error_check_Numbers_Ward_vs_B2F> view_error_check_Numbers_Ward_vs_B2F
        {
            get { return _view_error_check_Numbers_Ward_vs_B2F  ?? (_view_error_check_Numbers_Ward_vs_B2F = CreateObjectSet<view_error_check_Numbers_Ward_vs_B2F>("view_error_check_Numbers_Ward_vs_B2F")); }
        }
        private ObjectSet<view_error_check_Numbers_Ward_vs_B2F> _view_error_check_Numbers_Ward_vs_B2F;
    
        public ObjectSet<view_error_check_Sum_Numbers_Camp_vs_B2F> view_error_check_Sum_Numbers_Camp_vs_B2F
        {
            get { return _view_error_check_Sum_Numbers_Camp_vs_B2F  ?? (_view_error_check_Sum_Numbers_Camp_vs_B2F = CreateObjectSet<view_error_check_Sum_Numbers_Camp_vs_B2F>("view_error_check_Sum_Numbers_Camp_vs_B2F")); }
        }
        private ObjectSet<view_error_check_Sum_Numbers_Camp_vs_B2F> _view_error_check_Sum_Numbers_Camp_vs_B2F;
    
        public ObjectSet<view_error_check_Camp_with_No_Figues_In_B2F> view_error_check_Camp_with_No_Figues_In_B2F
        {
            get { return _view_error_check_Camp_with_No_Figues_In_B2F  ?? (_view_error_check_Camp_with_No_Figues_In_B2F = CreateObjectSet<view_error_check_Camp_with_No_Figues_In_B2F>("view_error_check_Camp_with_No_Figues_In_B2F")); }
        }
        private ObjectSet<view_error_check_Camp_with_No_Figues_In_B2F> _view_error_check_Camp_with_No_Figues_In_B2F;
    
        public ObjectSet<iom_ga_gender_age_sample> iom_ga_gender_age_sample
        {
            get { return _iom_ga_gender_age_sample  ?? (_iom_ga_gender_age_sample = CreateObjectSet<iom_ga_gender_age_sample>("iom_ga_gender_age_sample")); }
        }
        private ObjectSet<iom_ga_gender_age_sample> _iom_ga_gender_age_sample;
    
        public ObjectSet<iom_ga_informants> iom_ga_informants
        {
            get { return _iom_ga_informants  ?? (_iom_ga_informants = CreateObjectSet<iom_ga_informants>("iom_ga_informants")); }
        }
        private ObjectSet<iom_ga_informants> _iom_ga_informants;
    
        public ObjectSet<iom_ga_site_information> iom_ga_site_information
        {
            get { return _iom_ga_site_information  ?? (_iom_ga_site_information = CreateObjectSet<iom_ga_site_information>("iom_ga_site_information")); }
        }
        private ObjectSet<iom_ga_site_information> _iom_ga_site_information;
    
        public ObjectSet<lkp_Ethnicity> lkp_Ethnicity
        {
            get { return _lkp_Ethnicity  ?? (_lkp_Ethnicity = CreateObjectSet<lkp_Ethnicity>("lkp_Ethnicity")); }
        }
        private ObjectSet<lkp_Ethnicity> _lkp_Ethnicity;
    
        public ObjectSet<lkp_Religion> lkp_Religion
        {
            get { return _lkp_Religion  ?? (_lkp_Religion = CreateObjectSet<lkp_Religion>("lkp_Religion")); }
        }
        private ObjectSet<lkp_Religion> _lkp_Religion;
    
        public ObjectSet<lkp_Shelter> lkp_Shelter
        {
            get { return _lkp_Shelter  ?? (_lkp_Shelter = CreateObjectSet<lkp_Shelter>("lkp_Shelter")); }
        }
        private ObjectSet<lkp_Shelter> _lkp_Shelter;
    
        public ObjectSet<iom_ga_idp_population> iom_ga_idp_population
        {
            get { return _iom_ga_idp_population  ?? (_iom_ga_idp_population = CreateObjectSet<iom_ga_idp_population>("iom_ga_idp_population")); }
        }
        private ObjectSet<iom_ga_idp_population> _iom_ga_idp_population;
    
        public ObjectSet<lkp_ReasonOfDisp> lkp_ReasonOfDisp
        {
            get { return _lkp_ReasonOfDisp  ?? (_lkp_ReasonOfDisp = CreateObjectSet<lkp_ReasonOfDisp>("lkp_ReasonOfDisp")); }
        }
        private ObjectSet<lkp_ReasonOfDisp> _lkp_ReasonOfDisp;
    
        public ObjectSet<lkp_Period2> lkp_Period2
        {
            get { return _lkp_Period2  ?? (_lkp_Period2 = CreateObjectSet<lkp_Period2>("lkp_Period2")); }
        }
        private ObjectSet<lkp_Period2> _lkp_Period2;
    
        public ObjectSet<lkp_Intention> lkp_Intention
        {
            get { return _lkp_Intention  ?? (_lkp_Intention = CreateObjectSet<lkp_Intention>("lkp_Intention")); }
        }
        private ObjectSet<lkp_Intention> _lkp_Intention;
    
        public ObjectSet<lkp_Relationship_Type> lkp_Relationship_Type
        {
            get { return _lkp_Relationship_Type  ?? (_lkp_Relationship_Type = CreateObjectSet<lkp_Relationship_Type>("lkp_Relationship_Type")); }
        }
        private ObjectSet<lkp_Relationship_Type> _lkp_Relationship_Type;
    
        public ObjectSet<lkp_HealthProblem> lkp_HealthProblem
        {
            get { return _lkp_HealthProblem  ?? (_lkp_HealthProblem = CreateObjectSet<lkp_HealthProblem>("lkp_HealthProblem")); }
        }
        private ObjectSet<lkp_HealthProblem> _lkp_HealthProblem;
    
        public ObjectSet<iom_idp_arrival> iom_idp_arrival
        {
            get { return _iom_idp_arrival  ?? (_iom_idp_arrival = CreateObjectSet<iom_idp_arrival>("iom_idp_arrival")); }
        }
        private ObjectSet<iom_idp_arrival> _iom_idp_arrival;
    
        public ObjectSet<iom_profile> iom_profile
        {
            get { return _iom_profile  ?? (_iom_profile = CreateObjectSet<iom_profile>("iom_profile")); }
        }
        private ObjectSet<iom_profile> _iom_profile;
    
        public ObjectSet<iom_ward_idp_arrival> iom_ward_idp_arrival
        {
            get { return _iom_ward_idp_arrival  ?? (_iom_ward_idp_arrival = CreateObjectSet<iom_ward_idp_arrival>("iom_ward_idp_arrival")); }
        }
        private ObjectSet<iom_ward_idp_arrival> _iom_ward_idp_arrival;
    
        public ObjectSet<iom_ward_profile> iom_ward_profile
        {
            get { return _iom_ward_profile  ?? (_iom_ward_profile = CreateObjectSet<iom_ward_profile>("iom_ward_profile")); }
        }
        private ObjectSet<iom_ward_profile> _iom_ward_profile;
    
        public ObjectSet<iom_group_assessment_1> iom_group_assessment_1
        {
            get { return _iom_group_assessment_1  ?? (_iom_group_assessment_1 = CreateObjectSet<iom_group_assessment_1>("iom_group_assessment_1")); }
        }
        private ObjectSet<iom_group_assessment_1> _iom_group_assessment_1;
    
        public ObjectSet<iom_group_assessment_2> iom_group_assessment_2
        {
            get { return _iom_group_assessment_2  ?? (_iom_group_assessment_2 = CreateObjectSet<iom_group_assessment_2>("iom_group_assessment_2")); }
        }
        private ObjectSet<iom_group_assessment_2> _iom_group_assessment_2;
    
        public ObjectSet<lkp_ChildProIncident> lkp_ChildProIncident
        {
            get { return _lkp_ChildProIncident  ?? (_lkp_ChildProIncident = CreateObjectSet<lkp_ChildProIncident>("lkp_ChildProIncident")); }
        }
        private ObjectSet<lkp_ChildProIncident> _lkp_ChildProIncident;
    
        public ObjectSet<lkp_GBV> lkp_GBV
        {
            get { return _lkp_GBV  ?? (_lkp_GBV = CreateObjectSet<lkp_GBV>("lkp_GBV")); }
        }
        private ObjectSet<lkp_GBV> _lkp_GBV;
    
        public ObjectSet<lkp_Incident> lkp_Incident
        {
            get { return _lkp_Incident  ?? (_lkp_Incident = CreateObjectSet<lkp_Incident>("lkp_Incident")); }
        }
        private ObjectSet<lkp_Incident> _lkp_Incident;
    
        public ObjectSet<lkp_NeededNFI> lkp_NeededNFI
        {
            get { return _lkp_NeededNFI  ?? (_lkp_NeededNFI = CreateObjectSet<lkp_NeededNFI>("lkp_NeededNFI")); }
        }
        private ObjectSet<lkp_NeededNFI> _lkp_NeededNFI;
    
        public ObjectSet<lkp_Opportunity> lkp_Opportunity
        {
            get { return _lkp_Opportunity  ?? (_lkp_Opportunity = CreateObjectSet<lkp_Opportunity>("lkp_Opportunity")); }
        }
        private ObjectSet<lkp_Opportunity> _lkp_Opportunity;
    
        public ObjectSet<lkp_TravelLocation> lkp_TravelLocation
        {
            get { return _lkp_TravelLocation  ?? (_lkp_TravelLocation = CreateObjectSet<lkp_TravelLocation>("lkp_TravelLocation")); }
        }
        private ObjectSet<lkp_TravelLocation> _lkp_TravelLocation;
    
        public ObjectSet<lkp_YesNo> lkp_YesNo
        {
            get { return _lkp_YesNo  ?? (_lkp_YesNo = CreateObjectSet<lkp_YesNo>("lkp_YesNo")); }
        }
        private ObjectSet<lkp_YesNo> _lkp_YesNo;

        #endregion

    }
}
