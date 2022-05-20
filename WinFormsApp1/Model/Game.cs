using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Game
    {
        public readonly Player player = new(new Point(0, 0), 1, 12);

        public List<Rectangle> enemys = new();

        private Form1 f;
        private Timer timer;
        

        public Game(Form1 form)
        {
            f=form;
            SpawnManager.Spawn(ref enemys, 12);
            player.Move(f.ClientSize.Width / 2, f.ClientSize.Height / 2);
        }
    }
}
