using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

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
            int speed = 30;
            Frog newFrog = new Frog();
            Car newCar = new Car();
            Car secondNewCar = new Car();
            Car thirdNewCar = new Car();
            Car firstLeftCar = new Car();


            while (true)
            {
                Console.Clear();
                newFrog.Move();
                newCar.Move(7);
                newCar.CheckCrash(newFrog, 42, 6);
                newFrog.Draw();
                newCar.DrawCar(42);
                secondNewCar.SecondCarMovement(17);
                secondNewCar.DrawCar(36);
                secondNewCar.CheckCrash(newFrog, 36, 16);
                thirdNewCar.DrawCar(30);
                thirdNewCar.CheckCrash(newFrog, 30, 10);
                thirdNewCar.ThirdCarMovement(11);
                firstLeftCar.DrawLeftCar(27);
                firstLeftCar.CheckCrash(newFrog, 27, 16);
                firstLeftCar.FirstLeftCarMovement(17);
                Thread.Sleep(speed);
            }

            //List<Car> cars = new List<Car>();
            //Random randomGenerator = new Random();
            //cars.Add(new Car(30, 20));
            //cars.Add(new Car(60, 40));
            //foreach (var car in cars)
            //{
            //    car.RenderCar();
            //}
            //Frog frog = new Frog(Console.WindowHeight - 4, Console.WindowWidth / 2);
            //frog.Draw();
            //frog.Lives = 3;
            //frog.Home = 0;
            //while (frog.Lives != 0)
            //{
            //    Console.Clear();
            //    newFrog.Move();
            //    newCar.Move();
            //    newCar.CheckCrash(newFrog);
            //    newFrog.Draw();
            //    newCar.Draw();
            //    Thread.Sleep(speed);
            //    if (frog.Home == 3)
            //    {
            //        break;
            //    }
            //}
            //if (frog.Lives == 0)
            //{
            //    Console.WriteLine("GAME OVER", 48, ConsoleColor.Red);

            //}
            //else
            //{
            //    Console.WriteLine("LEVELE COMPLETE", 48, ConsoleColor.Red);
            //}

        }

    }
}
