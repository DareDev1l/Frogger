namespace Frogger
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Threading;
    using System.IO;
    using System.Media;
    using Frogger.Enemies;

    //here the game starts and ends, here we call all other stuff
    public class Engine
    {
        public static void Main()
        {
            string fullPath = Path.GetFullPath(@"..\..\Frog Sound.wav");
            SoundPlayer frogSound = new SoundPlayer(fullPath);
            Console.WindowWidth = 100;
            Console.WindowHeight = 49;
            Console.BufferHeight = 49;
            Console.BufferWidth = 100;
            string file_path = @"D:\Telerik Team Projects\C# 2 Team Project Copy\C-Sharp-2-Group-Project\Frogger\Frogger\HighScore.txt";
            int speed = 30;
            int startReach = 0;

            Frog newFrog = new Frog();

            // Cars coming from right
            Enemy firstRightCar = new Car();
            Enemy secondRightCar = new Bus();
            Enemy thirdRightCar = new Truck();
            Enemy fourthRightCar = new Truck();
            Enemy fifthRightCar = new Bus();
            Enemy sixthRightCar = new Car();

            // Cars coming from left
            Enemy firstLeftCar = new Bus();
            Enemy secondLeftCar = new Car();
            Enemy thirdLeftCar = new Truck();
            Enemy fourthLeftCar = new Car();
            Enemy fifthLeftCar = new Truck();
            Enemy sixthLeftCar = new Bus();

            // Tunnels
            Tunnel firstTunnel = new Tunnel();
            Tunnel secondTunnel = new Tunnel();
            Tunnel thirdTunnel = new Tunnel();

            // Frogs that are displayed when frog reaches top
            StringBuilder frogsAtTheTop1 = new StringBuilder();
            StringBuilder frogsAtTheTop2 = new StringBuilder();
            StringBuilder frogsAtTheTop3 = new StringBuilder();

            // Lifes info
            StringBuilder infoLives = new StringBuilder();
            infoLives.Append("Lives: ");
            infoLives.Append(newFrog.LivesLeft);


            //      //Makes an Instance of the HighScore Class
            //      var scores = new HighScores("1.Peshoo 250").ReadScoresFromFile(file_path);
            //      scores.ForEach(s => Console.WriteLine(s));
            //      //NOT WORKING, MUST BE FIXED -> Adds the new Highscore to the Highscores text file
            //      using (FileStream fs = File.Open(file_path, FileMode.Open, FileAccess.Write, FileShare.None))
            //      {
            //          StreamWriter sw = new StreamWriter(fs);
            //          sw.WriteLine("Chesho 2000");
            //      }

            Menu.DrawMenu();
            while(true)
            {
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.D1 || choice.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (choice.Key == ConsoleKey.D2)
                {
                    // Show highscore
                }
                else if (choice.Key == ConsoleKey.D3)
                {
                    // Show credits
                }
                else if (choice.Key == ConsoleKey.D4)
                {
                    // Show Rules
                }
                else if (choice.Key == ConsoleKey.D5 || choice.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(1);
                }
                else
                {
                    Menu.DrawMenu();
                }
            }
          

            while (true)
            {
                Console.Clear();
                FrogFinishes.ConsoleFill(frogsAtTheTop1, frogsAtTheTop2, frogsAtTheTop3);
                newFrog.Move();
                newFrog.Draw();
                firstRightCar.MoveRight(17);
                firstRightCar.CheckCrash(newFrog, 42, 6);
                firstRightCar.DrawCar(42);
                secondRightCar.MoveRight(17);
                secondRightCar.DrawCar(36);
                secondRightCar.CheckCrash(newFrog, 36, 16);
                thirdRightCar.DrawCar(30);
                thirdRightCar.CheckCrash(newFrog, 30, 10);
                thirdRightCar.MoveRight(30);
                fourthRightCar.DrawCar(21);
                fourthRightCar.CheckCrash(newFrog, 21, 10);
                fourthRightCar.MoveRight(11);
                fifthRightCar.DrawCar(15);
                fifthRightCar.CheckCrash(newFrog, 15, 16);
                fifthRightCar.MoveRight(30);
                sixthRightCar.DrawCar(9);
                sixthRightCar.CheckCrash(newFrog, 9, 6);
                sixthRightCar.MoveRight(6);
                //TUNNEL DRAW
                firstTunnel.FirstCarTunnel();
                firstTunnel.DrawFirstTunnel(42, 12);
                secondTunnel.SecondCarTunnel();
                secondTunnel.DrawFirstTunnel(30, 19);
                thirdTunnel.SecondCarTunnel();
                thirdTunnel.DrawFirstTunnel(15, 19);
                // Inner car
                //firstInnerCar.DrawCar(42);
                //firstInnerCar.CheckCrash(newFrog, 42, 6);
                //firstInnerCar.Move(17);
                // Inner car end
                firstLeftCar.DrawCar(27);
                firstLeftCar.CheckCrash(newFrog, 27, 16);
                firstLeftCar.MoveLeft(17);
                secondLeftCar.DrawCar(33);
                secondLeftCar.MoveLeft(7);
                secondLeftCar.CheckCrash(newFrog, 33, 6);
                thirdLeftCar.DrawCar(39);
                thirdLeftCar.MoveLeft(11);
                thirdLeftCar.CheckCrash(newFrog, 39, 10);
                fourthLeftCar.DrawCar(18);
                fourthLeftCar.CheckCrash(newFrog, 18, 6);
                fourthLeftCar.MoveLeft(7);
                fifthLeftCar.DrawCar(12);
                fifthLeftCar.CheckCrash(newFrog, 12, 10);
                fifthLeftCar.MoveLeft(11);
                sixthLeftCar.DrawCar(6);
                sixthLeftCar.CheckCrash(newFrog, 6, 16);
                sixthLeftCar.MoveLeft(17);

                DrawStats(1, newFrog.LivesLeft, newFrog.Score);

                FrogFinishes.FrogAtSafeZone(newFrog);
                // Check if the frog reached the top and print a frog at the top 
                FrogFinishes.FrogAtTop(newFrog, ref startReach, frogSound, frogsAtTheTop1, frogsAtTheTop2, frogsAtTheTop3);
                // Check if the frog has lost all lifes or won the game
                FrogFinishes.WinOrLose(newFrog);
                Thread.Sleep(newFrog.speed);
            }
        }

        private static void DrawStats(int level, int lives, int score)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '┌', '┬', '┐', new string('─', 25));
            Console.SetCursorPosition(10, 1);
            Console.Write("{0}{1}{2}{0}{3}", '|', "LEVEL:".PadLeft(13), level.ToString().PadRight(12), "LIVES:".PadLeft(13));
            if (lives == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (lives == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (lives == 3)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.SetCursorPosition(51, 1);
            for (int i = 0; i < lives; i++)
            {
                Console.Write("♥" + " ");
            }

            Console.SetCursorPosition(62, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("{0}{1}{2}{0}", '|', "SCORE:".PadLeft(13), score.ToString().PadRight(12));
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '└', '┴', '┘', new string('─', 25));
        }
    }
}
