using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{

    class Tunnel
    {
        public StringBuilder tunnelFirstRow = new StringBuilder();
        public StringBuilder tunnelSecondRow = new StringBuilder();
        public StringBuilder tunnelThirdRow = new StringBuilder();
        public int Coll = Console.BufferWidth;
        public int Row = 0;

        public virtual void FirstCarTunnel()
        {
            if (this.tunnelFirstRow.Length == 0)
            {

                this.tunnelFirstRow.Append("------------");
                this.tunnelSecondRow.Append(")===)==)===)");
                this.tunnelThirdRow.Append("------------");
            }
        }

        public virtual void DrawFirstTunnel(int n, int m)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(this.Coll - m, this.Row + (n));
            Console.WriteLine(this.tunnelFirstRow.ToString());
            Console.SetCursorPosition(this.Coll - m, this.Row + (n + 1));
            Console.WriteLine(this.tunnelSecondRow.ToString());
            Console.SetCursorPosition(this.Coll - m, this.Row + (n + 2));
            Console.WriteLine(this.tunnelThirdRow.ToString());
            Console.ResetColor();
        }

        public virtual void SecondCarTunnel()
        {
            if (this.tunnelFirstRow.Length == 0)
            {
                tunnelFirstRow.Append("-------------------");
                tunnelSecondRow.Append(")==)===)===)===)==)");
                tunnelThirdRow.Append("-------------------");
            }
        }
    }
}
