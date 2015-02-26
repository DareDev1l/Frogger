using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Menu
    {
        static void DrawMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Start Game");
            Console.SetCursorPosition(20,20);
            Console.WriteLine("PROJECT BY GROUP SERPENT FLY");
            Console.WriteLine();
        }
    }
}
