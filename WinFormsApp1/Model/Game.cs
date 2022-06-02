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
        
        public GameStage GameStage;
        
        public Rectangle ViewZone =>
            new (new Point(player.Position.X - player.Radius, player.Position.Y - player.Radius),
                player.Bounds.Size + new Size(player.Radius * 2, player.Radius * 2));

        public Game()
        {
            Enemy.Objects = SpawnManager.Spawn(int.Parse(Resources.EnemyCount), Point.Empty)
                .Select(x=>new Enemy(x))
                .ToList();
            HealthBonus.Objects = SpawnManager.Spawn(int.Parse(Resources.BonusCount), Point.Empty)
                .Select(x=>new HealthBonus(x))
                .ToList();
            Bush.Objects = SpawnManager.Spawn(int.Parse(Resources.BushCount), Point.Empty)
                .Select(x=>new Bush(x))
                .ToList();
            EnergyBonus.Objects = SpawnManager.Spawn(int.Parse(Resources.BonusCount), Point.Empty)
                .Select(x => new EnergyBonus(x))
                .ToList();
            player.Stage = PlayerStage.Normal;
            GameStage = GameStage.Play;
        }

        public void Update()
        {
            switch (GameStage)
            {
                case GameStage.Play:
                    if (player.Health <= 0 || player.Energy <= 0)
                        GameStage = GameStage.Lose;
                    else if (Controller.IsPaused)
                        GameStage = GameStage.Pause;
                    
                    Enemy.Update(player);
                    HealthBonus.Update(player);
                    Bush.Update(player);
                    EnergyBonus.Update(player);
                    
                    player.Move();
                    break;
                case GameStage.Pause:
                    player.Die();
                    if (!Controller.IsPaused)
                    {
                        player.Start();
                        GameStage = GameStage.Play;
                    }
                    break;
                case GameStage.Lose:
                    player.Die();
                    break;
            }
        }
    }
}
