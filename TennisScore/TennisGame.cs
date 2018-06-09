using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>
        {
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (game.IsScoreDifferent())
            {
                if (game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3)
                {
                    if (Math.Abs(game.FirstPlayerScore - game.SecondPlayerScore) == 1)
                    {
                        var advPlayer = game.FirstPlayerScore > game.SecondPlayerScore
                            ? game.FirstPlayerName
                            : game.SecondPlayerName;

                        return advPlayer + " Adv";
                    }
                }

                return _scoreLookup[game.FirstPlayerScore] + " " + _scoreLookup[game.SecondPlayerScore];
            }

            if (game.IsDeuce())
            {
                return "Deuce";
            }

            return _scoreLookup[game.FirstPlayerScore] + " All";
        }
    }
}