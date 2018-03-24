using Pixonic.TestTask.Moba.Interfaces;
using Pixonic.TestTask.Moba.Skills;
using Pixonic.TestTask.Moba.Skills.CriticalDamageAura;
using Pixonic.TestTask.Moba.Skills.SlowingAttackSpeedAttack;
using Pixonic.TestTask.Moba.Skills.SlowingMovementAttack;
using System.Diagnostics.Contracts;

namespace Pixonic.TestTask.Moba.Heroes
{
    public class HeroAbilityProvider : IHeroAbilityProvider
    {
        #region Private Fields

        private readonly IIntervalFromLastTickService _intervalFromLastTickService;
        private readonly IEffectIdProvider _effectIdProvider;

        #endregion Private Fields

        #region Public Constructors

        public HeroAbilityProvider(IEffectIdProvider effectIdProvider, IIntervalFromLastTickService intervalFromLastTickService)
        {
            Contract.Assert(intervalFromLastTickService != null, "intervalFromLastTickService != null");
            Contract.Assert(effectIdProvider != null, "effectIdProvider != null");

            _intervalFromLastTickService = intervalFromLastTickService;
            _effectIdProvider = effectIdProvider;
        }

        #endregion Public Constructors

        #region Public Methods

        public void AddAbilitiesToConfig(ref IHero hero)
        {
            Contract.Assert(hero != null, "hero != null");

            switch (hero.HeroType)
            {
                case HeroType.Fighter:
                    {
                        hero.OnAttackAbilities.Add(new SlowingAttackSpeedAttack(
                            new SlowingAttackSpeedDebuffBuilder(_effectIdProvider, _intervalFromLastTickService,
                                SkillsConsts.SlowingAttackSpeedDebuffRate, SkillsConsts.SlowingAttackSpeedDebuffDuration)));
                        break;
                    }
                case HeroType.Range:
                    {
                        hero.OnAttackAbilities.Add(new SlowingMovementAttack(
                                new SlowingMovementDebuffBuilder(_effectIdProvider, _intervalFromLastTickService, hero.Id,
                                    SkillsConsts.SlowingMovementDebuffRate, SkillsConsts.SlowingMovementDebuffDuration)));
                        break;
                    }
                case HeroType.Support:
                    {
                        hero.OnTickStartAbilities.Add(new CriticalDamageAura(hero,
                                new CriticalDamageBuffBuilder(_effectIdProvider, hero.Id, SkillsConsts.CriticalDamageAuraDamageMultiplier), SkillsConsts.CriticalDamageAuraRange));
                        break;
                    }
                default:
                    {
                        //TODO Notification
                        break;
                    }
            }
        }

        #endregion Public Methods
    }
}