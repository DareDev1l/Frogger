using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

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
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Safe                                                                                            Safe");
            Console.SetCursorPosition(0, 25);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                                                                                                    ");
            Console.SetCursorPosition(0, 26);
            Console.BackgroundColor = ConsoleColor.DarkYellow;
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
                frogSound.Play();
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
                newFrog.speed -= 5;
                startReach++;
            }
        }

        public static void WinOrLose(Frog newFrog)
        {
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
                Environment.Exit(0);
            }
        }
    }
}
