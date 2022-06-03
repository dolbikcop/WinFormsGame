using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Player
    {
        public Point Position
        {
            get => View.Location;
            set => View.Location = value;
        }
        public Rectangle Bounds => View.Bounds;
        public Image Image => View.Image;
        
        public PictureBox View = new()
        {
            Image = Resources.MainHero,
            Size = Resources.MainHero.Size,
            Location = new Point(0, 0)
        };
        
        public int Speed { get; private set; }
        private int startSpeed;
        public int Health { get; private set; }
        public int X => Position.X;

        public int Y => Position.Y;

        public int Radius => eManager.Energy * 2;

        private EnergyManager eManager;
        public int Energy => eManager.Energy;

        public PlayerStage Stage;
        public Player(Point start, int speed, int health)
        {
            eManager = new EnergyManager();
            eManager.Start();
            
            Position = start;
            Speed = speed;
            startSpeed = speed;
            Health = health;
        }

        public void Die()
        {
            eManager.Stop();
            Stage = PlayerStage.Died;
            Speed = 0;
        }

        public void Start()
        {
            eManager.Start();
            Stage = PlayerStage.Normal;
            Speed = startSpeed;
        }

        public void Move(int dx, int dy)
        {
            var delta = new Size(dx * Speed, dy * Speed);
            Position = Point.Add(Position, delta);
        }
        public void Move()
        {
            if (Controller.IsInputDown)
                Move(0, 1);
            if (Controller.IsInputUp)
                Move(0, -1);
            if (Controller.IsInputRight)
                Move(1, 0);
            if (Controller.IsInputLeft)
                Move(-1, 0);
        }

        public void Update()
        {
            Move();
            if (Controller.IsHeal && Health >= 200) 
                Stage = PlayerStage.Heal;
            switch (Stage)
            {
                case PlayerStage.Normal:
                    break;
                case PlayerStage.Died:
                    break;
                case PlayerStage.Heal:
                    break;
            }
        }
        public void TakeHealth(int i)
        {
            Health += i;
        }
        public void TakeEnergy(int i)
        {
            eManager.Energy += i;
        }
    }
}