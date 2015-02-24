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
            {this.coll = value; }
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

        public void RenderCar()
        {
            carFirstRow.Append("______");
            carSecondRow.Append("[][][]");
            carThirtRow.Append("-0--0-");
            
        }

        public void SecondRenderCar()
        {
            carFirstRow.Append("________________");
            carSecondRow.Append(" [][][][][][][] ");
            carThirtRow.Append("-0------------0-");

        }

        public void ThirdRenderCar()
        {
            carFirstRow.Append("__________");
            carSecondRow.Append("[][][][][]");
            carThirtRow.Append("-0------0-");

        }

        public void Move(int n)
        {
            this.Coll++;
            if (this.Coll + n >= Console.BufferWidth+2)
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

        public void SecondCarMovement(int n)
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
                this.SecondRenderCar();
                this.Coll = 0;
            }
        }

        public void ThirdCarMovement(int n)
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
                this.ThirdRenderCar();
                this.Coll = 0;
            }
        }

        public void FirstLeftCarMovement(int n)
        {
            this.Coll--;
            if (this.Coll - n >= Console.BufferWidth + 2)
            {
                this.carFirstRow.Remove(this.carFirstRow[0] + 1, - 1);
                this.carSecondRow.Remove(this.carSecondRow[0] + 1, - 1);
                this.carThirtRow.Remove(this.carThirtRow[0] + 1, - 1);
            }
            if (this.carThirtRow.Length == 0 || this.Coll == 0)
            {
                this.SecondRenderCar();
                this.Coll = 84;
            }
        }

        public void DrawCar(int n)
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

        public void DrawLeftCar(int n)
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

        public void CheckCrash(Frog frog, int n, int m)
        {
            if (frog.X >= this.Coll - 4  &&  frog.X <= this.Coll + m  &&  frog.Y == this.Row + n)
            {
                crashSound.Play();
                frog.X = Console.BufferWidth / 2;
                frog.Y = Console.BufferHeight - 4;
                frog.Lives--;
            }
        }
    }
}
