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

        private int horizontal = 0;
        private int vertival = 0;
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
            Load += (sender, args) =>
                GoFullscreen(true);
            DoubleBuffered = true;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (_, _) => UpdateForm();
            timer.Tick += (_, _) => IntersectionObject(); 
            timer.Start();
            _spawnManager = new SpawnManager(this);
        }

        private void UpdateForm()
        {
            pl.Move(horizontal, vertival);
            Invalidate();
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
            var playerView = new Rectangle(ClientSize.Width / 2 + pl.X,
                ClientSize.Height / 2 + pl.Y, 50, 50);
            g.FillEllipse(Brushes.Coral, playerView);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D:
                    horizontal = 1;
                    break;
                case Keys.A:
                    horizontal = -1;
                    break;
                case Keys.W:
                    vertival = -1;
                    break;
                case Keys.S:
                    vertival = 1;
                    break;
                case Keys.Escape:
                    GoFullscreen(false);
                    break;
                case Keys.Enter:
                    _spawnManager.StartSpawn();
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyData == Keys.A || e.KeyData == Keys.D)
                horizontal = 0;
            if (e.KeyData == Keys.W || e.KeyData == Keys.S)
                vertival = 0;
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

        bool isCollisionWith(Rectangle r1, Rectangle r2)
        {
            return r1.IntersectsWith(r2);
        }
    }
}