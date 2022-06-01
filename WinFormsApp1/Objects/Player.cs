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
        public Rectangle Bounds => View.Bounds;
        public Image Image => View.Image;
        
        public PictureBox View = new()
        {
            Image = Resources.MainHero,
            Size = Resources.MainHero.Size,
            Tag = "player",
            Location = new Point(0, 0)
        };
        
        public readonly int Speed;
        public int Health { get; private set; }
        public int X => Position.X;

        public int Y => Position.Y;

        public int Radius = int.Parse(Resources.StartViewRadius);

        private EnergyManager eManager = new EnergyManager();
        public int Energy => eManager.Energy;

        public PlayerStage Stage;
        public Player(Point start, int speed, int health)
        {
            Position = start;
            Speed = speed;
            Health = health;
        }

        public void Move(int dx, int dy)
        {
            var delta = new Size(dx * Speed, dy * Speed);
            Position = Point.Add(Position, delta);
        }
        public void Move()
        {
            if (Controller.IsInputDown)
                Move(0, 1);
            if (Controller.IsInputUp)
                Move(0, -1);
            if (Controller.IsInputRight)
                Move(1, 0);
            if (Controller.IsInputLeft)
                Move(-1, 0);
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