using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new item template", menuName ="Data/Items/Item Template")]
    public  abstract class ItemTemplate : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
        public ItemType ItemData;

        public EquipmentSlotType EquipmentSlotType;
        public int Price;
        public ItemQuality Quality;
        //public abstract void Interact(CharacterData character);

        public abstract Item Generate(int level, int requiredLevel);
      
    }


}
