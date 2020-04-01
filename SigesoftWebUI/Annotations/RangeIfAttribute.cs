using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace SigesoftWebUI.Annotations
{
    public class RangeIfAttribute : RangeAttribute
    {
        public string Property { get; set; }
        public object Value { get; set; }

        public RangeIfAttribute(string property, object value, double min, double max)
            : base(min, max)
        {
            this.Property = property;
            this.Value = value ?? "";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            PropertyInfo property = validationContext.ObjectType.GetProperty(this.Property);

            if (property == null)
            {
                return new ValidationResult(
                    string.Format(CultureInfo.CurrentCulture, "Could not find a property named '{0}'.", this.Property));
            }

            object propertyValue = property.GetValue(validationContext.ObjectInstance, null);

            var listaValores = Value.ToString().Split(',');

            if (listaValores.Contains(propertyValue) && value == null)
            {
                return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
    }
}