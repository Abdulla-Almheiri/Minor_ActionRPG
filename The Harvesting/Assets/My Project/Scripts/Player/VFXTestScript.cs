using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting {
    public class VFXTestScript : MonoBehaviour
    {
        public Player Player;
        public LayerMask Layer;
        public GameObject PrefabToSpawn;
        public Transform Loc1, Loc2, Loc3;

        public GameObject PrefabToSpawn2;

        private NavMeshAgent navMeshAgent;
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                RotateToMouseDirection();
                var spawn1 = Instantiate(PrefabToSpawn, Loc1);
                Destroy(spawn1, 2f);
                spawn1.transform.parent = null;

                var spawn2 = Instantiate(PrefabToSpawn, Loc2);
                Destroy(spawn2, 2f);
                spawn2.transform.parent = null;


                var spawn3 = Instantiate(PrefabToSpawn, Loc3);
                Destroy(spawn3, 2f);
                spawn3.transform.parent = null;

            }

            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                var spawn = Instantiate(PrefabToSpawn2, Loc1);
                spawn.transform.parent = null;
                Destroy(spawn, 10f);
            }
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
    }
}