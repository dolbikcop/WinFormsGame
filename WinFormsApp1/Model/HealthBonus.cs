using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class HealthBonus
    {
        public int Bonus;
        public PictureBox View = new()
        {
            Size = new Size(50, 50),
            Tag = "health",
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\HealthBonus.png")
        };

        public HealthBonus(int b)
        {
            Bonus = b;
        }
        
    }
}