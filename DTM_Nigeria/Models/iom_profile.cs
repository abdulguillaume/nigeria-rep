//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;
using DTM_Nigeria.Validation;

namespace DTM_Nigeria.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(iom_b1f_informants))]
    [KnownType(typeof(iom_b1f_organizations_assisting))]
    [KnownType(typeof(iom_dtm_phase))]
    [KnownType(typeof(iom_idp_arrival))]
    [KnownType(typeof(iom_presence_wards))]
    [KnownType(typeof(iom_researchers))]
    [KnownType(typeof(lkp_Lga))]
    [KnownType(typeof(lkp_NotReturnLocation))]
    [KnownType(typeof(lkp_Period2))]
    [KnownType(typeof(lkp_Settlement))]
    [KnownType(typeof(lkp_State))]
    public partial class iom_profile
    {
        #region Primitive Properties
        [DataMember]
        public virtual int id
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int phase
        {
            get { return _phase; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_phase != value)
                    {
                        if (iom_dtm_phase != null && iom_dtm_phase.phase != value)
                        {
                            iom_dtm_phase = null;
                        }
                        _phase = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _phase;
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual string date
        {
            get;
            set;
        }
        [DataMember]
        public virtual int researcher_id
        {
            get { return _researcher_id; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_researcher_id != value)
                    {
                        if (iom_researchers != null && iom_researchers.id != value)
                        {
                            iom_researchers = null;
                        }
                        _researcher_id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _researcher_id;

        [Required(ErrorMessage="*")]
        public string state { get; set; }

        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual string lga
        {
            get { return _lga; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_lga != value)
                    {
                        if (lkp_Lga != null && lkp_Lga.lga_code != value)
                        {
                            lkp_Lga = null;
                        }
                        _lga = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _lga;
        [DataMember]
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public virtual string settlement
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual string settlement_type
        {
            get { return _settlement_type; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_settlement_type != value)
                    {
                        if (lkp_Settlement != null && lkp_Settlement.id != value)
                        {
                            lkp_Settlement = null;
                        }
                        _settlement_type = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _settlement_type;
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int displaced_hh_ind_YesNo
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> number_hh
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> number_ind
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int nr_YesNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual string nr_location
        {
            get { return _nr_location; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_nr_location != value)
                    {
                        if (lkp_NotReturnLocation != null && lkp_NotReturnLocation.id != value)
                        {
                            lkp_NotReturnLocation = null;
                        }
                        _nr_location = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _nr_location;
        [DataMember]
        public virtual string nr_state1
        {
            get { return _nr_state1; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_nr_state1 != value)
                    {
                        if (lkp_State != null && lkp_State.state_code != value)
                        {
                            lkp_State = null;
                        }
                        _nr_state1 = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _nr_state1;
        [DataMember]
        public virtual string nr_state2
        {
            get { return _nr_state2; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_nr_state2 != value)
                    {
                        if (lkp_State1 != null && lkp_State1.state_code != value)
                        {
                            lkp_State1 = null;
                        }
                        _nr_state2 = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _nr_state2;
        [DataMember]
        public virtual Nullable<int> nr_period
        {
            get { return _nr_period; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_nr_period != value)
                    {
                        if (lkp_Period2 != null && lkp_Period2.id != value)
                        {
                            lkp_Period2 = null;
                        }
                        _nr_period = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _nr_period;
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int reason_insurgency_YesNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> reason_insurg_year
        {
            get { return _reason_insurg_year; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_reason_insurg_year != value)
                    {
                        if (lkp_Period21 != null && lkp_Period21.id != value)
                        {
                            lkp_Period21 = null;
                        }
                        _reason_insurg_year = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _reason_insurg_year;
        [DataMember]
        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_insurg_hh
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("reason_insurgency_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_insurg_ind
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int reason_clash_YesNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> reason_clash_year
        {
            get { return _reason_clash_year; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_reason_clash_year != value)
                    {
                        if (lkp_Period22 != null && lkp_Period22.id != value)
                        {
                            lkp_Period22 = null;
                        }
                        _reason_clash_year = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _reason_clash_year;
        [DataMember]
        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_clash_hh
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("reason_clash_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_clash_ind
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int reason_disaster_YesNo
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> reason_disaster_year
        {
            get { return _reason_disaster_year; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_reason_disaster_year != value)
                    {
                        if (lkp_Period23 != null && lkp_Period23.id != value)
                        {
                            lkp_Period23 = null;
                        }
                        _reason_disaster_year = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _reason_disaster_year;
        [DataMember]
        [RequiredIf("reason_disaster_YesNo", 1, "*")]
        public virtual Nullable<int> reason_disaster_hh
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("reason_disaster_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_disaster_ind
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int reason_others_YesNo
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("reason_others_YesNo", 1, "*")]
        public virtual string reason_others_name
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> reason_others_year
        {
            get { return _reason_others_year; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_reason_others_year != value)
                    {
                        if (lkp_Period24 != null && lkp_Period24.id != value)
                        {
                            lkp_Period24 = null;
                        }
                        _reason_others_year = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _reason_others_year;
        [DataMember]
        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_others_hh
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("reason_others_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> reason_others_ind
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int temporary_settlement_type_camp_YesNo
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> temporary_settlement_hh_camp
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("temporary_settlement_type_camp_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> temporary_settlement_ind_camp
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual int temporary_settlement_type_hc_YesNo
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("temporary_settlement_type_hc_YesNo",1,"*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> temporary_settlement_hh_hc
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("temporary_settlement_type_hc_YesNo", 1, "*")]
        [RegularExpression("^[1-9]+[0-9]*", ErrorMessage = "number>0")]
        public virtual Nullable<int> temporary_settlement_ind_hc
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> create_time
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<System.DateTime> update_time
        {
            get;
            set;
        }
        [DataMember]
        public virtual string created_by
        {
            get;
            set;
        }
        [DataMember]
        public virtual string updated_by
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
        
    
        [DataMember]
        public virtual ICollection<iom_b1f_informants> iom_b1f_informants
        {
            get
            {
                if (_iom_b1f_informants == null)
                {
                    var newCollection = new FixupCollection<iom_b1f_informants>();
                    newCollection.CollectionChanged += Fixupiom_b1f_informants;
                    _iom_b1f_informants = newCollection;
                }
                return _iom_b1f_informants;
            }
            set
            {
                if (!ReferenceEquals(_iom_b1f_informants, value))
                {
                    var previousValue = _iom_b1f_informants as FixupCollection<iom_b1f_informants>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_b1f_informants;
                    }
                    _iom_b1f_informants = value;
                    var newValue = value as FixupCollection<iom_b1f_informants>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_b1f_informants;
                    }
                }
            }
        }
        private ICollection<iom_b1f_informants> _iom_b1f_informants;
        
    
        [DataMember]
        public virtual ICollection<iom_b1f_organizations_assisting> iom_b1f_organizations_assisting
        {
            get
            {
                if (_iom_b1f_organizations_assisting == null)
                {
                    var newCollection = new FixupCollection<iom_b1f_organizations_assisting>();
                    newCollection.CollectionChanged += Fixupiom_b1f_organizations_assisting;
                    _iom_b1f_organizations_assisting = newCollection;
                }
                return _iom_b1f_organizations_assisting;
            }
            set
            {
                if (!ReferenceEquals(_iom_b1f_organizations_assisting, value))
                {
                    var previousValue = _iom_b1f_organizations_assisting as FixupCollection<iom_b1f_organizations_assisting>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_b1f_organizations_assisting;
                    }
                    _iom_b1f_organizations_assisting = value;
                    var newValue = value as FixupCollection<iom_b1f_organizations_assisting>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_b1f_organizations_assisting;
                    }
                }
            }
        }
        private ICollection<iom_b1f_organizations_assisting> _iom_b1f_organizations_assisting;
        
    
        [DataMember]
        public virtual iom_dtm_phase iom_dtm_phase
        {
            get { return _iom_dtm_phase; }
            set
            {
                if (!ReferenceEquals(_iom_dtm_phase, value))
                {
                    var previousValue = _iom_dtm_phase;
                    _iom_dtm_phase = value;
                    Fixupiom_dtm_phase(previousValue);
                }
            }
        }
        private iom_dtm_phase _iom_dtm_phase;
        
    
        [DataMember]
        public virtual ICollection<iom_idp_arrival> iom_idp_arrival
        {
            get
            {
                if (_iom_idp_arrival == null)
                {
                    var newCollection = new FixupCollection<iom_idp_arrival>();
                    newCollection.CollectionChanged += Fixupiom_idp_arrival;
                    _iom_idp_arrival = newCollection;
                }
                return _iom_idp_arrival;
            }
            set
            {
                if (!ReferenceEquals(_iom_idp_arrival, value))
                {
                    var previousValue = _iom_idp_arrival as FixupCollection<iom_idp_arrival>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_idp_arrival;
                    }
                    _iom_idp_arrival = value;
                    var newValue = value as FixupCollection<iom_idp_arrival>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_idp_arrival;
                    }
                }
            }
        }
        private ICollection<iom_idp_arrival> _iom_idp_arrival;
        
    
        [DataMember]
        public virtual ICollection<iom_presence_wards> iom_presence_wards
        {
            get
            {
                if (_iom_presence_wards == null)
                {
                    var newCollection = new FixupCollection<iom_presence_wards>();
                    newCollection.CollectionChanged += Fixupiom_presence_wards;
                    _iom_presence_wards = newCollection;
                }
                return _iom_presence_wards;
            }
            set
            {
                if (!ReferenceEquals(_iom_presence_wards, value))
                {
                    var previousValue = _iom_presence_wards as FixupCollection<iom_presence_wards>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_presence_wards;
                    }
                    _iom_presence_wards = value;
                    var newValue = value as FixupCollection<iom_presence_wards>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_presence_wards;
                    }
                }
            }
        }
        private ICollection<iom_presence_wards> _iom_presence_wards;
        
    
        [DataMember]
        public virtual iom_researchers iom_researchers
        {
            get { return _iom_researchers; }
            set
            {
                if (!ReferenceEquals(_iom_researchers, value))
                {
                    var previousValue = _iom_researchers;
                    _iom_researchers = value;
                    Fixupiom_researchers(previousValue);
                }
            }
        }
        private iom_researchers _iom_researchers;
        
    
        [DataMember]
        public virtual lkp_Lga lkp_Lga
        {
            get { return _lkp_Lga; }
            set
            {
                if (!ReferenceEquals(_lkp_Lga, value))
                {
                    var previousValue = _lkp_Lga;
                    _lkp_Lga = value;
                    Fixuplkp_Lga(previousValue);
                }
            }
        }
        private lkp_Lga _lkp_Lga;
        
    
        [DataMember]
        public virtual lkp_NotReturnLocation lkp_NotReturnLocation
        {
            get { return _lkp_NotReturnLocation; }
            set
            {
                if (!ReferenceEquals(_lkp_NotReturnLocation, value))
                {
                    var previousValue = _lkp_NotReturnLocation;
                    _lkp_NotReturnLocation = value;
                    Fixuplkp_NotReturnLocation(previousValue);
                }
            }
        }
        private lkp_NotReturnLocation _lkp_NotReturnLocation;
        
    
        [DataMember]
        public virtual lkp_Period2 lkp_Period2
        {
            get { return _lkp_Period2; }
            set
            {
                if (!ReferenceEquals(_lkp_Period2, value))
                {
                    var previousValue = _lkp_Period2;
                    _lkp_Period2 = value;
                    Fixuplkp_Period2(previousValue);
                }
            }
        }
        private lkp_Period2 _lkp_Period2;
        
    
        [DataMember]
        public virtual lkp_Period2 lkp_Period21
        {
            get { return _lkp_Period21; }
            set
            {
                if (!ReferenceEquals(_lkp_Period21, value))
                {
                    var previousValue = _lkp_Period21;
                    _lkp_Period21 = value;
                    Fixuplkp_Period21(previousValue);
                }
            }
        }
        private lkp_Period2 _lkp_Period21;
        
    
        [DataMember]
        public virtual lkp_Period2 lkp_Period22
        {
            get { return _lkp_Period22; }
            set
            {
                if (!ReferenceEquals(_lkp_Period22, value))
                {
                    var previousValue = _lkp_Period22;
                    _lkp_Period22 = value;
                    Fixuplkp_Period22(previousValue);
                }
            }
        }
        private lkp_Period2 _lkp_Period22;
        
    
        [DataMember]
        public virtual lkp_Period2 lkp_Period23
        {
            get { return _lkp_Period23; }
            set
            {
                if (!ReferenceEquals(_lkp_Period23, value))
                {
                    var previousValue = _lkp_Period23;
                    _lkp_Period23 = value;
                    Fixuplkp_Period23(previousValue);
                }
            }
        }
        private lkp_Period2 _lkp_Period23;
        
    
        [DataMember]
        public virtual lkp_Period2 lkp_Period24
        {
            get { return _lkp_Period24; }
            set
            {
                if (!ReferenceEquals(_lkp_Period24, value))
                {
                    var previousValue = _lkp_Period24;
                    _lkp_Period24 = value;
                    Fixuplkp_Period24(previousValue);
                }
            }
        }
        private lkp_Period2 _lkp_Period24;
        
    
        [DataMember]
        public virtual lkp_Settlement lkp_Settlement
        {
            get { return _lkp_Settlement; }
            set
            {
                if (!ReferenceEquals(_lkp_Settlement, value))
                {
                    var previousValue = _lkp_Settlement;
                    _lkp_Settlement = value;
                    Fixuplkp_Settlement(previousValue);
                }
            }
        }
        private lkp_Settlement _lkp_Settlement;
        
    
        [DataMember]
        public virtual lkp_State lkp_State
        {
            get { return _lkp_State; }
            set
            {
                if (!ReferenceEquals(_lkp_State, value))
                {
                    var previousValue = _lkp_State;
                    _lkp_State = value;
                    Fixuplkp_State(previousValue);
                }
            }
        }
        private lkp_State _lkp_State;
        
    
        [DataMember]
        public virtual lkp_State lkp_State1
        {
            get { return _lkp_State1; }
            set
            {
                if (!ReferenceEquals(_lkp_State1, value))
                {
                    var previousValue = _lkp_State1;
                    _lkp_State1 = value;
                    Fixuplkp_State1(previousValue);
                }
            }
        }
        private lkp_State _lkp_State1;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixupiom_dtm_phase(iom_dtm_phase previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (iom_dtm_phase != null)
            {
                if (!iom_dtm_phase.iom_profile.Contains(this))
                {
                    iom_dtm_phase.iom_profile.Add(this);
                }
                if (phase != iom_dtm_phase.phase)
                {
                    phase = iom_dtm_phase.phase;
                }
            }
        }
    
        private void Fixupiom_researchers(iom_researchers previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (iom_researchers != null)
            {
                if (!iom_researchers.iom_profile.Contains(this))
                {
                    iom_researchers.iom_profile.Add(this);
                }
                if (researcher_id != iom_researchers.id)
                {
                    researcher_id = iom_researchers.id;
                }
            }
        }
    
        private void Fixuplkp_Lga(lkp_Lga previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (lkp_Lga != null)
            {
                if (!lkp_Lga.iom_profile.Contains(this))
                {
                    lkp_Lga.iom_profile.Add(this);
                }
                if (lga != lkp_Lga.lga_code)
                {
                    lga = lkp_Lga.lga_code;
                }
            }
        }
    
        private void Fixuplkp_NotReturnLocation(lkp_NotReturnLocation previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (lkp_NotReturnLocation != null)
            {
                if (!lkp_NotReturnLocation.iom_profile.Contains(this))
                {
                    lkp_NotReturnLocation.iom_profile.Add(this);
                }
                if (nr_location != lkp_NotReturnLocation.id)
                {
                    nr_location = lkp_NotReturnLocation.id;
                }
            }
            else if (!_settingFK)
            {
                nr_location = null;
            }
        }
    
        private void Fixuplkp_Period2(lkp_Period2 previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (lkp_Period2 != null)
            {
                if (!lkp_Period2.iom_profile.Contains(this))
                {
                    lkp_Period2.iom_profile.Add(this);
                }
                if (nr_period != lkp_Period2.id)
                {
                    nr_period = lkp_Period2.id;
                }
            }
            else if (!_settingFK)
            {
                nr_period = null;
            }
        }
    
        private void Fixuplkp_Period21(lkp_Period2 previousValue)
        {
            if (previousValue != null && previousValue.iom_profile1.Contains(this))
            {
                previousValue.iom_profile1.Remove(this);
            }
    
            if (lkp_Period21 != null)
            {
                if (!lkp_Period21.iom_profile1.Contains(this))
                {
                    lkp_Period21.iom_profile1.Add(this);
                }
                if (reason_insurg_year != lkp_Period21.id)
                {
                    reason_insurg_year = lkp_Period21.id;
                }
            }
            else if (!_settingFK)
            {
                reason_insurg_year = null;
            }
        }
    
        private void Fixuplkp_Period22(lkp_Period2 previousValue)
        {
            if (previousValue != null && previousValue.iom_profile2.Contains(this))
            {
                previousValue.iom_profile2.Remove(this);
            }
    
            if (lkp_Period22 != null)
            {
                if (!lkp_Period22.iom_profile2.Contains(this))
                {
                    lkp_Period22.iom_profile2.Add(this);
                }
                if (reason_clash_year != lkp_Period22.id)
                {
                    reason_clash_year = lkp_Period22.id;
                }
            }
            else if (!_settingFK)
            {
                reason_clash_year = null;
            }
        }
    
        private void Fixuplkp_Period23(lkp_Period2 previousValue)
        {
            if (previousValue != null && previousValue.iom_profile3.Contains(this))
            {
                previousValue.iom_profile3.Remove(this);
            }
    
            if (lkp_Period23 != null)
            {
                if (!lkp_Period23.iom_profile3.Contains(this))
                {
                    lkp_Period23.iom_profile3.Add(this);
                }
                if (reason_disaster_year != lkp_Period23.id)
                {
                    reason_disaster_year = lkp_Period23.id;
                }
            }
            else if (!_settingFK)
            {
                reason_disaster_year = null;
            }
        }
    
        private void Fixuplkp_Period24(lkp_Period2 previousValue)
        {
            if (previousValue != null && previousValue.iom_profile4.Contains(this))
            {
                previousValue.iom_profile4.Remove(this);
            }
    
            if (lkp_Period24 != null)
            {
                if (!lkp_Period24.iom_profile4.Contains(this))
                {
                    lkp_Period24.iom_profile4.Add(this);
                }
                if (reason_others_year != lkp_Period24.id)
                {
                    reason_others_year = lkp_Period24.id;
                }
            }
            else if (!_settingFK)
            {
                reason_others_year = null;
            }
        }
    
        private void Fixuplkp_Settlement(lkp_Settlement previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (lkp_Settlement != null)
            {
                if (!lkp_Settlement.iom_profile.Contains(this))
                {
                    lkp_Settlement.iom_profile.Add(this);
                }
                if (settlement_type != lkp_Settlement.id)
                {
                    settlement_type = lkp_Settlement.id;
                }
            }
        }
    
        private void Fixuplkp_State(lkp_State previousValue)
        {
            if (previousValue != null && previousValue.iom_profile.Contains(this))
            {
                previousValue.iom_profile.Remove(this);
            }
    
            if (lkp_State != null)
            {
                if (!lkp_State.iom_profile.Contains(this))
                {
                    lkp_State.iom_profile.Add(this);
                }
                if (nr_state1 != lkp_State.state_code)
                {
                    nr_state1 = lkp_State.state_code;
                }
            }
            else if (!_settingFK)
            {
                nr_state1 = null;
            }
        }
    
        private void Fixuplkp_State1(lkp_State previousValue)
        {
            if (previousValue != null && previousValue.iom_profile1.Contains(this))
            {
                previousValue.iom_profile1.Remove(this);
            }
    
            if (lkp_State1 != null)
            {
                if (!lkp_State1.iom_profile1.Contains(this))
                {
                    lkp_State1.iom_profile1.Add(this);
                }
                if (nr_state2 != lkp_State1.state_code)
                {
                    nr_state2 = lkp_State1.state_code;
                }
            }
            else if (!_settingFK)
            {
                nr_state2 = null;
            }
        }
    
        private void Fixupiom_b1f_informants(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_b1f_informants item in e.NewItems)
                {
                    item.iom_profile = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_b1f_informants item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_profile, this))
                    {
                        item.iom_profile = null;
                    }
                }
            }
        }
    
        private void Fixupiom_b1f_organizations_assisting(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_b1f_organizations_assisting item in e.NewItems)
                {
                    item.iom_profile = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_b1f_organizations_assisting item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_profile, this))
                    {
                        item.iom_profile = null;
                    }
                }
            }
        }
    
        private void Fixupiom_idp_arrival(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_idp_arrival item in e.NewItems)
                {
                    item.iom_profile = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_idp_arrival item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_profile, this))
                    {
                        item.iom_profile = null;
                    }
                }
            }
        }
    
        private void Fixupiom_presence_wards(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_presence_wards item in e.NewItems)
                {
                    item.iom_profile = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_presence_wards item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_profile, this))
                    {
                        item.iom_profile = null;
                    }
                }
            }
        }

        #endregion
    }
}