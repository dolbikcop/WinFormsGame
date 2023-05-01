using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Form1 : Form
    {
        private Game g;
        public View view;

        public Form1()
        {
            ClientSize = new Size(1000, 1000);
            
            Initialize();
        }

        private void Initialize()
        {
            g = new Game();
            view = new View(g);
            
            Load += (x, y) => Control.GoFullscreen(true, this);
            DoubleBuffered = true;

            Paint += (x, args) => view.UpdateGraphics(args.Graphics);
            Paint += (x, y) => Invalidate();
            
            KeyDown += (x, args) => Control.ControlKeys(args.KeyCode, true);
            KeyUp += (x, args) => Control.ControlKeys(args.KeyCode, false);
        }
        
    }
}