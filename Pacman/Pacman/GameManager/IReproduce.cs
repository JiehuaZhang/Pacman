using CommonType;

namespace PacmanGame.GameManager
{
    public interface IReproduce
    {
        Pacman[] GetNextGenerationPacmans(Pacman[] lastGenerationPacmans);
    }
}