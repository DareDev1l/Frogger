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
    using System.Runtime.Serialization.Formatters.Binary;


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
            int speed = 30;
            int startReach = 0;

            Frog newFrog = new Frog(Environment.MachineName, 0);
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

            //Bridges
            Bridge firstBridge = new Bridge();
            Bridge secondBridge = new Bridge();

            // Frogs that are displayed when frog reaches top
            StringBuilder frogsAtTheTop1 = new StringBuilder();
            StringBuilder frogsAtTheTop2 = new StringBuilder();
            StringBuilder frogsAtTheTop3 = new StringBuilder();

            // Lifes info
            StringBuilder infoLives = new StringBuilder();
            infoLives.Append("Lives: ");
            infoLives.Append(newFrog.LivesLeft);

            // Read music file
            try
            {
                string musicFilePath = Path.GetFullPath(@"..\..\music.wav");
                var music = new SoundPlayer(musicFilePath);
                music.PlayLooping();

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Music file not available");
            }
 
            Menu.DrawMenu();
            while (true)
            {
                ConsoleKeyInfo choice = Console.ReadKey();
                if (choice.Key == ConsoleKey.D1 || choice.Key == ConsoleKey.Enter)
                {                   
                    break;
                }
                else if (choice.Key == ConsoleKey.D2)
                {
                    // Show highscore
                    Console.Clear();
                    try
                    {
                        using (Stream stream = File.Open("data.txt", FileMode.Open))
                        {
                            BinaryFormatter bin = new BinaryFormatter();
                            var frogs2 = (List<Frog>) bin.Deserialize(stream);
                            int a = 0;
                            int cursorline = 2;
                            Console.SetCursorPosition(45, 0);
                            Console.WriteLine("HIGHSCORES");
                            foreach (Frog frog in frogs2)
                            {
                                a++;
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.SetCursorPosition(40, cursorline);
                                cursorline += 2;
                                Console.WriteLine("{0}.{1} has {2} points",a ,frog.Name, frog.Score);
                            }                            
                        }
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("Error: File not found");
                    }
                    catch
                    {
                        Console.WriteLine("Highscore cannot be visualized");
                    }
                }
                else if (choice.Key == ConsoleKey.D3)
                {
                    // Show credits
                    Console.Clear();
                    Console.WriteLine("Project made for TELERIK Academy by: Team SERPENT FLY");
                    Console.WriteLine("The contributors of this project are: ");
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Radostin Angelov, Teodor Hanev, Nikolai Mishev,");
                    Console.WriteLine("Liubomir Svilenov, Ivan Vasilev, Krasimir Stoyanov,");
                    Console.WriteLine("Konstantin Malinov, Dobromira Boytcheva and Silvia Ivanova");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Thank you for playing and have a nice day!");
                }
                else if (choice.Key == ConsoleKey.D4)
                {
                    // Show Rules
                    Console.Clear();
                    Console.Write(new string(' ', 46));
                    Console.WriteLine("Rules:");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Help the froggie cross the busy road and navigate it to a calmer " +
                                      "and safer place – the wonderful \nhome swamp, at the top of the " +
                                      "screen! \nYou guide the frog using the following navigation keys: \"↑\"" +
                                      " for up, \"↓\" - down, \"←\" - left, and \n\"→\" - right, and each "+
                                      "pressing of the respective key of direction causes the frog to hop " +
                                      "once in \nthat direction. \n\nThe game starts at the bottom of the " +
                                      "screen. In general the screen is divided in two: the lower and the " +
                                      "upper halves of it represent a heavy traffic road with various motor" +
                                      " vehicles: cars, trucks, \nbuses, which move at different speeds. " +
                                      "There are also tunnels and bridges, on which the frog can't \njump " +
                                      "and must go around them. So your job is not an easy task! The froggie" +
                                      " should pass through that traffic chaos in attempt to reach the upper" +
                                      " part of the screen. In the middle of the play area is a \"Safe Zone\"" +
                                      " – a place where the little frog can have some rest before continuing " +
                                      "its dangerous \njourney. The frog has only three lives! If it gets hit" +
                                      " by a vehicle, the frog remains with one life less. And when the " +
                                      "froggie is run over by a vehicle three times – the game is over." +
                                      "\n\nEnjoy the game!");
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
                // Bridges
                firstBridge.FirstBridge();
                firstBridge.DrawBridge(12, 59);
                secondBridge.SecondBridge();
                secondBridge.DrawBridge(36, 60);
                // Right cars
                firstRightCar.MoveRight(17);
                firstRightCar.CheckCrash(newFrog, 42, 6);
                firstRightCar.DrawCar(42);
                secondRightCar.MoveRight(17);
                secondRightCar.DrawCar(36);
                secondRightCar.CheckCrash(newFrog, 36, 16);
                thirdRightCar.DrawCar(30);
                thirdRightCar.CheckCrash(newFrog, 30, 10);
                thirdRightCar.MoveRight(28);
                fourthRightCar.DrawCar(21);
                fourthRightCar.CheckCrash(newFrog, 21, 10);
                fourthRightCar.MoveRight(11);
                fifthRightCar.DrawCar(15);
                fifthRightCar.CheckCrash(newFrog, 15, 16);
                fifthRightCar.MoveRight(30);
                sixthRightCar.DrawCar(9);
                sixthRightCar.CheckCrash(newFrog, 9, 6);
                sixthRightCar.MoveRight(6);
                //Tunnels
                firstTunnel.FirstCarTunnel();
                firstTunnel.DrawFirstTunnel(42, 12);
                secondTunnel.SecondCarTunnel();
                secondTunnel.DrawFirstTunnel(30, 19);
                thirdTunnel.SecondCarTunnel();
                thirdTunnel.DrawFirstTunnel(15, 19);
                // Left cars
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
        public static int speed = 1;
        private static void DrawStats(int level, int lives, int score)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("{0}{3}{1}{3}{1}{3}{2}", '┌', '┬', '┐', new string('─', 25));
            Console.SetCursorPosition(10, 1);
            Console.Write("{0}{1}{2}{0}{3}", '|', "SPEED:".PadLeft(13), speed.ToString().PadRight(12), "LIVES:".PadLeft(13));
            if (lives == 1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
            }
            else if (lives == 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else if (lives >= 3)
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
