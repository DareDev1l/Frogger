namespace Frogger.Enemies
{
    using System;
    using System.IO;
    using System.Media;
    using System.Text;

    public class Enemy
    {
        public static string fullPath = Path.GetFullPath(@"..\..\crash.wav");
        SoundPlayer crashSound = new SoundPlayer(fullPath);

        private int x = Console.BufferWidth / 2;
        private int y = Console.BufferHeight;
        public StringBuilder carFirstRow;
        public StringBuilder carSecondRow;
        public StringBuilder carThirtRow;
        public int row;
        public int coll;

        public Enemy()
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
        }

        public Enemy(int row, int col)
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
            this.Row = row;
            this.Coll = col;
        }

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

        public virtual void RenderEnemy()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("______");
                carSecondRow.Append("[][][]");
                carThirtRow.Append("-0--0-");
            }
        }

        public void DrawCar(int n)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(this.Coll, this.Row + (n));
            Console.WriteLine(this.carFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + (n + 1));
            Console.WriteLine(this.carSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + (n + 2));
            Console.WriteLine(this.carThirtRow.ToString());
            Console.ResetColor();
        }


        public void MoveRight(int n)
        {
            this.Coll++;
            if (this.Coll + n >= Console.BufferWidth)
            {
                this.carFirstRow.Remove(this.carFirstRow.Length - 1, 1);
                this.carSecondRow.Remove(this.carSecondRow.Length - 1, 1);
                this.carThirtRow.Remove(this.carThirtRow.Length - 1, 1);
            }
            if (this.carThirtRow.Length == 0)
            {
                this.RenderEnemy();
                this.Coll = 0;
            }
        }

        //Movement for the cars coming from right to left
        public void MoveLeft(int n)
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
                this.RenderEnemy();
                this.Coll = 100 - carFirstRow.Length;
            }
        }

        //This method checks whether the frog will crash in a vehicle. It's not optimised but works
        public void CheckCrash(Frog frog, int n, int m)
        {
            if (frog.X >= this.Coll - 4 && frog.X <= this.Coll + m && frog.Y == this.Row + n)
            {
                //crashSound.Play();
                frog.X = Console.BufferWidth / 2;
                frog.Y = Console.BufferHeight - 4;
                frog.LivesLeft--;
                frog.Score -= 30;
                if (frog.Score < 0)
                {
                    frog.Score = 0;
                }
                frog.WasInSafeZone = false;
            }
        }
    }
}
