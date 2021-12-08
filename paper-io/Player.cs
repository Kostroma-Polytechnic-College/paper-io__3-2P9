using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace paper_io
{
    /// <summary>
    /// Класс, отвечающий за логику игрока
    /// </summary>
    public class Player
    {
        Point location = new Point();
        List<Point> plume = new List<Point>();

        Boolean areNotEqual = true;

        public bool CheckdDeathCondition(Point Players)
        {
            foreach (Point item in plume)
                if (item.X == location.X && item.Y == location.Y)
                    return true;




            return false;
        }
    }
}
