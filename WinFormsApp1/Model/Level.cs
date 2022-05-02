using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1.Model
{
    class Level
    {
        public Size size { get; set; }

        public List<Item> Items { get; private set; }
        public List<PointF> SpawnPoint { get; private set; }

        public readonly PointF Start= new PointF(0, 0);

        public Level(Size size, PointF start)
        {
            Items = new List<Item>();
            SpawnPoint = new List<PointF>();
            this.size = size;
            Start = start;
        }

    }
}