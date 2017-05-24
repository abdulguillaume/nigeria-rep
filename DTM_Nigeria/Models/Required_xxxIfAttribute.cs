using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;


namespace DTM_Nigeria.Models
{
    public class Required_xxxIfAttribute : RequiredAttribute
        
    {

        private String PropertyName { get; set; }
        private int DesiredValue { get; set; }

        public Required_xxxIfAttribute(String propertyName, int desiredvalue)
        {
            PropertyName = propertyName;
            DesiredValue = desiredvalue;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (((int)proprtyvalue) == DesiredValue)
            {
                ValidationResult result = base.IsValid(value, context);
                return result;
            }
            return ValidationResult.Success;
        }

        //    public IEnumerable<ModelClientValidationRule> GetClientValidationRules
        //(ModelMetadata metadata, ControllerContext context)
        //{
        //    ModelClientValidationRule mcvrTwo = new ModelClientValidationRule();
        //    mcvrTwo.ValidationType = "checkage";
        //    mcvrTwo.ErrorMessage = "Age range is 18 to 30 yrs. old.";
        //    mcvrTwo.ValidationParameters.Add
        //    ("param", DateTime.Now.ToString("dd-MM-yyyy"));
        //    return new List<modelclientvalidationrule /> { mcvrTwo };
        //}

        //protected override 


        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    //throw new NotImplementedException();
        //    var rule = new ModelClientValidationRule
        //    {
        //        ErrorMessage = FormatErrorMessage(metadata.DisplayName),
        //        ValidationType = "otherspecifyvalidation" //must be lower case
        //    };

        //    rule.ValidationParameters["desiredvalue"] = (int)DesiredValue;

        //    yield return rule;
        //}
    }

}