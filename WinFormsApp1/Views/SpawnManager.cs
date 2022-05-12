using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class SpawnManager
    {
        private Form1 _form1;
        private Random r = new();
        private Timer timer;
        public SpawnManager(Form1 form1, int interval)
        {
            _form1 = form1;
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += (_, _) => AddEnemies();
        }

        public void StartSpawn() => timer.Start();
        public void StopSpawn() => timer.Stop();
        

        public void AddEnemies()
        {
            PictureBox enemy = new PictureBox();
            enemy.Tag = "zombie";
            enemy.Image = Image.FromFile("E:\\StudioProject\\WinFormsApp1\\WinFormsApp1\\Resources\\enemy.png");
            enemy.Left = r.Next(0, _form1.ClientSize.Width);
            enemy.Top = r.Next(0, _form1.ClientSize.Height);
            enemy.SizeMode=PictureBoxSizeMode.Normal;
            // add enemy in levele
            _form1.Controls.Add(enemy);
            enemy.BringToFront();

        }
    }
}