using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.ObjectBuilder2;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;
using WebService.Models;

namespace WebService.Providers
{
    public class PacmanProvider
    {
        public List<CheckerObject> InitialChecker { get; set; }
        public string StartPosition { get; set; }
        public List<StrategyObject> Strategy { get;set; }
        public List<CheckerObject> GetInitialCherkers()
        {
            var checkerMaker = new GenerateChecker();
            var checker = checkerMaker.GenerateInitialChecker();
            InitialChecker = checker.Checks.Keys.Select(checksKey => new CheckerObject
            {
                position = checksKey.Position.JoinStrings(string.Empty),
                situation = checker.Checks[checksKey].JoinStrings(string.Empty)
            }).ToList();
            return InitialChecker;
        }

        public string GetStartPosition()
        {
            var runTheGame = new RunTheGame();
            StartPosition = runTheGame.FindStartCheck().Position.JoinStrings(string.Empty);
            return StartPosition;
        }

        public List<StrategyObject> GetOneStrategy()
        {
            var strategyStr = "00000:5,00001:5,00002:3,00010:3,00011:4,00012:6,00020:1,00021:6,00022:3,00100:0,00101:0,00102:2,00110:4,00111:5,00112:6,00120:0,00121:5,00122:5,00200:1,00201:6,00202:6,00210:2,00211:0,00212:3,00220:4,00221:1,00222:2,01000:3,01001:3,01002:5,01010:5,01011:4,01012:5,01020:4,01021:5,01022:1,01100:1,01101:4,01102:1,01110:4,01111:1,01112:6,01120:2,01121:6,01122:1,01200:0,01201:4,01202:5,01210:1,01211:5,01212:3,01220:0,01221:1,01222:1,02000:5,02001:2,02002:1,02010:3,02011:5,02012:0,02020:3,02021:3,02022:6,02100:0,02101:3,02102:0,02110:5,02111:5,02112:4,02120:4,02121:6,02122:6,02200:1,02201:6,02202:6,02210:4,02211:3,02212:5,02220:2,02221:4,02222:5,10000:0,10001:3,10002:5,10010:5,10011:6,10012:5,10020:1,10021:5,10022:2,10100:3,10101:2,10102:4,10110:2,10111:3,10112:2,10120:4,10121:3,10122:2,10200:5,10201:2,10202:0,10210:1,10211:1,10212:3,10220:1,10221:3,10222:3,11000:0,11001:3,11002:2,11010:3,11011:3,11012:6,11020:1,11021:6,11022:3,11100:2,11101:4,11102:5,11110:2,11111:6,11112:3,11120:5,11121:4,11122:2,11200:4,11201:4,11202:1,11210:0,11211:6,11212:4,11220:2,11221:5,11222:4,12000:5,12001:3,12002:2,12010:6,12011:3,12012:1,12020:1,12021:4,12022:3,12100:6,12101:3,12102:1,12110:6,12111:2,12112:4,12120:4,12121:3,12122:5,12200:0,12201:2,12202:3,12210:0,12211:6,12212:2,12220:1,12221:4,12222:5,20000:3,20001:0,20002:3,20010:5,20011:4,20012:6,20020:1,20021:1,20022:5,20100:6,20101:2,20102:5,20110:3,20111:1,20112:6,20120:1,20121:0,20122:1,20200:5,20201:0,20202:2,20210:2,20211:2,20212:5,20220:6,20221:6,20222:5,21000:2,21001:4,21002:4,21010:2,21011:2,21012:3,21020:2,21021:0,21022:4,21100:2,21101:2,21102:1,21110:4,21111:5,21112:3,21120:5,21121:3,21122:2,21200:0,21201:2,21202:1,21210:0,21211:0,21212:0,21220:0,21221:0,21222:2,22000:5,22001:2,22002:0,22010:4,22011:2,22012:2,22020:3,22021:4,22022:3,22100:6,22101:0,22102:6,22110:4,22111:6,22112:4,22120:1,22121:1,22122:1,22200:6,22201:6,22202:3,22210:6,22211:3,22212:4,22220:4,22221:0,22222:1,";
            var strategyArr = strategyStr.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var s in strategyArr)
            {
                var value = s.Split(new char[] {':'}, StringSplitOptions.RemoveEmptyEntries);
                if (value.Length == 2)
                {
                    var strategy = new StrategyObject
                    {
                        position = value[0],
                        strategy = value[1]
                    };
                    Strategy.Add(strategy);
                }
            }
            return Strategy;
        }
    }
}