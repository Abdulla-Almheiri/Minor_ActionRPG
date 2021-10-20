using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [CreateAssetMenu(fileName ="new player data", menuName ="Data/Player/Player Data")]
    public class PlayerData : CharacterData
    {
        public Skill Skill1;
        public Skill Skill2;
        public Skill Skill3;
        public Skill Skill4;
        public Skill Skill5;
        public Skill Skill6;
        public Skill Skill7;

        private Inventory inventory;
        private EquipmentContainer equipment;
        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public override void ActivateSkill(SkillAction skillAction)
        {
            throw new System.NotImplementedException();
        }

        public override void ReceiveSkillAction(SkillAction skillAction)
        {
            throw new System.NotImplementedException();
        }

        public override void UseItem(Item item)
        {
            throw new System.NotImplementedException();
        }

        public bool Equip(Item item, EquipmentSlot slot)
        {
            if(item.Equipable == false || item.EquipmentSlotType != slot.EquipmentSlotType)
            {
                return false;
            }

            return true;

        }

        public bool AddItemToInventory(Item item, int quantity)
        {
            var amount = item.Stackable ? quantity : 0;
            return inventory.AddItem(item, amount);
        }
    }
}