using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class StatusEffect: ScriptableObject
    {
        public Attribute Attribute;
        public Modifier Modifier;
    }
}
