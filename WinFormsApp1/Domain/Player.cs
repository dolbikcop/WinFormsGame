using System.Drawing;

namespace WinFormsApp1.Domain
{
    class Player
    {
        public PointF Position { get; set; }
        //public int Speed { get; set; }
        public int Health { get; set; }
        // energy
        public int Score { get; set; }

        public Player(float x, float y, int health)
        {
            Position = new PointF(x, y);
            //Speed = speed;
            Health = health;
            Score = 0;
        }

        public void Move(float dx, float dy)
        {
            Position = new PointF(Position.X + dx, Position.Y + dy);
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