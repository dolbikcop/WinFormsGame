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

namespace WinFormsApp1
{
    public class Form1 : Form
    {
        private Game g;
        public Graphics gr;
        public View view;
        
        

        public Label healthBar = new()
        {
            Text = "Health: ", 
            Size = new Size(100, 100)
        };

        public Form1()
        {
            ClientSize = new Size(1000, 1000);
            
            Controls.Add(healthBar);
            
            Initialize();
        }

        private void Initialize()
        {
            g = new Game(this);
            view = new View(g);
            
            Load += (_, _) => GoFullscreen(true);
            DoubleBuffered = true;

            Paint += (_, args) => view.UpdateGraphics(args.Graphics);
            Paint += (_, _) => Invalidate();
            KeyDown += (_, args) => Control.ControlKeys(args.KeyCode, true);
            KeyUp += (_, args) => Control.ControlKeys(args.KeyCode, false);
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