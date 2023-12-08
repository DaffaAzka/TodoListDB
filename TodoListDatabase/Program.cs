using System.Security.Cryptography;
using TodoListDatabase;
using TodoListDatabase.Controllers;
using TodoListDatabase.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        string name = "Sarah";

        IRegister register = new RegisterUser();
        ITodo todo = new TodoUser();
        ILogin login = new LoginUser();

        // register.register(["2", GenerateHash(name, "5"), name, "az@gmail.com", "Password"]);

        // Console.WriteLine("Success Register");


        // Console.WriteLine("Success Create Task");

        // todo.changeTodo(1, "Mamah juga takut");

        // todo.isDoneTodo(1);
        // Console.WriteLine("Success Doned");


        // login.login("az@gmail.com", "Password");

        // todo.addTodo(["", GenerateHash(Temp.user.Username, "5"), "Kakak Juga Takut"]);




        // todo.getAllTodo();

        foreach (var item in Temp.tasks)
        {
            Console.WriteLine(item.Task);
        }

    }

    
}