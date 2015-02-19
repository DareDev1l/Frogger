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
            
            
            //while (true)
            //{
            //    Console.Clear();
            //    newFrog.Move();
            //    newFrog.Draw();
            //    Thread.Sleep(80);
            //}

        }
    }
}