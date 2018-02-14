using System.Collections.Generic;
using CommonType;

namespace OperationManager.DataManager
{
    public interface ISqLiteConnection
    {
        void CheckIfNeedToCreateReportTable();
        bool CheckIfNeedToDoReport(int pacmanLastGeneration, ref int reportGeneration);
        int GetLastGeneration();
        List<Pacman> GetOneGenerationPacmans(int generation);
        string GetOneStrategy();
        bool IfTableExist();
        void InsertConnection(List<string> insertValueQuery);
        void InsertReport(List<Report> reports);
        void UpdatePacmansMaxPoints(Pacman p);
        void UpdateWeight(Pacman p);
    }
}