using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Item Data Scriptable Object.
    /// </summary>
    [CreateAssetMenu(fileName ="new item type", menuName ="Data/Items/Item Type")]
    public class ItemType : ScriptableObject
    {
        public string UnidentifiedName = "";
    }
}