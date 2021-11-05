using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="Core Attributes", menuName ="Data/Skills/Core Attributes")]
    public class CoreAttributes : ScriptableObject
    {
        public List<Attribute> Attributes;
    }
}