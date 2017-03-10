using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;

namespace SmallOutput
{
    public class RunAStrategy
    {
     
        private readonly RunTheGame _runTheGame;
        private readonly SqLiteConnection _sqLite;
        public RunAStrategy( RunTheGame runTheGame, SqLiteConnection sqLite)
        {
            _runTheGame = runTheGame;
            _sqLite = sqLite;
        }
        public int RunAStartegyToGetPoint(int generation, int pacmanOrdder, CheckPosition position, Checker checker)
        {
            var strategy = GetStrategy(generation, pacmanOrdder);

            return GetResultByStrategy(strategy, position,checker);
        }

        private  Strategy GetStrategy(int generation, int pacmanOrdder)
        {
            var pacmans = _sqLite.GetOneGenerationPacmans(generation).OrderByDescending(x => x.Weight).ToArray();
            var strategy = pacmans[pacmanOrdder - 1].Strategy;
            return strategy;
        }

        public int GetResultByStrategy(Strategy strategy, CheckPosition position, Checker checker)
        {
        
            var pacman = new Pacman
            {
                Strategy = strategy,
                Points = new int[1],
            };
            _runTheGame.StartMove(ref pacman, position, checker, 0);
            return pacman.Points[0];
        }
    }
}
