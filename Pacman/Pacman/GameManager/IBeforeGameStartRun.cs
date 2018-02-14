namespace PacmanGame.GameManager
{
    public interface IBeforeGameStartRun
    {
        void DoReport();
        bool IsNewStart();
    }
}