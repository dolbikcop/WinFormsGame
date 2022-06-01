using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class View
    {
        private Game game;
        private UI ui;

        public View(Game game)
        {
            this.game = game;
            ui = new UI(game);
        }
        public void UpdateGraphics(Graphics g)
        {
            //transform camera
            g.TranslateTransform(-game.player.X+700, -game.player.Y+450);
            if (game.GameStage != GameStage.Pause)
            {
                game.Update();
            
                DrawObjects(g);   
            }
            
            ui.UpdateUI(g);
        }
        
        private void DrawObjects(Graphics g)
        {
            //BackgroundColor
            g.Clear(Color.MidnightBlue);
            g.FillEllipse(Brushes.Azure, game.ViewZone);
            
            g.DrawImage(game.player.Image, game.player.Position);
            
            //bounds of player
            g.DrawRectangle(Pens.Aquamarine, game.player.Bounds);
            
            foreach (var enemy in Enemy.Objects)
                if (enemy.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(enemy.Image, enemy.Bounds);
            
            foreach (var bonus in HealthBonus.Objects)
                if (bonus.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(bonus.Image, bonus.Bounds);
            
            foreach (var item in Bush.Objects)
                if (item.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(item.Image, item.Bounds);
        }
    }
}
