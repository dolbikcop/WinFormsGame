using System.Windows.Forms;

namespace WinFormsApp1
{
    internal class Control
    {
        public static bool IsInputUp { get; private set; }
        public static bool IsInputLeft { get; private set; }
        public static bool IsInputDown { get; private set; }
        public static bool IsInputRight { get; private set; }
        internal static void ControlKeys(Keys key, bool isActive)
        {
            switch (key)
            {
                case Keys.W:
                    IsInputUp = isActive;
                    break;
                case Keys.A:
                    IsInputLeft = isActive;
                    break;
                case Keys.S:
                    IsInputDown = isActive;
                    break;
                case Keys.D:
                    IsInputRight = isActive;
                    break;

                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.R:
                    Application.Restart();
                    break;
                /*case Keys.F:
                    View.GoFullscreen();
                    break;*/
            }
        }
    }
}