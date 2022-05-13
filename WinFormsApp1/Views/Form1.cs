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
        private Game g;
        
        public int HInput { get; private set; }
        public int VInput { get; private set; }
        
        public Form1()
        {
            ClientSize = new Size(1000, 1000);
            Initialize();
        }

        private void Initialize()
        {
            g = new Game(this);
            
            Load += (_, _) => GoFullscreen(true);
            DoubleBuffered = true;
            
            //timer.Tick += (_, _) => IntersectionObject(); 
            
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.D:
                    HInput = 1;
                    break;
                case Keys.A:
                    HInput = -1;
                    break;
                case Keys.W:
                    VInput = -1;
                    break;
                case Keys.S:
                    VInput = 1;
                    break;
                case Keys.Escape:
                    GoFullscreen(false);
                    break;
                case Keys.Enter:
                    g.spawnHealth.StartSpawn();
                    break;
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyData == Keys.A || e.KeyData == Keys.D)
                HInput = 0;
            if (e.KeyData == Keys.W || e.KeyData == Keys.S)
                VInput = 0;
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