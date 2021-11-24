using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paper_io
{
    /// <summary>
    /// 
    /// </summary>
    class Game
    {
        /// <summary>
        /// 
        /// </summary>
        public Player[] Players;
        /// <summary>
        /// 
        /// </summary>
        public Player[,] Room;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n"></param>
        public Game(byte n)
        {
            Players = new Player[n];
            Room = new Player[n * 10, n * 10];
        }
    }
}
