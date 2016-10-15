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

namespace DTM_Nigeria.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(lkp_Ethnicity))]
    [KnownType(typeof(lkp_Religion))]
    [KnownType(typeof(lkp_Ward))]
    [KnownType(typeof(iom_group_assessment_1))]
    public partial class iom_ga_idp_population
    {
        #region Primitive Properties

        //public string state { get; set; }

        public bool notEmpty { get; set; }

        [DataMember]
        public virtual int id
        {
            get;
            set;
        }
        [DataMember]
        public virtual int ga_id
        {
            get { return _ga_id; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_ga_id != value)
                    {
                        if (iom_group_assessment_1 != null && iom_group_assessment_1.id != value)
                        {
                            iom_group_assessment_1 = null;
                        }
                        _ga_id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _ga_id;
        [DataMember]
        public virtual string ward_orig
        {
            get { return _ward_orig; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_ward_orig != value)
                    {
                        if (lkp_Ward != null && lkp_Ward.ward_code != value)
                        {
                            lkp_Ward = null;
                        }
                        _ward_orig = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _ward_orig;
        [DataMember]
        public virtual Nullable<int> hh
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> ind
        {
            get;
            set;
        }
        [DataMember]
        public virtual Nullable<int> ethnicity
        {
            get { return _ethnicity; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_ethnicity != value)
                    {
                        if (lkp_Ethnicity != null && lkp_Ethnicity.id != value)
                        {
                            lkp_Ethnicity = null;
                        }
                        _ethnicity = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _ethnicity;
        [DataMember]
        public virtual Nullable<int> religion
        {
            get { return _religion; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_religion != value)
                    {
                        if (lkp_Religion != null && lkp_Religion.id != value)
                        {
                            lkp_Religion = null;
                        }
                        _religion = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _religion;
        [DataMember]
        public virtual string religion_other
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
        public virtual string created_by
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
        public virtual string updated_by
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual lkp_Ethnicity lkp_Ethnicity
        {
            get { return _lkp_Ethnicity; }
            set
            {
                if (!ReferenceEquals(_lkp_Ethnicity, value))
                {
                    var previousValue = _lkp_Ethnicity;
                    _lkp_Ethnicity = value;
                    Fixuplkp_Ethnicity(previousValue);
                }
            }
        }
        private lkp_Ethnicity _lkp_Ethnicity;
        
    
        [DataMember]
        public virtual lkp_Religion lkp_Religion
        {
            get { return _lkp_Religion; }
            set
            {
                if (!ReferenceEquals(_lkp_Religion, value))
                {
                    var previousValue = _lkp_Religion;
                    _lkp_Religion = value;
                    Fixuplkp_Religion(previousValue);
                }
            }
        }
        private lkp_Religion _lkp_Religion;
        
    
        [DataMember]
        public virtual lkp_Ward lkp_Ward
        {
            get { return _lkp_Ward; }
            set
            {
                if (!ReferenceEquals(_lkp_Ward, value))
                {
                    var previousValue = _lkp_Ward;
                    _lkp_Ward = value;
                    Fixuplkp_Ward(previousValue);
                }
            }
        }
        private lkp_Ward _lkp_Ward;
        
    
        [DataMember]
        public virtual iom_group_assessment_1 iom_group_assessment_1
        {
            get { return _iom_group_assessment_1; }
            set
            {
                if (!ReferenceEquals(_iom_group_assessment_1, value))
                {
                    var previousValue = _iom_group_assessment_1;
                    _iom_group_assessment_1 = value;
                    Fixupiom_group_assessment_1(previousValue);
                }
            }
        }
        private iom_group_assessment_1 _iom_group_assessment_1;

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixuplkp_Ethnicity(lkp_Ethnicity previousValue)
        {
            if (previousValue != null && previousValue.iom_ga_idp_population.Contains(this))
            {
                previousValue.iom_ga_idp_population.Remove(this);
            }
    
            if (lkp_Ethnicity != null)
            {
                if (!lkp_Ethnicity.iom_ga_idp_population.Contains(this))
                {
                    lkp_Ethnicity.iom_ga_idp_population.Add(this);
                }
                if (ethnicity != lkp_Ethnicity.id)
                {
                    ethnicity = lkp_Ethnicity.id;
                }
            }
            else if (!_settingFK)
            {
                ethnicity = null;
            }
        }
    
        private void Fixuplkp_Religion(lkp_Religion previousValue)
        {
            if (previousValue != null && previousValue.iom_ga_idp_population.Contains(this))
            {
                previousValue.iom_ga_idp_population.Remove(this);
            }
    
            if (lkp_Religion != null)
            {
                if (!lkp_Religion.iom_ga_idp_population.Contains(this))
                {
                    lkp_Religion.iom_ga_idp_population.Add(this);
                }
                if (religion != lkp_Religion.id)
                {
                    religion = lkp_Religion.id;
                }
            }
            else if (!_settingFK)
            {
                religion = null;
            }
        }
    
        private void Fixuplkp_Ward(lkp_Ward previousValue)
        {
            if (previousValue != null && previousValue.iom_ga_idp_population.Contains(this))
            {
                previousValue.iom_ga_idp_population.Remove(this);
            }
    
            if (lkp_Ward != null)
            {
                if (!lkp_Ward.iom_ga_idp_population.Contains(this))
                {
                    lkp_Ward.iom_ga_idp_population.Add(this);
                }
                if (ward_orig != lkp_Ward.ward_code)
                {
                    ward_orig = lkp_Ward.ward_code;
                }
            }
            else if (!_settingFK)
            {
                ward_orig = null;
            }
        }
    
        private void Fixupiom_group_assessment_1(iom_group_assessment_1 previousValue)
        {
            if (previousValue != null && previousValue.iom_ga_idp_population.Contains(this))
            {
                previousValue.iom_ga_idp_population.Remove(this);
            }
    
            if (iom_group_assessment_1 != null)
            {
                if (!iom_group_assessment_1.iom_ga_idp_population.Contains(this))
                {
                    iom_group_assessment_1.iom_ga_idp_population.Add(this);
                }
                if (ga_id != iom_group_assessment_1.id)
                {
                    ga_id = iom_group_assessment_1.id;
                }
            }
        }

        #endregion

    }
}
