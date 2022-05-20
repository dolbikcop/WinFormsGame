using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class View
    {
        public PictureBox view = new()
        {
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\character.png"),
            Height = 100, Width = 100,
            Tag = "player",
            Location = new Point(0, 0)
        };
        private Game _game;

        public View(Game game)
        {
            _game = game;
        }
        public void UpdateGraphics(Graphics g)
        {
            g.TranslateTransform(-_game.player.X+100, -_game.player.Y+100);
            view.Location = _game.player.Position;
            _game.player.Move();
            
            g.DrawImage(view.Image, view.Location);
            
        }
    }
}
