using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IEquipmentItemTemplate : IGameItemTemplate<EquipmentItem>
    {
        List<ItemModifier> Attributes {get;}
        List<SkillAction> AdditionalEffects { get; }

        EquipmentSlotType EquipmenSlottType { get; }

    }
}