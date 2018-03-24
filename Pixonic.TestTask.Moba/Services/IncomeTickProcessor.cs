using Pixonic.TestTask.Moba.Contracts;
using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Services
{
    public class IncomeTickProcessor : IIncomeTickProcessor
    {
        #region Private Fields

        private readonly IIntervalFromLastTickService _intervalFromLastTickService;
        private readonly IMovementManager _movementEvaluator;
        private List<IHero> _heroes;

        #endregion Private Fields

        #region Public Constructors

        public IncomeTickProcessor(IMovementManager movementEvaluator, IIntervalFromLastTickService intervalFromLastTickService)
        {
            Contract.Assert(movementEvaluator != null, "movementEvaluator!=null");
            Contract.Assert(intervalFromLastTickService != null, "intervalFromLastTickService!=null");

            _movementEvaluator = movementEvaluator;
            _intervalFromLastTickService = intervalFromLastTickService;
        }

        #endregion Public Constructors

        #region Public Methods

        public void InsertHeroList(List<IHero> heroes)
        {
            Contract.Assert(heroes != null, "heroes!=null");

            _heroes = heroes;
        }

        public void ProcessTick(Tick tick)
        {
            Contract.Assert(tick != null, "tick!=null");

            _intervalFromLastTickService.SetIntervalFromLastTick(tick.LastTickDeltaTime);

            MoveHeroes(tick);

            ShiftAttackIntervals(tick.LastTickDeltaTime);
        }

        #endregion Public Methods

        #region Private Methods

        private void MoveHeroes(Tick tick)
        {
            foreach (var hero in _heroes)
            {
                _movementEvaluator.MoveHero(hero, tick.LastTickDeltaTime, tick.HeroesMovement[hero.Id]);
            }
        }

        private void ShiftAttackIntervals(TimeSpan dt)
        {
            foreach (var hero in _heroes)
            {
                hero.ShiftNextAutoAttackTime(dt);
            }
        }

        #endregion Private Methods
    }
}