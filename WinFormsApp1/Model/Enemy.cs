using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Enemy
    {
        public readonly int Damage;
        public readonly int Speed;
        
        public PictureBox View = new()
        {
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\враг.png"),
            Tag = "enemy",
            Size = new Size(100, 100)
        };

        public Enemy(int damage, int speed)
        {
            Damage = damage;
            Speed = speed;
        }
    }
}