using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Controllers;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Utilities;

namespace TodoListDatabase.Views
{
    public class RegisterView : IViews
    {
        IFieldValidator _fieldValidator = null;
        IRegister _register = null;

        public RegisterView(IFieldValidator fieldValidator, IRegister register)
        {
            _fieldValidator = fieldValidator;
            _register = register;
        }

        public IFieldValidator FieldValidator { get => _fieldValidator;  }

        public void RunView()
        {
            CommonOutputText.WriteLineMainHeading();

            _fieldValidator.FieldArray[(int)FieldConstants.USER.Username] = GetInputUserRegister(FieldConstants.USER.Username, "Please enter your username: ");
            _fieldValidator.FieldArray[(int)FieldConstants.USER.Email] = GetInputUserRegister(FieldConstants.USER.Email, "Please enter your email address: ");
            _fieldValidator.FieldArray[(int)FieldConstants.USER.Password] = GetInputUserRegister(FieldConstants.USER.Password, "Please enter your password: ");
            _fieldValidator.FieldArray[(int)FieldConstants.USER.VeridyId] = InputUtil.GenerateHash(_fieldValidator.FieldArray[(int)FieldConstants.USER.Username], "5");

            RegisterUser();
        }

        private void RegisterUser()
        {
            _register.register(_fieldValidator.FieldArray);

            CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
            Console.WriteLine("Success to register!");
            CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

            Console.Clear();

        }

        private bool FieldValid(FieldConstants.USER field, string fieldValue)
        {
            if (!_fieldValidator.ValidatorGate((int)field, fieldValue, _fieldValidator.FieldArray, out string invalidMessage))
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);

                Console.WriteLine(invalidMessage);

                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

                return false;
            }
            return true;
        }

        public string GetInputUserRegister(FieldConstants.USER field, string prompt)
        {
            string fieldValid = "";

            do
            {
                Console.Write(prompt);
                fieldValid = Console.ReadLine();
            } while (!FieldValid(field, fieldValid));

            return fieldValid;
        }
    }
}
