using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidGate(string fieldVal);
    public delegate bool PatternMatchValidGate(string fieldVal, string pattern);
    public delegate bool CompareFieldsValidGate(string fieldVal, string fieldCompare);
    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidGate _requiredValidGate = null;
        private static PatternMatchValidGate _patternMatchValidGate = null;
        private static CompareFieldsValidGate _compareFieldsValidGate = null;

        public static RequiredValidGate RequiredValidGate
        {
            get
            {
                if (_requiredValidGate == null)
                {
                    _requiredValidGate = new RequiredValidGate(RequiredValid);
                }
                return _requiredValidGate;
            }
        }

        public static PatternMatchValidGate PatternMatchValidGate
        {
            get
            {
                if (_patternMatchValidGate == null)
                {
                    _patternMatchValidGate = new PatternMatchValidGate(PatternMatchValid);
                }
                return _patternMatchValidGate;
            }
        }

        public static CompareFieldsValidGate CompareFieldsValidGate
        {
            get
            {
                if (_compareFieldsValidGate == null)
                {
                    _compareFieldsValidGate = new CompareFieldsValidGate(CompareFieldsValid);
                }
                return CompareFieldsValidGate;
            }
        }




        private static bool RequiredValid(string fieldVal)
        {
            return !string.IsNullOrEmpty(fieldVal);
        }

        private static bool PatternMatchValid(string fieldVal, string regexVal)
        {
            Regex regex = new Regex(regexVal);
            return regex.IsMatch(fieldVal);
        }

        private static bool CompareFieldsValid(string fieldVal, string fieldCompare)
        {
            return fieldVal.Equals(fieldCompare);
        }
    }
}
