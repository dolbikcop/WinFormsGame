using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class View
    {
        private Game _game;

        public View(Game game)
        {
            _game = game;
        }
        public void UpdateGraphics(Graphics g)
        {

            g.TranslateTransform(-_game.player.X+700, -_game.player.Y+450);
            
            _game.Update();
            
            DrawObjects(g);
        }
        
        private void DrawObjects(Graphics g)
        {
            g.Clear(Color.MidnightBlue);
            g.FillEllipse(Brushes.Azure, _game.ViewZone);
            
            g.DrawImage(_game.player.Image, _game.player.Position);
            
            g.DrawRectangle(Pens.Aquamarine, _game.player.Bounds);
            
            foreach (var enemy in _game.Enemies)
                if (enemy.Bounds.IntersectsWith(_game.ViewZone))
                    g.DrawImage(enemy.Image, enemy.Bounds);
            
            foreach (var bonus in _game.HealthBonuses)
                if (bonus.Bounds.IntersectsWith(_game.ViewZone))
                    g.DrawImage(bonus.Image, bonus.Bounds);
            
            foreach (var item in _game.Bushes)
                if (item.IntersectsWith(_game.ViewZone))
                    g.DrawImage(Resources.Bush, item);
            g.DrawString(_game.player.Health.ToString(), 
                new Font(FontFamily.GenericMonospace, 24, FontStyle.Bold), Brushes.Chartreuse, new Point(0, 0));
        }
    }
}
