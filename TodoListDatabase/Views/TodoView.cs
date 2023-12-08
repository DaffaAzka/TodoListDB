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
    public class TodoView : IViews
    {
        IFieldValidator _fieldValidator = null;
        ITodo _todo = null;

        public TodoView(IFieldValidator fieldValidator, ITodo todo)
        {
            _fieldValidator = fieldValidator;
            _todo = todo;
        }

        public IFieldValidator FieldValidator { get => _fieldValidator; }

        public void RunView()
        {
            _todo.getAllTodo();

            CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
            Console.WriteLine($"Welcome on the app {Temp.user.Username}!");
            CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

            Console.WriteLine("=====================");
            if (Temp.tasks != null)
            {
                for (int i = 0; i < Temp.tasks.Length; i++)
                {
                    Console.WriteLine($"{i+1}. {Temp.tasks[i].Task}");
                }
            }
            Console.WriteLine("=====================");

            Console.WriteLine("a. add Task");
            Console.WriteLine("b. change Task");
            Console.WriteLine("c. delete Task");

            Console.WriteLine("=====================");

            Console.Write("Please select key: ");

            var choice = Console.ReadKey();

            switch(choice.Key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    AddView();
                    break;

                case ConsoleKey.B:
                    Console.Clear();
                    changeView();
                    break;
            }
        }


        private bool AddView()
        {
            _fieldValidator.FieldArray[(int)FieldConstants.TODO.Task] = GetInputUserTodo(FieldConstants.TODO.Task, "Please enter your task: ");
            _fieldValidator.FieldArray[(int)FieldConstants.TODO.VerifyId] = Temp.user.VeridyId;

            _todo.addTodo(_fieldValidator.FieldArray);


            CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
            Console.WriteLine("Success to add todo!");
            CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

            Console.ReadKey();
            Console.Clear();
            RunView();


            return true;
        }

        private bool changeView()
        {
            
            try
            {
                int i = InputInteger("Enter the task id: ");
                string v = InputUtil.GetInputUser("Enter the value: ");

                _todo.changeTodo(Temp.tasks[i - 1].Id, v);

                CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
                Console.WriteLine("Success to add todo!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            } catch
            {

                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);
                Console.WriteLine("The value id is not found!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            }



            Console.ReadKey();
            Console.Clear();
            RunView();


            return true;
        }


        private bool FieldValid(FieldConstants.TODO field, string fieldValue)
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

        public string GetInputUserTodo(FieldConstants.TODO field, string prompt)
        {
            string fieldValid = "";

            do
            {
                Console.Write(prompt);
                fieldValid = Console.ReadLine();
            } while (!FieldValid(field, fieldValid));

            return fieldValid;
        }

        public static int InputInteger(String s)
        {
            while (true)
            {
                try
                {
                    Console.Write(s);
                    int e = int.Parse(Console.ReadLine());
                    return e;
                }
                catch
                {
                    Console.WriteLine($"the value that your input is not a number");
                }
            }
        }
    }
}
