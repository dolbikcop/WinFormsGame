using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public static class SpawnManager
    {
        private static Random r = new();
        public static void Spawn(ref List<Rectangle> r, int count, Point p)
        {
            for(int i = 0; i<count; i++)
                r.Add(SpawnObjectWithSize(new Size(50, 50), p));
        }
        
        public static void Spawn(ref List<Enemy> r, int count, Point p)
        {
            for(int i = 0; i<count; i++)
                r.Add(new Enemy(SpawnObjectWithSize(new Size(100, 100), p)));
        }
        public static void Spawn(ref List<HealthBonus> r, int count, Point p)
        {
            for(int i = 0; i<count; i++)
                r.Add(new HealthBonus(SpawnObjectWithSize(new Size(100, 100), p)));
        }
        
        public static Rectangle SpawnObjectWithSize(Size s, Point p) => new()
        {
            Size = s,
            Location = new Point(r.Next(p.X-1000, p.X+1000), r.Next(p.Y-1000, p.Y+1000))
        };
    }
}