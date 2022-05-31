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
            Tag = "health",
            Image = Resources.HealthBonus,
            Size = Resources.HealthBonus.Size
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