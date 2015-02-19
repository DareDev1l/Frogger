using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Frog
    {
        private int x = Console.BufferWidth / 2;
        private int y = Console.BufferHeight - 4;
        private string[] humanFace = 
                                {
                                 "_ _",
                                 "o.o",
                                 "\\-/"
                                };
        public string[] HumanFace
        {
            get { return this.humanFace; }
        }

        public Frog()
        {
            
        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public void Move()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.UpArrow && this.y > 0)
                {
                    this.y -= 3;
                }
                else if (key.Key == ConsoleKey.DownArrow && this.y < Console.BufferHeight - 4)
                {
                    this.y += 3;
                }
                else if (key.Key == ConsoleKey.LeftArrow && this.x > 1)
                {
                    this.x -= 3;
                }
                else if (key.Key == ConsoleKey.RightArrow && this.x < Console.BufferWidth - 4)
                {
                    this.x += 3;
                }
            }
        }

        public void Draw()
        {
            int yPos = this.y;
            for (int row = 0; row < humanFace.Length; row++)
            {
                Console.SetCursorPosition(this.x, yPos);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(humanFace[row]);
                Console.ResetColor();
                yPos++;
            }
        }

    }
}
