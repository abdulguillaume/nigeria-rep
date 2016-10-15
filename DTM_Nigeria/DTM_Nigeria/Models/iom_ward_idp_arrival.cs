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
    [KnownType(typeof(iom_ward_profile))]
    [KnownType(typeof(lkp_Location))]
    [KnownType(typeof(lkp_Period2))]
    [KnownType(typeof(lkp_State))]
    public partial class iom_ward_idp_arrival
    {
        #region Primitive Properties
        [DataMember]
        public virtual int id
        {
            get;
            set;
        }
        [DataMember]
        public virtual int ward_profile_id
        {
            get { return _ward_profile_id; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_ward_profile_id != value)
                    {
                        if (iom_ward_profile != null && iom_ward_profile.id != value)
                        {
                            iom_ward_profile = null;
                        }
                        _ward_profile_id = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _ward_profile_id;
        [DataMember]
        public virtual int year
        {
            get { return _year; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_year != value)
                    {
                        if (lkp_Period2 != null && lkp_Period2.id != value)
                        {
                            lkp_Period2 = null;
                        }
                        _year = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private int _year;
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
        public virtual string state_type
        {
            get { return _state_type; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_state_type != value)
                    {
                        if (lkp_Location != null && lkp_Location.id != value)
                        {
                            lkp_Location = null;
                        }
                        _state_type = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _state_type;
        [DataMember]
        public virtual string location
        {
            get { return _location; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_location != value)
                    {
                        if (lkp_State != null && lkp_State.state_code != value)
                        {
                            lkp_State = null;
                        }
                        _location = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _location;
        [DataMember]
        public virtual string created_by
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
        public virtual string updated_by
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

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
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
        
    
        [DataMember]
        public virtual lkp_Location lkp_Location
        {
            get { return _lkp_Location; }
            set
            {
                if (!ReferenceEquals(_lkp_Location, value))
                {
                    var previousValue = _lkp_Location;
                    _lkp_Location = value;
                    Fixuplkp_Location(previousValue);
                }
            }
        }
        private lkp_Location _lkp_Location;
        
    
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

        #endregion

        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixupiom_ward_profile(iom_ward_profile previousValue)
        {
            if (previousValue != null && previousValue.iom_ward_idp_arrival.Contains(this))
            {
                previousValue.iom_ward_idp_arrival.Remove(this);
            }
    
            if (iom_ward_profile != null)
            {
                if (!iom_ward_profile.iom_ward_idp_arrival.Contains(this))
                {
                    iom_ward_profile.iom_ward_idp_arrival.Add(this);
                }
                if (ward_profile_id != iom_ward_profile.id)
                {
                    ward_profile_id = iom_ward_profile.id;
                }
            }
        }
    
        private void Fixuplkp_Location(lkp_Location previousValue)
        {
            if (previousValue != null && previousValue.iom_ward_idp_arrival.Contains(this))
            {
                previousValue.iom_ward_idp_arrival.Remove(this);
            }
    
            if (lkp_Location != null)
            {
                if (!lkp_Location.iom_ward_idp_arrival.Contains(this))
                {
                    lkp_Location.iom_ward_idp_arrival.Add(this);
                }
                if (state_type != lkp_Location.id)
                {
                    state_type = lkp_Location.id;
                }
            }
            else if (!_settingFK)
            {
                state_type = null;
            }
        }
    
        private void Fixuplkp_Period2(lkp_Period2 previousValue)
        {
            if (previousValue != null && previousValue.iom_ward_idp_arrival.Contains(this))
            {
                previousValue.iom_ward_idp_arrival.Remove(this);
            }
    
            if (lkp_Period2 != null)
            {
                if (!lkp_Period2.iom_ward_idp_arrival.Contains(this))
                {
                    lkp_Period2.iom_ward_idp_arrival.Add(this);
                }
                if (year != lkp_Period2.id)
                {
                    year = lkp_Period2.id;
                }
            }
        }
    
        private void Fixuplkp_State(lkp_State previousValue)
        {
            if (previousValue != null && previousValue.iom_ward_idp_arrival.Contains(this))
            {
                previousValue.iom_ward_idp_arrival.Remove(this);
            }
    
            if (lkp_State != null)
            {
                if (!lkp_State.iom_ward_idp_arrival.Contains(this))
                {
                    lkp_State.iom_ward_idp_arrival.Add(this);
                }
                if (location != lkp_State.state_code)
                {
                    location = lkp_State.state_code;
                }
            }
            else if (!_settingFK)
            {
                location = null;
            }
        }

        #endregion

    }
}
