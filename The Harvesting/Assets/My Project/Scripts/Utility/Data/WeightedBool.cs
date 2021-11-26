using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [System.Serializable]
    public class WeightedBool
    {
        public bool Condition;
        [Range(0,1)]
        public float Weight;
    }
}