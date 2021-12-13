using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;

namespace paper_io
{
    /// <summary>
    /// Заглушка класса Player
    /// </summary>
    public class Player
    {
        /// <summary>
        /// 
        /// </summary>
        public Point location = new Point();
        /// <summary>
        /// 
        /// </summary>
        List<Point> plume = new List<Point>();

        Boolean areNotEqual = true;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="players"></param>
        /// <param name="Room"></param>
        /// <returns></returns>
        public bool CheckdDeathCondition(List<Player> players, Player[,] Room)
        {

            foreach (Player playerItem in players)
            {
                foreach (Point plumeItem in plume)
                {

                    if (playerItem.location.X == plumeItem.X && playerItem.location.Y == plumeItem.Y)
                    {
                        return true;
                    }
                }
            }
            if (location.X < 0 || location.X > Room.GetLength(1) || location.Y < 0 || location.Y > Room.GetLength(0))
            {
                return true;
            }
            if ()
            {
                return true;
            }
            return false;
        }

    }
}
