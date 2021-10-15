using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class ClickToMoveScript : MonoBehaviour
    {
        private NavMeshAgent navAgent;
        public LayerMask Layer;
        void Start()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
            navAgent.updateRotation = true;
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
                navAgent.isStopped = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, Layer))
                {
                    navAgent.SetDestination(rayHit.point);
                }
            }
        }
    }
}