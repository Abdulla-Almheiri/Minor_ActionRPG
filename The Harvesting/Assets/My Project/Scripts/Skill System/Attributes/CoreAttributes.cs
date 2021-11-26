using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// A list of the core Attributes. Only the first instance of this object will be used.
    /// </summary>
    [CreateAssetMenu(fileName ="Core Attributes", menuName ="Data/Skills/Core Attributes")]
    public class CoreAttributes : ScriptableObject
    {
  


        private Attribute health;
        public static Attribute Health;

        public List<Attribute> AdditionalAttributes;
        public void OnEnable()
        {
            CoreAttributes.Health = health;
        }

    }
}