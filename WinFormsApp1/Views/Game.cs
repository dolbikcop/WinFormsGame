using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1.Model
{
    public class Game
    {
        readonly Player player;

        public Size size;
        private Form1 f;
        private Timer timer;
        
        
        
        
        
        PictureBox playerImage = new()
        {
            ImageLocation = @"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\enemy.png"
        };

        public Game(Player player)
        {
            this.player = player;
        }

        public Game(Form1 form)
        {
        f=form;
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += (_, _) => UpdateForm();
            timer.Tick += (_, _) => PlayerView();
            player = new Player(new Point(0, 0), 30, 12);
            
            f.Controls.Add(playerImage);
            timer.Start();
        }
        void PlayerView()
        {
            playerImage.Location = new Point(f.ClientSize.Width / 2 + player.X,
                f.ClientSize.Height / 2 + player.Y);
        }

        private void UpdateForm()
        {
            player.Move(f.HInput, f.VInput);
            f.Invalidate();
        }
    }
}
