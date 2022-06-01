using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Enemy
    {
        public Rectangle Bounds => View.Bounds;
        public Point Position => View.Location;
        public Image Image => View.Image;
        
        public Point StartPosition;

        public PictureBox View = new()
        {
            Image = Resources.Enemy,
            Tag = "enemy",
            Size = Resources.Enemy.Size
        };

        public static readonly int Damage = int.Parse(Resources.EnemyDamage);
        public static readonly int Speed = int.Parse(Resources.EnemySpeed);
        public Enemy(Rectangle r)
        {
            View.Bounds = r;
            StartPosition = r.Location;
        }
        
        public void Move(int dx, int dy)
        {
            View.Location = new Point(Position.X + dx * Speed, Position.Y + dy * Speed);
        }
    }
}