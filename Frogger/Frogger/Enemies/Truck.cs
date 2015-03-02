namespace Frogger.Enemies
{
    using System;

    public class Truck : Enemy
    {
        public Truck()
            : base()
        {
        }

        public Truck(int row, int col)
            : base(row, col)
        {
        }

        //Visual representation of the Object Truck
        public override void RenderEnemy()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("__________");
                carSecondRow.Append("[][][][][]");
                carThirtRow.Append("-0------0-");
            }
        }
    }
}
