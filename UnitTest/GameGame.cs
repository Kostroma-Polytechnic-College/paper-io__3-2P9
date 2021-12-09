using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    /// <summary>
    /// Тестирование конструктора класса Game
    /// </summary>
    [TestClass]
    public class GameGame
    {
        [TestMethod]
        public void PlayerCount()
        {
            byte playerCount = 5;
            Game game = new Game(playerCount);
            Assert.IsTrue(game.Players.Count == playerCount);
            Assert.IsTrue(game.Room.Length == playerCount * playerCount * 100);
        }
    }
}
