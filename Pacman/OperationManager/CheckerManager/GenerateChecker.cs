using System.Collections.Generic;
using System.Linq;
using CommonType;

namespace OperationManager.CheckerManager
{
    public  class GenerateChecker
    {
        public  Checker GenerateEmptyChecker()
        {
            var checker = new Checker();
            var dic = new Dictionary<CheckPosition, int[]>();
            for (var i = 1; i < 11; i++)
            {
                for (var j = 1; j < 11; j++)
                {
                    var position = new[] { i, j };
                    var value = new int[5];
                    if (i == 1)
                    {
                        value[0] = 2;
                    }
                    if (i == 10)
                    {
                        value[2] = 2;
                    }
                    if (j == 1)
                    {
                        value[3] = 2;
                    }
                    if (j == 10)
                    {
                        value[1] = 2;
                    }
                    var key = new CheckPosition {Position = position };
                    dic.Add(key, value);
                }
            }
            checker.Checks = dic;
            return checker;
        }

        public Checker GenerateInitialChecker()
        {
            var checker = GenerateEmptyChecker();
            var beanPosition = SprinkleBeans.GetRandomSprinkleBeansPosition();
            foreach (var position in checker.Checks.Keys.Where(position => beanPosition.Any(x => x.SequenceEqual(position.Position))))
            {
                checker.Checks[position][4] = 1;
            }

            foreach (var key in checker.Checks.Keys)
            {
                if (key.Position.SequenceEqual(new[] {1, 1}))
                {
                    checker.Checks[key][1] = CheckOtherSituation(1, key.Position, checker);
                    checker.Checks[key][2] = CheckOtherSituation(2, key.Position, checker);
                }
                else if (key.Position.SequenceEqual(new[] {1, 10}))
                {
                    checker.Checks[key][2] = CheckOtherSituation(2, key.Position, checker);
                    checker.Checks[key][3] = CheckOtherSituation(3, key.Position, checker);
                }
                else if (key.Position.SequenceEqual(new[] {10, 1}))
                {
                    checker.Checks[key][0] = CheckOtherSituation(0, key.Position, checker);
                    checker.Checks[key][1] = CheckOtherSituation(1, key.Position, checker);
                }
                else if (key.Position.SequenceEqual(new[] {10, 10}))
                {
                    checker.Checks[key][0] = CheckOtherSituation(0, key.Position, checker);
                    checker.Checks[key][3] = CheckOtherSituation(3, key.Position, checker);
                }
                else if (key.Position[0] == 1)
                {
                    checker.Checks[key][1] = CheckOtherSituation(1, key.Position, checker);
                    checker.Checks[key][2] = CheckOtherSituation(2, key.Position, checker);
                    checker.Checks[key][3] = CheckOtherSituation(3, key.Position, checker);
                }
                else if (key.Position[0] == 10)
                {
                    checker.Checks[key][0] = CheckOtherSituation(0, key.Position, checker);
                    checker.Checks[key][3] = CheckOtherSituation(3, key.Position, checker);
                    checker.Checks[key][1] = CheckOtherSituation(1, key.Position, checker);
                }
                else if (key.Position[1] == 1)
                {
                    checker.Checks[key][0] = CheckOtherSituation(0, key.Position, checker);
                    checker.Checks[key][1] = CheckOtherSituation(1, key.Position, checker);
                    checker.Checks[key][2] = CheckOtherSituation(2, key.Position, checker);
                }
                else if (key.Position[1] == 10)
                {
                    checker.Checks[key][0] = CheckOtherSituation(0, key.Position, checker);
                    checker.Checks[key][3] = CheckOtherSituation(3, key.Position, checker);
                    checker.Checks[key][2] = CheckOtherSituation(2, key.Position, checker);
                }
                else
                {
                    checker.Checks[key][0] = CheckOtherSituation(0, key.Position, checker);
                    checker.Checks[key][1] = CheckOtherSituation(1, key.Position, checker);
                    checker.Checks[key][2] = CheckOtherSituation(2, key.Position, checker);
                    checker.Checks[key][3] = CheckOtherSituation(3, key.Position, checker);
                }
            }
            return checker;

        }

        private static int CheckOtherSituation(int relativePosition, int[] position, Checker checker)
        {
            var key=new CheckPosition();
            switch (relativePosition)
            {
                case 0:
                    key.Position = new[] {position[0] - 1, position[1]};
                    break;
                case 1:
                    key.Position = new[] {position[0], position[1] + 1};
                    break;
                case 2:
                     key.Position = new[] {position[0] + 1, position[1]};
                    break;
                case 3:
                     key.Position = new[] {position[0], position[1] - 1};
                    break;
            }
            return checker.Checks[key][4];
        }
    }
}
