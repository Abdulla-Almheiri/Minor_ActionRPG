using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using FMODUnity;

namespace Harvesting {

    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerSkillController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerUIController))]
    [RequireComponent(typeof(PlayerSFXController))]

    public class PlayerCore : MonoBehaviour
    {
        public PlayerData PlayerData;
        public GameObject CharacterScreen;
        public LayerMask ItemUILayer;
        [EventRef, SerializeField]
        public string FootStepsSound = default;
        [EventRef, SerializeField]
        public string ItemPickupSound = default;
        private FMOD.Studio.EventInstance footstepSoundEvent;
        private FMOD.Studio.EventInstance itemPickupSoundEvent;

        public PlayerAnimationController AnimationController;
        public PlayerCombatController CombatController;
        public PlayerSkillController SkillController;
        public PlayerMovementController MovementController;
        public PlayerUIController UIController;
        public Inventory Inventory;
        public ItemTemplate StartingItem;
        public List<Modifier> Stats;
        public List<Modifier> TemporaryEnhancements;

        private float itemPickupCooldown = 0.1f;
        private float itemPickupTimer = 0.1f;

        public void Start()
        {
            footstepSoundEvent  = RuntimeManager.CreateInstance(FootStepsSound);
            itemPickupSoundEvent = RuntimeManager.CreateInstance(ItemPickupSound);
            // FMODUnity.RuntimeManager.AttachInstanceToGameObject(sound, gameObject.transform);
            footstepSoundEvent.start();
            

            itemPickupTimer = itemPickupCooldown;
            //Inventory.Fill(null);
            MovementController = GetComponent<PlayerMovementController>();
            /*Inventory = new Inventory();
            Inventory.AddItem(StartingItem, 0);*/

            Debug.Log("The name of the Attribute is :   " + CoreAttributes.Health.name);
        }

        public void ToggleCharacterScreen()
        {
            CharacterScreen?.SetActive(!CharacterScreen.activeSelf);
        }

        public void Update()
        {
            if(MovementController.IsRunning())
            {
                footstepSoundEvent.setVolume(1f);
            } else
            {
                footstepSoundEvent.setVolume(0f);
            }

            if(MovementController.IsRunning())
            {

            }
            if (itemPickupTimer > 0)
            {
                itemPickupTimer -= Time.deltaTime;
            }


            if(Input.GetKeyUp(KeyCode.I))
            {
                ToggleCharacterScreen();
            }
            //Debug.Log("PICKIP ::           " + PickUpItem());
            HandleItemsPickup();
        }
        public bool HandleItemsPickup()
        {
            if(itemPickupTimer> 0)
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
                        if(result.gameObject.GetComponentInChildren<ItemGroundPrefab>() != null && Vector3.Distance(result.gameObject.GetComponent<ItemGroundPrefab>().WorldPosition, transform.position) < 2f)
                        {
                            //Debug.Log("ITEM GROUND FOUND!!!!");
                            if (result.gameObject.GetComponent<ItemGroundPrefab>().PickUp(this) == true)
                            {
                                CharacterScreen.GetComponentInChildren<InventoryUIScript>().UpdateUI();
                                itemPickupTimer = itemPickupCooldown;
                                PlayItemSound();
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
            }
            return false;
        }


        private void PlayItemSound()
        {
            itemPickupSoundEvent.start();
        }
    }
}
