using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IDamageable 
    {
        float Health { get; }
        bool ReceiveDamage(SkillAction skillAction);
    }
}