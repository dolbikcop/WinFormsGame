using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public static class SpawnManager
    {
        private static int spawnMin => int.Parse(Resources.SpawnLocationMin);
        private static int spawnMax => int.Parse(Resources.SpawnLocationMax);
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

            while (!(isValidLocation(result, p)))
            {
                var randomLocationX = r.Next(p.X - spawnMax, spawnMax + p.X);

                var randomLocationY = r.Next(p.Y - spawnMax, spawnMax + p.Y);

                result = new Point(randomLocationX, randomLocationY);
            }

            return result;
        }

        private static bool isValidLocation(Point p,Point pl)
        {
            return ((p.X < pl.X && p.X < pl.X - spawnMin) || (p.X > pl.X && p.X > pl.X + spawnMin))
                   && ((p.Y < pl.Y && p.Y < pl.Y - spawnMin) || (p.Y > pl.Y && p.Y > pl.Y + spawnMin))
                   && p.X<1500 && p.X > -1500 && p.Y<1500 && p.Y > -1500;
        }
    }
}