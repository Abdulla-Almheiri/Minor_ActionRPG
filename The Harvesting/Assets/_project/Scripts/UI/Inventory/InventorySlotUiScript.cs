using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class InventorySlotUiScript : MonoBehaviour
    {
        public GameItem Item;
        public Image Image;

        public void PutItem(GameItem item)
        {
            Item = item;
            Image.sprite = Item.Template.Icon;
        }

        public void Clear()
        {
            Item = null;
            Image.sprite = null;
        }
    }
}