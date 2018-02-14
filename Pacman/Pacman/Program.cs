using System;
using Castle.Windsor;
using OperationManager.CheckerManager;
using OperationManager.DataManager;
using OperationManager.GameManager;
using OperationManager.StoreDataManager;
using OperationManager.Update;
using PacmanGame.GameManager;
using PacmanGame.ReportManager;

namespace PacmanGame
{
    class Program
    { 
        static void Main(string[] args)
        {

            var container = WindsorSetting.RegisterContainer();

            //var update = container.Resolve<UpgradeFromOldDatabase>();
            //update.UpdatePacman(2);
            // update.UpdatePacmanWeight(8);

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


    }

}
