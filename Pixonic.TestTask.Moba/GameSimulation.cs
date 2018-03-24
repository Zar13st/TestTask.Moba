using Pixonic.TestTask.Moba.Contracts;
using Pixonic.TestTask.Moba.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba
{
    public class GameSimulation : IGameSimulation
    {
        #region Private Fields

        private readonly IAutoAttackTargetProvider _autoAttackTargetProvider;
        private readonly IIncomeTickProcessor _incomeTickProcessor;
        private List<IHero> _heroes;

        #endregion Private Fields

        #region Public Properties

        public bool GameOver { get; private set; }

        #endregion Public Properties

        #region Public Constructors

        public GameSimulation(IIncomeTickProcessor incomeTickProcessor, IAutoAttackTargetProvider autoAttackTargetProvider)
        {
            Contract.Assert(incomeTickProcessor != null, "incomeTickProcessor!=null");
            Contract.Assert(autoAttackTargetProvider != null, "autoAttackTargetProvider!=null");

            _incomeTickProcessor = incomeTickProcessor;
            _autoAttackTargetProvider = autoAttackTargetProvider;
        }

        #endregion Public Constructors

        #region Public Methods

        public void InsertHeroList(List<IHero> heroes)
        {
            Contract.Assert(heroes != null, "heroes!=null");

            _heroes = heroes;

            _incomeTickProcessor.InsertHeroList(heroes);
        }

        public void TickHandler(Tick tick)
        {
            Contract.Assert(_heroes != null, "_heroes!=null");

            if (GameOver) return;

            _incomeTickProcessor.ProcessTick(tick);

            UseOnTickStartAbilities();

            UseAutoAttacks();

            ActivateOnTickEndEffects();

            CleanAllEffects();

            CheckGameResult();
        }

        #endregion Public Methods

        #region Private Methods

        private void ActivateOnTickEndEffects()
        {
            foreach (var hero in _heroes)
            {
                foreach (var effect in hero.OnTickEndEffectByType)
                {
                    effect.Value.Activate();
                }
            }
        }

        private void CheckGameResult()
        {
            int redTeamPalayersCount = 0;
            int blueTeamPalayersCount = 0;

            for (int i = 0; i < _heroes.Count; i++)
            {
                if (!_heroes[i].IsAlive)
                {
                    Console.WriteLine(_heroes[i].Id);
                    _heroes.RemoveAt(i--);
                }
            }

            foreach (var hero in _heroes)
            {
                if (hero.Team == Team.Red)
                {
                    redTeamPalayersCount++;
                }
                else
                {
                    blueTeamPalayersCount++;
                }
            }

            if (redTeamPalayersCount == 0 && blueTeamPalayersCount == 0)
            {
                Console.WriteLine("Draw");
                GameOver = true;
            }
            else if (redTeamPalayersCount == 0)
            {
                Console.WriteLine("Blue Team Win");
                GameOver = true;
            }
            else if (blueTeamPalayersCount == 0)
            {
                Console.WriteLine("Red Team Win");
                GameOver = true;
            }
        }

        private void CleanAllEffects()
        {
            foreach (var hero in _heroes)
            {
                hero.CleanAllEffects();
            }
        }

        private void UseAutoAttacks()
        {
            foreach (var sourceHero in _heroes)
            {
                if (!sourceHero.CanAttack)
                {
                    continue;
                }

                var isTargetFound = _autoAttackTargetProvider.FindTarget(sourceHero, _heroes, out IHero targetHero);
                if (!isTargetFound)
                {
                    continue;
                }

                sourceHero.AutoAttack(targetHero);
            }
        }

        private void UseOnTickStartAbilities()
        {
            foreach (var sourceHero in _heroes)
            {
                foreach (var ability in sourceHero.OnTickStartAbilities)
                {
                    ability.Apply(_heroes);
                }
            }
        }

        #endregion Private Methods
    }
}