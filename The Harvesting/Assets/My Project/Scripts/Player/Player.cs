using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public class Player : Character
    {


        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        public override void PerformSkillAction(SkillAction skillAction)
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

        public void Equip(Item item)
        {
            if(item.Equipable == false)
            {
                return;
            }


        }
    }
}