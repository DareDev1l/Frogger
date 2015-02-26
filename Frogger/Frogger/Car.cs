using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Car
    {
        public static string fullPath = Path.GetFullPath(@"..\..\crash.wav");
        SoundPlayer crashSound = new SoundPlayer(fullPath);

        private int x = Console.BufferWidth / 2;
        private int y = Console.BufferHeight;
        public StringBuilder carFirstRow;
        public StringBuilder carSecondRow;
        public StringBuilder carThirtRow;
        private int row;
        private int coll;
        private int p1;
        private int p2;

        public int Row
        {
            get { return this.row; }
            set
            { this.row = value; }
        }
        public int Coll
        {
            get { return coll; }
            set
            { this.coll = value; }
        }


        public Car()
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
        }

        public Car(int p1, int p2)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
        }

        public virtual void RenderCar()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("______");
                carSecondRow.Append("[][][]");
                carThirtRow.Append("-0--0-");
            }
        }

        public virtual void DrawCar(int n)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(this.Coll, this.Row + (n));
            Console.WriteLine(this.carFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + (n + 1));
            Console.WriteLine(this.carSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + (n + 2));
            Console.WriteLine(this.carThirtRow.ToString());
            Console.ResetColor();
        }

        public virtual void Move(int n)
        {
            this.Coll++;
            if (this.Coll + n >= Console.BufferWidth + 2)
            {
                this.carFirstRow.Remove(this.carFirstRow.Length - 1, 1);
                this.carSecondRow.Remove(this.carSecondRow.Length - 1, 1);
                this.carThirtRow.Remove(this.carThirtRow.Length - 1, 1);
            }
            if (this.carThirtRow.Length == 0)
            {
                this.RenderCar();
                this.Coll = 0;
            }
        }
        //Movement for the cars coming from right to left
        public virtual void FirstLeftCarMovement(int n)
        {
            this.Coll--;
            if (this.Coll - n >= Console.BufferWidth + 2)
            {
                this.carFirstRow.Remove(this.carFirstRow[0] + 1, -1);
                this.carSecondRow.Remove(this.carSecondRow[0] + 1, -1);
                this.carThirtRow.Remove(this.carThirtRow[0] + 1, -1);
            }
            if (this.carThirtRow.Length == 0 || this.Coll == 0)
            {
                RenderCar();
                this.Coll = 100 - carFirstRow.Length;
            }
        }

        //This method checks whether the frog will crash in a vehicle. It's not optimised but works
        public void CheckCrash(Frog frog, int n, int m)
        {
            if (frog.X >= this.Coll - 4 && frog.X <= this.Coll + m && frog.Y == this.Row + n)
            {
                crashSound.Play();
                frog.X = Console.BufferWidth / 2;
                frog.Y = Console.BufferHeight - 4;
                frog.Lives--;
            }
        }
    }

    //Class Truck inherits the methods of Car
    class Truck : Car
    {
        //Constructor of Truck is the same as Car
        public Truck()
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
        }
        //Visual representation of the Object Truck
        public override void RenderCar()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("__________");
                carSecondRow.Append("[][][][][]");
                carThirtRow.Append("-0------0-");
            }
        }
        //The movement is the same as in the Car
        public override void Move(int n)
        {
            this.Coll++;
            if (this.Coll + n >= Console.BufferWidth + 2)
            {
                this.carFirstRow.Remove(this.carFirstRow.Length - 1, 1);
                this.carSecondRow.Remove(this.carSecondRow.Length - 1, 1);
                this.carThirtRow.Remove(this.carThirtRow.Length - 1, 1);
            }
            if (this.carThirtRow.Length == 0)
            {
                RenderCar();
                this.Coll = 0;
            }
        }

    }
    //Class Bus inherits the methods of Car
    class Bus : Car
    {
        //Constructor of Bus is the same as Car
        public Bus()
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
        }
        //Visual representation of the Object Bus
        public override void RenderCar()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("________________");
                carSecondRow.Append(" [][][][][][][] ");
                carThirtRow.Append("-0------------0-");
            }
        }
        //The movement is the same as in the Car
        public override void Move(int n)
        {
            this.Coll++;
            if (this.Coll + n >= Console.BufferWidth + 2)
            {
                this.carFirstRow.Remove(this.carFirstRow.Length - 1, 1);
                this.carSecondRow.Remove(this.carSecondRow.Length - 1, 1);
                this.carThirtRow.Remove(this.carThirtRow.Length - 1, 1);
            }
            if (this.carThirtRow.Length == 0)
            {
                RenderCar();
                this.Coll = 0;
            }
        }
        //Draws the car coming from right to left
        public override void DrawCar(int n)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(this.Coll, this.Row + n);
            Console.WriteLine(this.carFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + (n + 1));
            Console.WriteLine(this.carSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + (n + 2));
            Console.WriteLine(this.carThirtRow.ToString());
            Console.ResetColor();
        }
    }
}