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
    public class LoginView : IViews
    {
        public IFieldValidator FieldValidator => null;

        ILogin _login = null;

        public LoginView(ILogin login)
        {
            _login = login;
        }

        public void RunView()
        {
            CommonOutputText.WriteLineMainHeading();
            CommonOutputText.WriteLineLoginHeading();

            string email = InputUtil.GetInputUser("Please enter your email: ");
            string password = InputUtil.GetInputUser("Please enter your password: ");

            Models.User user = _login.login(email, password);

            if (user != null)
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.SUCCESS);
                Console.WriteLine("Success to login!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);

                Console.Clear();

                // UserHompageView userHompage = new UserHompageView(user);
                // userHompage.RunView();
            }
            else
            {
                CommonOutputFormat.ChangeFontColor(FontTheme.DANGER);
                Console.WriteLine("The credentials that your entered do not match on our records!");
                CommonOutputFormat.ChangeFontColor(FontTheme.DEFAULT);
            }
        }
    }
}
