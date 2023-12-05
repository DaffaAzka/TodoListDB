using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.FieldValidators
{
    public delegate bool FieldValidatorGate(int index, string fieldValue, string[] fieldArray, out string fieldInvalidMsg);
    public interface IFieldValidator
    {
        void InitialiseValidatorDelegates();
        string[] FieldArray { get; }
        FieldValidatorGate ValidatorGate { get; }
    }
}
