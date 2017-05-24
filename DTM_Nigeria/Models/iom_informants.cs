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
    [KnownType(typeof(iom_b2f_informants))]
    [KnownType(typeof(lkp_Informant_Type))]
    [KnownType(typeof(lkp_Sex))]
    [KnownType(typeof(iom_ga_informants))]
    public partial class iom_informants
    {
        #region Primitive Properties
        [DataMember]
        public virtual int id
        {
            get;
            set;
        }

        [Required]
        public bool notEmpty { get; set; }

        [DataMember]
        [RequiredIf("notEmpty",true,"*")]
        public virtual string name
        {
            get;
            set;
        }
        [DataMember]
        [RequiredIf("notEmpty", true, "*")]
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
                        if (lkp_Informant_Type != null && lkp_Informant_Type.id != value)
                        {
                            lkp_Informant_Type = null;
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
        [RequiredIf("notEmpty", true, "*")]
        public virtual string sex
        {
            get { return _sex; }
            set
            {
                try
                {
                    _settingFK = true;
                    if (_sex != value)
                    {
                        if (lkp_Sex != null && lkp_Sex.id != value)
                        {
                            lkp_Sex = null;
                        }
                        _sex = value;
                    }
                }
                finally
                {
                    _settingFK = false;
                }
            }
        }
        private string _sex;
        [DataMember]
        public virtual string details
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
        public virtual ICollection<iom_b2f_informants> iom_b2f_informants
        {
            get
            {
                if (_iom_b2f_informants == null)
                {
                    var newCollection = new FixupCollection<iom_b2f_informants>();
                    newCollection.CollectionChanged += Fixupiom_b2f_informants;
                    _iom_b2f_informants = newCollection;
                }
                return _iom_b2f_informants;
            }
            set
            {
                if (!ReferenceEquals(_iom_b2f_informants, value))
                {
                    var previousValue = _iom_b2f_informants as FixupCollection<iom_b2f_informants>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_b2f_informants;
                    }
                    _iom_b2f_informants = value;
                    var newValue = value as FixupCollection<iom_b2f_informants>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_b2f_informants;
                    }
                }
            }
        }
        private ICollection<iom_b2f_informants> _iom_b2f_informants;
        
    
        [DataMember]
        public virtual lkp_Informant_Type lkp_Informant_Type
        {
            get { return _lkp_Informant_Type; }
            set
            {
                if (!ReferenceEquals(_lkp_Informant_Type, value))
                {
                    var previousValue = _lkp_Informant_Type;
                    _lkp_Informant_Type = value;
                    Fixuplkp_Informant_Type(previousValue);
                }
            }
        }
        private lkp_Informant_Type _lkp_Informant_Type;
        
    
        [DataMember]
        public virtual lkp_Sex lkp_Sex
        {
            get { return _lkp_Sex; }
            set
            {
                if (!ReferenceEquals(_lkp_Sex, value))
                {
                    var previousValue = _lkp_Sex;
                    _lkp_Sex = value;
                    Fixuplkp_Sex(previousValue);
                }
            }
        }
        private lkp_Sex _lkp_Sex;
        
    
        [DataMember]
        public virtual ICollection<iom_ga_informants> iom_ga_informants
        {
            get
            {
                if (_iom_ga_informants == null)
                {
                    var newCollection = new FixupCollection<iom_ga_informants>();
                    newCollection.CollectionChanged += Fixupiom_ga_informants;
                    _iom_ga_informants = newCollection;
                }
                return _iom_ga_informants;
            }
            set
            {
                if (!ReferenceEquals(_iom_ga_informants, value))
                {
                    var previousValue = _iom_ga_informants as FixupCollection<iom_ga_informants>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_ga_informants;
                    }
                    _iom_ga_informants = value;
                    var newValue = value as FixupCollection<iom_ga_informants>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_ga_informants;
                    }
                }
            }
        }
        private ICollection<iom_ga_informants> _iom_ga_informants;

        #endregion
        #region Association Fixup
    
        private bool _settingFK = false;
    
        private void Fixuplkp_Informant_Type(lkp_Informant_Type previousValue)
        {
            if (previousValue != null && previousValue.iom_informants.Contains(this))
            {
                previousValue.iom_informants.Remove(this);
            }
    
            if (lkp_Informant_Type != null)
            {
                if (!lkp_Informant_Type.iom_informants.Contains(this))
                {
                    lkp_Informant_Type.iom_informants.Add(this);
                }
                if (type != lkp_Informant_Type.id)
                {
                    type = lkp_Informant_Type.id;
                }
            }
            else if (!_settingFK)
            {
                type = null;
            }
        }
    
        private void Fixuplkp_Sex(lkp_Sex previousValue)
        {
            if (previousValue != null && previousValue.iom_informants.Contains(this))
            {
                previousValue.iom_informants.Remove(this);
            }
    
            if (lkp_Sex != null)
            {
                if (!lkp_Sex.iom_informants.Contains(this))
                {
                    lkp_Sex.iom_informants.Add(this);
                }
                if (sex != lkp_Sex.id)
                {
                    sex = lkp_Sex.id;
                }
            }
        }
    
        private void Fixupiom_b1f_informants(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_b1f_informants item in e.NewItems)
                {
                    item.iom_informants = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_b1f_informants item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_informants, this))
                    {
                        item.iom_informants = null;
                    }
                }
            }
        }
    
        private void Fixupiom_b2f_informants(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_b2f_informants item in e.NewItems)
                {
                    item.iom_informants = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_b2f_informants item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_informants, this))
                    {
                        item.iom_informants = null;
                    }
                }
            }
        }
    
        private void Fixupiom_ga_informants(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_ga_informants item in e.NewItems)
                {
                    item.iom_informants = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_ga_informants item in e.OldItems)
                {
                    if (ReferenceEquals(item.iom_informants, this))
                    {
                        item.iom_informants = null;
                    }
                }
            }
        }

        #endregion
    }
}
