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
    public partial class lkp_Period2
    {
        #region Primitive Properties
    
        public virtual int id
        {
            get;
            set;
        }
    
        public virtual string phase
        {
            get;
            set;
        }
    
        public virtual string label
        {
            get;
            set;
        }
    
        public virtual string tmp
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
        public virtual ICollection<iom_group_assessment_1> iom_group_assessment_1
        {
            get
            {
                if (_iom_group_assessment_1 == null)
                {
                    var newCollection = new FixupCollection<iom_group_assessment_1>();
                    newCollection.CollectionChanged += Fixupiom_group_assessment_1;
                    _iom_group_assessment_1 = newCollection;
                }
                return _iom_group_assessment_1;
            }
            set
            {
                if (!ReferenceEquals(_iom_group_assessment_1, value))
                {
                    var previousValue = _iom_group_assessment_1 as FixupCollection<iom_group_assessment_1>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_group_assessment_1;
                    }
                    _iom_group_assessment_1 = value;
                    var newValue = value as FixupCollection<iom_group_assessment_1>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_group_assessment_1;
                    }
                }
            }
        }
        private ICollection<iom_group_assessment_1> _iom_group_assessment_1;
    
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
    
        public virtual ICollection<iom_profile> iom_profile2
        {
            get
            {
                if (_iom_profile2 == null)
                {
                    var newCollection = new FixupCollection<iom_profile>();
                    newCollection.CollectionChanged += Fixupiom_profile2;
                    _iom_profile2 = newCollection;
                }
                return _iom_profile2;
            }
            set
            {
                if (!ReferenceEquals(_iom_profile2, value))
                {
                    var previousValue = _iom_profile2 as FixupCollection<iom_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_profile2;
                    }
                    _iom_profile2 = value;
                    var newValue = value as FixupCollection<iom_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_profile2;
                    }
                }
            }
        }
        private ICollection<iom_profile> _iom_profile2;
    
        public virtual ICollection<iom_profile> iom_profile3
        {
            get
            {
                if (_iom_profile3 == null)
                {
                    var newCollection = new FixupCollection<iom_profile>();
                    newCollection.CollectionChanged += Fixupiom_profile3;
                    _iom_profile3 = newCollection;
                }
                return _iom_profile3;
            }
            set
            {
                if (!ReferenceEquals(_iom_profile3, value))
                {
                    var previousValue = _iom_profile3 as FixupCollection<iom_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_profile3;
                    }
                    _iom_profile3 = value;
                    var newValue = value as FixupCollection<iom_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_profile3;
                    }
                }
            }
        }
        private ICollection<iom_profile> _iom_profile3;
    
        public virtual ICollection<iom_profile> iom_profile4
        {
            get
            {
                if (_iom_profile4 == null)
                {
                    var newCollection = new FixupCollection<iom_profile>();
                    newCollection.CollectionChanged += Fixupiom_profile4;
                    _iom_profile4 = newCollection;
                }
                return _iom_profile4;
            }
            set
            {
                if (!ReferenceEquals(_iom_profile4, value))
                {
                    var previousValue = _iom_profile4 as FixupCollection<iom_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_profile4;
                    }
                    _iom_profile4 = value;
                    var newValue = value as FixupCollection<iom_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_profile4;
                    }
                }
            }
        }
        private ICollection<iom_profile> _iom_profile4;
    
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
    
        public virtual ICollection<iom_ward_profile> iom_ward_profile2
        {
            get
            {
                if (_iom_ward_profile2 == null)
                {
                    var newCollection = new FixupCollection<iom_ward_profile>();
                    newCollection.CollectionChanged += Fixupiom_ward_profile2;
                    _iom_ward_profile2 = newCollection;
                }
                return _iom_ward_profile2;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_profile2, value))
                {
                    var previousValue = _iom_ward_profile2 as FixupCollection<iom_ward_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_profile2;
                    }
                    _iom_ward_profile2 = value;
                    var newValue = value as FixupCollection<iom_ward_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_profile2;
                    }
                }
            }
        }
        private ICollection<iom_ward_profile> _iom_ward_profile2;
    
        public virtual ICollection<iom_ward_profile> iom_ward_profile3
        {
            get
            {
                if (_iom_ward_profile3 == null)
                {
                    var newCollection = new FixupCollection<iom_ward_profile>();
                    newCollection.CollectionChanged += Fixupiom_ward_profile3;
                    _iom_ward_profile3 = newCollection;
                }
                return _iom_ward_profile3;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_profile3, value))
                {
                    var previousValue = _iom_ward_profile3 as FixupCollection<iom_ward_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_profile3;
                    }
                    _iom_ward_profile3 = value;
                    var newValue = value as FixupCollection<iom_ward_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_profile3;
                    }
                }
            }
        }
        private ICollection<iom_ward_profile> _iom_ward_profile3;
    
        public virtual ICollection<iom_ward_profile> iom_ward_profile4
        {
            get
            {
                if (_iom_ward_profile4 == null)
                {
                    var newCollection = new FixupCollection<iom_ward_profile>();
                    newCollection.CollectionChanged += Fixupiom_ward_profile4;
                    _iom_ward_profile4 = newCollection;
                }
                return _iom_ward_profile4;
            }
            set
            {
                if (!ReferenceEquals(_iom_ward_profile4, value))
                {
                    var previousValue = _iom_ward_profile4 as FixupCollection<iom_ward_profile>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ward_profile4;
                    }
                    _iom_ward_profile4 = value;
                    var newValue = value as FixupCollection<iom_ward_profile>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ward_profile4;
                    }
                }
            }
        }
        private ICollection<iom_ward_profile> _iom_ward_profile4;

        #endregion
        #region Association Fixup
    
        private void Fixupiom_group_assessment_1(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_group_assessment_1 item in e.NewItems)
                {
                    item.lkp_Period2 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_group_assessment_1 item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period2, this))
                    {
                        item.lkp_Period2 = null;
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
                    item.lkp_Period2 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_idp_arrival item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period2, this))
                    {
                        item.lkp_Period2 = null;
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
                    item.lkp_Period2 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period2, this))
                    {
                        item.lkp_Period2 = null;
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
                    item.lkp_Period21 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period21, this))
                    {
                        item.lkp_Period21 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_profile2(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_profile item in e.NewItems)
                {
                    item.lkp_Period22 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period22, this))
                    {
                        item.lkp_Period22 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_profile3(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_profile item in e.NewItems)
                {
                    item.lkp_Period23 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period23, this))
                    {
                        item.lkp_Period23 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_profile4(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_profile item in e.NewItems)
                {
                    item.lkp_Period24 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period24, this))
                    {
                        item.lkp_Period24 = null;
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
                    item.lkp_Period2 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_idp_arrival item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period2, this))
                    {
                        item.lkp_Period2 = null;
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
                    item.lkp_Period2 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period2, this))
                    {
                        item.lkp_Period2 = null;
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
                    item.lkp_Period21 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period21, this))
                    {
                        item.lkp_Period21 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_profile2(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_profile item in e.NewItems)
                {
                    item.lkp_Period22 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period22, this))
                    {
                        item.lkp_Period22 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_profile3(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_profile item in e.NewItems)
                {
                    item.lkp_Period23 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period23, this))
                    {
                        item.lkp_Period23 = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ward_profile4(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ward_profile item in e.NewItems)
                {
                    item.lkp_Period24 = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_profile item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_Period24, this))
                    {
                        item.lkp_Period24 = null;
                    }
                }
            }
        }

        #endregion
    }
}
