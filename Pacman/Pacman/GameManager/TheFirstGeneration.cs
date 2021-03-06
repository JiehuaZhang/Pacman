﻿using System;
using System.Collections.Generic;
using CommonType;
using CommonType.Enum;
using OperationManager.CheckerManager;
using OperationManager.StrategyManager;

namespace PacmanGame.GameManager
{
    public  class TheFirstGeneration : IGeneration
    {
        private readonly IGame _game;
        private readonly IGenerateChecker _generateChecker;
        public  TheFirstGeneration(IGame game, IGenerateChecker generateChecker)
        {
            _game = game;
            _generateChecker = generateChecker;
        }
        public void Play()
        {
            _game.Run(Get200NewPacman(), _generateChecker.Generate1000Checkers());
        }

        private static Pacman[] Get200NewPacman()
        {
            var newPacmans = new Pacman[(int)GameRules.NumberOfOneGenerationPacman];
            var rnd = new Random();
            for (var i = 0; i < (int)GameRules.NumberOfOneGenerationPacman; i++)
            {
                var p = new Pacman
                {
                    Strategy = GenerateStartegy.FillRandomActionToSituation(GenerateSituationArray.GetSituationArray(), rnd),
                    Generation =1,
                    Points = new int[(int)GameRules.NumberOfOneGenerationChecker]
                };
                newPacmans[i] =p;
            }
            return newPacmans;
        } 
    }
}