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
            for (int i = 0; i < 43; i++)
            {
                Console.WriteLine();
            }
            Console.Write("###########################################");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("PRESS ENTER");
            //Console.WriteLine("PROJECT BY GROUP SERPENT FLY");
        }
    }
}
