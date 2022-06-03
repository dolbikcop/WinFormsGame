using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;

namespace WinFormsApp1
{
    public class UI
    {
        private Game game;

        public bool isShowInstruction => Controller.IsInstruction;
        private Timer iTimer = new Timer();

        private List<Bitmap> instraction = new List<Bitmap>
        {
            Resources.Rule0, Resources.Rule1, 
            Resources.Rule2, Resources.Rule3, Resources.Rule4
        };

        private int animate = 0;
        
        public UI(Game g)
        {
            game = g;
            iTimer.Elapsed += (_, _) => animate++;
            iTimer.Interval = 1000;
            iTimer.Start();
        }

        public void UpdateUI(Graphics g)
        {
            //health and energy
            DrawElement(g, Resources.Interface, -700, -450);
            g.DrawString(game.player.Health.ToString(), 
                new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold), 
                Brushes.MistyRose,
                Point.Add(game.player.Position, new Size(-650, -450)));
            g.DrawString(game.player.Energy.ToString(), 
                new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold), 
                Brushes.LightBlue,
                Point.Add(game.player.Position, new Size(-650, -425)));
            
            //input
            DrawElement(g, Resources.InputInstrucion, 600, 300);
            
            if (game.GameStage == GameStage.Lose)
                DrawElement(g, Resources.Interface, 0, 0);
            if (game.GameStage == GameStage.Pause)
                DrawElement(g, Resources.Pause, -30, -40);
            if (isShowInstruction)
            {
                DrawInstruction(g);
            }
            else animate = 0;
        }

        public void DrawInstruction(Graphics g)
        {
            
            if (animate == instraction.Count) iTimer.Stop();
            
            foreach (var s in instraction.Take(animate))
            {
                DrawElement(g, s, -800, -450);
            }   
        }

        private void DrawElement(Graphics g, Image i, int x, int y)
            => g.DrawImage(i, Point.Add(game.player.Position, new Size(x, y)));
    }
}