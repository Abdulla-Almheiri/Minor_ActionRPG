using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class MonsterMovementController : MonoBehaviour
    {
        public CharacterData MonsterData;
        public MonsterAnimationController AnimationController;
        public MonsterCombatController CombatController;
        public MonsterSkillController SkillController;
        public NavMeshAgent navMeshAgent;

        // Start is called before the first frame update
        void Start()
        {
            MoveToPoint(transform.position);
            AnimationController = GetComponent<MonsterAnimationController>();
            CombatController = GetComponent<MonsterCombatController>();
            SkillController = GetComponent<MonsterSkillController>();
            //navMeshAgent = GetComponent<NavMeshAgent>();
            MoveToPoint(transform.position);
        }

        // Update is called once per frame
        void Update()
        {
            if(!CombatController.CanMove(CombatController.CurrentCharacterState()))
            {
                navMeshAgent.isStopped = true;
            } else
            {
                navMeshAgent.isStopped = false;
            }
        }

        public void MoveToPoint(Vector3 point)
        {
            navMeshAgent.SetDestination(point);
        }

        public bool IsRunning()
        {
            return (navMeshAgent.remainingDistance >= navMeshAgent.stoppingDistance) && CombatController.CanMove(CombatController.CurrentCharacterState());
        }
    }
}