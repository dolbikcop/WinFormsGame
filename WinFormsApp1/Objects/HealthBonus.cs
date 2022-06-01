using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class HealthBonus
    {
        public static List<HealthBonus> Objects;
        public Rectangle Bounds => View.Bounds;
        public Point Position => View.Location;
        public Image Image => View.Image;
        
        public PictureBox View = new()
        {
            Tag = "health",
            Image = Resources.HealthBonus,
            Size = Resources.HealthBonus.Size
        };

        public static readonly int Bonus = int.Parse(Resources.HealthBonusValue);

        public HealthBonus(Rectangle r)
        {
            View.Bounds = r;
        }
        public static void Update(Player player)
        {
            for (int i = 0; i<Objects.Count; i++)
            {
                var b = Objects[i];
                if (b.Bounds.IntersectsWith(player.Bounds))
                {
                    player.TakeHealth(Bonus);
                    Objects.RemoveAt(i);
                    Objects.Add(new HealthBonus(SpawnManager.Spawn(1, player.Position).First()));
                }
            }
        }
    }
}