using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonType;
using CommonType.Enum;
using log4net;
using OperationManager.Helper;
using OperationManager.Interface;

namespace OperationManager.GameManager
{
    public  class RunTheGame : IRunTheGame
    {
        public ILog Log => LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public  void GetPoints(ref Pacman[] pacmans, Checker checker, int checkerindex)
        {
            for (var i=0;i<pacmans.Length;i++)
            {
                var position = FindStartCheck();
                StartMove(ref pacmans[i], position,checker, checkerindex);
                Log.Info(StringHelper.GenerateStrategyString(pacmans[i].Strategy));
            }
        }

        public  CheckPosition FindStartCheck()
        {
            var rnd = new Random();
            return new CheckPosition {Position = IntHelper.FindPositionFromRandomNumber(rnd.Next(1, 101))};
        }

        public void StartMove(ref Pacman pacman, CheckPosition startPosition, Checker checker, int index)
        {
            var currentPosition = startPosition;
            for (var i = 0; i < (int)GameRules.NumberOfOneGameMove; i++)
            {
                var allSituation = checker.Checks[currentPosition];
                var action = (Actions)pacman.Strategy.Lines.Where(x => x.Key == string.Join("", currentPosition.Position)).FirstOrDefault().Value;
                
                while (action == Actions.Random)
                {
                    action =(Actions)IntHelper.GetRandomAction();
                }

                switch (action)
                {
                    case Actions.Freeze:
                        continue;
                    case Actions.Up:
                    case Actions.Right:
                    case Actions.Down:
                    case Actions.Left:
                        var nextCheck = (Situations)allSituation[(int)action];
                        if (nextCheck == Situations.Wall)
                        {
                            pacman.Points[index] = pacman.Points[index] + (int)Points.HitWall;
                        }
                        else
                        {
                            currentPosition = GetNextPosition(currentPosition, action);
                            pacman.Points[index] = pacman.Points[index] + (int) Points.Move;
                        }
                        break;
                    case Actions.Eat:
                        if ((Situations)allSituation[(int)Check.Me] == Situations.Bean)
                        {
                            
                            pacman.Points[index] = pacman.Points[index] + (int)Points.EatBean;
                            CheckerChange(ref checker, currentPosition);
                        }
                        else
                        {
                            pacman.Points[index] = pacman.Points[index] + (int)Points.EatEmpty;
                        }
                        break;
                }
            }
            Log.Info(pacman.Points[index]);
        }

        private void CheckerChange(ref Checker checker, CheckPosition eatenBeanCheckPosition)
        {
            checker.Checks[eatenBeanCheckPosition][(int) Check.Me] = 0;
           
            var type = GetCheckType(eatenBeanCheckPosition);
            switch (type)
            {
                case CheckTypes.LeftTopCorner:
                    ChangeAccoundSituation(new []{Check.MyRight, Check.MyUnderneath}, ref checker,eatenBeanCheckPosition);
                    break;
                case CheckTypes.RightTopCorner:
                    ChangeAccoundSituation(new []{Check.MyUnderneath, Check.MyLeft}, ref checker,eatenBeanCheckPosition);
                    break;
                case CheckTypes.LeftUnderneathCorner:
                    ChangeAccoundSituation(new [] {Check.MyTop, Check.MyRight},ref checker, eatenBeanCheckPosition);
                    break;
                case CheckTypes.RightUnderneathCorner:
                    ChangeAccoundSituation(new[] {Check.MyTop, Check.MyLeft}, ref checker, eatenBeanCheckPosition);
                    break;
                case CheckTypes.TopLine:
                    ChangeAccoundSituation(new [] {Check.MyRight, Check.MyUnderneath, Check.MyLeft},ref checker,eatenBeanCheckPosition);
                    break;
                case CheckTypes.RightColumn:
                    ChangeAccoundSituation(new [] {Check.MyTop, Check.MyUnderneath, Check.MyLeft}, ref checker, eatenBeanCheckPosition);
                    break;
                case CheckTypes.UnderneathLine:
                    ChangeAccoundSituation(new [] {Check.MyTop, Check.MyLeft, Check.MyLeft},ref checker,eatenBeanCheckPosition);
                    break;
                case CheckTypes.LeftColumn:
                    ChangeAccoundSituation(new [] {Check.MyTop, Check.MyRight, Check.MyUnderneath}, ref checker, eatenBeanCheckPosition);
                    break;
                 case CheckTypes.Center:
                    ChangeAccoundSituation(new [] {Check.MyTop, Check.MyRight, Check.MyUnderneath, Check.MyLeft},ref checker, eatenBeanCheckPosition);
                    break;
            }


        }

        private void ChangeAccoundSituation(IEnumerable<Check> position, ref Checker checker, CheckPosition me)
        {
            foreach (var i in position)
            {
                switch (i)
                {
                    case Check.MyTop:
                        checker.Checks[GetArroundPosition(me, Check.MyTop)][(int) Check.MyUnderneath] = 0;
                        break;
                    case Check.MyRight:
                        checker.Checks[GetArroundPosition(me, Check.MyRight)][(int) Check.MyLeft] = 0;
                        break;
                    case Check.MyUnderneath:
                        checker.Checks[GetArroundPosition(me, Check.MyUnderneath)][(int) Check.MyTop] = 0;
                        break;
                    case Check.MyLeft:
                        checker.Checks[GetArroundPosition(me, Check.MyLeft)][(int) Check.MyRight] = 0;
                        break;
                }
            }
        }
        
        private CheckPosition GetNextPosition(CheckPosition currentPosition, Actions action)
        {
            var line = currentPosition.Position[0];
            var column = currentPosition.Position[1];
            switch (action)
            {
                case Actions.Up:
                    return new CheckPosition {Position = new[] {line-1,column}};
                case Actions.Right:
                    return new CheckPosition {Position = new[] {line, column+1}};
                case Actions.Down:
                    return new CheckPosition { Position = new[] { line+1, column} };
                case Actions.Left:
                    return new CheckPosition { Position = new[] { line, column - 1 } };
                default:
                    return currentPosition;
            }
        }

        private CheckPosition GetArroundPosition(CheckPosition myPosition, Check check)
        {
            var line = myPosition.Position[0];
            var column = myPosition.Position[1];
            switch (check)
            {
                case Check.MyTop:
                    return new CheckPosition { Position = new[] { line - 1, column } };
                case Check.MyRight:
                    return new CheckPosition { Position = new[] { line, column + 1 } };
                case Check.MyUnderneath:
                    return new CheckPosition { Position = new[] { line + 1, column } };
                case Check.MyLeft:
                    return new CheckPosition { Position = new[] { line, column - 1 } };
                default:
                    return myPosition;
            }
        }

        public CheckTypes GetCheckType(CheckPosition position)
        {
            var line = position.Position[0];
            var column = position.Position[1];

            if (line == 1 && column == 1)
            {
                return CheckTypes.LeftTopCorner;
            }
            if (line == 1 && column == 10)
            {
                return CheckTypes.RightTopCorner;
            }
            if (line==10 && column == 1)
            {
                return CheckTypes.LeftUnderneathCorner;
            }
            if (line==10&&column==10)
            {
                return CheckTypes.RightUnderneathCorner;
            }
            if (line == 1)
            {
                return CheckTypes.TopLine;
            }
            if (line == 10)
            {
                return CheckTypes.UnderneathLine;
            }
            if (column == 1)
            {
                return CheckTypes.LeftColumn;
            }
            if(column ==10)
            {
                return CheckTypes.RightColumn;
            }
            else
            {
                return CheckTypes.Center;
            }
        }
    }
}
