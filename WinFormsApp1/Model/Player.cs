using System.Drawing;

namespace WinFormsApp1.Model
{
    public class Player
    {
        public Point Position { get; private set; }
        public readonly int Speed;
        public int Health { get; private set; }

        public int X => Position.X;
        public int Y => Position.Y;
        // energy
        public int Score { get; set; }

        public Player(Point start, int speed, int health)
        {
            Position = start;
            Speed = speed;
            Health = health;
            Score = 0;
        }

        public void Move(int dx, int dy)
        {
            Position = new Point(Position.X + dx*Speed, Position.Y + dy*Speed);
        }

        public void TakeDamage(Enemy e)
        {
            Health -= e.damage;
        }

        public void TakeItem(Item i)
        {
            Score += i.Bonus;
        }
        public void TakeHealth(int i)
        {
            Health += i;
        }
    }
}