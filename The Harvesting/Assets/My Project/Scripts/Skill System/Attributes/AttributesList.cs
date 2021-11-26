using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public static class AttributesList 
    {

        private static Attribute criticalChance;
        private static Attribute criticalDamage;

        public static Attribute CriticalChance {
            get
            {
                if (criticalChance == null)
                {
                    criticalChance = ScriptableObject.CreateInstance<Attribute>();
                }
                return criticalChance;
            }
        }
        public static Attribute CriticalDamage
        {
            get
            {
                if (criticalDamage == null)
                {
                    criticalDamage = ScriptableObject.CreateInstance<Attribute>();
                }
                return criticalDamage;
            }
        }


    }
}