using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class ClickToMoveScript : MonoBehaviour
    {
        private NavMeshAgent navAgent;
        void Start()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            MoveToMouse();
        }

        public void MoveToMouse()
        {
            if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, 100))
                {
                    navAgent.SetDestination(rayHit.point);
                }
            }
        }
    }
}