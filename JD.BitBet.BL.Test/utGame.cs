using JBS.BitBet.BL.Test;

namespace JD.BitBet.BL.Test
{
    [TestClass]
    public class utGame : utBase
    {
        [TestMethod]
        public async Task LoadTest()
        {
            List<Game> directors = await new GameManager(options).LoadAsync();
            int expected = 0;
            Assert.AreEqual(2, directors.Count);
        }
        [TestMethod]
        public async Task InsertTest()
        {
            int id = 0;
            Game game = new Game
            {
                GameResult = 20.00,
            };

            Guid results = await new GameManager(options).InsertAsync(game, true);
            Assert.AreNotEqual(results, Guid.Empty);
        }

        [TestMethod]
        public async Task UpdateTest()
        {
            Game director = (await new GameManager(options).LoadAsync()).FirstOrDefault(); ;

            Assert.IsTrue(new GameManager(options).UpdateAsync(director, true).Result > 0);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            Game director = (await new GameManager(options).LoadAsync()).FirstOrDefault();
            Assert.IsTrue(new GameManager(options).DeleteAsync(director.Id, true).Result > 0);
        }
        [TestMethod]
        public async Task LoadByIdTest()
        {
            Game director = (await new GameManager(options).LoadAsync()).FirstOrDefault();
            Assert.AreEqual((await new GameManager(options).LoadByIdAsync(director.Id)).Id, director.Id);

        }
    }
}