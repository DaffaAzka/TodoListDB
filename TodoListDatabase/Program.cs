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
        Factory.GetMainObjectView().RunView();

    }


}