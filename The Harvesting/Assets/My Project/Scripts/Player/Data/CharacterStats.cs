using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{ 
    public class CharacterStats
    {
        public int level;
        public float MaxHealth;
        public float CurrentHealth;
        public float MaxMana;
        public float CurrentMana;

        public float HealthRegen;
        public float ManaRegen;

        public float AttackSpeed;
        public float MovementSpeed;

        public float CriticalChance;
        public float CriticalDamageBonus;

        protected CharacterModifier _damageTakenReduction;
        protected CharacterModifier _damageDoneIncrease;

        public Modifier Stat;
        public CharacterStats()
        {
        }
        public Dictionary<Attribute, CharacterModifier> Attributes;

    }
}