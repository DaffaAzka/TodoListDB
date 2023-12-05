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
            return true;
        }
    }
}
