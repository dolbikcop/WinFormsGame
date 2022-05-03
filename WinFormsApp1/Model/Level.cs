using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.Model
{
    public class Level
    {
        public Size size { get; set; }

        public List<Item> Items { get; private set; }
        public List<Point> SpawnPoint { get; private set; }

        public readonly Point Start= new Point(0, 0);

        public Level(Size size, Point start)
        {
            Items = new List<Item>();
            SpawnPoint = new List<Point>();
            this.size = size;
            Start = start;
        }

        public Level()
        {
            Items = new List<Item>();
            SpawnPoint = new List<Point>();
        }

    }
}