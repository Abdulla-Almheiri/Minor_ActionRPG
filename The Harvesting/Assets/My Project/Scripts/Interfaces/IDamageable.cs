using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IDamageable 
    {
        public void TakeDamage(float amount);
    }
}