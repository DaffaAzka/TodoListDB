using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Controllers;

namespace TodoListDatabase.FieldValidators
{
    internal class UserRegistrationValidator : IFieldValidator
    {
        delegate bool EmailExistGate(string email);
        delegate bool UsernameExistGate(string username);

        FieldValidatorGate _fieldValidatorGate = null;


        RequiredValidGate _requiredValidGate = null;
        PatternMatchValidGate _patternMatchValidGate = null;
        CompareFieldsValidGate _compareFieldsValidGate = null;

        EmailExistGate _emailExistGate = null;
        UsernameExistGate _usernameExistGate = null;

        string[] _fieldArray = null;
        IRegister _register = null;


        public string[] FieldArray {

            get
            {
                if (_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.USER)).Length];
                }
                return _fieldArray;
            }

        }

        public FieldValidatorGate ValidatorGate => _fieldValidatorGate;

        public UserRegistrationValidator(IRegister register)
        {
            _register = register;
        }

        public void InitialiseValidatorDelegates()
        {
            throw new NotImplementedException();
        }

        private bool ValidField(int index, string fieldValue, string[] fieldArray, out string fieldInvalidMsg)
        {
            fieldInvalidMsg = "";

            FieldConstants.USER registration = (FieldConstants.USER)index;

            switch(registration)
            {
                case FieldConstants.USER.VeridyId:
                    fieldInvalidMsg = (!_requiredValidGate(fieldValue)) ? $"You must enter the value for field-{Enum.GetName(typeof(FieldConstants.USER), registration)}{Environment.NewLine}" : "";
                    break;

                case FieldConstants.USER.Username:
                    fieldInvalidMsg = (!_requiredValidGate(fieldValue)) ? $"You must enter the value for field-{Enum.GetName(typeof(FieldConstants.USER), registration)}{Environment.NewLine}" : "";
                    fieldInvalidMsg = (fieldInvalidMsg == "") && !_patternMatchValidGate(fieldValue, CommonRegularExpressionValidationPatterns.Username_RegEx_Pattern) ? $"You must enter a valid username{Environment.NewLine}" : fieldInvalidMsg;
                    fieldInvalidMsg = (fieldInvalidMsg == "") && _usernameExistGate(fieldValue) ? $"Username already exists{Environment.NewLine}" : fieldInvalidMsg;
                    break;

                case FieldConstants.USER.Email:
                    fieldInvalidMsg = (!_requiredValidGate(fieldValue)) ? $"You must enter the value for field-{Enum.GetName(typeof(FieldConstants.USER), registration)}{Environment.NewLine}" : "";
                    fieldInvalidMsg = (fieldInvalidMsg == "") && !_patternMatchValidGate(fieldValue, CommonRegularExpressionValidationPatterns.Email_RegEx_Pattern) ? $"You must enter a valid username{Environment.NewLine}" : fieldInvalidMsg;
                    fieldInvalidMsg = (fieldInvalidMsg == "") && _emailExistGate (fieldValue) ? $"email already exists{Environment.NewLine}" : fieldInvalidMsg;
                    break;

                case FieldConstants.USER.Password:
                    fieldInvalidMsg = (!_requiredValidGate(fieldValue)) ? $"You must enter the value for field-{Enum.GetName(typeof(FieldConstants.USER), registration)}{Environment.NewLine}" : "";
                    fieldInvalidMsg = (fieldInvalidMsg == "") && !_patternMatchValidGate(fieldValue, CommonRegularExpressionValidationPatterns.Password_RegEx_Pattern) ? $"You must enter a valid password{Environment.NewLine}" : fieldInvalidMsg;
                    break;

                default:
                    throw new ArgumentException("This field does not exist!");

            }
            return fieldInvalidMsg == "";

        }
    }
}
