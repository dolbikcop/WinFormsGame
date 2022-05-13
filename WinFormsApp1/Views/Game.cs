﻿using System;
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
        public readonly Player player;

        public Size size;
        private Form1 f;
        private Timer timer;

        private Label healthBar = new()
        {
            Text = "Health: ", 
        };





        PictureBox playerImage = new()
        {
            ImageLocation = @"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\character.png", 
            Height = 100, Width = 100,
            Tag = "player"
        };

        private PictureBox hBonusImage = new()
        {
            Size = new Size(50, 50),
            Tag = "health",
            Image = Image.FromFile(@"E:\StudioProject\WinFormsApp1\WinFormsApp1\Resources\HealthBonus.png")
        };
        
        
        
        public SpawnManager spawnHealth;

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

            timer.Tick += (_, _) => IntersectionObject();
            player = new Player(new Point(0, 0), 30, 12);
            
            f.Controls.Add(playerImage);
            timer.Start();
            
            spawnHealth = new SpawnManager(f, 10000, hBonusImage);
            f.Controls.Add(healthBar);
        }
        void PlayerView()
        {
            playerImage.Location = new Point(f.ClientSize.Width / 2 + player.X,
                f.ClientSize.Height / 2 + player.Y);
        }

        private void UpdateForm()
        {
            player.Move(f.HInput, f.VInput);
            healthBar.Text = "Health: " + player.Health;
            f.Invalidate();
        }
        
        
        private void IntersectionObject()
        {
            foreach (var i in f.Controls)
            {
                foreach (var j in f.Controls)
                {
                    if (i is PictureBox && j is PictureBox && i != j)
                    {
                        PictureBox a = (PictureBox)i, b=(PictureBox)j;
                        if (a.Tag == "player" && b.Tag == "health" && a.Bounds.IntersectsWith(b.Bounds))
                        {
                            player.TakeHealth(10);
                            f.Controls.Remove(b);
                            b.Dispose();
                        }
                    }
                }
            }
        }
    }
}
