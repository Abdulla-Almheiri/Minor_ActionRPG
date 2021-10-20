using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class Weapon : Item
    {
        public int ItemLevel;
        public int RequiredLevel = 1;
        public List<Attribute> Attributes = new List<Attribute>();
        public override void Interact(CharacterData character)
        {
            if (character is PlayerData)
            {
                Equip((PlayerData)character);
            }
        }

        public void Equip(PlayerData player)
        {
            //player.Equip(this, EquipmentSlotthis.EquipmentSlotType);
        }
    }
}