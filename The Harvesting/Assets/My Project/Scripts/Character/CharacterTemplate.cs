using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class CharacterTemplate : ScriptableObject, ICharacterTemplate
    {
        [Header("Primary Attributes")]
        [SerializeField] private int level = 1;
        [SerializeField] private float size = 1f;

        [SerializeField] private float attributePercentageIncrementPerLevel = 20f;

        [SerializeField] private float health = 100f;
        [SerializeField] private float mana = 30f;

        [SerializeField] private float healthRegen;
        [SerializeField] private float manaRegen;

        [SerializeField] private float strength = 5;
        [SerializeField] private float intellect = 5;
        [SerializeField] private float faith = 5;
        [SerializeField] private float dexterity = 5;
        [SerializeField] private float power = 5;

        [SerializeField] private float attackSpeed = 100;
        [SerializeField] private float movementSpeed = 1f;

        [SerializeField] private float criticalChance = 5f;
        [SerializeField] private float criticalDamageBonus = 0f;

        [SerializeField] private float allDamageTakenReduction = 0f;
        [SerializeField] private float allDamageDoneIncrease = 0f;

        [Header("Abilities")]
        [SerializeField] private List<ProgressionSkill> _abilities; 
        public List<ProgressionSkill> Abilities { get => _abilities; }

        [Header("Secondary Attributes")]
        public List<AttributeFloat> Attributes;

        [Header("Animations")]
        public CharacterAnimationData InteractAnimation;
        public CharacterAnimationData WalkAnimation;
        public CharacterAnimationData DeathAnimation;
        public List<CharacterAnimationData> AttackAnimations;
        public List<CharacterAnimationData> CastAnimations;
        public List<CharacterAnimationData> HitAnimations;
        public List<CharacterAnimationData> BlockAnimations;

        public int Level { get => level; }
        public float Size { get => size; }
        public float AttributePercentageIncrementPerLevel { get => attributePercentageIncrementPerLevel; }
        public float Health { get => health; }
        public float Mana { get => mana; }
        public float HealthRegen { get => healthRegen; }
        public float ManaRegen { get => manaRegen; }
        public float Strength { get => strength; }
        public float Intellect { get => intellect; }
        public float Faith { get => faith; }
        public float Dexterity { get => dexterity; }
        public float Power { get => power; }
        public float AttackSpeed { get => attackSpeed; }
        public float MovementSpeed { get => movementSpeed; }
        public float CriticalChance { get => criticalChance; }
        public float CriticalDamageBonus { get => criticalDamageBonus; }
        public float AllDamageTakenReduction { get => allDamageTakenReduction; }
        public float AllDamageDoneIncrease { get => allDamageDoneIncrease; }

    }

    [System.Serializable]
    public struct AttributeFloat
    {
        public Attribute Attribute;
        public float Value;
    }
}