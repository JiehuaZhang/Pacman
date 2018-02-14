using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationManager.DataManager;
using PacmanGame.ReportManager;

namespace PacmanGame.GameManager
{
    public class BeforeGameStartRun : IBeforeGameStartRun
    {
        private readonly ISqLiteConnection _sqlLiteConnection;
        private readonly IReportGenerate _reportGenerate;
        private static int _pacmanLastGeneration;
        public BeforeGameStartRun(ISqLiteConnection sqlLiteConnection, IReportGenerate reportGenerate)
        {
            _sqlLiteConnection = sqlLiteConnection;
            _reportGenerate = reportGenerate;
            _pacmanLastGeneration = _sqlLiteConnection.GetLastGeneration();
        }

        public  bool IsNewStart()
        {
            var ifTalbeExist = _sqlLiteConnection.IfTableExist();
            if (!ifTalbeExist) return true;

            return _pacmanLastGeneration == 0;
        }

        public  void DoReport()
        {
            _sqlLiteConnection.CheckIfNeedToCreateReportTable();
            var reportLastGeneration = 0;
            if (!_sqlLiteConnection.CheckIfNeedToDoReport(_pacmanLastGeneration, ref reportLastGeneration)) return;

            _reportGenerate.GetReport(_pacmanLastGeneration, reportLastGeneration);
        }
    }
}
