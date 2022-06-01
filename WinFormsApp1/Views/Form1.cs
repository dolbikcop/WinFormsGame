using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Form1 : Form
    {
        private Game g;
        public View view;
        
        public Label label = new Label()
        {
            TextAlign = ContentAlignment.MiddleLeft,
            Font = new Font(FontFamily.GenericMonospace, 30, FontStyle.Bold),
            AutoSize = true,
            //Location = new Point(0, 0), 
            ForeColor = Color.Azure, 
            Text = "Play",
            BackColor = Color.Brown,
            Visible = true
        };
        
        public Form1()
        {
            Controls.Add(label); 
            Initialize();
        }

        private void Initialize()
        {
            g = new Game(this);
            view = new View(g);

            DoubleBuffered = true;
            Load += (_, _) => Controller.GoFullscreen(true, this);

            Paint += (_, args) => view.UpdateGraphics(args.Graphics);
            Paint += (_, _) => Invalidate();
            
            KeyDown += (_, args) => Controller.ControlKeys(args.KeyCode, true);
            KeyUp += (_, args) => Controller.ControlKeys(args.KeyCode, false);
            
            MouseMove+=(_, _) => label.Text = g.player.Position.ToString();
        }
        
    }
}