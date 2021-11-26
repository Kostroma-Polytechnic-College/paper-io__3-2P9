using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paper_io
{
    public class Player
    {
        public enum Dir
        {
            Up, Left, Down, Right
        }
        public Dir dir;
        public Player()
        {
            dir = Dir.Up;
        }
        public void Bot()
        {

        }

    }
}
