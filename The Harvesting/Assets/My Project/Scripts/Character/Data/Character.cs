using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Character Class. Contains Character game data.
    /// </summary>
    public class Character
    {
        public int Level;
        public CharacterModifier Health;
        public CharacterModifier Mana;

        public Dictionary<Attribute, CharacterModifier> Attributes;
        public Dictionary<EquipmentSlotType, Item> Equipments;

        private float health;
        private float mana;

        public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {
           
        }

        public Character(CoreAttributes coreAttributes, CharacterTemplate characterTemplate)
        {
            foreach(Attribute attribute in coreAttributes.AdditionalAttributes)
            {
                Attributes[attribute] = new CharacterModifier();
            }
        }

        public float Attribute(Attribute attribute)
        {
            CharacterModifier mod = Attributes[attribute];
            return mod.FinalValue();
        }

        private void TakeDamage(float amount)
        {
            health -= amount;
            BoundHealth();
        }

        private void GetHealed(float amount)
        {
            health += amount;
            BoundHealth();
        }

        private void BoundHealth()
        {
            var value = Health.FinalValue();

            if(health > value)
            {
                health = value;
            } else if(health < 0)
            {
                health = 0;
            }
        }

        private void BoundMana()
        {
            var value = Mana.FinalValue();

            if (mana > value)
            {
                mana= value;
            }
            else if (mana < 0)
            {
                mana = 0;
            }
        }


     
    }
}