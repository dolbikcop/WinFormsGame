using System.Drawing;

namespace WinFormsApp1.Domain
{
    class Enemy
    {
        public PointF Position { get; private set; }

        public readonly int damage;
        // size 

        public Enemy(float x, float y, int damage)
        {
            Position = new PointF(x, y);
            this.damage = damage;
        }
    }
}