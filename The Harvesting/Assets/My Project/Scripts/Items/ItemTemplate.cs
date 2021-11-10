using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new item template", menuName ="Data/Items/Item Template")]
    public  class ItemTemplate : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public ItemType ItemData;
        public bool Stackable;
        public bool Consumable;
        public bool Equipable;
        public EquipmentSlotType EquipmentSlotType;
        public int Price;
        public ItemQuality Quality;
        //public abstract void Interact(CharacterData character);
    }
}
