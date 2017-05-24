using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTM_Nigeria.Models
{
    public class VerifForm
    {
        iomdtmEntities _entity = new iomdtmEntities();

        public VerifForm()
        {

        }

        public VerifForm(iom_group_assessment_2 ga_p2, int phase)
        {
            int closed_YesNo = _entity.iom_dtm_phase.Where(x => x.phase == phase).Select(y => y.closed_YesNo).FirstOrDefault();

            if (closed_YesNo == 1)
            {
                throw new MyException("DTM 'Phase " + phase.ToString() + "' is closed, cannot add/edit this F2B form!");
            }

            //if (!(ga_p2.b_v_children_at_risk || ga_p2.b_v_female_hh || ga_p2.b_v_mental_disability ||
            //    ga_p2.b_v_minor_hh || ga_p2.b_v_missing_relatives || ga_p2.b_v_older_at_risk || ga_p2.b_v_other ||
            //    ga_p2.b_v_physical_disability || ga_p2.b_v_profile_based_risk || ga_p2.b_v_separated_children ||
            //    ga_p2.b_v_serious_med_condition || ga_p2.b_v_single_parent || ga_p2.b_v_surviror_at_risk_of_viol ||
            //    ga_p2.b_v_unaccompanied_children || ga_p2.b_v_women_at_risk))
            //{
            //    throw new MyException("Please make sure in section 3 (Vulnerability) you check at least one");
            //}


            int sum2 = 0;

            sum2 = sum2 + (ga_p2.need_access_icome ?? 0) + (ga_p2.need_education ?? 0) +
                (ga_p2.need_food ?? 0) + (ga_p2.need_health ?? 0) + (ga_p2.need_lhelp ?? 0) +
                (ga_p2.need_nfi ?? 0) + (ga_p2.need_other ?? 0) + (ga_p2.need_sanitation ?? 0) +
                (ga_p2.need_shelter ?? 0) + (ga_p2.need_water ?? 0);

            if (sum2 != 15)
            {
                throw new MyException("Please make sure in section 5 (Needs) you select any 5 needs and rank them from 1 to 5 !");
            }

        }

        public VerifForm(B3F b3f, int phase)
        {
            int closed_YesNo = _entity.iom_dtm_phase.Where(x => x.phase == phase).Select(y => y.closed_YesNo).FirstOrDefault();

            if (closed_YesNo == 1)
            {
                throw new MyException("DTM 'Phase " + phase.ToString() + "' is closed, cannot add/edit this F2B form!");
            }

            int sum = 0;
            sum = sum + (b3f.ga_p1.m0_5 ?? 0) + (b3f.ga_p1.m15_24 ?? 0) + (b3f.ga_p1.m25_59 ?? 0) + (b3f.ga_p1.m5_14 ?? 0) + (b3f.ga_p1.m60p ?? 0);
            sum = sum + (b3f.ga_p1.f0_5 ?? 0) + (b3f.ga_p1.f15_24 ?? 0) + (b3f.ga_p1.f25_59 ?? 0) + (b3f.ga_p1.f5_14 ?? 0) + (b3f.ga_p1.f60p ?? 0);

            if (sum != b3f.ga_p1.number_ind && b3f.ga_p1.number_hh <= 20)
            {
                throw new MyException("Total of individuals in section 1.7 should be equal to " + b3f.ga_p1.number_ind + " !");
            }
            else if (sum != 0 && b3f.ga_p1.number_hh > 20)
            {
                throw new MyException("Number of households>20, Section 1.7 should remain empty !");
            }



        }





        public VerifForm(B2F b2f)
        {
            int phase = b2f.profile.iom_presence_wards.iom_profile.iom_dtm_phase.closed_YesNo;

            if (phase == 1)
            {
                throw new MyException("DTM 'Phase " + phase + "' is closed, cannot add/edit this F2B form!");
            }

            if (b2f.profile.displaced_hh_ind_YesNo == 1 && (b2f.profile.number_hh == null || b2f.profile.number_ind == null))
            {
                throw new MyException("If there are displaced people, you need to indicate the # of households and # of individuals!");
            }
            else if (b2f.profile.displaced_hh_ind_YesNo == 2 && (b2f.profile.number_hh != null || b2f.profile.number_ind != null))
            {
                throw new MyException("If there are no displaced people, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b2f.profile.nr_YesNo == 2 &&
                (!string.IsNullOrEmpty(b2f.profile.nr_location) || b2f.profile.nr_period != null ||
                !string.IsNullOrEmpty(b2f.profile.nr_state1) || !string.IsNullOrEmpty(b2f.profile.nr_state2)))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If IDPs have not returned, leave the corresponding fields empty!");
            }
            else if (b2f.profile.nr_YesNo == 1 &&
                (string.IsNullOrEmpty(b2f.profile.nr_location) && b2f.profile.nr_period == null &&
                string.IsNullOrEmpty(b2f.profile.nr_state1) && string.IsNullOrEmpty(b2f.profile.nr_state2))
                )
            {
                throw new MyException("If IDPs have returned, fill up the corresponding fields!");

            }


            if (b2f.profile.reason_insurgency_YesNo == 1 &&
                (b2f.profile.reason_insurg_hh == null || b2f.profile.reason_insurg_ind == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Insurgency is the reason of displacement, you need to indicate # of households and # of individuals!");
            }
            else if (b2f.profile.reason_insurgency_YesNo == 2 &&
                (b2f.profile.reason_insurg_hh != null || b2f.profile.reason_insurg_ind != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Insurgency is not the reason of displacement, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b2f.profile.reason_clash_YesNo == 1 &&
                (b2f.profile.reason_clash_hh == null || b2f.profile.reason_clash_ind == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Community clashes is the reason of displacement, you need to indicate # of households and # of individuals!");
            }
            else if (b2f.profile.reason_clash_YesNo == 2 &&
                (b2f.profile.reason_clash_hh != null || b2f.profile.reason_clash_ind != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Community clashes is not the reason of displacement, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b2f.profile.reason_disaster_YesNo == 1 &&
                (b2f.profile.reason_disaster_hh == null || b2f.profile.reason_disaster_ind == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Natural disasters is the reason of displacement, you need to indicate # of households and # of individuals!");
            }
            else if (b2f.profile.reason_disaster_YesNo == 2 &&
                (b2f.profile.reason_disaster_hh != null || b2f.profile.reason_disaster_ind != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Natural disasters is not the reason of displacement, you need to keep the fields # of households and # of individuals empty!");
            }


            if (b2f.profile.reason_others_YesNo == 1 &&
                (b2f.profile.reason_others_hh == null || b2f.profile.reason_others_hh == null || string.IsNullOrEmpty(b2f.profile.reason_others_name)))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Other is selected for the reason of displacement, you need to specify the reason, then indicate the # of households and # of individuals!");
            }
            else if (b2f.profile.reason_others_YesNo == 2 &&
                (b2f.profile.reason_others_hh != null || b2f.profile.reason_others_hh != null || !string.IsNullOrEmpty(b2f.profile.reason_others_name)))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Other/reason is not selected for the reason of displacement, you need to keep the fields other/specify, # of households and # of individuals empty!");
            }


            if (b2f.profile.temporary_settlement_type_camp_YesNo == 1 &&
                (b2f.profile.temporary_settlement_hh_camp == null || b2f.profile.temporary_settlement_ind_camp == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Camp is selected, you need to indicate the # of households and # of individuals!");
            }
            else if (b2f.profile.temporary_settlement_type_camp_YesNo == 2 &&
                (b2f.profile.temporary_settlement_hh_camp != null || b2f.profile.temporary_settlement_ind_camp != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Camp is not selected, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b2f.profile.temporary_settlement_type_hc_YesNo == 1 &&
                (b2f.profile.temporary_settlement_hh_hc == null || b2f.profile.temporary_settlement_ind_hc == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Host family is selected, you need to indicate the # of households and # of individuals!");
            }
            else if (b2f.profile.temporary_settlement_type_hc_YesNo == 2 &&
                (b2f.profile.temporary_settlement_hh_hc != null || b2f.profile.temporary_settlement_ind_hc != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Host family is not selected, you need to keep the fields # of households and # of individuals empty!");
            }

            int hhs = 0, inds = 0;

            foreach (iom_ward_idp_arrival arrival in b2f.arrivals)
            {
                if ((arrival.hh != null && arrival.ind == null) || (arrival.hh == null && arrival.ind != null))
                {
                    throw new MyException("Please make sure the fields # of household and # of individuals are filled or keep them both empty in section B. for the selected year of arrival.");
                }
                else if ((!string.IsNullOrEmpty(arrival.state_type)
                    || !string.IsNullOrEmpty(arrival.location)) && arrival.hh == null && arrival.ind == null)
                {
                    throw new MyException("Please make sure whether state type and state name are kept empty if no year of arrival is selected in section B.");
                }
                else if (!string.IsNullOrEmpty(arrival.state_type) && arrival.state_type.Equals("1") && b2f.inSameState(arrival.location) == null)
                {
                    throw new MyException("If you select [1-Same state], make sure you keep the location field empty or select the correct state in section B.");
                }
                else if (!string.IsNullOrEmpty(arrival.state_type) && arrival.state_type.Equals("2") && b2f.inSameState(arrival.location) != null)
                {
                    throw new MyException("If you select [2-Other state], make sure you keep the location field empty or select the correct state in section B.");
                }



                hhs = hhs + (arrival.hh ?? 0);
                inds = inds + (arrival.ind ?? 0);

            }

            if (b2f.profile.displaced_hh_ind_YesNo == 1 && (hhs != (b2f.profile.number_hh ?? 0) || inds != (b2f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please make sure the totals are correct for both # of household and # of individuals in section B. for the selected years of arrival. (" + b2f.profile.number_hh.ToString() + " hh(s)/" + b2f.profile.number_ind.ToString() + " ind(s))");
            }

            int hhs_ = (b2f.profile.reason_clash_hh ?? 0) + (b2f.profile.reason_disaster_hh ?? 0) + (b2f.profile.reason_insurg_hh ?? 0) +
                (b2f.profile.reason_others_hh ?? 0);

            int inds_ = (b2f.profile.reason_clash_ind ?? 0) + (b2f.profile.reason_disaster_ind ?? 0) + (b2f.profile.reason_insurg_ind ?? 0) +
                (b2f.profile.reason_others_ind ?? 0);

            if (b2f.profile.displaced_hh_ind_YesNo == 1 && (hhs_ != (b2f.profile.number_hh ?? 0) || inds_ != (b2f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please make sure the totals are correct for both # of household and # of individuals in section D. for the selected reasons for displacement. (" + b2f.profile.number_hh.ToString() + " hh(s)/" + b2f.profile.number_ind.ToString() + " ind(s))");
            }

            hhs_ = 0; inds_ = 0;

            hhs_ = (b2f.profile.temporary_settlement_hh_camp ?? 0) + (b2f.profile.temporary_settlement_hh_hc ?? 0);
            inds_ = (b2f.profile.temporary_settlement_ind_camp ?? 0) + (b2f.profile.temporary_settlement_ind_hc ?? 0);

            if (b2f.profile.displaced_hh_ind_YesNo == 1 && (hhs_ != (b2f.profile.number_hh ?? 0) || inds_ != (b2f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please make sure the totals are correct for both # of household and # of individuals in section E. in camps like site and host family. (" + b2f.profile.number_hh.ToString() + " hh(s)/" + b2f.profile.number_ind.ToString() + " ind(s))");
            }

            int perc_ = 0;
            perc_ = (b2f.profile.disp_1T_perc ?? 0) + (b2f.profile.disp_2T_perc ?? 0) + (b2f.profile.disp_3T_perc ?? 0)
                    + (b2f.profile.disp_3Tp_perc ?? 0);

            if (perc_ > 100)
            {
                throw new MyException("Please correct below numbers. The total of percentages of IDPs [" + perc_.ToString() + "%] in section F. SECONDARY DISPLACEMENT cannot exceed 100%.");
            }


            //Check IDPs who originate from this LGA and are currently displaced in the Ward vs Total IDPs
            if (b2f.profile.displaced_hh_ind_YesNo == 1 && ((b2f.profile.NbHH_dispInWard ?? 0) > (b2f.profile.number_hh ?? 0)))
            {
                throw new MyException("Please correct below numbers. The number of Households (" + (b2f.profile.NbHH_dispInWard ?? 0).ToString() +
                    ") in section 'G. IDPs WHO WERE ORIGINALLY DISPLACED FROM THIS LGA' cannot exceed the total households in the ward. (" + (b2f.profile.number_hh ?? 0).ToString() + " hh(s))");
            }
            if (b2f.profile.displaced_hh_ind_YesNo == 1 && ((b2f.profile.NbIND_dispInWard ?? 0) > (b2f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please correct below numbers. The number of Individuals (" + (b2f.profile.NbIND_dispInWard ?? 0).ToString() +
                    ") in section 'G. IDPs WHO WERE ORIGINALLY DISPLACED FROM THIS LGA' cannot exceed the total individuals in the ward. (" + (b2f.profile.number_ind ?? 0).ToString() + " inds(s))");
            }

            hhs_ = 0; inds_ = 0;

            hhs_ = (b2f.profile.NbHH_LargestGrp1 ?? 0) + (b2f.profile.NbHH_LargestGrp2 ?? 0);
            inds_ = (b2f.profile.NbIND_LargestGrp1 ?? 0) + (b2f.profile.NbIND_LargestGrp2 ?? 0);

            if (b2f.profile.idps_fromLGA_dispInWard == 1 && (hhs_ > (b2f.profile.NbHH_dispInWard ?? 0)))
            {
                throw new MyException("Please correct below numbers. The sum of Households (" + hhs_.ToString() +
                    ") for largest & 2nd largest group in section G. cannot exceed the number of households in the ward originated from this LGA. (" + (b2f.profile.NbHH_dispInWard ?? 0).ToString() + " hh(s))");
            }

            if (b2f.profile.idps_fromLGA_dispInWard == 1 && (inds_ > (b2f.profile.NbIND_dispInWard ?? 0)))
            {
                throw new MyException("Please correct below numbers. The sum of Individuals (" + inds_.ToString() +
                    ") for largest & 2nd largest group in section G. cannot exceed the number of individuals in the ward originated from this LGA. (" + (b2f.profile.NbIND_dispInWard ?? 0).ToString() + " inds(s))");
            }

            hhs_ = 0;

            hhs_ = (b2f.profile.NbHH_makeshift ?? 0) + (b2f.profile.NbHH_overcrowded_houses ?? 0) +
                   (b2f.profile.NbHH_damaged_houses ?? 0) + (b2f.profile.NbHH_living_outdoors ?? 0);

            if (b2f.profile.displaced_hh_ind_YesNo == 1 && (hhs_ > (b2f.profile.number_hh ?? 0)))
            {
                throw new MyException("Please correct below. The total HHs for shelter (" + hhs_.ToString() + ") in section I. SHELTER/NFI NEEDS cannot exceed the total households in the ward. (" + b2f.profile.number_hh.ToString() + " hh(s))");
            }

            hhs_ = 0;

            hhs_ = (b2f.profile.NbHH_need_NFI ?? 0) + (b2f.profile.NbHH_need_KitchenSet ?? 0) +
                   (b2f.profile.NbHH_need_Full_kits ?? 0);

            if (b2f.profile.displaced_hh_ind_YesNo == 1 && (hhs_ > (b2f.profile.number_hh ?? 0)))
            {
                throw new MyException("Please correct below. The total HHs for NFI (" + hhs_.ToString() + ") in section I. SHELTER/NFI NEEDS cannot exceed the total households in the ward. (" + b2f.profile.number_hh.ToString() + " hh(s))");
            }
        }

        public VerifForm(B1F b1f)
        {
            //if (b1f.profile.iom_dtm_phase.closed_YesNo==1)
            //{
            //    throw new MyException("DTM phase is closed, cannot add/edit forms!");
            //}

            int phase = b1f.profile.iom_dtm_phase.closed_YesNo;
            if (phase == 1)
            {
                throw new MyException("DTM 'Phase " + phase + "' is closed, cannot add/edit this F1B form!");
            }
            //var vv = form.GetType();

            // B1_2F b1f;

            //if (form.GetType() == typeof(B1F))
            //{
            //    B1_2F b1f = (B2F)form;
            if (b1f.profile.displaced_hh_ind_YesNo == 1 && (b1f.profile.number_hh == null || b1f.profile.number_ind == null))
            {
                throw new MyException("If there are displaced people, you need to indicate the # of households and # of individuals!");
            }
            else if (b1f.profile.displaced_hh_ind_YesNo == 2 && (b1f.profile.number_hh != null || b1f.profile.number_ind != null))
            {
                throw new MyException("If there are no displaced people, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b1f.profile.nr_YesNo == 2 &&
                (!string.IsNullOrEmpty(b1f.profile.nr_location) || b1f.profile.nr_period != null ||
                !string.IsNullOrEmpty(b1f.profile.nr_state1) || !string.IsNullOrEmpty(b1f.profile.nr_state2)))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If IDPs have not returned, leave the corresponding fields empty!");
            }
            else if (b1f.profile.nr_YesNo == 1 &&
                (string.IsNullOrEmpty(b1f.profile.nr_location) && b1f.profile.nr_period == null &&
                string.IsNullOrEmpty(b1f.profile.nr_state1) && string.IsNullOrEmpty(b1f.profile.nr_state2))
                )
            {
                throw new MyException("If IDPs have returned, fill up the corresponding fields!");

            }


            if (b1f.profile.reason_insurgency_YesNo == 1 &&
                (b1f.profile.reason_insurg_hh == null || b1f.profile.reason_insurg_ind == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Insurgency is the reason of displacement, you need to indicate # of households and # of individuals!");
            }
            else if (b1f.profile.reason_insurgency_YesNo == 2 &&
                (b1f.profile.reason_insurg_hh != null || b1f.profile.reason_insurg_ind != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Insurgency is not the reason of displacement, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b1f.profile.reason_clash_YesNo == 1 &&
                (b1f.profile.reason_clash_hh == null || b1f.profile.reason_clash_ind == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Community clashes is the reason of displacement, you need to indicate # of households and # of individuals!");
            }
            else if (b1f.profile.reason_clash_YesNo == 2 &&
                (b1f.profile.reason_clash_hh != null || b1f.profile.reason_clash_ind != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Community clashes is not the reason of displacement, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b1f.profile.reason_disaster_YesNo == 1 &&
                (b1f.profile.reason_disaster_hh == null || b1f.profile.reason_disaster_ind == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Natural disasters is the reason of displacement, you need to indicate # of households and # of individuals!");
            }
            else if (b1f.profile.reason_disaster_YesNo == 2 &&
                (b1f.profile.reason_disaster_hh != null || b1f.profile.reason_disaster_ind != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Natural disasters is not the reason of displacement, you need to keep the fields # of households and # of individuals empty!");
            }


            if (b1f.profile.reason_others_YesNo == 1 &&
                (b1f.profile.reason_others_hh == null || b1f.profile.reason_others_hh == null || string.IsNullOrEmpty(b1f.profile.reason_others_name)))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Other is selected for the reason of displacement, you need to specify the reason, then indicate the # of households and # of individuals!");
            }
            else if (b1f.profile.reason_others_YesNo == 2 &&
                (b1f.profile.reason_others_hh != null || b1f.profile.reason_others_hh != null || !string.IsNullOrEmpty(b1f.profile.reason_others_name)))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("Other/reason is not selected for the reason of displacement, you need to keep the fields other/specify, # of households and # of individuals empty!");
            }


            if (b1f.profile.temporary_settlement_type_camp_YesNo == 1 &&
                (b1f.profile.temporary_settlement_hh_camp == null || b1f.profile.temporary_settlement_ind_camp == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Camp is selected, you need to indicate the # of households and # of individuals!");
            }
            else if (b1f.profile.temporary_settlement_type_camp_YesNo == 2 &&
                (b1f.profile.temporary_settlement_hh_camp != null || b1f.profile.temporary_settlement_ind_camp != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Camp is not selected, you need to keep the fields # of households and # of individuals empty!");
            }

            if (b1f.profile.temporary_settlement_type_hc_YesNo == 1 &&
                (b1f.profile.temporary_settlement_hh_hc == null || b1f.profile.temporary_settlement_ind_hc == null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Host family is selected, you need to indicate the # of households and # of individuals!");
            }
            else if (b1f.profile.temporary_settlement_type_hc_YesNo == 2 &&
                (b1f.profile.temporary_settlement_hh_hc != null || b1f.profile.temporary_settlement_ind_hc != null))
            {
                //return "If IDPs have not returned, don't fill corresponding fields!";
                throw new MyException("If Temporary settlement/Host family is not selected, you need to keep the fields # of households and # of individuals empty!");
            }


            int hhs = 0, inds = 0;


            foreach (iom_idp_arrival arrival in b1f.arrivals)
            {

                if ((arrival.hh != null && arrival.ind == null) || (arrival.hh == null && arrival.ind != null))
                {
                    throw new MyException("Please make sure the fields # of household and # of individuals are filled or keep them both empty in section B. for the selected year of arrival.");
                }
                else if ((!string.IsNullOrEmpty(arrival.state_type)
                    || !string.IsNullOrEmpty(arrival.location)) && arrival.hh == null && arrival.ind == null)
                {
                    throw new MyException("Please make sure whether state type and state name are kept empty if no year of arrival is selected in section B.");
                }
                else if (!string.IsNullOrEmpty(arrival.state_type) && arrival.state_type.Equals("1") && b1f.inSameState(arrival.location) == null)
                {
                    throw new MyException("If you select [1-Same state], make sure you keep the location field empty or select the correct state in section B.");
                }
                else if (!string.IsNullOrEmpty(arrival.state_type) && arrival.state_type.Equals("2") && b1f.inSameState(arrival.location) != null)
                {
                    throw new MyException("If you select [2-Other state], make sure you keep the location field empty or select the correct state in section B.");
                }


                hhs = hhs + (arrival.hh ?? 0);
                inds = inds + (arrival.ind ?? 0);

            }

            if (b1f.profile.displaced_hh_ind_YesNo == 1 && (hhs != (b1f.profile.number_hh ?? 0) || inds != (b1f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please make sure the totals are correct for both # of household and # of individuals in section B. for the selected years of arrival. (" + b1f.profile.number_hh.ToString() + " hh(s)/" + b1f.profile.number_ind.ToString() + " ind(s))");
            }

            int hhs_ = (b1f.profile.reason_clash_hh ?? 0) + (b1f.profile.reason_disaster_hh ?? 0) + (b1f.profile.reason_insurg_hh ?? 0) +
                (b1f.profile.reason_others_hh ?? 0);

            int inds_ = (b1f.profile.reason_clash_ind ?? 0) + (b1f.profile.reason_disaster_ind ?? 0) + (b1f.profile.reason_insurg_ind ?? 0) +
                (b1f.profile.reason_others_ind ?? 0);

            if (b1f.profile.displaced_hh_ind_YesNo == 1 && (hhs_ != (b1f.profile.number_hh ?? 0) || inds_ != (b1f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please make sure the totals are correct for both # of household and # of individuals in section D. for the selected reasons for displacement. (" + b1f.profile.number_hh.ToString() + " hh(s)/" + b1f.profile.number_ind.ToString() + " ind(s))");
            }

            hhs_ = 0; inds_ = 0;

            hhs_ = (b1f.profile.temporary_settlement_hh_camp ?? 0) + (b1f.profile.temporary_settlement_hh_hc ?? 0);
            inds_ = (b1f.profile.temporary_settlement_ind_camp ?? 0) + (b1f.profile.temporary_settlement_ind_hc ?? 0);

            if (b1f.profile.displaced_hh_ind_YesNo == 1 && (hhs_ != (b1f.profile.number_hh ?? 0) || inds_ != (b1f.profile.number_ind ?? 0)))
            {
                throw new MyException("Please make sure the totals are correct for both # of household and # of individuals in section E. in camps like site and host family. (" + b1f.profile.number_hh.ToString() + " hh(s)/" + b1f.profile.number_ind.ToString() + " ind(s))");
            }
            //}

        }

    }
}