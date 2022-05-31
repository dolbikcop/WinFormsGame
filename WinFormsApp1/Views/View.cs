using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class View
    {
        private Game _game;
        
        public PictureBox enemyView = new()
        {
            Image = Resources.Enemy,
            Tag = "enemy",
            Size = new Size(100, 100)
        };

        public View(Game game)
        {
            _game = game;
        }
        public void UpdateGraphics(Graphics g)
        {
            g.Clear(Color.MidnightBlue);

            g.TranslateTransform(-_game.player.X+500, -_game.player.Y+500);
            
            _game.Update();
            
            DrawObjects(g);
        }
        
        private void DrawObjects(Graphics g)
        {
            _game.ActiveForm.label.Text = _game.player.Health.ToString();
            g.DrawRectangle(Pens.Azure, _game.ViewZone);
            
            g.DrawImage(_game.player.Image, _game.player.Position);
            
            g.DrawRectangle(Pens.Aquamarine, _game.player.Bounds);
            
            foreach (var enemy in _game.Enemies)
                if (enemy.Bounds.IntersectsWith(_game.ViewZone))
                    g.DrawImage(enemy.Image, enemy.Bounds);
            
            foreach (var bonus in _game.HealthBonuses)
                if (bonus.Bounds.IntersectsWith(_game.ViewZone))
                    g.DrawImage(bonus.Image, bonus.Bounds);
            
            foreach (var item in _game.Items)
                if (item.IntersectsWith(_game.ViewZone))
                    g.DrawImage(Resources.Bush, item);
        }
    }
}
