using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterCombatController : MonoBehaviour
    {
        public CoreAttributes CoreAttributes;
        public Dictionary<Attribute, float> Attributes;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Initiliaze()
        {
            foreach(Attribute attr in CoreAttributes.Attributes)
            {
                Attributes[attr] = 0f;
            }
        }
    }
}