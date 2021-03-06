﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;

namespace OperationManager.Interface
{
    public interface IRunTheGame
    {
        void GetPoints(ref Pacman[] pacmans, Checker checker, int checkerindex);
        void StartMove(ref Pacman pacman, CheckPosition startPosition, Checker checker, int index);
        CheckPosition FindStartCheck();
    }
}
