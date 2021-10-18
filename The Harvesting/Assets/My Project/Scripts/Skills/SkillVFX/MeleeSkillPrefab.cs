using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MeleeSkillPrefab : SkillPrefab
    {
        public float Radius;
        public bool IsFrontal = true;
        private SphereCollider myCollider;

        public void Start()
        {
            myCollider = GetComponent<SphereCollider>();
            if (IsFrontal)
            {
                myCollider.radius = Radius;
                myCollider.transform.Translate(new Vector3(Radius, 0f, 0f));

            }

            Destroy(gameObject, 3f);
        }


        public void OnTriggerEnter(Collider other)
        {
            var monster = other.GetComponent<Monster>();
            TriggerSkillAction(Performer, monster);
        }
    }
}