

using System.Timers;

namespace WinFormsApp1
{
    public class EnergyManager
    {
        public int Energy = int.Parse(Resources.EnergyCount);
        public static Timer timer;

        public EnergyManager()
        {
            timer = new Timer();
            timer.Interval = 500;
            timer.Elapsed += (sender, args) => Energy--;
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();
    }
}