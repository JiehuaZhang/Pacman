namespace PacmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var pacmans = TheFirstGeneration.PlayGame();
            var nextGenerationPacmans = Reproduce.GetNextGenerationPacmans(pacmans);
            StartGame.Start(ref nextGenerationPacmans);
        }
    }
}
