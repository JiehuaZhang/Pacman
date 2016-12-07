using System.Collections.Generic;
using CommonType;
using OperationManager.StrategyManager;

namespace PacmanGame
{
    public static class TheFirstGeneration
    {
        public static List<Pacman> GetTheFistGeneration()
        {
            var pacmans = Get200NewPacman();
            RunTheGameGetPoints(ref pacmans);
            GetRankingAndWeight(ref pacmans);
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

        public static void RunTheGameGetPoints(ref List<Pacman> pacmans)
        {
            foreach (var p in pacmans)
            {
                
            }
        }

        public static void GetRankingAndWeight(ref List<Pacman> pacmans)
        {
            
        }
    }
}
