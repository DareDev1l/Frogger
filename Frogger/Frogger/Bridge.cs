using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{

    class Bridge
    {
        public StringBuilder bridgeFirstRow = new StringBuilder();
        public StringBuilder bridgeSecondRow = new StringBuilder();
        public StringBuilder bridgeThirdRow = new StringBuilder();

        public virtual void FirstBridge()
        {
            if (this.bridgeFirstRow.Length == 0)
            {

                this.bridgeFirstRow.Append("---------------");
                this.bridgeSecondRow.Append("|||||||||||||||");
                this.bridgeThirdRow.Append("---------------");
            }
        }

        public virtual void DrawBridge(int n, int m)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(Console.BufferWidth - m, n);
            Console.WriteLine(this.bridgeFirstRow.ToString());
            Console.SetCursorPosition(Console.BufferWidth - m, n + 1);
            Console.WriteLine(this.bridgeSecondRow.ToString());
            Console.SetCursorPosition(Console.BufferWidth - m, n + 2);
            Console.WriteLine(this.bridgeThirdRow.ToString());
            Console.ResetColor();
        }

        public virtual void SecondBridge()
        {
            if (this.bridgeFirstRow.Length == 0)
            {
                this.bridgeFirstRow.Append("----------------------");
                this.bridgeSecondRow.Append("||||||||||||||||||||||");
                this.bridgeThirdRow.Append("----------------------");
            }
        }
    }
}
