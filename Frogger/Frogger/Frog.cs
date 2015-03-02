using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Frogger
{
    public class Frog
    {
        private int x = Console.BufferWidth / 2;
        private int y = Console.BufferHeight - 4;
        // Model of the frog
        private string[] frogFace = 
                                {
                                 " @ @ ",
                                 "\\(_)/",
                                 " \\ / "
                                };

        private int livesLeft;
        private int home;
        private int score;
        public int ReachedTop = 0;
        public int speed = 30;

        public Frog()
        {
            this.Score = 0;
            this.LivesLeft = 3;
            this.WasInSafeZone = false;
        }
       
        
        public string[] FrogFace
        {
            get { return this.frogFace; }
        }

        public int LivesLeft { get; set; }
        public int Score { get; set; }

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
            get { return livesLeft; }
            set
            {
                if(this.livesLeft<0)
                {

                }
                else
                {
                    this.livesLeft = value;
                }
            }
        }

        public bool WasInSafeZone { get; set; }
        public int Home
        {
            get { return score; }
            set { score = value; }
        }
        public void Move()
        {
            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                
                // If upper arrow is pressed
                if (key.Key == ConsoleKey.UpArrow && this.y > 0)
                {
                    if (!(this.y == 45 && this.x > 84) && !(this.y == 33 && this.x > 76) && !(this.y == 18 && this.x > 76))
                    {
                        this.y -= 3;
                        if (this.y == 3)
                        {
                            ReachedTop++;
                            x = Console.BufferWidth / 2;
                            y = Console.BufferHeight - 4;
                        }
                    }
                }
                // If down arrow is pressed
                else if (key.Key == ConsoleKey.DownArrow && this.y < Console.BufferHeight - 4)
                {
                    if (!(this.y == 39 && this.x > 84) && !(this.y == 27 && this.x > 76) && !(this.y == 12 && this.x > 76))
                    {
                        this.y += 3;
                    }
                }
                // If left arrow is pressed
                else if (key.Key == ConsoleKey.LeftArrow && this.x > 2)
                {
                    this.x -= 5;
                }
                // If right arrow is pressed
                else if (key.Key == ConsoleKey.RightArrow && this.x < Console.BufferWidth - 8)
                {
                    if (!(this.y == 42 && this.x > 79) && !(this.y == 30 && this.x > 73) && !(this.y == 15 && this.x > 73))
                    {
                        this.x += 5;
                    }
                }
            }
        }

        // Draws the frog
        public void Draw()
        {
            int yPos = this.y;
            for (int row = 0; row < frogFace.Length; row++)
            {
                if (y == 24)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                Console.SetCursorPosition(this.x, yPos);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(frogFace[row]);
                Console.ResetColor();
                yPos++;
            }
        }

    }
}
