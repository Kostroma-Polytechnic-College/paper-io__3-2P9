using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows;
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
        /// <summary>
        /// Метод, отвечающий за изменение направления бота
        /// </summary>
        /// <param name="room">Игровое поле</param>
        /// <returns>Истина, если направление изменилось</returns>
        public bool Bot(Player[,] room)
        {
            int x = (int)location.X;
            int y = (int)location.Y;

            return AllSidesFriendTerritory(room, x, y)
                || ForwardLeft(room, x, y)
                || ForwardRight(room, x, y)
                || ForwardLeftRight(room, x, y);
        }
        /// <summary>
        /// Если впереди игрока находится стена и справа нет стены, то повернуть направо.
        /// </summary>
        /// <param name="room">Игровое поле</param>
        /// <param name="x">Настоящее положение игрока по оси X</param>
        /// <param name="y">Настоящее положение игрока по оси Y</param>
        /// <returns>Истина, если направление изменилось</returns>
        bool ForwardRight(Player[,] room, int x, int y)
        {
            if (y < room.Length - 1)
            {
                if (x == 0 || x == room.Length - 1)
                {
                    ToRight();
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Если впереди текущего игрока находится стена и слева нет стены, то повернуть налево.
        /// </summary>
        /// <param name="room">Игровое поле</param>
        /// <param name="x">Настоящее положение игрока по оси X</param>
        /// <param name="y">Настоящее положение игрока по оси Y</param>
        /// <returns>Истина, если направление изменилось</returns>
        bool ForwardLeft(Player[,] room, int x, int y)
        {
            if (y > 0)
            {
                if (x == 0 || x == room.Length - 1)
                {
                    ToLeft();
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Если со всех сторон находится территория текущего игрока, то направление движения не менять
        /// </summary>
        /// <param name="room">Игровое поле</param>
        /// <param name="x">Настоящее положение игрока по оси X</param>
        /// <param name="y">Настоящее положение игрока по оси Y</param>
        /// <returns>Истина, если направление изменилось</returns>
        bool AllSidesFriendTerritory(Player[,] room, int x, int y)
        {
            if (room[x, y + 1] == this
                && room[x - 1, y] == this
                && room[x + 1, y] == this
                && room[x, y - 1] == this
                )
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// Если впереди и слева и справа нет территории текущего игрока, то повернуть
        /// направо если там нет стены или повернуть налево если справа есть стена.
        /// </summary>
        /// <param name="room">Игровое поле</param>
        /// <param name="x">Настоящее положение игрока по оси X</param>
        /// <param name="y">Настоящее положение игрока по оси Y</param>
        /// <returns>Истина, если направление изменилось</returns>
        bool ForwardLeftRight(Player[,] room, int x, int y)
        {
            if (room[x, y + 1] == this
                && room[x - 1, y] == this
                && room[x + 1, y] == this
                )
            {
                if (x != 0 || y < room.Length - 1)
                {
                    ToRight();
                    return true;
                }

                ToLeft();
                return true;
            }

            return false;
        }
    }
}
