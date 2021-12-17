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
        /// <summary>
        /// Перечисление сторон для управления
        /// </summary>
        public enum Direction
        {
            Left,
            Up,
            Right,
            Down
        }
        public Direction direction;
        /// <summary>
        /// Метод, реализующий поворот налево
        /// </summary>
        public void ToLeft()
        {
            int result = (int)direction - 1;
            if (result < 0)
            {
                result = 3;
            }
            direction = (Direction)result;
        }
        /// <summary>
        /// Метод, реализующий поворот направо
        /// </summary>
        public void ToRight()
        {
            int result = (int)direction + 1;
            if (result > 3)
            {
                result = 0;
            }
            direction = (Direction)result;
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
        int m; // территоря текущего икгрока
        int k; // стена
        int c; // свободная территория
        int q; // вражеская территория

        public void Step(Game[,] room)
        {
            if (location.X == c && location.Y == c && location.X == q && location.Y == q)
            {
                plume.Add(location);
            }
        }
        /// <summary>
        /// Метод, реализующий логику поведения бота
        /// </summary>
        public void Bot()
        {
            ///Если со всех сторон находится территория текущего игрока, то направление движения не менять. 
            if (location.X + 1 == m && location.X - 1 == m && location.Y + 1 == m && location.Y - 1 == m)
            {

            }
            ///Если впереди текущего игрока находится стена и слева нет стены, то повернуть на лево.
            else if (location.X + 1 == k && location.Y - 1 != k)
            {
                ToLeft();
            }
            ///Если впереди игрока находится стена и справа нет стены, то повернуть направо.
            else if (location.X + 1 == k  && location.Y + 1 !=  k )
            {
                ToRight();
            }
            ///Если впереди и слева и справа нет территории текущего игрока, то повернуть направо если там нет стены или повернуть налево если справа есть стена.
            else if (location.X + 1 == m && location.Y + 1 == m && location.Y - 1 == m)
            {
                if (location.Y - 1 != k )
                {
                    ToRight();
                }
                else
                {
                    ToLeft();
                }
            }
            ///Если впереди нет территории текущего игрока, а слево или справа есть территория текущего игрока, то повернуть в сторону территории текущего игрока.
            else if (location.X + 1 != m )
            {
                if (location.Y + 1 == m)
                {
                    ToLeft();
                }
                else
                {
                    ToRight();
                }
            }

        }
     
    }
}
