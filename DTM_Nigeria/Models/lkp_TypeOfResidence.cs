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
    public partial class lkp_TypeOfResidence
    {
        #region Primitive Properties
    
        public virtual string id
        {
            get;
            set;
        }
    
        public virtual string residence
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
    
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

        #endregion
        #region Association Fixup
    
        private void Fixupiom_presence_wards(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_presence_wards item in e.NewItems)
                {
                    item.lkp_TypeOfResidence = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_presence_wards item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_TypeOfResidence, this))
                    {
                        item.lkp_TypeOfResidence = null;
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
                    item.lkp_TypeOfResidence = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ward_presence_per_location item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_TypeOfResidence, this))
                    {
                        item.lkp_TypeOfResidence = null;
                    }
                }
            }
        }

        #endregion
    }
}
