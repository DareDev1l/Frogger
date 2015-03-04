using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Frogger
{
    public class FrogFinishes
    {
        public static void ConsoleFill(StringBuilder frogsAtTheTop1, StringBuilder frogsAtTheTop2, StringBuilder frogsAtTheTop3)
        {
            // 
            Console.SetCursorPosition(0, 3);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                     ");
            Console.SetCursorPosition(0, 4);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                    ");
            Console.SetCursorPosition(0, 5);
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("                                                                                                    ");
            // The safe zone
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(0, 24);
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Safe                                                                                            Safe");
            Console.SetCursorPosition(0, 25);
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("                                                                                                    ");
            Console.SetCursorPosition(0, 26);
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("Zone!                                                                                          Zone!");
            //
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 3);
            Console.WriteLine(frogsAtTheTop1.ToString());
            Console.WriteLine(frogsAtTheTop2.ToString());
            Console.WriteLine(frogsAtTheTop3.ToString());
            Console.ResetColor();
        }

        public static void FrogAtTop(Frog newFrog, ref int startReach, SoundPlayer frogSound, StringBuilder frogsAtTheTop1, StringBuilder frogsAtTheTop2, StringBuilder frogsAtTheTop3)
        {
            if (newFrog.ReachedTop > startReach)
            {
                //frogSound.Play();
                newFrog.Score += 100;
                newFrog.WasInSafeZone = false;

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
                newFrog.speed -= 3;
                startReach++;
                Engine.speed++;
            }
        }

        public static void FrogAtSafeZone(Frog frog)
        {
            if (frog.Y == 24)
            {
                if (frog.WasInSafeZone == false)
                {
                    frog.WasInSafeZone = true;
                    frog.Score += 50;
                }
            }
        }

        public static void WinOrLose(Frog newFrog)
        {
            if (newFrog.LivesLeft == 0 && newFrog.Score != 0)
            {
                List<Frog> frogs = new List<Frog>();
                frogs.Add(new Frog("Alexander", 500));
                frogs.Add(new Frog("Ivan", 450));
                frogs.Add(new Frog("Pesho", 250));
                frogs.Add(new Frog("Gosho", 200));
                frogs.Add(new Frog(newFrog.Name, newFrog.Score));
                List<Frog> SortedList = frogs.OrderByDescending(o => o.Score).ToList();

                try
                {
                    using (Stream stream = File.Open("data.txt", FileMode.Create))
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        bin.Serialize(stream, SortedList);
                    }
                }
                catch (IOException)
                {
                }
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
                Environment.Exit(0);

            }
            else if (newFrog.ReachedTop == 5)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                string[] levelComplete = new string[]
                    {
                    @"           _____                                            ",
                    @"          / ____\    __     _____    ____                   ",
                    @"         / /  ____  /  \   /     \ _/ __ \                  ",
                    @"         \ \___/ / /_--_\ |  Y Y  \\  ___/                  ",
                    @"          \_____/ /_/  \_\|__|_|  / \___  >                 ",
                    @"                                \/      \/                  ",
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
                Environment.Exit(0);
            }
        }
    }
}
