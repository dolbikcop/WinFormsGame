using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Game
    {
        public readonly Player player = new(new Point(0, 0), 1, 12);
        public Enemy enemySourse = new (1, 1);
        public HealthBonus HealthBonus = new(10);

        public List<Rectangle> enemys = new List<Rectangle>();

        public Size size;
        private Form1 f;
        private Timer timer;

        public SpawnManager spawnHealth;
        public SpawnManager spawnEnemy;

        Timer upTimer = new() { Interval = 10};
        public Game(Form1 form)
        {
            f=form;
            
            upTimer.Tick += (_, _) => UpdateForm();
            upTimer.Tick += (_, _) => IntersectionObject();
            upTimer.Start();

            spawnEnemy = new SpawnManager(f, 2000, enemySourse.View);
            spawnEnemy.StartSpawn();

            spawnHealth = new SpawnManager(f, 10000, HealthBonus.View);
            
            //f.Controls.Add(player.View);
            
            player.Move(f.ClientSize.Width / 2, f.ClientSize.Height / 2);
        }

        private void UpdateForm()
        {
            if (player.Health <= 0)
                LoseGame();
            f.healthBar.Text = "Health: " + player.Health+ " " + player.Position.X+ " " + player.Position.Y;
            f.Invalidate();
        }

        private void LoseGame()
        {
            timer.Stop();
            spawnEnemy.StopSpawn();
            spawnHealth.StopSpawn();
            f.Controls.Add(new Label{Text = "You're loser:(", Location = player.Position, ForeColor = Color.Red});
        }


        private void IntersectionObject()
        {
            foreach (var i in f.Controls)
            {
                if (i is PictureBox box && box.Tag == "enemy")
                {
                    box.Location = new Point(box.Location.X+(box.Location.X<player.X ? 
                            enemySourse.Speed : 
                            box.Location.X==player.X ? 0 : -enemySourse.Speed), 
                        box.Location.Y+(box.Location.Y<player.Y ? 
                            enemySourse.Speed : 
                            box.Location.Y==player.Y ? 0 : -enemySourse.Speed));
                }
                foreach (var j in f.Controls)
                {
                    if (i is PictureBox && j is PictureBox && i != j)
                    {
                        PictureBox a = (PictureBox)i, b=(PictureBox)j;
                        if (a.Tag == "player" && b.Tag == "health" && a.Bounds.IntersectsWith(b.Bounds))
                        {
                            player.TakeHealth(HealthBonus.Bonus);
                            f.Controls.Remove(b);
                            b.Dispose();
                        }
                        if (a.Tag == "player" && b.Tag == "enemy" && a.Bounds.IntersectsWith(b.Bounds))
                        {
                            player.TakeDamage(enemySourse.Damage);
                        }
                   }
                }
            }
        }
    }
}
