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
        public override void Interact(Character character)
        {
            if (character is Player)
            {
                Equip((Player)character);
            }
        }

        public void Equip(Player player)
        {
            player.Equip(this);
        }
    }
}