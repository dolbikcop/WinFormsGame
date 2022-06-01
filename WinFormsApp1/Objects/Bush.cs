using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Bush
    {
        public Rectangle Bounds => View.Bounds;
        public Point Position => View.Location;
        public Image Image => View.Image;
        
        public PictureBox View = new()
        {
            Tag = "bush",
            Image = Resources.Bush,
            Size = Resources.Bush.Size
        };

        public Bush(Rectangle r)
        {
            View.Bounds = r;
        }
    }
}