using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paper_io
{
    /// <summary>
    /// Основной класс, использьзуется для создания поля и отслеживания количества игроков
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Список всех игроков
        /// </summary>
        List<Player> Players = new List<Player>();
        /// <summary>
        /// Хранит территорию игроков
        /// </summary>
        public Player[,] Room;
        /// <summary>
        /// Принимает количество игроков и делает поле размерностью n*n, где n- количество игроков * 10
        /// </summary>
        /// <param name="n">Количество игроков</param>
        public Game(byte n)
        {
            Room = new Player[n * 10, n * 10];
            for (int i = 0; i < n; i++)
                Players.Add(new Player());
        }
    }
}
