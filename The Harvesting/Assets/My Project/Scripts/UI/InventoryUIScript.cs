using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class InventoryUIScript : MonoBehaviour
    {
        public PlayerCore PlayerCore;
        public Inventory Inventory;
        private List<InventorySlotUiScript> slots = new List<InventorySlotUiScript>();

        void Start()
        {
            Inventory = PlayerCore.Inventory;
            int i = 0;
            foreach(InventorySlotUiScript slotUI in GetComponentsInChildren<InventorySlotUiScript>())
            {
                if(i == Inventory.Items.Count)
                {
                    break;
                }
                slotUI.PutItem(Inventory.Items[i]);
                i++;
            }
        }

        void Update()
        {
            if (Inventory.DirtySlot != -1)
            {
                slots[Inventory.DirtySlot].PutItem(Inventory.Items[Inventory.DirtySlot]);
                Inventory.DirtySlot = -1;
            }
        }

    }
}