using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListDatabase.Utilities
{
    public enum FontTheme
    {
        DEFAULT,
        DANGER,
        SUCCESS
    }
    public static class CommonOutputFormat
    {
        public static void ChangeFontColor(FontTheme theme)
        {
            switch (theme)
            {
                case FontTheme.DANGER:
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                case FontTheme.SUCCESS:
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    break;

                default:
                    Console.ResetColor();
                    break;
            }


        }
    }
}
