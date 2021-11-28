using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICriticalHitter 
    {
        float CriticalChance { get; }
        float CriticalDamageBonus { get; }


    }
}