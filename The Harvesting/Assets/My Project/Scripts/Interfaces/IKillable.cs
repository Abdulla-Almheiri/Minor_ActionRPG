using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IKillable : IDamageable, IHealable
    {
        public void Kill();
    }
}