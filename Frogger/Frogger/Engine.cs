using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace Frogger
{
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
            Frog newFrog = new Frog() { Score = 0, LivesLeft = 3 };
            Car newCar = new Car();
            Car secondNewCar = new Bus();
            Car thirdNewCar = new Truck();
            Car firstLeftCar = new Bus();
            Car secondLeftCar = new Car();
            Car thirdLeftCar = new Truck();
            Car firstInnerCar = new Car(0,55);


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
                FrogFinishes.ConsoleFill(frogsAtTheTop1,frogsAtTheTop2, frogsAtTheTop3);
                newFrog.Move();
                newCar.Move(7);
                newCar.CheckCrash(newFrog, 42, 6);
                newFrog.Draw();
                newCar.DrawCar(42);
                // Inner car
                firstInnerCar.DrawCar(42, 10);
                firstInnerCar.CheckCrash(newFrog, 42, 6, 10);
                firstInnerCar.Move(17);
                // Inner car end
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
                // Check if the frog reached the top and print a frog at the top 
                FrogFinishes.FrogAtTop(newFrog, ref startReach, frogSound, frogsAtTheTop1, frogsAtTheTop2, frogsAtTheTop3);
                // Check if the frog has lost all lifes or won the game
                FrogFinishes.WinOrLose(newFrog);
            }
        }
    }
}
