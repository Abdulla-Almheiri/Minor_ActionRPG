using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SelfSkillPrefab : SkillPrefab
    {
        public float Duration = 5f;
        void Start()
        {
            Destroy(gameObject, Duration);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}