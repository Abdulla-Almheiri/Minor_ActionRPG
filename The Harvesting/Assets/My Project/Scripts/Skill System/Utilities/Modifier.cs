using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class Modifier
    {
        public Attribute Attribute;
        public float MaxValue = 0f;
        public float Value = 0f;
        public float Duration = 0f;
        public float Percentage = 0f;

    }
}