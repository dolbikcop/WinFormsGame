using System;
using System.Collections.Generic;
using System.Drawing;

namespace WinFormsApp1
{
    public static class SpawnManager
    {
        private static Random r = new();
        public static void Spawn(ref List<Rectangle> r, int count)
        {
            for(int i = 0; i<count; i++)
                r.Add(SpawnObject());
        }
        public static Rectangle SpawnObject() => new()
            {
                Size = new Size(100, 100),
                Location = new Point(r.Next(0, 1000), r.Next(0, 1000))
            };
    }
}