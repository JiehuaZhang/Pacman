using System;
using Castle.Windsor;
using OperationManager.Update;
using PacmanGame.GameManager;

namespace PacmanGame
{
    internal class Program
    {
        private static void Main()
        {

            var container = WindsorSetting.RegisterContainer();

            IGeneration needToRunGeneration;
            var beforeGameStart = container.Resolve<IBeforeGameStartRun>();
            if (beforeGameStart.IsNewStart())
            {
                needToRunGeneration = container.Resolve<IGeneration>("First");
                needToRunGeneration.Play();
            }
            else
            {
                beforeGameStart.DoReport();

                Console.WriteLine("Give a number:");
                var number = Convert.ToInt32(Console.ReadLine());

                for (var i = 0; i < number; i++)
                {
                    Console.WriteLine("\n{0}", i+1);
                    needToRunGeneration = container.Resolve<IGeneration>("Next");
                    needToRunGeneration.Play();
                }
            }
        }

        private static void ExtraMethod( WindsorContainer container)
        {
            var update = container.Resolve<UpgradeFromOldDatabase>();
            update.UpdatePacman(2);
            update.UpdatePacmanWeight(8);
        }
    }

}
