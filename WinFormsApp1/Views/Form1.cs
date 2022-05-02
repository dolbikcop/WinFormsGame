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
        private Player pl = new Player(100, 100, 5, 10);
        public Form1()
        {
            this.KeyDown += OKP;
            this.Load += (sender, args) =>
                GoFullscreen(true);
            DoubleBuffered = true;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (sender, args) => Invalidate();
            timer.Start();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            
            g.FillEllipse(Brushes.Coral, new Rectangle(pl.Position, new Size(50, 50)));
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                    pl.Move(pl.Speed, 0);
                    break;
                case Keys.Left:
                    pl.Move(-pl.Speed, 0);
                    break;
                case Keys.Up:
                    pl.Move(0, -pl.Speed);
                    break;
                case Keys.Down:
                    pl.Move(0, pl.Speed);
                    break;
                case Keys.Escape:
                    GoFullscreen(false);
                    break;
            }
        }
        private void GoFullscreen(bool fullscreen)
        {
            if (fullscreen)
            {
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.Bounds = Screen.PrimaryScreen.Bounds;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
    }
}