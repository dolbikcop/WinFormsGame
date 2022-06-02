using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class UI
    {
        private Game game;
        public UI(Game g)
        {
            game = g;
        }

        public void UpdateUI(Graphics g)
        {
            //health and energy
            g.DrawImage(Resources.Interface, 
                Point.Add(game.player.Position, new Size(-600, -300)));
            g.DrawString(game.player.Health.ToString(), 
                new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold), 
                Brushes.MistyRose,
                Point.Add(game.player.Position, new Size(-550, -300)));
            g.DrawString(game.player.Energy.ToString(), 
                new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold), 
                Brushes.LightBlue,
                Point.Add(game.player.Position, new Size(-550, -265)));
            
            //input
            g.DrawImage(Resources.InputInstrucion, 
                Point.Add(game.player.Position, new Size(600, 300)));
            if (game.GameStage == GameStage.Lose)
                g.DrawImage(Resources.InputInstrucion, 
                    Point.Add(game.player.Position, new Size(0, 0)));
            
            g.DrawString(Screen.PrimaryScreen.Bounds.Width + " " + Screen.PrimaryScreen.Bounds.Height, 
                new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold), 
                Brushes.MistyRose,
                Point.Add(game.player.Position, new Size(-500, -200)));
        }
    }
}