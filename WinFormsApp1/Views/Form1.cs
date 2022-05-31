using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Form1 : Form
    {
        private Game g;
        public View view;
        
        public Label label = new Label
        {
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold),
            Size = new Size(400, 400),
            Location = new Point(0, 0)
        };
        
        public Form1()
        {
            //ClientSize = new Size(1000, 1000);
            Controls.Add(label);    
            Initialize();
        }

        private void Initialize()
        {
            g = new Game(this);
            view = new View(g);
            
            Load += (_, _) => Controller.GoFullscreen(true, this);
            DoubleBuffered = true;

            Paint += (_, args) => view.UpdateGraphics(args.Graphics);
            Paint += (_, _) => Invalidate();
            
            KeyDown += (_, args) => Controller.ControlKeys(args.KeyCode, true);
            KeyUp += (_, args) => Controller.ControlKeys(args.KeyCode, false);
        }
        
    }
}