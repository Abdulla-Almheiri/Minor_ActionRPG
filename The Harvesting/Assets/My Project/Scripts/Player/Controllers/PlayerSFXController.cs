using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace Harvesting
{
    public class PlayerSFXController : CharacterSFXController, IPlayerSFXController
    {
        public new IPlayerCore Core { get; protected set; }

        [EventRef, SerializeField]
        public string FootStepsSound = default;
        [EventRef, SerializeField]
        public string ItemPickupSound = default;
        private FMOD.Studio.EventInstance footstepSoundEvent;
        private FMOD.Studio.EventInstance itemPickupSoundEvent;

        

        // Start is called before the first frame update
        void Awake()
        {
            Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            /*if (_playerCore.PlayerMovementController.IsRunning())
            {
                footstepSoundEvent.setVolume(1f);
            }
            else
            {
                footstepSoundEvent.setVolume(0f);
            }

            if (_playerCore.PlayerMovementController.IsRunning())
            {

            }*/
        }

        private void InitializeSFX()
        {
            footstepSoundEvent = RuntimeManager.CreateInstance(FootStepsSound);
            itemPickupSoundEvent = RuntimeManager.CreateInstance(ItemPickupSound);
            footstepSoundEvent.start();

        }

        public void PlayItemSound()
        {
            itemPickupSoundEvent.start();
        }

        private void Initialize()
        {
            Core = GetComponent<PlayerCore>();
            if (Core == null) print("Player Core is NULL!!!!!!");

            footstepSoundEvent = RuntimeManager.CreateInstance(FootStepsSound);
            itemPickupSoundEvent = RuntimeManager.CreateInstance(ItemPickupSound);
            // FMODUnity.RuntimeManager.AttachInstanceToGameObject(sound, gameObject.transform);
            footstepSoundEvent.start();
        }
    }
}