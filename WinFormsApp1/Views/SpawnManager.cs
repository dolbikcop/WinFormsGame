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
        public SpawnManager(Form1 form1, int interval, PictureBox p)
        {
            _form1 = form1;
            timer = new Timer();
            timer.Interval = interval;
            timer.Tick += (_, _) => SpawnObject(p);
        }

        public void StartSpawn() => timer.Start();
        public void StopSpawn() => timer.Stop();
        

        public void SpawnObject(PictureBox s)
        {
            PictureBox p = new()
            {
                Image = s.Image, 
                Size = s.Size,
                Tag = s.Tag
            };
            p.Left = r.Next(0, _form1.ClientSize.Width);
            p.Top = r.Next(0, _form1.ClientSize.Height);
            p.SizeMode=PictureBoxSizeMode.Normal;
            _form1.Controls.Add(p);
            p.BringToFront();

        }
    }
}