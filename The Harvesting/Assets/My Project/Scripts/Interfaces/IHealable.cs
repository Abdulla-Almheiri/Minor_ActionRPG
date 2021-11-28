using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IHealable 
    {
        public bool ReceiveHeal(float amount);
    }
}