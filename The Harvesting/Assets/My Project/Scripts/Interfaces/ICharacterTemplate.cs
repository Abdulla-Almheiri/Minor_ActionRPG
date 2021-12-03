using System.Collections.Generic;

namespace Harvesting
{
    public interface ICharacterTemplate
    {
        float AllDamageDoneIncrease { get; }
        float AllDamageTakenReduction { get; }
        float AttackSpeed { get; }
        float AttributePercentageIncrementPerLevel { get; }
        float CriticalChance { get; }
        float CriticalDamage { get; }
        float Dexterity { get; }
        float Faith { get; }
        float Health { get; }
        float HealthRegen { get; }
        float Intellect { get; }
        int Level { get; }
        float Mana { get; }
        float ManaRegen { get; }
        float MovementSpeed { get; }
        float Power { get; }
        float Strength { get; }
        List<ProgressionSkill> Abilities { get; } 
    }
}