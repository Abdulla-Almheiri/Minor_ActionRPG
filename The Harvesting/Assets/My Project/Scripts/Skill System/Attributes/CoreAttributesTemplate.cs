using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// A list of the core Attributes. Only the first instance of this object will be used.
    /// </summary>
    [CreateAssetMenu(fileName = "Core Attributes Template", menuName ="Data/Skills/Core Attributes Template")]
    public class CoreAttributesTemplate : ScriptableObject
    {
        [Header("Primary Attributes")]
        [SerializeField] private Attribute _level;
        [SerializeField] private Attribute _experiencePoints;

        [SerializeField] private Attribute _health;
        [SerializeField] private Attribute _healthRegen;

        [SerializeField] private Attribute _mana;
        [SerializeField] private Attribute _manaRegen;

        [SerializeField] private Attribute _weaponDamage;
        [SerializeField] private Attribute _strength;
        [SerializeField] private Attribute _intellect;
        [SerializeField] private Attribute _dexterity;
        [SerializeField] private Attribute _faith;
        [SerializeField] private Attribute _power;


        [SerializeField] private Attribute _criticalChance;
        [SerializeField] private Attribute _criticalDamage;

        [SerializeField] private Attribute _attackSpeed;
        [SerializeField] private Attribute _movementSpeed;

        [SerializeField] private Attribute _allDamageTakenReduction;
        [SerializeField] private Attribute _allDamageDoneIncrease;
        [SerializeField] private Attribute _criticalDamageTakenReduction;

        [Header("Stat Default Values")]
        [SerializeField] private float _faithToHealthRegen = 0.1f;
        [SerializeField] private float _healthRegenTickRate = 1f;
        [SerializeField] private float _faithToManaRegen = 1f;
        [SerializeField] private float _manaRegenTickRate = 1f;
        [SerializeField] private float _strengthToHealth = 5f;
        [SerializeField] private float _strengthToWeaponSkillDamage = 1f;
        [SerializeField] private float _intellectToMaximumMana = 3f;
        [SerializeField] private float _intellectToCriticalDamage = 1f;
        [SerializeField] private float _dexterityToAttackSpeed = 1f;
        [SerializeField] private float _criticalMultiplier = 2f;

        [Header("Skill Action Types")]
        [SerializeField] private SkillActionType _skillActionDamage;
        [SerializeField] private SkillActionType _skillActionHeal;
        [SerializeField] private SkillActionType _skillActionStatusEffect;
        [SerializeField] private SkillActionType _skillActionResourceDrain;

        [Header("Secondary Attributes")]
        [SerializeField] private List<Attribute> _secondaryAttributes;

        public Attribute CriticalChance { get => _criticalChance; }
        public Attribute CriticalDamage { get => _criticalDamage; }
        public Attribute Level { get => _level; }
        public Attribute ExperiencePoints { get => _experiencePoints;  }
        public Attribute Health { get => _health;  }
        public Attribute Mana { get => _mana;  }
        public Attribute HealthRegen { get => _healthRegen; }
        public Attribute ManaRegen { get => _manaRegen; }
        public Attribute Strength { get => _strength; }
        public Attribute Intellect { get => _intellect; }
        public Attribute Dexterity { get => _dexterity; }
        public Attribute Faith { get => _faith; }
        public Attribute Power { get => _power; }
        public Attribute AttackSpeed { get => _attackSpeed; }
        public Attribute MovementSpeed { get => _movementSpeed; }
        public Attribute AllDamageTakenReduction { get => _allDamageTakenReduction; }
        public Attribute AllDamageDoneIncrease { get => _allDamageDoneIncrease; }

        public List<Attribute> SecondaryAttributes { get => _secondaryAttributes; }
        public float FaithToHealthRegen { get => _faithToHealthRegen; set => _faithToHealthRegen = value; }
        public float FaithToManaRegen { get => _faithToManaRegen; set => _faithToManaRegen = value; }
        public float StrengthToHealth { get => _strengthToHealth; set => _strengthToHealth = value; }

        public float StrengthToWeaponSkillDamage { get => _strengthToWeaponSkillDamage; }
        public float IntellectToMaximumMana { get => _intellectToMaximumMana; }
        public float IntellectToCriticalDamage { get => _intellectToCriticalDamage;  }
        public float DexterityToAttackSpeed { get => _dexterityToAttackSpeed; }
        public SkillActionType SkillActionDamage { get => _skillActionDamage;  }
        public SkillActionType SkillActionHeal { get => _skillActionHeal;  }
        public SkillActionType SkillActionStatusEffect { get => _skillActionStatusEffect; }
        public SkillActionType SkillActionResourceDrain { get => _skillActionResourceDrain;  }
        public float CriticalMultiplier { get => _criticalMultiplier; }
        public float ManaRegenTickRate { get => _manaRegenTickRate; }
        public float HealthRegenTickRate { get => _healthRegenTickRate;  }
        public Attribute WeaponDamage { get => _weaponDamage; }
    }
}