namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }

        public bool IsScoreDifferent()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        public bool IsDeuce()
        {
            var isSameScore = FirstPlayerScore == SecondPlayerScore;
            return FirstPlayerScore >= 3 && isSameScore;
        }
    }
}