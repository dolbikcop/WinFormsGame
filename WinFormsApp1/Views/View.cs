using System.Drawing;

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
            g.TranslateTransform(-_game.player.X+500, -_game.player.Y+500);
            _game.player.Move();
            
            g.DrawImage(_game.player.View.Image, _game.player.View.Location);
            foreach (var r in _game.enemys)
            {
                g.DrawRectangle(Pens.Red, r);
            }
        }
    }
}
