using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class View
    {
        private Game _game;
        
        public PictureBox enemyView = new()
        {
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\враг.png"),
            Tag = "enemy",
            Size = new Size(100, 100)
        };

        public View(Game game)
        {
            _game = game;
        }
        public void UpdateGraphics(Graphics g)
        {
            g.TranslateTransform(-_game.player.X+500, -_game.player.Y+500);
            
            _game.Update();
            
            DrawObject(g);
        }

        private void DrawObject(Graphics g)
        {
            g.DrawImage(_game.player.Image, _game.player.Position);
            
            g.DrawRectangle(Pens.Aquamarine, _game.player.Bounds);
            
            foreach (var enemy in _game.Enemies)
                g.DrawImage(enemy.Image, enemy.Bounds);
            
            foreach (var bonus in _game.HealthBonuses)
                g.DrawImage(bonus.Image, bonus.Bounds);
            
            foreach (var item in _game.Items)
                g.DrawRectangle(Pens.Chartreuse, item);
        }
    }
}
