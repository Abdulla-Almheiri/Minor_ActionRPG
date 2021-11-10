using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class InventoryUIScript : MonoBehaviour
    {
        public PlayerCore PlayerCore;
        public Inventory Inventory;
        private InventorySlotUiScript[] slots;

        void Start()
        {
            Inventory = PlayerCore.Inventory;
            slots = GetComponentsInChildren<InventorySlotUiScript>();
            UpdateUI();
        }

        void Update()
        {
        }

        public void UpdateUI()
        {
            int i = 0;
            foreach (ItemTemplate item in Inventory.Items)
            {
                if(i >= slots.Length)
                {
                    break;
                }
                slots[i].PutItem(item);
                if(item == null)
                {
                    slots[i].Clear();
                }

                i++;
            }
        }

    }
}