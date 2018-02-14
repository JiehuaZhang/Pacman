namespace PacmanGame.ReportManager
{
    public interface IReportGenerate
    {
        void GetReport(int pacmanLastGeneration, int reportLastGeneration);
    }
}