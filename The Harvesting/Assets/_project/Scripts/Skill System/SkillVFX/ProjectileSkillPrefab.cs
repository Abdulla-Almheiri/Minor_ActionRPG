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
        public FMOD.Studio.EventInstance ImpactSound;
        public UnityEvent ImpactEvent;


        public void Start()
        {
            Destroy(gameObject, Duration);
            ImpactSound.start();
        }

        public void FixedUpdate()
        {
            gameObject.transform.Translate(Direction * Speed * Time.deltaTime * 50f);
            gameObject.transform.Rotate(RotationDirection * Time.deltaTime * RotationSpeed * 50f);
        }


        public void OnTriggerEnter(Collider other)
        {
            if (ImpactSkills.Count != 0 && other.gameObject.GetComponent<IMonsterCore>() != null)
            {
                foreach(Skill skill in ImpactSkills)
                {
                    skill?.Spawn(_performer, other.gameObject.transform);
                }
            }

            

            if (MyUtility.CompareLayers(_performer.GameObject.layer, _performer.GameManager.PlayerLayer) == true)
            {
                if (MyUtility.CompareLayers(other.gameObject.layer, _performer.GameManager.CombatSettings.EnemyLayer) == true)
                {
                    TriggerSkillActions(_performer, other.GetComponent<ICharacterCore>());
                }
            }
            else if (MyUtility.CompareLayers(_performer.GameObject.layer, _performer.GameManager.CombatSettings.EnemyLayer) == true)
            {
                
                if (MyUtility.CompareLayers(other.gameObject.layer, _performer.GameManager.PlayerLayer) == true)
                {
                    UnityEngine.Debug.Log("ON trigger entered enemy and player");
                    TriggerSkillActions(_performer, other.gameObject.GetComponent<ICharacterCore>());
                }
            }

            if (!Piercing)
            {
                Destroy(gameObject);
            }



        }
    }
}