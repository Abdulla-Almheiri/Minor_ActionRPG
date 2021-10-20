using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using FMOD;
using FMODUnity;

namespace Harvesting {
    [RequireComponent(typeof(Collider))]
    public class ProjectileSkillPrefab : SkillPrefab
    {
        
        public float Duration = 10f;
        [Range(0f,1f)]
        [Header("Movement")]
        public float Speed = 0.5f;
        public Vector3 Direction = new Vector3(0f,0f,1f);
        public bool Piercing = true;

        [Range(0f, 1f)]
        [Header("Rotation")]
        public float RotationSpeed = 0.5f;
        public Vector3 RotationDirection = new Vector3(0,0f,1f);



        [Header("Impact Events")]
        public SkillPrefab OnImpact;
        public FMOD.Studio.EventInstance ImpactSound;
        public UnityEvent ImpactEvent;


        void Start()
        {
            Destroy(gameObject, Duration);
            ImpactSound.start();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void FixedUpdate()
        {
            gameObject.transform.Translate(Direction * Speed * Time.deltaTime * 50f);
            gameObject.transform.Rotate(RotationDirection * Time.deltaTime * RotationSpeed * 50f);
        }


        public void OnTriggerEnter(Collider other)
        {
            if (OnImpact != null)
            {
                var spawn = Instantiate(OnImpact, transform);
                spawn.transform.parent = null;
            }


            if(!Piercing)
            {
                Destroy(gameObject);
            }
            var monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                TriggerSkillAction(Performer, monster);
            }
        }
    }
}