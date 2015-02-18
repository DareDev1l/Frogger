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

        Car Car
        {

        }

        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public void Move()
        {

        }

        public void Draw()
        {

        }
    }
}
