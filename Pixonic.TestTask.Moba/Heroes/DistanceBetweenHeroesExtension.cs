using Pixonic.TestTask.Moba.Interfaces;
using System;

namespace Pixonic.TestTask.Moba.Heroes
{
    public static class DistanceBetweenHeroesExtension
    {
        #region Public Methods

        public static double SqrDistanceTo(this ICoordinateProvider hero1, ICoordinateProvider hero2)
        {
            return Math.Pow(hero2.X - hero1.X, 2) + Math.Pow(hero2.Y - hero1.Y, 2);
        }

        #endregion Public Methods
    }
}