using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Frogger
{
    //here the game starts and ends, here we call all other stuff
    class Engine
    {
        public static void Main()
        {
            Console.WindowWidth = 100;
            Console.WindowHeight = 49;
            Console.BufferHeight = 49;
            Console.BufferWidth = 100;
            string file_path = @"D:\Telerik Team Projects\C# 2 Team Project Copy\C-Sharp-2-Group-Project\Frogger\Frogger\HighScore.txt";
            int speed = 30;
            Frog newFrog = new Frog() { Score = 0, LivesLeft = 3 };
            Car newCar = new Car();
            Car secondNewCar = new Bus();
            Car thirdNewCar = new Truck();
            Car firstLeftCar = new Bus();
            Car secondLeftCar = new Car();
            Car thirdLeftCar = new Truck();


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
            Console.ReadLine();
            int startReach = 0;

            StringBuilder frogsAtTheTop1 = new StringBuilder();
            StringBuilder frogsAtTheTop2 = new StringBuilder();
            StringBuilder frogsAtTheTop3 = new StringBuilder();
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                                                                                            ");
                Console.SetCursorPosition(0, 1);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                                                                                        ");
                Console.SetCursorPosition(0, 2);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.WriteLine("                                                                                                    ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(frogsAtTheTop1.ToString());
                Console.WriteLine(frogsAtTheTop2.ToString());
                Console.WriteLine(frogsAtTheTop3.ToString());
                Console.ResetColor();
                newFrog.Move();
                newCar.Move(7);
                newCar.CheckCrash(newFrog, 42, 6);
                newFrog.Draw();
                newCar.DrawCar(42);
                secondNewCar.Move(17);
                secondNewCar.DrawCar(36);
                secondNewCar.CheckCrash(newFrog, 36, 16);
                thirdNewCar.DrawCar(30);
                thirdNewCar.CheckCrash(newFrog, 30, 10);
                thirdNewCar.Move(11);
                firstLeftCar.DrawCar(27);
                firstLeftCar.CheckCrash(newFrog, 27, 16);
                firstLeftCar.FirstLeftCarMovement(17);
                secondLeftCar.DrawCar(33);
                secondLeftCar.FirstLeftCarMovement(7);
                secondLeftCar.CheckCrash(newFrog, 33, 6);
                thirdLeftCar.DrawCar(39);
                thirdLeftCar.FirstLeftCarMovement(11);
                thirdLeftCar.CheckCrash(newFrog, 39, 10);
                Thread.Sleep(speed);
                //check if the frog reasched the top and print a frog at the top 
                
                if (newFrog.ReachedTop > startReach)
                {
                    switch (startReach)
                    {
                        case 0:
                            frogsAtTheTop1.Append("           @ @  - Mmm!");
                            frogsAtTheTop2.Append("          \\(_)/");
                            frogsAtTheTop3.Append("           \\ / ");
                            break;
                        case 1:
                            frogsAtTheTop1.Append("       @ @  - O Yeah!");
                            frogsAtTheTop2.Append("             \\(_)/");
                            frogsAtTheTop3.Append("              \\ / ");
                            break;
                        case 2:
                             frogsAtTheTop1.Append("    @ @  - Keep");
                            frogsAtTheTop2.Append("             \\(_)/ going!");
                            frogsAtTheTop3.Append("              \\ / ");
                            break;
                        case 3:
                             frogsAtTheTop1.Append("     @ @  - One More");
                            frogsAtTheTop2.Append("    \\(_)/ and you're");
                            frogsAtTheTop3.Append("            \\ /   done!");
                            break;
                    }


                    startReach++;
                }

                if (newFrog.LivesLeft == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    string[,] gameOver = new string[,]
                {
                    {"                                                         ","          .-'''-.                                           "},
                    {"                                                         ","         '   _    \\                                         "},
                    {"                  __  __   ___        __.....__          ","      /   /` '.   .----.     .----.  __.....__              "},
                    {"  .--.           |  |/  `.'   `.  .-''         '.        ","     .   |     \\  '\\    \\   /    .-''         '.            "},
                    {" /.''\\          |   .-.  .-.   '/     .-''\"'-.  `.      ","     |   '      |  ''   '. /'   /     .-''\"'-.  `..-,.--.   "},
                    {"| |  | |     __  |  |  |  |  |  /     /________\\   \\     ","     \\    \\     / / |    |'    /     /________\\   |  .-. |  "},
                    {" \\`-' /   .:--.'.|  |  |  |  |  |                  |     ","      `.   ` ..' /  |    ||    |                  | |  | |  "},
                    {" /(\"'`   / |   \\ |  |  |  |  |  \\    .-------------'     ","         '-...-'`   '.   `'   .\\    .-------------| |  | |  "},
                    {" \\ '---. `\" __ | |  |  |  |  |  |\\    '-.____...---.     ","                     \\        / \\    '-.____...---| |  '-   "},
                    {"  /'\"\"'.\\ .'.''| |__|  |__|  |__| `.             .'      ","                      \\      /   `.             .'| |       "},
                    {" ||     |/ /   | |_                 `''-...... -'        ","                       '----'      `\\''-...... -' | |       "},
                    {" \\'. __//\\ \\._,\\ '/                                      ","                                                  |_|       "},
                    {"  `'---'  `--'  `\"                                       ","                                                            "}
                };
                    for (int row = 0; row < gameOver.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameOver.GetLength(1); col++)
                        {
                            if (col % 2 == 0)
                                Console.WriteLine(gameOver[row, col].PadLeft(80, ' '));
                        }

                    }
                    Console.WriteLine();
                    for (int row = 0; row < gameOver.GetLength(0); row++)
                    {
                        for (int col = 0; col < gameOver.GetLength(1); col++)
                        {
                            if (col % 2 != 0)
                                Console.WriteLine(gameOver[row, col].PadLeft(80, ' '));
                        }

                    }
                    Console.WriteLine();
                    return;

                }
                else if (newFrog.ReachedTop == 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    string[] levelComplete = new string[]
            {
            @"             .__                         .__                ",
            @"             |  |    ____ ___  __  ____  |  |               ",
            @"             |  |  _/ __ \\  \/ /_/ __ \ |  |               ",
            @"             |  |__\  ___/ \   / \  ___/ |  |__             ",
            @"             |____/ \___  > \_/   \___  >|____/             ",
            @"                        \/            \/                    ",
            @"                                .__            __           ",
            @"  ____   ____    _____  ______  |  |    ____ _/  |_   ____  ",
            @"_/ ___\ /  _ \  /     \ \____ \ |  |  _/ __ \\   __\_/ __ \ ",
            @"\  \___(  <_> )|  Y Y  \|  |_> >|  |__\  ___/ |  |  \  ___/ ",
            @" \___  >\____/ |__|_|  /|   __/ |____/ \___  >|__|   \___  >",
            @"     \/              \/ |__|               \/            \/ "
            };
                    string[] gameName = new string[]
            {
                @"  .----------------------------------------------------------------.  ",
                @" /  .-.    ______ _____   ____   _____  _____ ______ _____     .-.  \ ",
                @"|  /   \  |  ____|  __ \ / __ \ / ____|/ ____|  ____|  __ \   /   \  |",
                @"| |\_.  | | |__  | |__) | |  | | |  __| |  __| |__  | |__) | |    /| |",
                @"|\|  | /| |  __| |  _  /| |  | | | |_ | | |_ |  __| |  _  /  |\  | |/|",
                @"| `---' | | |    | | \ \| |__| | |__| | |__| | |____| | \ \  | `---' |",
                @"|       | |_|    |_|  \_\\____/ \_____|\_____|______|_|  \_\ |       |",
                @"|       |----------------------------------------------------|       |",
                @"\       |                                                    |       /",
                @" \     /                                                      \     / ",
                @"  `---'                                                        `---'  ",  
            };
                    foreach (var text in levelComplete)
                    {
                        Console.WriteLine(text.PadLeft(80, ' '));
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (var text in gameName)
                    {
                        Console.WriteLine(text.PadLeft(80, ' '));
                    }
                    return;
                }

            }
        }
    }
}