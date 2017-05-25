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

namespace DTM_Nigeria.Models
{
    public partial class iom_presence_wards
    {
        #region Primitive Properties
    
        public virtual int id
        {
            get;
            set;
        }
    
        public virtual int profile_id
        {
            get { return _profile_id; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_profile_id != value)
                    {
                        if (iom_profile != null && iom_profile.id != value)
                        {
                            iom_profile = null;
                        }
                        _profile_id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _profile_id;
    
        public virtual string ward_code
        {
            get { return _ward_code; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_ward_code != value)
                    {
                        if (lkp_Ward != null && lkp_Ward.ward_code != value)
                        {
                            lkp_Ward = null;
                        }
                        _ward_code = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _ward_code;
    
        public virtual string location_type
        {
            get { return _location_type; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_location_type != value)
                    {
                        if (lkp_TypeOfResidence != null && lkp_TypeOfResidence.id != value)
                        {
                            lkp_TypeOfResidence = null;
                        }
                        _location_type = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _location_type;
    
        public virtual int idp_category
        {
            get { return _idp_category; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_idp_category != value)
                    {
                        if (lkp_IDP_Category != null && lkp_IDP_Category.id != value)
                        {
                            lkp_IDP_Category = null;
                        }
                        _idp_category = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _idp_category;
    
        public virtual string location_name
        {
            get;
            set;
        }
    
        public virtual int estimate_hh
        {
            get;
            set;
        }
    
        public virtual int estimate_ind
        {
            get;
            set;
        }
    
        public virtual string majority_stateoforigin
        {
            get { return _majority_stateoforigin; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_majority_stateoforigin != value)
                    {
                        if (lkp_State != null && lkp_State.state_code != value)
                        {
                            lkp_State = null;
                        }
                        _majority_stateoforigin = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _majority_stateoforigin;
    
        public virtual string majority_lgaoforigin
        {
            get { return _majority_lgaoforigin; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_majority_lgaoforigin != value)
                    {
                        if (lkp_Lga != null && lkp_Lga.lga_code != value)
                        {
                            lkp_Lga = null;
                        }
                        _majority_lgaoforigin = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _majority_lgaoforigin;
    
        public virtual Nullable<double> coord_lon
        {
            get;
            set;
        }
    
        public virtual Nullable<double> coord_lat
        {
            get;
            set;
        }
    
        public virtual string created_by
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> create_time
        {
            get;
            set;
        }
    
        public virtual string updated_by
        {
            get;
            set;
        }
    
        public virtual Nullable<System.DateTime> update_time
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual iom_profile iom_profile
        {
            get { return _iom_profile; }
            set
            {
                if (!ReferenceEquals(_iom_profile, value))
                {
                    var previousValue = _iom_profile;
                    _iom_profile = value;
                    Fixupiom_profile(previousValue);
                }
            }
        }
        private iom_profile _iom_profile;
    
        public virtual lkp_IDP_Category lkp_IDP_Category
        {
            get { return _lkp_IDP_Category; }
            set
            {
                if (!ReferenceEquals(_lkp_IDP_Category, value))
                {
                    var previousValue = _lkp_IDP_Category;
                    _lkp_IDP_Category = value;
                    Fixuplkp_IDP_Category(previousValue);
                }
            }
        }
        private lkp_IDP_Category _lkp_IDP_Category;
    
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
    
        public virtual lkp_TypeOfResidence lkp_TypeOfResidence
        {
            get { return _lkp_TypeOfResidence; }
            set
            {
                if (!ReferenceEquals(_lkp_TypeOfResidence, value))
                {
                    var previousValue = _lkp_TypeOfResidence;
                    _lkp_TypeOfResidence = value;
                    Fixuplkp_TypeOfResidence(previousValue);
                }
            }
        }
        private lkp_TypeOfResidence _lkp_TypeOfResidence;
    
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
    
        public virtual iom_ward_profile iom_ward_profile
        {
            get { return _iom_ward_profile; }
            set
            {
                if (!ReferenceEquals(_iom_ward_profile, value))
                {
                    var previousValue = _iom_ward_profile;
                    _iom_ward_profile = value;
                    Fixupiom_ward_profile(previousValue);
                }
            }
        }
        private iom_ward_profile _iom_ward_profile;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixupiom_profile(iom_profile previousValue)
        {
            if (previousValue != null && previousValue.iom_presence_wards.Contains(this))
            {
                previousValue.iom_presence_wards.Remove(this);
            }
    
            if (iom_profile != null)
            {
                if (!iom_profile.iom_presence_wards.Contains(this))
                {
                    iom_profile.iom_presence_wards.Add(this);
                }
                if (profile_id != iom_profile.id)
                {
                    profile_id = iom_profile.id;
                }
            }
        }
    
        private void Fixuplkp_IDP_Category(lkp_IDP_Category previousValue)
        {
            if (previousValue != null && previousValue.iom_presence_wards.Contains(this))
            {
                previousValue.iom_presence_wards.Remove(this);
            }
    
            if (lkp_IDP_Category != null)
            {
                if (!lkp_IDP_Category.iom_presence_wards.Contains(this))
                {
                    lkp_IDP_Category.iom_presence_wards.Add(this);
                }
                if (idp_category != lkp_IDP_Category.id)
                {
                    idp_category = lkp_IDP_Category.id;
                }
            }
        }
    
        private void Fixuplkp_Lga(lkp_Lga previousValue)
        {
            if (previousValue != null && previousValue.iom_presence_wards.Contains(this))
            {
                previousValue.iom_presence_wards.Remove(this);
            }
    
            if (lkp_Lga != null)
            {
                if (!lkp_Lga.iom_presence_wards.Contains(this))
                {
                    lkp_Lga.iom_presence_wards.Add(this);
                }
                if (majority_lgaoforigin != lkp_Lga.lga_code)
                {
                    majority_lgaoforigin = lkp_Lga.lga_code;
                }
            }
            else if (!_settingFK)
            {
                majority_lgaoforigin = null;
            }
        }
    
        private void Fixuplkp_State(lkp_State previousValue)
        {
            if (previousValue != null && previousValue.iom_presence_wards.Contains(this))
            {
                previousValue.iom_presence_wards.Remove(this);
            }
    
            if (lkp_State != null)
            {
                if (!lkp_State.iom_presence_wards.Contains(this))
                {
                    lkp_State.iom_presence_wards.Add(this);
                }
                if (majority_stateoforigin != lkp_State.state_code)
                {
                    majority_stateoforigin = lkp_State.state_code;
                }
            }
            else if (!_settingFK)
            {
                majority_stateoforigin = null;
            }
        }
    
        private void Fixuplkp_TypeOfResidence(lkp_TypeOfResidence previousValue)
        {
            if (previousValue != null && previousValue.iom_presence_wards.Contains(this))
            {
                previousValue.iom_presence_wards.Remove(this);
            }
    
            if (lkp_TypeOfResidence != null)
            {
                if (!lkp_TypeOfResidence.iom_presence_wards.Contains(this))
                {
                    lkp_TypeOfResidence.iom_presence_wards.Add(this);
                }
                if (location_type != lkp_TypeOfResidence.id)
                {
                    location_type = lkp_TypeOfResidence.id;
                }
            }
        }
    
        private void Fixuplkp_Ward(lkp_Ward previousValue)
        {
            if (previousValue != null && previousValue.iom_presence_wards.Contains(this))
            {
                previousValue.iom_presence_wards.Remove(this);
            }
    
            if (lkp_Ward != null)
            {
                if (!lkp_Ward.iom_presence_wards.Contains(this))
                {
                    lkp_Ward.iom_presence_wards.Add(this);
                }
                if (ward_code != lkp_Ward.ward_code)
                {
                    ward_code = lkp_Ward.ward_code;
                }
            }
        }
    
        private void Fixupiom_ward_profile(iom_ward_profile previousValue)
        {
            if (previousValue != null && ReferenceEquals(previousValue.iom_presence_wards, this))
            {
                previousValue.iom_presence_wards = null;
            }
    
            if (iom_ward_profile != null)
            {
                iom_ward_profile.iom_presence_wards = this;
            }
        }

        #endregion
    }
}
