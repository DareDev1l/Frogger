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


            while (true)
            {
                Console.Clear();
                newFrog.Move();
                newCar.Move();
                newCar.CheckCrash(newFrog);
                newFrog.Draw();
                newCar.Draw();
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
