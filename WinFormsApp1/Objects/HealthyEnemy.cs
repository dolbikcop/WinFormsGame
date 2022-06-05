﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class HealthyEnemy
    {
        private static List<Bitmap> view = new()
        {
            Resources.Buba0, Resources.Buba1, Resources.Buba2, 
            Resources.Buba3, Resources.Buba4, Resources.Buba5, 
            Resources.DeadHero
        };

        private static Random r = new Random();
        public PictureBox View = new PictureBox()
        {
            Image = Resources.Buba0,
            Size = new Size(100, 100)
        };
        public Rectangle Bounds => View.Bounds;
        public Image Image => View.Image;

        public HealthyEnemy(Point p, bool isDead)
        {
            int i;
            if (isDead) i = view.Count - 1;
            else i = r.Next(0, view.Count - 2);
            View.Image = view[i];
            View.Location = p;
            View.Size = view[i].Size;  
        }
    }
}