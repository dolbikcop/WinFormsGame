using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Player
    {
        public Point Position
        {
            get => View.Location;
            set => View.Location = value;
        }
        
        public PictureBox View = new()
        {
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\character.png"),
            Height = 100, Width = 100,
            Tag = "player",
            Location = new Point(0, 0)
        };
        
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
            Position = new Point(Position.X + dx * Speed, Position.Y + dy * Speed);
        }
        public void Move()
        {
            if (Control.IsInputDown)
                Position = new Point(Position.X, Position.Y + Speed);
            if (Control.IsInputUp)
                Position = new Point(Position.X, Position.Y - Speed);
            if (Control.IsInputRight)
                Position = new Point(Position.X + Speed, Position.Y);
            if (Control.IsInputLeft)
                Position = new Point(Position.X - Speed, Position.Y);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
        }

        public void TakeHealth(int i)
        {
            Health += i;
        }
    }
}