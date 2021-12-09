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
        enum Direction
        {
            Left,
            Right,
            Down,
            Up
        }
        Direction direction;
        public Player(byte rand)
        {
            
        }

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
        int m;
        int k;

        public void Bot(Game[,] room)
        {
            ///Если со всех сторон находится территория текущего игрока, то направление движения не менять. 
            if (location.X + 1 == m && location.X - 1 == m && location.Y + 1 == m && location.Y - 1 == m)
            {

            }
            ///Если впереди текущего игрока находится стена и слева нет стены, то повернуть на лево.
            else if ()
            {

            }
            ///Если впереди игрока находится стена и справа нет стены, то повернуть направо.
            else if ()
            {

            }
            ///Если впереди и слева и справа нет территории текущего игрока, то повернуть направо если там нет стены или повернуть налево если справа есть стена.
            else if ()
            {
                if ()
                {

                }
                else
                {

                }
            }
            ///Если впереди нет территории текущего игрока, а слево или справа есть территория текущего игрока, то повернуть в сторону территории текущего игрока.
            else if ()
            {

            }

        }
    }
}
