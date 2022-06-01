using System.Drawing;

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
        }
    }
}