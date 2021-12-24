using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///<summary> 
///Это пространво имён необходимо для реализации структуры Point 
///</summary>
using System.Windows;

namespace paper_io
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
    /// <summary>
    /// Класс, отвечающий за логику игрока
    /// </summary>
    public class Player
    {
        public Direction Direction;
        /// <summary>
        /// Метод, реализующий поворот налево
        /// </summary>
        public void ToLeft()
        {
            int result = (int)Direction - 1;
            if (result < 0)
            {
                result = 3;
            }
            Direction = (Direction)result;
        }
        /// <summary>
        /// Метод, реализующий поворот направо
        /// </summary>
        public void ToRight()
        {
            int result = (int)Direction + 1;
            if (result > 3)
            {
                result = 0;
            }
            Direction = (Direction)result;
        }
        /// <summary>
        /// положение игрока
        /// </summary>
        public Point location = new Point();
        /// <summary>
        /// координаты шлейфа
        /// </summary>
        List<Point> plume = new List<Point>();
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
