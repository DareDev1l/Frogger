namespace Frogger.Enemies
{
    using System;

    public class Car : Enemy
    {


        public Car()
            : base()
        {
        }

        public Car(int row, int col)
            : base(row, col)
        {
        }

        public override void RenderEnemy()
        {
            if (carFirstRow.Length == 0)
            {
                carFirstRow.Append("______");
                carSecondRow.Append("[][][]");
                carThirtRow.Append("-0--0-");
            }
        }
    }
}
