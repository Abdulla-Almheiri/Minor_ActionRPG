using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MeleeSkillPrefab : SkillPrefab
    {
        public float Radius;
        public float ScalingSpeed = 0f;
        public bool IsFrontal = true;
        private SphereCollider myCollider;

        public void Start()
        {
            myCollider = GetComponent<SphereCollider>();
            if (IsFrontal)
            {
                myCollider.radius = Radius;
                //myCollider.transform.Translate(new Vector3(Radius/2, 0f, 0f));

            }

            Destroy(gameObject, 6f);
        }

        public void FixedUpdate()
        {
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Monster>())
            {
                monstersInCollider.Add(other.gameObject.GetComponent<Monster>());
                TriggerSkillActions(Performer, other.gameObject.GetComponent<Monster>());
            }
            
        }

        public void OnTriggerExit(Collider other)
        {
            monstersInCollider.Remove(other.gameObject.GetComponent<Monster>());
        }
    }
}