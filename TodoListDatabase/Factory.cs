using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.Controllers;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Views;

namespace TodoListDatabase
{
    public static class Factory
    {
        public static IViews GetMainObjectView()
        {
            IRegister register = new RegisterUser();
            IFieldValidator fieldValidatorRegistration = new UserRegistrationValidator(register);
            fieldValidatorRegistration.InitialiseValidatorDelegates();
            RegisterView regristrationView = new RegisterView(fieldValidatorRegistration, register);

            ILogin login = new LoginUser();
            LoginView loginView = new LoginView(login);

            ITodo todo = new TodoUser();
            IFieldValidator fieldValidatorTodo = new UserTodoValidator(todo);
            fieldValidatorTodo.InitialiseValidatorDelegates();
            TodoView todoView = new TodoView(fieldValidatorTodo, todo);


            MainView mainView = new MainView(regristrationView, loginView, todoView);
            return mainView;
        }
    }
}
