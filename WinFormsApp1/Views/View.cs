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
            game.Update(); 
            
            //transform camera
            g.TranslateTransform(-game.player.X+700, -game.player.Y+450);
            
            DrawObjects(g);
            
            ui.UpdateUI(g);
        }
        
        private void DrawObjects(Graphics g)
        {
            //BackgroundColor
            g.Clear(Color.Black);
            
            g.FillEllipse(Brushes.DarkGreen, game.ViewZone);
            
            
            
            foreach (var h in Enemy.hObjects)
                if (h.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(h.Image, h.Bounds);
            foreach (var h in Plant.Objects)
                if (h.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(h.Image, h.Bounds);

            g.DrawImage(game.player.Star, game.player.Position+new Size(15, -25));
            g.DrawImage(game.player.Image, game.player.Position);
            
            foreach (var enemy in Enemy.Objects)
                if (enemy.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(enemy.Image, enemy.Bounds);
            
            foreach (var item in Bush.Objects)
                if (item.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(item.Image, item.Bounds);
            
            foreach (var bonus in HealthBonus.Objects)
                if (bonus.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(bonus.Image, bonus.Bounds);
            
            foreach (var bonus in EnergyBonus.Objects)
                if (bonus.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(bonus.Image, bonus.Bounds);
            foreach (var bonus in TimeBonus.Objects)
                if (bonus.Bounds.IntersectsWith(game.ViewZone))
                    g.DrawImage(bonus.Image, bonus.Bounds);
        }
    }
}
