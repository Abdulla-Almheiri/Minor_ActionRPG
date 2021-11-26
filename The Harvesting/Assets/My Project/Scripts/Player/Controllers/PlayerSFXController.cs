using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

namespace Harvesting
{
    public class PlayerSFXController : MonoBehaviour
    {
        [EventRef, SerializeField]
        public string FootStepsSound = default;
        [EventRef, SerializeField]
        public string ItemPickupSound = default;
        private FMOD.Studio.EventInstance footstepSoundEvent;
        private FMOD.Studio.EventInstance itemPickupSoundEvent;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void InitilizeSFX()
        {
            footstepSoundEvent = RuntimeManager.CreateInstance(FootStepsSound);
            itemPickupSoundEvent = RuntimeManager.CreateInstance(ItemPickupSound);
        }
    }
}