using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class InventorySlotUiScript : MonoBehaviour
    {
        public ItemTemplate Item;
        public Image Image;

        public void PutItem(ItemTemplate item)
        {
            Item = item;
            Image.sprite = Item.Icon;
        }

        public void Clear()
        {
            Item = null;
            Image.sprite = null;
        }
    }
}