using System.Collections.Generic;
using CommonType;
using OperationManager.GameManager;
using OperationManager.StrategyManager;

namespace PacmanGame
{
    public static class TheFirstGeneration
    {
        public static List<Pacman> PlayGame()
        {
            var pacmans = Get200NewPacman();
            RunTheGame.GetPoints(ref pacmans);
            GameResult.GetRankingAndWeight(ref pacmans);
            return pacmans;
        }

        public static List<Pacman> Get200NewPacman()
        {
            var newPacmans = new List<Pacman>();
            for (var i = 0; i < 200; i++)
            {
                var p = new Pacman
                {
                    Strategy = GenerateStartegy.FillRandomActionToSituation(GenerateSituationArray.GetSituationArray())
                };
                newPacmans.Add(p);
            }
            return newPacmans;
        }
    }
}
