using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting {
    public class PlayerSkillController : MonoBehaviour
    {
        public PlayerData Player;
        public LayerMask Layer;
        public GameObject PrefabToSpawn;
        public Transform Loc1, Loc2, Loc3;
        public SkillUIScript SkillUI;

        public GameObject PrefabToSpawn2;

        private NavMeshAgent navMeshAgent;


        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {
            HandleInput();
        }

        public void RotateToMouseDirection()
        {
            navMeshAgent.isStopped = true;
            if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, Layer))
                {
                    var direction = (rayHit.point - transform.position);
                    direction.y = 0;
                    direction = direction.normalized;
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }

        public void ActivateSkill(int number)
        {
            var skill = Player.Skills[number];
            var location = transform;
            if (skill.DefaultVFXPrefab != null)
            {
                if (skill.DefaultVFXPrefab is ProjectileSkillPrefab)
                {
                    location = Loc1;
                }
            }
            skill.Activate(Player, location);
            if(skill.FaceDirection == true)
            {
                RotateToMouseDirection();
            }
        }

        public void HandleInput()
        {
            for (int i = 0; i < Player.Skills.Count; i++)
            {
                if (Input.GetKeyDown((KeyCode)49 + i))
                {
                    ActivateSkill(i);
                }
            }
        }

    }
}