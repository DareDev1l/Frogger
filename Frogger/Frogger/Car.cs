using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    class Car
    {


        private int x = Console.BufferWidth / 2;
        private int y = Console.BufferHeight;
        public StringBuilder carFirstRow;
        public StringBuilder carSecondRow;
        public StringBuilder carThirtRow;
        private int row;
        private int coll;

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
        //private string[] car = 
        //                        {
        //                          "______",
        //                          "[][][]-",
        //                          "0---0-"
        //                        };


        public Car()
        {
            this.carFirstRow = new StringBuilder();
            this.carSecondRow = new StringBuilder();
            this.carThirtRow = new StringBuilder();
        }

        public void RenderCar()
        {
            carFirstRow.Append("______");
            carSecondRow.Append("[][][]");
            carThirtRow.Append("0---0-");
            //Bus size
            //this.SizeX = 7;
            // this.SizeY = 3;
        }
        //public Car()
        //{

        //}
        //public string[] carDrow
        //{
        //    get { return this.car; }
        //}

        //public int X
        //{
        //    get { return this.x; }
        //    set { this.x = value; }
        //}

        //public int Y
        //{
        //    get { return this.y; }
        //    set { this.y = value; }
        //}

        public void Move()
        {
            this.Coll++;
            if (this.Coll + 7 >= Console.WindowWidth)
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
        public void Draw()
        {
            Console.SetCursorPosition(this.Coll, this.Row);
            Console.WriteLine(this.carFirstRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 1);
            Console.WriteLine(this.carSecondRow.ToString());
            Console.SetCursorPosition(this.Coll, this.Row + 2);
            Console.WriteLine(this.carThirtRow.ToString());
        }
    }
}