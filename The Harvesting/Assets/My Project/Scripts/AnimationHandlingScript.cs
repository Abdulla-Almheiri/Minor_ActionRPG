using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class AnimationHandlingScript : MonoBehaviour
    {
        
        private NavMeshAgent navAgent;
        public Animator Animator;
        // Start is called before the first frame update
        void Start()
        {
            navAgent = gameObject.GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            if(IsRunning())
            {
                Animator.SetBool("IsRunning", true);
            } else
            {
                Animator.SetBool("IsRunning", false);
            }
        }

        public bool IsRunning()
        {
            if (navAgent.remainingDistance <= navAgent.stoppingDistance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}