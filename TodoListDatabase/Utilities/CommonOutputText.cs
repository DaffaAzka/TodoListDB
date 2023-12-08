using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Utilities
{
    public static class CommonOutputText
    {
        private static string MainHeading
        {
            get
            {
                string heading = "Todolist Database";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string RegisterHeading
        {
            get
            {
                string heading = "Register";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        private static string LoginHeading
        {
            get
            {
                string heading = "Login";
                return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
            }
        }

        public static void WriteLineMainHeading()
        {
            Console.Clear();
            Console.WriteLine(MainHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteLineRegisterHeading()
        {
            Console.Clear();
            Console.WriteLine(RegisterHeading);
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void WriteLineLoginHeading()
        {
            Console.Clear();
            Console.WriteLine(LoginHeading);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
