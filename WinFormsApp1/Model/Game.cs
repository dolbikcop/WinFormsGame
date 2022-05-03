using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class Game
    {
        public Player player;

        public List<Level> levels;

        public readonly Level internalLevel;

        public Game(Player player)
        {
            this.player = player;
            levels = new List<Level>
            {
                new Level()
            };
            internalLevel = levels[0];
        }

        public Game()
        {
        }
    }
}
