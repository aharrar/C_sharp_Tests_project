using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace PLWPF
{

    public class FieldValidation
    {
        public static bool IsValid(DependencyObject parent)
        {
            // Validate all the bindings on the parent
            bool valid = true;
            LocalValueEnumerator localValues = parent.GetLocalValueEnumerator();
            while (localValues.MoveNext())
            {
                LocalValueEntry entry = localValues.Current;
                if (BindingOperations.IsDataBound(parent, entry.Property))
                {
                    Binding binding = BindingOperations.GetBinding(parent, entry.Property);
                    if (binding.ValidationRules.Count > 0)
                    {
                        BindingExpression expression = BindingOperations.GetBindingExpression(parent, entry.Property);
                        expression.UpdateSource();

                        if (expression.HasError) valid = false;
                    }
                }
            }
            // Validate all the bindings on the children
            System.Collections.IEnumerable children = LogicalTreeHelper.GetChildren(parent);
            foreach (object obj in children)
            {
                if (obj is DependencyObject)
                {
                    DependencyObject child = (DependencyObject)obj;
                    if (!IsValid(child)) { valid = false; }
                }
            }



            return valid;
        }

        public static string IsValidText(string textToCheck)
        {
            string errorText = "";

            if (String.IsNullOrWhiteSpace(textToCheck))
            {
                return errorText = "Error fill the empty box";
            }

            if (textToCheck.Any(c => char.IsDigit(c)))
            {
                return errorText = "Error only letters are required";
            }

            return errorText;
        }

        public static string IsValidNum(string textToCheck)
        {
            string errorText = "";

            if (String.IsNullOrWhiteSpace(textToCheck))
            {
                return errorText = "Error fill the empty box";
            }

            if (!textToCheck.All(c => c >= '0' && c <= '9')) //
            {
                return errorText = "Error only numbers are required";
            }

            return errorText;
        }
    }

    public class RegexValidationRule : ValidationRule
    {
        //Test date dd/mm/yyyy
        //^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$
        // With @ for escaping special caracters like "\"
        //=> @"^(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}$"

        #region Data

        private string errorMessage;
        private RegexOptions regexOptions = RegexOptions.None;
        private string regexText;

        #endregion // Data

        #region Constructors

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public RegexValidationRule()
        {
        }

        /// <summary>
        /// Creates a RegexValidationRule with the specified regular expression.
        /// </summary>
        /// <param name="regexText">The regular expression used by the new instance.</param>
        public RegexValidationRule(string regexText)
        {
            this.RegexText = regexText;
        }

        /// <summary>
        /// Creates a RegexValidationRule with the specified regular expression
        /// and error message.
        /// </summary>
        /// <param name="regexText">The regular expression used by the new instance.</param>
        /// <param name="errorMessage">The error message used when validation fails.</param>
        public RegexValidationRule(string regexText, string errorMessage)
            : this(regexText)
        {
            this.RegexOptions = regexOptions;
        }

        /// <summary>
        /// Creates a RegexValidationRule with the specified regular expression,
        /// error message, and RegexOptions.
        /// </summary>
        /// <param name="regexText">The regular expression used by the new instance.</param>
        /// <param name="errorMessage">The error message used when validation fails.</param>
        /// <param name="regexOptions">The RegexOptions used by the new instance.</param>
        public RegexValidationRule(string regexText, string errorMessage, RegexOptions regexOptions)
            : this(regexText)
        {
            this.RegexOptions = regexOptions;
        }

        #endregion // Constructors

        #region Properties

        /// <summary>
        /// Gets/sets the error message to be used when validation fails.
        /// </summary>
        public string ErrorMessage
        {
            get { return this.errorMessage; }
            set { this.errorMessage = value; }
        }

        /// <summary>
        /// Gets/sets the RegexOptions to be used during validation.
        /// This property's default value is 'None'.
        /// </summary>
        public RegexOptions RegexOptions
        {
            get { return regexOptions; }
            set { regexOptions = value; }
        }

        /// <summary>
        /// Gets/sets the regular expression used during validation.
        /// </summary>
        public string RegexText
        {
            get { return regexText; }
            set { regexText = value; }
        }

        #endregion // Properties

        #region Validate

        /// <summary>
        /// Validates the 'value' argument using the regular 
        /// expression and RegexOptions associated with this object.
        /// </summary>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = ValidationResult.ValidResult;

            // If there is no regular expression to evaluate,
            // then the data is considered to be valid.
            if (!String.IsNullOrEmpty(this.RegexText))
            {
                // Cast the input value to a string (null becomes empty string).
                string text = value as string ?? String.Empty;

                // If the string does not match the regex, return a value
                // which indicates failure and provide an error mesasge.
                if (!Regex.IsMatch(text, this.RegexText, this.RegexOptions))
                    result = new ValidationResult(false, this.ErrorMessage);
            }

            return result;
        }

        #endregion // Validate
    }

    public class IntZeoutValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;
        private string _errorMessage;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);

            string inputString = value as string ?? String.Empty;

            //Test not null and number between 0 et 9
            bool valid = !string.IsNullOrWhiteSpace(inputString) && inputString.All(c => c >= '0' && c <= '9');

            if (!valid)
            {
                return new ValidationResult(false, "Only Digit are reqired");
            }
            if (inputString.Length < this.MinimumLength || (this.MaximumLength > 0 && inputString.Length > this.MaximumLength))
            {
                result = new ValidationResult(false, "9 Digits are required");
            }
            //if ((inputString.Split())[0] == "0")
            //{
            //    result = new ValidationResult(false, "Number \"0\" is not accepted as first caracter");
            //}
            return result;
        }
    }

    public class NumericValidationRule : ValidationRule
    {
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);

            var inputString = value ?? String.Empty;

            double val = 0;

            bool isDouble = Double.TryParse(inputString.ToString(), out val);

            if (!isDouble)
            {
                return result = new ValidationResult(false, "Enter a number");
            }

            //Test not null and number between 0 et 9
            bool valid = !string.IsNullOrWhiteSpace(inputString.ToString()) && inputString.ToString().All(c => c >= '0' && c <= '9' || c == ',');

            if (!valid)
            {
                return new ValidationResult(false, "Only Digit are required");
            }

            //if (inputString.Contains(","))    
            //{
            //    result = new ValidationResult(false, "Use a \".\" as the decimal symbol");
            //}

            return result;
        }

    }

    public class StringRangeValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;
        private string _errorMessage;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);
            string inputString = value as string ?? String.Empty;

            //bool valid = !string.IsNullOrWhiteSpace(inputString) && inputString.All(c => c >= '0' && c <= '9');

            if (inputString.Any(c => char.IsDigit(c)))
            {
                return new ValidationResult(false, "Only letters are allowed");
            }
            if (inputString.Length < this.MinimumLength || (this.MaximumLength > 0 && inputString.Length > this.MaximumLength))
            {
                result = new ValidationResult(false, "A name max 20 char is required");
            }
            return result;
        }
    }

    /*public class DateTimeValidationRule : ValidationRule
    {
        private int _minimumLength = -1;
        private int _maximumLength = -1;
        private string _errorMessage;

        public int MinimumLength
        {
            get { return _minimumLength; }
            set { _minimumLength = value; }
        }

        public int MaximumLength
        {
            get { return _maximumLength; }
            set { _maximumLength = value; }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);

            var date = (DateTime)value;


            //bool experimented = (DateTime.Now.Year - date.Year > 30) && (DateTime.Now.Year - date.Year < 65);
            bool experimented = (DateTime.Now.CompareTo(date) < 0);

            if (!experimented)
            {
                result = new ValidationResult(false, this.ErrorMessage);
            }

            return result;
        }
    }*/

    public class ListIsSelectedValidationRule : ValidationRule
    {
        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new ValidationResult(true, null);

            var input = value ?? String.Empty;

            bool valid = !string.IsNullOrEmpty(input.ToString());



            if (!valid || input.ToString() == "0" || input.ToString() == "Select")
            {
                return new ValidationResult(false, this.ErrorMessage);
            }

            return result;
        }
    }

}

//***********************************************************
//Test if is number(not used here):
//string someString;
//int myInt;
//bool isNumerical = int.TryParse(someString, out myInt);
//***********************************************************

//if ((inputString.Split())[0] == "0")
//{
//    result = new ValidationResult(false, "Number \"0\" is not accepted as first caracter");
//}