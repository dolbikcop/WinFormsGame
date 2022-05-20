using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Enemy
    {
        public readonly int Damage;
        public readonly int Speed;
        public Rectangle Bounds => View.Bounds;
        public Point Position => View.Location;
        public Image Image => View.Image;
        
        private PictureBox View = new()
        {
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\враг.png"),
            Tag = "enemy",
            Size = new Size(100, 100)
        };

        public Enemy(int damage, int speed, Rectangle r)
        {
            Damage = damage;
            Speed = speed;
            View.Bounds = r;
        }

        public Enemy(Rectangle r) : this(1, 1, r) {}
        
        public void Move(int dx, int dy)
        {
            View.Location = new Point(Position.X + dx * Speed, Position.Y + dy * Speed);
        }
    }
}