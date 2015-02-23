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
        private string[] frogFace = 
                                {
                                 " @ @ ",
                                 "\\(_)/",
                                 " \\ / "
                                };

        private int lives;
        private int home;
        private int points;
        public string[] FrogFace
        {
            get { return this.frogFace; }
        }

        public Frog(int x,int y)
        {
            this.x = x;
            this.y = y;
        }

        public Frog()
        {
            // TODO: Complete member initialization
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
        public int Lives
        {
            get { return lives; }
            set
            {
                if(this.lives<0)
                {

                }
                else
                {
                    this.lives = value;
                }
            }
        }
        public int Home
        {
            get { return points; }
            set { points = value; }
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
                else if (key.Key == ConsoleKey.LeftArrow && this.x > 2)
                {
                    this.x -= 5;
                }
                else if (key.Key == ConsoleKey.RightArrow && this.x < Console.BufferWidth - 8)
                {
                    this.x += 5;
                }
            }
        }

        public void Draw()
        {
            int yPos = this.y;
            for (int row = 0; row < frogFace.Length; row++)
            {
                Console.SetCursorPosition(this.x, yPos);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(frogFace[row]);
                Console.ResetColor();
                yPos++;
            }
        }

    }
}
