using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Utilities;

namespace TodoListDatabase.Views
{
    public class MainView: IViews
    {
        IViews _registrationView = null;
        IViews _loginView = null;
        IViews _todoView = null;

        public MainView(IViews registrationView, IViews loginView, IViews todoView)
        {
            _registrationView = registrationView;
            _loginView = loginView;
            _todoView = todoView;
        }

        public IFieldValidator FieldValidator => null;

        public void RunView()
        {
            CommonOutputText.WriteLineMainHeading();
            Console.WriteLine("Welcomet to the Todolist Database!");
            Console.WriteLine("Press ('l' for login) or ('r' for register)");

            ConsoleKey key = Console.ReadKey().Key;

            switch (key)
            {
                case ConsoleKey.L:
                    RunLoginView();
                    Console.Clear();
                    RunTodoView();
                    break;
                case ConsoleKey.R:
                    RunRegistrationView();
                    Console.Clear();
                    RunLoginView();
                    Console.Clear();
                    Console.Clear();
                    RunTodoView();
                    break;

                default:
                    Console.WriteLine("Goodbye");
                    break;
            }


        }

        private void RunRegistrationView()
        {
            _registrationView.RunView();
        }

        private void RunLoginView()
        {
            _loginView.RunView();
        }

        private void RunTodoView()
        {
            if (Temp.user == null)
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);
                Console.WriteLine("The credentials that your entered do not match on our records!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
                Console.ReadKey();
                Console.Clear();
                RunLoginView();
            } else
            {
                _todoView.RunView();
            }
        }
    }
}
