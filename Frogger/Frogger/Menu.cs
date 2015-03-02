using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Menu
    {
        public static void DrawMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            PictureGenerator.StartScreen();
            for (int i = 0; i < 40; i++)
            {
                Console.WriteLine();
            }
            Console.Write("###########################################");
            Console.ForegroundColor = ConsoleColor.White;
            // Start game 
            Console.Write("1.START GAME");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("###########################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("2.HIGHSCORES");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.Write("###########################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("3.CREDITS");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("###########################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("4.RULES");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine();
            Console.Write("###########################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("5.EXIT");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("####################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("PROJECT BY TEAM SERPENT FLY");
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
