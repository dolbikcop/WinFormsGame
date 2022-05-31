using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace WinFormsApp1
{
    public class Game
    {
        public readonly Player player = new(new Point(0, 0), 3, 200);

        public List<Enemy> Enemies = new();

        public List<HealthBonus> HealthBonuses = new();
        
        public List<Rectangle> Items = new();

        public Game()
        {
            SpawnManager.Spawn(ref Enemies, 12, Point.Empty);
            SpawnManager.Spawn(ref HealthBonuses, 20, Point.Empty);
            SpawnManager.Spawn(ref Items, 5, Point.Empty);
        }

        public void Update()
        {
            EnemyUpdate();
            BonusUpdate();
            
            player.Move();
            
            if (player.Health<=0)
                Application.Restart();
        }
        private void EnemyUpdate()
        {
            foreach (var e in Enemies)
            {
                if (e.View.Bounds.IntersectsWith(player.Bounds))
                    player.TakeDamage(e.Damage);
                else
                {
                    if (e.Position.X > player.X) e.Move(-1, 0);
                    else if (e.Position.X < player.X) e.Move(1, 0);
                    if (e.Position.Y < player.Y) e.Move(0, 1);
                    else if (e.Position.Y > player.Y) e.Move(0, -1);
                }
            }
        }

        private void BonusUpdate()
        {
            for (int i = 0; i<HealthBonuses.Count; i++)
            {
                var b = HealthBonuses[i];
                if (b.Bounds.IntersectsWith(player.Bounds))
                {
                    player.Bounds.Inflate(new Size(-50, -50));
                    player.TakeHealth(10);
                    HealthBonuses.RemoveAt(i);
                    SpawnManager.Spawn(ref HealthBonuses, 1, player.Position);
                }
            }
        }
    }
}
