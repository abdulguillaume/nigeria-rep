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
    [KnownType(typeof(iom_group_assessment_2))]
    public partial class lkp_HealthProblem
    {
        #region Primitive Properties
        [DataMember]
        public virtual int id
        {
            get;
            set;
        }
        [DataMember]
        public virtual string value
        {
            get;
            set;
        }

        #endregion

        #region Navigation Properties
        
    
        [DataMember]
        public virtual ICollection<iom_group_assessment_2> iom_group_assessment_2
        {
            get
            {
                if (_iom_group_assessment_2 == null)
                {
                    var newCollection = new FixupCollection<iom_group_assessment_2>();
                    newCollection.CollectionChanged += Fixupiom_group_assessment_2;
                    _iom_group_assessment_2 = newCollection;
                }
                return _iom_group_assessment_2;
            }
            set
            {
                if (!ReferenceEquals(_iom_group_assessment_2, value))
                {
                    var previousValue = _iom_group_assessment_2 as FixupCollection<iom_group_assessment_2>;
                    if (previousValue != null)
                    {
                        previousValue.CollectionChanged -= Fixupiom_group_assessment_2;
                    }
                    _iom_group_assessment_2 = value;
                    var newValue = value as FixupCollection<iom_group_assessment_2>;
                    if (newValue != null)
                    {
                        newValue.CollectionChanged += Fixupiom_group_assessment_2;
                    }
                }
            }
        }
        private ICollection<iom_group_assessment_2> _iom_group_assessment_2;

        #endregion

        #region Association Fixup
    
        private void Fixupiom_group_assessment_2(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (iom_group_assessment_2 item in e.NewItems)
                {
                    item.lkp_HealthProblem = this;
                }
            }
    
            if (e.OldItems != null)
            {
                foreach (iom_group_assessment_2 item in e.OldItems)
                {
                    if (ReferenceEquals(item.lkp_HealthProblem, this))
                    {
                        item.lkp_HealthProblem = null;
                    }
                }
            }
        }

        #endregion

    }
}
