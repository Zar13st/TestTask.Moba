using System.Collections.Generic;
using System.Linq;
using Pixonic.TestTask.Moba.Heroes;
using Pixonic.TestTask.Moba.Interfaces;

namespace Pixonic.TestTask.Moba.Services
{
    public class AutoAttackTargetProvider : IAutoAttackTargetProvider
    {
        public bool FindTarget(IHero sourceHero, List<IHero> heroes, out IHero targetHero)
        {
            //уверен это не самое быстрое решение, зато я умею в LINQ =)
            //но это не точно
            var target = heroes
                .Where(h => h.Team != sourceHero.Team)
                .Select(h => new { SqrDistance = sourceHero.SqrDistanceTo(h), Hero = h })
                .Where(o => o.SqrDistance <= sourceHero.AutoAttackRange * sourceHero.AutoAttackRange)
                .OrderBy(o => o.SqrDistance)
                .FirstOrDefault()?.Hero;

            if (target != null)
            {
                targetHero = target;
                return true;
            }
            else
            {
                targetHero = null;
                return false;
            }
        }
    }
}
