using System.Security.Cryptography;
using TodoListDatabase.Controllers;
using TodoListDatabase.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        string name = "Dest";

        IRegister register = new RegisterUser();
        ITodo todo = new TodoUser();

        // register.register(["1", GenerateHash(name, "5"), name, "azkadaiki26@gmail.com", "Password"]);

        // Console.WriteLine("Success Register");

        // todo.addTodo(["", GenerateHash(name, "5"), "Mamah Aku takut"]);

        // Console.WriteLine("Success Create Task");

        // todo.changeTodo(1, "Mamah juga takut");

        todo.isDoneTodo(1);
        Console.WriteLine("Success Doned");




    }

    private static string GenerateHash(string value, string salt)
    {
        byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
        data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
        return Convert.ToBase64String(data);
    }
}