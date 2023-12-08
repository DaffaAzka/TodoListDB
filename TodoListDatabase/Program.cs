using System.Security.Cryptography;
using TodoListDatabase;
using TodoListDatabase.Controllers;
using TodoListDatabase.FieldValidators;
using TodoListDatabase.Models;
using TodoListDatabase.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        string name = "Sarah";

        IRegister register = new RegisterUser();
        ITodo todo = new TodoUser();
        ILogin login = new LoginUser();
        IFieldValidator validator = new UserRegistrationValidator(register);
        validator.InitialiseValidatorDelegates();

        // register.register(["2", GenerateHash(name, "5"), name, "az@gmail.com", "Password"]);

        // Console.WriteLine("Success Register");


        // Console.WriteLine("Success Create Task");

        // todo.changeTodo(1, "Mamah juga takut");

        // todo.isDoneTodo(1);
        // Console.WriteLine("Success Doned");


        // login.login("az@gmail.com", "Password");

        // todo.addTodo(["", GenerateHash(Temp.user.Username, "5"), "Kakak Juga Takut"]);




        // todo.getAllTodo();

        var reg = new RegisterView(validator, register);
        var log = new LoginView(login);
        log.RunView();

    }

    
}