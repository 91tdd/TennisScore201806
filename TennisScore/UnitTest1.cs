using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class TennisGameTests
    {
        private IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private TennisGame _tennisGame;
        private const int AnyGameId = 1;


        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }

        [TestMethod]
        public void Love_All()
        {
            GivenGame(firstPlayerScore: 0, secondPlayerScore: 0);
            ScoreResultShouldBe("Love All");
        }

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(firstPlayerScore: 1, secondPlayerScore: 0);
            ScoreResultShouldBe("Fifteen Love");
        }

        private void ScoreResultShouldBe(string expected)
        {
            Assert.AreEqual(expected, _tennisGame.ScoreResult(AnyGameId));
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            _repository.GetGame(AnyGameId).Returns(new Game
            {
                Id = AnyGameId,
                FirstPlayerScore = firstPlayerScore,
                SecondPlayerScore = secondPlayerScore
            });
        }
    }
}