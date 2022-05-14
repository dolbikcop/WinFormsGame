using System.Drawing;

namespace WinFormsApp1.Model
{
    public class Enemy
    {
        public Point Position { get; private set; }

        public readonly int damage;

        public readonly int Speed;
        // size 

        public Enemy(int x, int y, int damage)
        {
            Position = new Point(x, y);
            this.damage = damage;
        }
        public void Move(int dx, int dy)
        {
            Position = new Point(Position.X + dx*Speed, Position.Y + dy*Speed);
        }
    }
}