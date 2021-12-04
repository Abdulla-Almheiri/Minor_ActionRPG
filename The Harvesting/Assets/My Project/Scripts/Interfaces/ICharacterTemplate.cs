using System.Collections.Generic;

namespace Harvesting
{
    public interface ICharacterTemplate
    {
        int Level { get; }
        float Size { get; }
        float AllDamageDoneIncrease { get; }
        float AllDamageTakenReduction { get; }
        float AttackSpeed { get; }
        float AttributePercentageIncrementPerLevel { get; }
        float CriticalChance { get; }
        float CriticalDamageBonus { get; }
        float Dexterity { get; }
        float Faith { get; }
        float Health { get; }
        float HealthRegen { get; }
        float Intellect { get; }
        float Mana { get; }
        float ManaRegen { get; }
        float MovementSpeed { get; }
        float Power { get; }
        float Strength { get; }
        List<ProgressionSkill> Abilities { get; } 
    }
}