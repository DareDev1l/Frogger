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
            this.p1 = p1;
            this.p2 = p2;
        }

        public virtual void RenderCar()
        {
            carFirstRow.Append("______");
            carSecondRow.Append("[][][]");
            carThirtRow.Append("0---0-");

        }

        public void Move()
        {
            this.Coll++;
            if (this.Coll + 7 >= Console.BufferWidth+2)
            {
                this.carFirstRow.Remove(this.carFirstRow.Length - 1, 1);
                this.carSecondRow.Remove(this.carSecondRow.Length - 1, 1);
                this.carThirtRow.Remove(this.carThirtRow.Length - 1, 1);
                //this.carFourthRow.Remove(this.carFourthRow.Length - 1, 1);
            }
            if (this.carThirtRow.Length == 0)
            {
                this.RenderCar();
                this.Coll = 0;
            }
        }

        public virtual void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.carFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.carSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.carThirtRow.ToString());
            Console.ResetColor();
        }

        public void CheckCrash(Frog frog)
        {
            if (frog.X >= this.Coll - 4 && frog.X <= this.Coll + 6 && (frog.Y == this.Row || frog.Y == this.Row+6))
            {
                crashSound.Play();
                frog.X = Console.BufferWidth / 2;
                frog.Y = Console.BufferHeight - 4;
                frog.LivesLeft--;
            }
        }

    }

    class Truck : Car
    {
        public Truck()
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
        }
        public override void RenderCar()
        {
            carFirstRow.Append("++++++");
            carSecondRow.Append("[][][]");
            carThirtRow.Append("0---0-");
        }
        public override void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(this.Coll, this.Row + 6);
            Console.WriteLine(this.carFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 7);
            Console.WriteLine(this.carSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 8);
            Console.WriteLine(this.carThirtRow.ToString());
            Console.ResetColor();
        }
    }
}
