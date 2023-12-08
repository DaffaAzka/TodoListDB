using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListDatabase.FieldValidators;

namespace TodoListDatabase.Utilities
{
    public static class InputUtil
    {
        public static string GetInputUser(string prompt)
        {
            string field = "";

            Console.Write(prompt);
            field = Console.ReadLine();

            return field;
        }

        public static string GenerateHash(string value, string salt)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(salt + value);
            data = System.Security.Cryptography.MD5.Create().ComputeHash(data);
            return Convert.ToBase64String(data);
        }
    }
}
