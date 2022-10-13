using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new item quality", menuName ="Data/Items/Item Quality")]
    public class ItemQuality : ScriptableObject
    {
        public Color Color = Color.red;
    }
}