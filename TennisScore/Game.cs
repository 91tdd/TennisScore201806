using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class Game
    {
        private const string Deuce = "Deuce";

        private static readonly Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"}
        };

        public string FirstPlayerName { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string SecondPlayerName { get; set; }
        public int SecondPlayerScore { get; set; }

        public string ScoreResult()
        {
            return IsScoreDifferent()
                ? (IsReadyForWin() ? AdvStateResult() : LookupScore())
                : (IsDeuce() ? Deuce : SameScore());
        }

        private string AdvPlayer()
        {
            var advPlayer = FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
            return advPlayer;
        }

        private string AdvScore()
        {
            return AdvPlayer() + " Adv";
        }

        private string AdvStateResult()
        {
            if (IsAdv())
            {
                return AdvScore();
            }

            return WinScore();
        }

        private bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        private bool IsDeuce()
        {
            var isSameScore = FirstPlayerScore == SecondPlayerScore;
            return FirstPlayerScore >= 3 && isSameScore;
        }

        private bool IsReadyForWin()
        {
            return FirstPlayerScore > 3 || SecondPlayerScore > 3;
        }

        private bool IsScoreDifferent()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        private string LookupScore()
        {
            return _scoreLookup[FirstPlayerScore] + " " + _scoreLookup[SecondPlayerScore];
        }

        private string SameScore()
        {
            return _scoreLookup[FirstPlayerScore] + " All";
        }

        private string WinScore()
        {
            return AdvPlayer() + " Win";
        }
    }
}