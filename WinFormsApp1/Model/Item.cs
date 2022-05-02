using System.Drawing;

namespace WinFormsApp1.Model
{
    class Item
    {
        public readonly PointF Position;
        public readonly int Bonus;

        public Item(float x, float y, int g)
        {
            Position = new PointF(x, y);
            Bonus = g;
        }
    }
}