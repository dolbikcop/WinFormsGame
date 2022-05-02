using System.Drawing;

namespace WinFormsApp1.Model
{
    class Player
    {
        internal Point Position { get; private set; }
        public readonly int Speed;
        internal int Health { get; private set; }
        // energy
        public int Score { get; set; }

        public Player(int x, int y, int speed, int health)
        {
            Position = new Point(x, y);
            Speed = speed;
            Health = health;
            Score = 0;
        }

        public void Move(int dx, int dy)
        {
            Position = new Point(Position.X + dx, Position.Y + dy);
        }

        public void TakeDamage(Enemy e)
        {
            Health -= e.damage;
        }

        public void TakeItem(Item i)
        {
            Score += i.Bonus;
        }
    }
}