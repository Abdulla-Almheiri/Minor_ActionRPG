using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public abstract class Item : ScriptableObject
    {
        public Image Icon;
        public string Name;
        public ItemType ItemData;
        public bool Stackable;
        public bool Consumable;
        public bool Equipable;
        public EquipmentSlotType EquipmentSlotType;
        public int Price;
        public ItemQuality Quality;
        public abstract void Interact(CharacterData character);


    }
}
