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

namespace DTM_Nigeria.Models
{
    [DataContract(IsReference = true)]
    [KnownType(typeof(iom_b1f_organizations_assisting))]
    [KnownType(typeof(iom_b2f_organizations_assisting))]
    [KnownType(typeof(lkp_Organization))]
    public partial class iom_organizations
    {
        #region Primitive Properties
        [DataMember]
        public virtual int id
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*", AllowEmptyStrings = false)]
        public virtual string name
        {
            get;
            set;
        }
        [DataMember]
        [Required(ErrorMessage = "*")]
        public virtual Nullable<int> type
        {
            get { return _type; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_type != value)
                    {
                        if (lkp_Organization != null && lkp_Organization.id != value)
                        {
                            lkp_Organization = null;
                        }
                        _type = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private Nullable<int> _type;
        [DataMember]
        public virtual string description
        {
            get;
            set;
        }

        #endregion
        #region Navigation Properties
        
    
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
        public virtual ICollection<iom_b2f_organizations_assisting> iom_b2f_organizations_assisting
        {
            get
            {
                if (_iom_b2f_organizations_assisting == null)
                {
                    var newCollection = new FixupCollection<iom_b2f_organizations_assisting>();
                    newCollection.CollectionChanged += Fixupiom_b2f_organizations_assisting;
                    _iom_b2f_organizations_assisting = newCollection;
                }
                return _iom_b2f_organizations_assisting;
            }
            set
            {
                if (!ReferenceEquals(_iom_b2f_organizations_assisting, value))
                {
                    var previousValue = _iom_b2f_organizations_assisting as FixupCollection<iom_b2f_organizations_assisting>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_b2f_organizations_assisting;
                    }
                    _iom_b2f_organizations_assisting = value;
                    var newValue = value as FixupCollection<iom_b2f_organizations_assisting>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_b2f_organizations_assisting;
                    }
                }
            }
        }
        private ICollection<iom_b2f_organizations_assisting> _iom_b2f_organizations_assisting;
        
    
        [DataMember]
        public virtual lkp_Organization lkp_Organization
        {
            get { return _lkp_Organization; }
            set
            {
                if (!ReferenceEquals(_lkp_Organization, value))
                {
                    var previousValue = _lkp_Organization;
                    _lkp_Organization = value;
                    Fixuplkp_Organization(previousValue);
                }
            }
        }
        private lkp_Organization _lkp_Organization;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixuplkp_Organization(lkp_Organization previousValue)
        {
            if (previousValue != null && previousValue.iom_organizations.Contains(this))
            {
                previousValue.iom_organizations.Remove(this);
            }
    
            if (lkp_Organization != null)
            {
                if (!lkp_Organization.iom_organizations.Contains(this))
                {
                    lkp_Organization.iom_organizations.Add(this);
                }
                if (type != lkp_Organization.id)
                {
                    type = lkp_Organization.id;
                }
            }
            else if (!_settingFK)
            {
                type = null;
            }
        }
    
        private void Fixupiom_b1f_organizations_assisting(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_b1f_organizations_assisting item in e.NewItems)
                {
                    item.iom_organizations = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_b1f_organizations_assisting item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_organizations, this))
                    {
                        item.iom_organizations = null;
                    }
                }
            }
        }
    
        private void Fixupiom_b2f_organizations_assisting(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_b2f_organizations_assisting item in e.NewItems)
                {
                    item.iom_organizations = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_b2f_organizations_assisting item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_organizations, this))
                    {
                        item.iom_organizations = null;
                    }
                }
            }
        }

        #endregion
    }
}
