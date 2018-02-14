namespace OperationManager.Update
{
    public interface IUpgradeFromOldDatabase
    {
        void UpdatePacman(int generation);
        void UpdatePacmanWeight(int generation);
    }
}