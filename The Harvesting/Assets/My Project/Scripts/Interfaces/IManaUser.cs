using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IManaUser
    {
        float Mana { get; }
        float ManaRegen { get; }
        bool ConsumeMana(Skill skill);
        bool DrainMana(SkillAction skillAction, ISkillActivator drainer);

        bool GainMana(float amount);
    }
}