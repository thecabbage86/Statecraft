using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statecraft.GameLogic.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.GameLogic.Tests
{
    [TestClass]
    public class GameHttpHelperTests
    {
        GameHttpHelper httpHelper = new GameHttpHelper();

        //TODO: refactor and improve
        [TestMethod]
        public void GameHttpHelperTest()
        {
            var games = httpHelper.GetGamesByPlayerId(Guid.NewGuid()).Result;

            Assert.IsNotNull(games);
        }
    }
}
