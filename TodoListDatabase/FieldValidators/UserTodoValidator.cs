using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Controllers;

namespace TodoListDatabase.FieldValidators
{
    public class UserTodoValidator : IFieldValidator
    {
        delegate bool TaskExistGate(string fieldVal);

        FieldValidatorGate _fieldValidatorGate = null;

        RequiredValidGate _requiredValidGate = null;

        string[] _fieldArray = null;

        ITodo todo = null;

        public string[] FieldArray
        {
            get
            {
                if (_fieldArray == null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.TODO)).Length];
                }
                return _fieldArray;
            }
        }

        public FieldValidatorGate ValidatorGate => _fieldValidatorGate;

        public UserTodoValidator(ITodo todo)
        {
            this.todo = todo;
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
