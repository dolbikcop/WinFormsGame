using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public static class SpawnManager
    {
        private static Random r = new();
        public static IEnumerable<Rectangle> Spawn(int count, Point p)
        {
            for(int i = 0; i<count; i++)
                yield return SpawnObjectWithSize(new Size(30, 30), p);
        }
        
        public static Rectangle SpawnObjectWithSize(Size s, Point p) 
            => new ()
            {
                Size = s,
                Location = GetValidSpawnLocation(p)
            };
        
        private static Point GetValidSpawnLocation(Point p)
        {
            var result = new Point(p.X, p.Y);

            while ((result.X > p.X - 500 && result.X < p.X + 500) 
                   || (result.Y > p.Y - 500 && result.Y < p.Y + 500))
            {
                var randomLocationX = r.Next(p.X - 800, 800 + p.X);

                var randomLocationY = r.Next(p.Y - 800, 800 + p.Y);

                result = new Point(randomLocationX, randomLocationY);
            }

            return result;
        }
    }
}