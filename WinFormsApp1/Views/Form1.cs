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
            g = new Game(this);
            view = new View(g);
            
            Load += (_, _) => Control.GoFullscreen(true, this);
            DoubleBuffered = true;

            Paint += (_, args) => view.UpdateGraphics(args.Graphics);
            Paint += (_, _) => Invalidate();
            
            KeyDown += (_, args) => Control.ControlKeys(args.KeyCode, true);
            KeyUp += (_, args) => Control.ControlKeys(args.KeyCode, false);
        }
        
    }
}