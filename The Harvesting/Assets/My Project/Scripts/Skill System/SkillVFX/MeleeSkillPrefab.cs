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
        public float Duration = 6f;
        private SphereCollider myCollider;

        public void Start()
        {
            myCollider = GetComponent<SphereCollider>();
            if (IsFrontal)
            {
                myCollider.radius = Radius;
                //myCollider.transform.Translate(new Vector3(Radius/2, 0f, 0f));

            }

            Destroy(gameObject, Duration);
        }

        public void FixedUpdate()
        {
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponentInChildren<MonsterNEW>())
            {
                monstersInCollider.Add(other.gameObject.GetComponentInChildren<MonsterNEW>());
                TriggerSkillActions(Performer, other.gameObject.GetComponentInChildren<MonsterNEW>());
            }
            
        }

        public void OnTriggerExit(Collider other)
        {
            monstersInCollider.Remove(other.gameObject.GetComponentInChildren<MonsterNEW>());
        }
    }
}