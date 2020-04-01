using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace SigesoftWebUI.Annotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ExpressionRequiredIfAttribute : ValidationAttribute, IClientValidatable
    {
        public string OtherProperty { get; private set; }
        public string OtherPropertyDisplayName { get; set; }
        public object OtherPropertyValue { get; private set; }
        public bool IsInverted { get; set; }
        public bool RegexNotMatch { get; set; }
        public string Expresion { get; set; }

        public override object TypeId
        {
            get { return new object(); }
        }

        //To avoid multiple rules with same name
        public static Dictionary<string, int> CountPerField = null;

        public ExpressionRequiredIfAttribute(string otherProperty, object otherPropertyValue)
            : base("'{0}' is required because '{1}' has a value {3}'{2}'.")
        {
            this.OtherProperty = otherProperty;
            this.OtherPropertyValue = otherPropertyValue;
            this.IsInverted = false;
        }

        public override bool RequiresValidationContext
        {
            get { return true; }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException("validationContext");
            }

            var otherProperties = this.OtherProperty.Split('|');
            var otherValueProperties = OtherPropertyValue.ToString().Split('|');
            int validateCount = 0;

            for (int i = 0; i < otherProperties.Length; i++)
            {
                var itemProperty = otherProperties[i];
                var itemValue = otherValueProperties[i];
                PropertyInfo otherProperty = validationContext.ObjectType.GetProperty(itemProperty);

                if (otherProperty == null)
                {
                    return new ValidationResult(
                        string.Format(CultureInfo.CurrentCulture, "Could not find a property named '{0}'.", this.OtherProperty));
                }

                object otherValue = otherProperty.GetValue(validationContext.ObjectInstance);

                if (otherValue != null)
                {
                    otherValue = otherValue.ToString();
                }

                var listaValores = itemValue.Split(',');

                // check if this value is actually required and validate it
                if (!this.IsInverted && listaValores.Contains(otherValue) ||
                    this.IsInverted && !listaValores.Contains(otherValue))
                {
                    validateCount++;
                }
            }

            if (validateCount == otherProperties.Length)
            {
                var expresionActual = Expresion;
                var mensajeErrorActual = ErrorMessage;

                var valor = (value == null) ? string.Empty : value.ToString();
                var responseMatch = Regex.IsMatch(valor, expresionActual);

                if ((!responseMatch && !RegexNotMatch) || (responseMatch && RegexNotMatch))
                {
                    return new ValidationResult(mensajeErrorActual);
                }
            }

            return ValidationResult.Success;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            string key = metadata.ContainerType.FullName + "." + metadata.GetDisplayName();

            int count = 0;
            if (CountPerField == null)
                CountPerField = new Dictionary<string, int>();

            if (CountPerField.ContainsKey(key))
            {
                count = ++CountPerField[key];
            }
            else
                CountPerField.Add(key, count);

            var rule = new ModelClientValidationRule();

            var ASCIIInicial = 97;
            var countLetras = count.ToString();
            string letras = string.Empty;

            for (int i = 0; i < countLetras.Count(); i++)
            {
                letras += char.ConvertFromUtf32(ASCIIInicial + Convert.ToInt32(countLetras[i].ToString()));
            }

            rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
            rule.ValidationParameters.Add("listvalues", OtherPropertyValue);
            rule.ValidationParameters.Add("otherproperty", OtherProperty);
            rule.ValidationParameters.Add("expresion", Expresion);
            rule.ValidationParameters.Add("regexnotmatch", RegexNotMatch ? 1 : 0);

            rule.ValidationType = "expressionrequiredif" + letras;
            yield return rule;
        }
    }
}