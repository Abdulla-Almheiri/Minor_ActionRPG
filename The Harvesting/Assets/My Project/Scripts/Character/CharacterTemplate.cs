using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public class CharacterTemplate : ScriptableObject
    {
        [Header("Primary Attributes")]
        public int Level = 1;
        public float AttributePercentageIncrementPerLevel = 20f;

        public float Health = 100f;
        public float Mana = 30f;

        public float HealthRegen;
        public float ManaRegen;

        public float Strength = 5;
        public float Intellect = 5;
        public float Faith = 5;
        public float Dexterity = 5;
        public float Power = 5;

        public float AttackSpeed = 100;
        public float MovementSpeed = 1f;

        public float CriticalChance = 5f;
        public float CriticalDamage = 100f;

        public float AllDamageTakenReduction = 0f;
        public float AllDamageDoneIncrease = 0f;

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

    }

    [System.Serializable]
    public struct AttributeFloat
    {
        public Attribute Attribute;
        public float Value;
    }
}