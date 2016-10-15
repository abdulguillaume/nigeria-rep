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
    [KnownType(typeof(iom_informants))]
    [KnownType(typeof(iom_ward_profile))]
    public partial class iom_b2f_informants
    {
        #region Primitive Properties
        [DataMember]
        public virtual int id
        {
            get;
            set;
        }
        [DataMember]
        public virtual int informant
        {
            get { return _informant; }
            set
            {
                if (_informant != value)
                {
                    if (iom_informants != null && iom_informants.id != value)
                    {
                        iom_informants = null;
                    }
                    _informant = value;
                }
            }
        }
        private int _informant;
        [DataMember]
        public virtual int ward_profile_id
        {
            get { return _ward_profile_id; }
            set
            {
                if (_ward_profile_id != value)
                {
                    if (iom_ward_profile != null && iom_ward_profile.id != value)
                    {
                        iom_ward_profile = null;
                    }
                    _ward_profile_id = value;
                }
            }
        }
        private int _ward_profile_id;
        [DataMember]
        public virtual string contact_details
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
        public virtual iom_informants iom_informants
        {
            get { return _iom_informants; }
            set
            {
                if (!ReferenceEquals(_iom_informants, value))
                {
                    var previousValue = _iom_informants;
                    _iom_informants = value;
                    Fixupiom_informants(previousValue);
                }
            }
        }
        private iom_informants _iom_informants;
        
    
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

        #endregion

        #region Association Fixup
    
        private void Fixupiom_informants(iom_informants previousValue)
        {
            if (previousValue != null && previousValue.iom_b2f_informants.Contains(this))
            {
                previousValue.iom_b2f_informants.Remove(this);
            }
    
            if (iom_informants != null)
            {
                if (!iom_informants.iom_b2f_informants.Contains(this))
                {
                    iom_informants.iom_b2f_informants.Add(this);
                }
                if (informant != iom_informants.id)
                {
                    informant = iom_informants.id;
                }
            }
        }
    
        private void Fixupiom_ward_profile(iom_ward_profile previousValue)
        {
            if (previousValue != null && previousValue.iom_b2f_informants.Contains(this))
            {
                previousValue.iom_b2f_informants.Remove(this);
            }
    
            if (iom_ward_profile != null)
            {
                if (!iom_ward_profile.iom_b2f_informants.Contains(this))
                {
                    iom_ward_profile.iom_b2f_informants.Add(this);
                }
                if (ward_profile_id != iom_ward_profile.id)
                {
                    ward_profile_id = iom_ward_profile.id;
                }
            }
        }

        #endregion

    }
}
