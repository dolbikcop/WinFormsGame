using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private int speed = 5;
        public Form1()
        {
            InitializeComponent();
            this.KeyDown += OKP;
        }

        private void OKP(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    break;
                case "Left":
                    break;
                case "Up":
                    break;
                case "Down":
                    break;
            }
        }
    }
}