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
    public partial class lkp_State
    {
        #region Primitive Properties
    
        public virtual int id
        {
            get;
            set;
        }
    
        public virtual string state_name
        {
            get;
            set;
        }
    
        public virtual string state_code
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
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
    
        public virtual ICollection<iom_profile> iom_profile
        {
            get
            {
                if (_iom_profile == null)
                {
                    var newCollection = new FixupCollection<iom_profile>();
                    newCollection.CollectionChanged += Fixupiom_profile;
                    _iom_profile = newCollection;
                }
                return _iom_profile;
            }
            set
            {
                if (!ReferenceEquals(_iom_profile, value))
                {
                    var previousValue = _iom_profile as FixupCollection<iom_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_profile;
                    }
                    _iom_profile = value;
                    var newValue = value as FixupCollection<iom_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_profile;
                    }
                }
            }
        }
        private ICollection<iom_profile> _iom_profile;
    
        public virtual ICollection<iom_profile> iom_profile1
        {
            get
            {
                if (_iom_profile1 == null)
                {
                    var newCollection = new FixupCollection<iom_profile>();
                    newCollection.CollectionChanged += Fixupiom_profile1;
                    _iom_profile1 = newCollection;
                }
                return _iom_profile1;
            }
            set
            {
                if (!ReferenceEquals(_iom_profile1, value))
                {
                    var previousValue = _iom_profile1 as FixupCollection<iom_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_profile1;
                    }
                    _iom_profile1 = value;
                    var newValue = value as FixupCollection<iom_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_profile1;
                    }
                }
            }
        }
        private ICollection<iom_profile> _iom_profile1;
    
        public virtual ICollection<iom_ward_idp_arrival> iom_ward_idp_arrival
        {
            get
            {
                if (_iom_ward_idp_arrival == null)
                {
                    var newCollection = new FixupCollection<iom_ward_idp_arrival>();
                    newCollection.CollectionChanged += Fixupiom_ward_idp_arrival;
                    _iom_ward_idp_arrival = newCollection;
                }
                return _iom_ward_idp_arrival;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_idp_arrival, value))
                {
                    var previousValue = _iom_ward_idp_arrival as FixupCollection<iom_ward_idp_arrival>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_idp_arrival;
                    }
                    _iom_ward_idp_arrival = value;
                    var newValue = value as FixupCollection<iom_ward_idp_arrival>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_idp_arrival;
                    }
                }
            }
        }
        private ICollection<iom_ward_idp_arrival> _iom_ward_idp_arrival;
    
        public virtual ICollection<iom_ward_presence_per_location> iom_ward_presence_per_location
        {
            get
            {
                if (_iom_ward_presence_per_location == null)
                {
                    var newCollection = new FixupCollection<iom_ward_presence_per_location>();
                    newCollection.CollectionChanged += Fixupiom_ward_presence_per_location;
                    _iom_ward_presence_per_location = newCollection;
                }
                return _iom_ward_presence_per_location;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_presence_per_location, value))
                {
                    var previousValue = _iom_ward_presence_per_location as FixupCollection<iom_ward_presence_per_location>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_presence_per_location;
                    }
                    _iom_ward_presence_per_location = value;
                    var newValue = value as FixupCollection<iom_ward_presence_per_location>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_presence_per_location;
                    }
                }
            }
        }
        private ICollection<iom_ward_presence_per_location> _iom_ward_presence_per_location;
    
        public virtual ICollection<iom_ward_profile> iom_ward_profile
        {
            get
            {
                if (_iom_ward_profile == null)
                {
                    var newCollection = new FixupCollection<iom_ward_profile>();
                    newCollection.CollectionChanged += Fixupiom_ward_profile;
                    _iom_ward_profile = newCollection;
                }
                return _iom_ward_profile;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_profile, value))
                {
                    var previousValue = _iom_ward_profile as FixupCollection<iom_ward_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_profile;
                    }
                    _iom_ward_profile = value;
                    var newValue = value as FixupCollection<iom_ward_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_profile;
                    }
                }
            }
        }
        private ICollection<iom_ward_profile> _iom_ward_profile;
    
        public virtual ICollection<iom_ward_profile> iom_ward_profile1
        {
            get
            {
                if (_iom_ward_profile1 == null)
                {
                    var newCollection = new FixupCollection<iom_ward_profile>();
                    newCollection.CollectionChanged += Fixupiom_ward_profile1;
                    _iom_ward_profile1 = newCollection;
                }
                return _iom_ward_profile1;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_profile1, value))
                {
                    var previousValue = _iom_ward_profile1 as FixupCollection<iom_ward_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_profile1;
                    }
                    _iom_ward_profile1 = value;
                    var newValue = value as FixupCollection<iom_ward_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_profile1;
                    }
                }
            }
        }
        private ICollection<iom_ward_profile> _iom_ward_profile1;
    
        public virtual ICollection<lkp_Lga> lkp_Lga
        {
            get
            {
                if (_lkp_Lga == null)
                {
                    var newCollection = new FixupCollection<lkp_Lga>();
                    newCollection.CollectionChanged += Fixuplkp_Lga;
                    _lkp_Lga = newCollection;
                }
                return _lkp_Lga;
            }
            set
            {
                if (!ReferenceEquals(_lkp_Lga, value))
                {
                    var previousValue = _lkp_Lga as FixupCollection<lkp_Lga>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixuplkp_Lga;
                    }
                    _lkp_Lga = value;
                    var newValue = value as FixupCollection<lkp_Lga>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixuplkp_Lga;
                    }
                }
            }
        }
        private ICollection<lkp_Lga> _lkp_Lga;

        #endregion
        #region Association Fixup
    
        private void Fixupiom_idp_arrival(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_idp_arrival item in e.NewItems)
                {
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_idp_arrival item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
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
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_presence_wards item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
                    }
                }
            }
        }
    
        private void Fixupiom_profile(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_profile item in e.NewItems)
                {
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
                    }
                }
            }
        }
    
        private void Fixupiom_profile1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_profile item in e.NewItems)
                {
                    item.lkp_State1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State1, this))
                    {
                        item.lkp_State1 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_idp_arrival(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_idp_arrival item in e.NewItems)
                {
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_idp_arrival item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_presence_per_location(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_presence_per_location item in e.NewItems)
                {
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_presence_per_location item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_profile(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_profile item in e.NewItems)
                {
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_profile1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_profile item in e.NewItems)
                {
                    item.lkp_State1 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State1, this))
                    {
                        item.lkp_State1 = null;
                    }
                }
            }
        }
    
        private void Fixuplkp_Lga(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (lkp_Lga item in e.NewItems)
                {
                    item.lkp_State = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (lkp_Lga item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_State, this))
                    {
                        item.lkp_State = null;
                    }
                }
            }
        }

        #endregion
    }
}
