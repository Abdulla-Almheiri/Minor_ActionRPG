using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class ArmorTemplate 
    {
        public int ItemLevel;
        public int RequiredLevel = 1;
        public List<Attribute> Attributes = new List<Attribute>();

    }
}