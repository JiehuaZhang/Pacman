using CommonType;

namespace OperationManager.CheckerManager
{
    public interface IGenerateChecker
    {
        Checker[] Generate1000Checkers();
        Checker GenerateEmptyChecker();
        Checker GenerateInitialChecker();
    }
}