using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private Game game;
        private Player pl;
        private SpawnManager _spawnManager;
        private Graphics g;
        public Form1()
        {
            Initialize();
        }

        private void Initialize()
        {
            game = new()
            {
                levels = new List<Level>()
                {
                    new(new Size(1000, 1000), new Point(0,0))
                }
            };
            game.player = new Player(game.levels[0].Start, 20, 12);
            pl = game.player;
            KeyDown += OKP;
            Load += (sender, args) =>
                GoFullscreen(true);
            DoubleBuffered = true;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) => Invalidate();
            timer.Tick += (sender, args) => IntersectionObject(); 
            timer.Start();
            _spawnManager = new SpawnManager(this);
        }

        private void IntersectionObject()
        {
            foreach (var i in Controls)
            {
                foreach (var j in Controls)
                {
                    if (i is Rectangle && j is Rectangle && i != j) ;
                    //if ()
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            g = e.Graphics;
            
            g.FillEllipse(Brushes.Coral, new Rectangle( ClientSize.Width/2 + pl.X, ClientSize.Height/2 + pl.Y, 50, 50));
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D:
                    pl.Move(pl.Speed, 0);
                    break;
                case Keys.A:
                    pl.Move(-pl.Speed, 0);
                    break;
                case Keys.W:
                    pl.Move(0, -pl.Speed);
                    break;
                case Keys.S:
                    pl.Move(0, pl.Speed);
                    break;
                case Keys.Escape:
                    GoFullscreen(false);
                    break;
                case Keys.Enter:
                    _spawnManager.StartSpawn();
                    break;
            }
        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                WindowState = FormWindowState.Normal;
                FormBorderStyle = FormBorderStyle.None;
                Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
                FormBorderStyle = FormBorderStyle.Sizable;
            }
        }
    }
}