using JD.Utility;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public async Task ExportDataTest()
        {
            var entities = await new GameManager(options).LoadAsync().ConfigureAwait(false);
            string[] columns = { "GameResult" };
            var data = GameManager.ConvertData(entities, columns);
            Excel.Export("game.xlsx", data);
        }

        [TestMethod]
        public async Task LoadTest()
        {
            List<Game> games = await new GameManager(options).LoadAsync();
            int expected = 2;
            Assert.AreEqual(expected, games.Count);
        }
        [TestMethod]
        public async Task InsertTest()
        {
            Game game = new Game
            {
                Id =Guid.NewGuid(),
                GameResult = 20.00,
            };

            Guid results = await new GameManager(options).InsertAsync(game, true);
            Assert.AreNotEqual(results, Guid.Empty);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            Game game = (await new GameManager(options).LoadAsync()).FirstOrDefault(); ;

            Assert.IsTrue(new GameManager(options).UpdateAsync(game, true).Result > 0);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Game game = (await new GameManager(options).LoadAsync()).FirstOrDefault();
            Assert.IsTrue(new GameManager(options).DeleteAsync(game.Id, true).Result > 0);
        }
        [TestMethod]
        public async Task LoadByIdTest()
        {
            Game game = (await new GameManager(options).LoadAsync()).FirstOrDefault();
            Assert.AreEqual((await new GameManager(options).LoadByIdAsync(game.Id)).Id, game.Id);

        }
        [TestMethod]
        public async Task StartGame()
        {
            Game game = new Game();
            game.GameResult = 200000000000;
            game.Users = new List<User>();
            game.Users.Add((await new UserManager(options).LoadAsync()).FirstOrDefault());
            List<GameState> state = (await new GameManager(options).StartNewGame(game));
            Assert.AreEqual((await new GameManager(options).LoadByIdAsync(state[0].Id)).Id, state[0].Id);

        }
    }
}