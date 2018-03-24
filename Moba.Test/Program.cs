using IoC.GameSimulation;
using Pixonic.TestTask.Moba.Contracts;
using System;

namespace Moba.Test
{
    internal class Program
    {
        #region Private Methods

        private static void Main()
        {
            var simulationContainer = new GameSimulationContainer();

            var simulation = simulationContainer.Begin();

            simulation.CreateMatch();

            var tick = new Tick()
            {
                HeroesMovement = new[] { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) },

                LastTickDeltaTime = TimeSpan.FromMilliseconds(100)
            };

            var tickCount = 0;
            while (!simulation.GameOver)
            {
                simulation.TickHandler(tick);
                tickCount++;
            }

            Console.ReadLine();
        }

        #endregion Private Methods
    }
}