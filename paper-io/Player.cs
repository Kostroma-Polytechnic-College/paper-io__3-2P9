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
        /// положение игрока
        /// </summary>
        public Point location = new Point();
        /// <summary>
        /// координаты шлейфа
        /// </summary>
        List<Point> plume = new List<Point>();
        Boolean areNotEqual = true;
        /// <summary>
        /// условие смерти
        /// </summary>
        /// <param name="players">для проверки касания шлейфа</param>
        /// <param name="Room">для проверки наличия территории игрока и проверки выезда игрока за карту</param>
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
            foreach (Player territory in Room)
            {
                if (this == territory)
                {
                }
                else return true;
            }
            return false;
        }
    }
}
