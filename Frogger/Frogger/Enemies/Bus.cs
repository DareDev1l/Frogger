namespace Frogger.Enemies
{
    using System;

    public class Bus : Enemy
    {
        //Constructor of Bus is the same as Car
        public Bus()
            : base()
        {
        }

        public Bus(int row, int col)
            : base(row, col)
        {
        }

        //Visual representation of the Object Bus
        public override void RenderEnemy()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("________________");
                carSecondRow.Append(" [][][][][][][] ");
                carThirtRow.Append("-0------------0-");
            }
        }
    }
}
