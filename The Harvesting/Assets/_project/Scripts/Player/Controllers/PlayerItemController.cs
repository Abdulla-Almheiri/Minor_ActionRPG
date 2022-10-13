using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Harvesting
{
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerUIController))]
    public class PlayerItemController : CharacterItemController, IPlayerItemController
    {
        public new IPlayerCore Core { get; protected set; }
        private float itemPickupTimer = 0.2f;
        private float itemPickupCooldown = 0.2f;

        private void Update()
        {
            //HandleItemsPickup();

        }
        public bool HandleItemsPickup()
        {
            /* if (itemPickupTimer > 0)
             {
                 return false;
             }

            if (Input.GetMouseButton(0))
            {

                var pointerEventData = new PointerEventData(EventSystem.current);
                pointerEventData.position = Input.mousePosition;
                var raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                if (raycastResults.Count > 0)
                {

                    foreach (RaycastResult result in raycastResults)
                    {
                        if (result.gameObject.GetComponentInChildren<ItemGroundPrefab>() != null && Vector3.Distance(result.gameObject.GetComponent<ItemGroundPrefab>().WorldPosition, transform.position) < 2f)
                        {
                            //Debug.Log("ITEM GROUND FOUND!!!!");
                            if (result.gameObject.GetComponent<ItemGroundPrefab>().PickUp(Core) == true)
                            {
                                Core.UIController.UI.GetComponentInChildren<InventoryUIScript>().UpdateUI();
                                itemPickupTimer = itemPickupCooldown;
                                Core.SFXController.PlayItemSound();
                                return true;
                            }
                            return false;
                        }
                    }

                }

                /*Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, ItemUILayer))
                {
                    Debug.Log("RAYCAST ITEM HIT");
                    var itemPrefab = rayHit.collider.GetComponent<ItemGroundPrefab>();
                    if (itemPrefab != null)
                    {
                        return itemPrefab.PickUp(this);
                    }
                }*/
            return false;
        }
        public void Initialize(IPlayerCore playerCore)
        {
            Core = playerCore ?? GetComponent<PlayerCore>();
            //_characterScreen = Core.UIController.CharacterScreen;
            itemPickupTimer = itemPickupCooldown;
        }

        public bool Equip(GameItem gameItem)
        {
            return false;
        }

        public bool Unequip(EquipmentSlotType equipmentSlot)
        {
            return false;
        }
    }
}