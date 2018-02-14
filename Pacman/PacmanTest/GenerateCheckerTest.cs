using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonType;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperationManager.CheckerManager;

namespace PacmanTest
{
    [TestClass]
    public class GenerateCheckerTest
    {
        [TestMethod]
        public void MakeChangeAfterBeansTest()
        {
            var generateChecker = new GenerateChecker();
            var checker = generateChecker.GenerateEmptyChecker();
            var beanPosition = new List<int[]>
            {
                new[]{1, 3},
                new []{1,5},
                new []{1,7},
                new []{1,9},
                new []{2,1},
                new []{2,4},
                new []{2,6},
                new []{2,7},
                new []{2,9},
                new []{3,2},
                new []{3,5},
                new []{3,8},
                new []{3,10},
                new []{4,1},
                new []{4,3},
                new []{4,6},
                new []{4,10},
                new []{5,2},
                new []{5,3},
                new []{5,8},
                new []{5,9},
                new []{6,1},
                new []{6,3},
                new []{6,5},
                new []{6,7},
                new []{6,9},
                new []{7,1},
                new []{7,3},
                new []{7,4},
                new []{7,5},
                new []{7,8},
                new []{7,10},
                new []{8,2},
                new []{8,3},
                new []{8,4},
                new []{8,6},
                new []{8,7},
                new []{8,9},
                new []{8,10},
                new []{9,1},
                new []{9,2},
                new []{9,4},
                new []{9,5},
                new []{9,6},
                new []{9,8},
                new []{9,9},
                new []{10,3},
                new []{10,5},
                new []{10,8},
                new []{10,10}

            }; //check out Pacman.xlsx

            Assert.IsTrue(beanPosition.Count ==50);

            generateChecker.MakeChangeAfterBeans(checker,beanPosition);

            foreach (var key in checker.Checks.Keys)
            {
                var situationStr = $"Up: {checker.Checks[key][0]} Right:{checker.Checks[key][1]} Button:{checker.Checks[key][2]} Left: {checker.Checks[key][3]} Center:{checker.Checks[key][4]}";
                Console.WriteLine($"Position: {key.Position[0]}:{key.Position[1]}  Situation: {situationStr}");
            }

            var testposition = new CheckPosition {Position = new[] {5, 6}};
            var testposition2 = new CheckPosition {Position = new[] {7, 4}};
            Assert.IsTrue(string.Join("," ,checker.Checks[testposition]) == string.Join(",",new[] { 1,0,0,0,0}));
            Assert.IsTrue(string.Join("," ,checker.Checks[testposition2]) == string.Join(",",new[] { 0,1,1,1,1}));
        }

        [TestMethod]
        public void GenerateEmptyCheckerTest()
        {
            var generateChecker = new GenerateChecker();
            var checker = generateChecker.GenerateEmptyChecker();

            foreach (var key in checker.Checks.Keys)
            {
                var situationStr = $"Up: {checker.Checks[key][0]} Right:{checker.Checks[key][1]} Button:{checker.Checks[key][2]} Left: {checker.Checks[key][3]} Center:{checker.Checks[key][4]}"; 
                Console.WriteLine($"Position: {key.Position[0]}:{key.Position[1]}  Situation: {situationStr}");
            }

            foreach (var key in checker.Checks.Keys)
            {
                if (key.Position[0] == 1)
                {
                    Assert.IsTrue(checker.Checks[key][0] == 2);

                }
                else if (key.Position[0] == 10)
                {
                    Assert.IsTrue(checker.Checks[key][2] == 2);
                }

                if (key.Position[1] == 1)
                {
                    Assert.IsTrue(checker.Checks[key][3] == 2);
                }
                else if (key.Position[1] == 10)
                {
                    Assert.IsTrue(checker.Checks[key][1] == 2);
                }

            }
        }

        [TestMethod]
        public void GetRandomSprinkleBeansPositionTest()
        {
            var beans = SprinkleBeans.GetRandomSprinkleBeansPosition();
            var beansOrderList = beans.OrderBy(x => x[0]).ThenBy(x=>x[1]).ToList();

            foreach (var b in beansOrderList)
            {
                Console.WriteLine(string.Join(":", b));
            }

            Assert.IsTrue(beansOrderList.Count ==50);
        }
    }
}
