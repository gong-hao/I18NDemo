using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TestI18n.Models
{
    public class FilterableClientDataTypeModelValidatorProvider : ClientDataTypeModelValidatorProvider
    {
        public override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context)
        {
            var validators = base.GetValidators(metadata, context);

            foreach (var validator in validators)
            {
                var name = validator.GetType().Name;

                switch (name)
                {
                    case "NumericModelValidator":
                        yield return new DataAnnotationsModelValidator(metadata, context, new NumericAttribute());
                        break;

                    case "DateModelValidator":
                        yield return new DataAnnotationsModelValidator(metadata, context, new DateTimeAttribute());
                        break;

                    default:
                        yield return validator;
                        break;
                }
            }
        }
    }

    internal class NumericAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ValidationType = "number",
                ErrorMessage = CustomizedI18N.ValidationNumber
            };
        }
    }

    internal class DateTimeAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return true;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ValidationType = "date",
                ErrorMessage = CustomizedI18N.ValidationDate
            };
        }
    }
}