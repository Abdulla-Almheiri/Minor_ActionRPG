using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public struct Modifier
    {
        public Attribute Attribute;
        public float MaxValue;
        public float Value;
        public float Duration;
        public float Percentage;

    }
}