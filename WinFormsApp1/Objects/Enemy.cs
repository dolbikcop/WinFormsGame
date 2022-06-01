using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Enemy
    {
        public static List<Enemy> Objects;
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
            View.Size = new Size(100, 100);
            StartPosition = new Point(r.Location.X, r.Location.Y);
        }
        
        public Point Move(int dx, int dy)
        {
            return new Point(Position.X + dx * Speed, Position.Y + dy * Speed);
        }

        public void MoveToPosition(Point p, int speed)
        {
            var tPos = Position;
            if (Position.X > p.X) tPos = Move(-speed, 0);
            else if (Position.X < p.X) tPos = Move(speed, 0);
            if (Position.Y < p.Y) tPos = Move(0, speed);
            else if (Position.Y > p.Y) tPos = Move(0, -speed);

            var tRect = new Rectangle(tPos, View.Size);
            if (Objects.All(x => !x.Bounds.IntersectsWith(tRect) || x.Position == Position))
                View.Location = tPos;
        }

        public void MoveToPosition(Point p) => MoveToPosition(p, Speed);

        public static void Update(Player player)
        {
            switch (player.Stage)
            {
                case PlayerStage.Normal:
                    foreach (var e in Objects)
                    {
                        if (e.View.Bounds.IntersectsWith(player.Bounds))
                            player.TakeDamage(Enemy.Damage);
                        else
                            e.MoveToPosition(player.Position);
                    }
                    break;
                case PlayerStage.Hidden:
                    foreach (var e in Objects)
                        e.MoveToPosition(e.StartPosition);
                    break;
            }
        }
    }
}