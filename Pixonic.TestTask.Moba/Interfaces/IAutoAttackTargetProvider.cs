using System.Collections.Generic;

namespace Pixonic.TestTask.Moba.Interfaces
{
    public interface IAutoAttackTargetProvider
    {
        bool FindTarget(IHero sourceHero, List<IHero> heroes, out IHero targetHero);
    }
}