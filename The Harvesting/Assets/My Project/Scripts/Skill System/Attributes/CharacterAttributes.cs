using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterAttributes
    {
        public int ModelSize = 1;
        public int Level;
        public int Health = 20;
        public int Mana = 10;


        public int Strength = 1;
        public int Intellect = 1;
        public int Faith = 1;
        public int Dexterity = 1;
        public int Power = 1;

        public int AttacksPerMinute = 20;
        public int HealthRegen;
        public int ManaRegen;

        public int CriticalChance = 5;
        public int CriticalDamage = 0;

        public int DamageTaken = 0;
        public int DamageDone = 0;

        public void Initialize(CharacterAttributes attributes)
        {
            ModelSize = attributes.ModelSize;
            Level = attributes.Level;
            Health = attributes.Health;
            Mana = attributes.Mana;


            Strength = attributes.Strength;
            Intellect = attributes.Intellect;
            Faith = attributes.Faith;
            Dexterity = attributes.Dexterity;
            Power = attributes.Power;

            AttacksPerMinute = attributes.AttacksPerMinute;
            HealthRegen = attributes.HealthRegen;
            ManaRegen = attributes.ManaRegen;

            CriticalChance = attributes.CriticalChance;
            CriticalDamage = attributes.CriticalDamage;

            DamageTaken = attributes.DamageTaken;
            DamageDone = attributes.DamageDone;
        }
    }
}