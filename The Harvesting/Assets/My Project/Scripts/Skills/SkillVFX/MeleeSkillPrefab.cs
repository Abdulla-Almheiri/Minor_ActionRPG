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

            Destroy(gameObject, 5f);
        }

        public void Update()
        {
            
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<Monster>())
            {
                monstersInCollider.Add(other.gameObject.GetComponent<Monster>());
            }
            TriggerSkillActions(Performer, other.gameObject.GetComponent<Monster>());
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<Monster>())
            {
                monstersInCollider.Remove(other.gameObject.GetComponent<Monster>());
            }
        }
    }
}