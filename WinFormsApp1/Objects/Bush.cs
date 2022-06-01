﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Bush
    {
        
        public static List<Bush> Objects;
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
        public static void Update(Player player)
        {
            if (Objects.Select(x => x.Bounds)
                .Any(x => x.IntersectsWith(player.Bounds)))
                player.Stage = PlayerStage.Hidden;
            else
                player.Stage = PlayerStage.Normal;
        }
    }
}