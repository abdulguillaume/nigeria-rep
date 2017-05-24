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
    [KnownType(typeof(iom_ward_profile))]
    public partial class iom_ward_households_breakdown
    {
        #region Primitive Properties
        [DataMember]
        public virtual int hhs
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
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> m_lt1
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> f_lt1
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> m_1_5
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> f_1_5
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> m_6_17
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> f_6_17
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> m_18_59
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> f_18_59
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> m_60p
        {
            get;
            set;
        }
        [DataMember]
        [RegularExpression("^[0-9]*", ErrorMessage = "*")]
        public virtual Nullable<int> f_60p
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
    
        private void Fixupiom_ward_profile(iom_ward_profile previousValue)
        {
            if (previousValue != null && previousValue.iom_ward_households_breakdown.Contains(this))
            {
                previousValue.iom_ward_households_breakdown.Remove(this);
            }
    
            if (iom_ward_profile != null)
            {
                if (!iom_ward_profile.iom_ward_households_breakdown.Contains(this))
                {
                    iom_ward_profile.iom_ward_households_breakdown.Add(this);
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
