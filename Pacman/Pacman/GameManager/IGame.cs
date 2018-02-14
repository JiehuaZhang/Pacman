using CommonType;

namespace PacmanGame.GameManager
{
    public interface IGame
    {
        void Run(Pacman[] pacmans, Checker[] checkers);
    }
}