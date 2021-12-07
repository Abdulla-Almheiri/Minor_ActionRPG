using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class EquipmentItemTemplate : GameItemTemplate<GameItem>
    {
        public List<ItemModifier> Attributes { get; protected set; }

        public List<SkillAction> AdditionalEffects { get; protected set; }

        public EquipmentSlotType EquipmenSlottType { get; protected set; }
        public abstract EquipmentItem Generate();

    }
}