using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;
using System.Linq;

namespace WinFormsApp1
{
    public class Game
    {
        //objects
        public readonly Player player = new(
            Point.Empty, 
            int.Parse(Resources.HeroStartSpeed), 
            int.Parse(Resources.HeroStartHealth));

        public List<Enemy> Enemies;
        public List<HealthBonus> HealthBonuses;
        public List<Bush> Bushes;
        
        //stages
        public PlayerStage PlayerStage;
        public GameStage GameStage;
        
        public Rectangle ViewZone =>
            new (new Point(player.Position.X - player.Radius, player.Position.Y - player.Radius),
                player.Bounds.Size + new Size(player.Radius * 2, player.Radius * 2));

        public Game()
        {
            Enemies = SpawnManager.Spawn(int.Parse(Resources.EnemyCount), Point.Empty)
                .Select(x=>new Enemy(x))
                .ToList();
            HealthBonuses = SpawnManager.Spawn(int.Parse(Resources.BonusCount), Point.Empty)
                .Select(x=>new HealthBonus(x))
                .ToList();
            Bushes = SpawnManager.Spawn(int.Parse(Resources.BushCount), Point.Empty)
                .Select(x=>new Bush(x))
                .ToList();

            PlayerStage = PlayerStage.Normal;
            GameStage = GameStage.Play;
        }

        public void Update()
        {
            if (GameStage == GameStage.Play)
            {
                
                EnemyUpdate();
                BonusUpdate();
            
                player.Move();
                
                if (player.Health <= 0)
                {
                    PlayerStage = PlayerStage.Died;
                    GameStage = GameStage.Lose;
                }
            }
        }
        private void EnemyUpdate()
        {
            if (PlayerStage==PlayerStage.Normal)
                foreach (var e in Enemies)
                {
                    if (e.View.Bounds.IntersectsWith(player.Bounds))
                        player.TakeDamage(Enemy.Damage);
                    else
                    {
                        if (e.Position.X > player.X) e.Move(-Enemy.Speed, 0);
                        else if (e.Position.X < player.X) e.Move(Enemy.Speed, 0);
                        if (e.Position.Y < player.Y) e.Move(0, Enemy.Speed);
                        else if (e.Position.Y > player.Y) e.Move(0, -Enemy.Speed);
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
                    player.TakeHealth(HealthBonus.Bonus);
                    HealthBonuses.RemoveAt(i);
                    HealthBonuses.Add(new HealthBonus(SpawnManager.Spawn(1, player.Position).First()));
                }
            }
        }
    }
}
