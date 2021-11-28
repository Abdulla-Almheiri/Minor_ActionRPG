using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
   // [CreateAssetMenu(fileName ="new player data", menuName ="Data/Player/Player Data")]
    public class PlayerData : CharacterStats
    {
        public List<Skill> Skills;
        private Inventory inventory;
        private EquipmentContainer equipment;
        /*public override void Initialize()
        {

        }

        public override void ActivateSkill(SkillAction skillAction)
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiveSkillAction(SkillAction skillAction)
        {
            throw new System.NotImplementedException();
        }

        public override void UseItem(ItemTemplate item)
        {
            throw new System.NotImplementedException();
        }

        public bool Equip(ItemTemplate item, EquipmentSlot slot)
        {
            if(item.Equipable == false || item.EquipmentSlotType != slot.EquipmentSlotType)
            {
                return false;
            }
        
            return true;

        }
    */
        /*public bool AddItemToInventory(Item item, int quantity)
        {
            var amount = item.Stackable ? quantity : 0;
            return inventory.AddItem(item, amount);
        }*/


    }
}