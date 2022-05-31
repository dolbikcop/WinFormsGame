using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class HealthBonus
    {
        public int Bonus;
        public Rectangle Bounds => View.Bounds;
        public Point Position => View.Location;
        public Image Image => View.Image;
        
        public PictureBox View = new()
        {
            Size = new Size(50, 50),
            Tag = "health",
            Image = Resources.HealthBonus
        };

        public HealthBonus(int b)
        {
            Bonus = b;
        }

        public HealthBonus(Rectangle r) : this(10)
        {
            View.Bounds = r;
        }
    }
}