using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class AnimationHandlingScript : MonoBehaviour
    {

        private NavMeshAgent navMeshAgent;
        public Animator Animator;


        private bool readyToAct = true;
        private float readyToActTimer = 0;

        private float movementSpeedMultiplier = 1f;
        private bool readyToMove = true;
        private float readyToMoveTimer = 0;

        private float attackSpeedMultiplier = 1f;
        private bool readyToAttack = true;
        private float readyToAttackTimer = 0;

        private float castSpeedMultiplier = 1f;
        private bool readyToCast = true;
        private float readyToCastTimer = 0f;

        private bool canInteract = true, canAttack = true, canMove = true, canCast = true, canBlock = true, canBeDamaged = true, canBeSeen = true;

        private AnimStates currentState = AnimStates.Idle;

        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            ResetStates();
        }

        void Update()
        {
            HandleTimers();
            HandleAnimation();
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                Animator.SetTrigger("Block2");
            }

        }

        private void HandleStates()
        {
            if (currentState == AnimStates.Idle)
            {
                canInteract = true;
                canMove = true;
                canAttack = true;
                canCast = true;
                canBeDamaged = true;
                canBeSeen = true;

            } else if (currentState == AnimStates.Stunned)
            {
                canInteract = false;
                canMove = false;
                canAttack = false;
                canCast = false;
                canBeDamaged = true;
                canBeSeen = true;
            } else if (currentState == AnimStates.Rooted)
            {
                canInteract = true;
                canMove = false;
                canAttack = true;
                canCast = true;
                canBeDamaged = true;
                canBeSeen = true;
            } else if (currentState == AnimStates.Silenced)
            {
                canInteract = true;
                canMove = true;
                canAttack = true;
                canCast = false;
                canBeDamaged = true;
                canBeSeen = true;
            } else if (currentState == AnimStates.Attacking)
            {
                canInteract = false;
                canMove = false;
                canAttack = false;
                canCast = false;
                canBeDamaged = true;
                canBeSeen = true;
            } else if (currentState == AnimStates.Casting)
            {
                canInteract = false;
                canMove = false;
                canAttack = false;
                canCast = false;
                canBeDamaged = true;
                canBeSeen = true;
            } else if (currentState == AnimStates.Immune)
            {
                canInteract = true;
                canMove = true;
                canAttack = true;
                canCast = true;
                canBeDamaged = false;
                canBeSeen = true;
            } else if(currentState == AnimStates.Dead)
            {
                canInteract = false;
                canMove = false;
                canAttack = false;
                canCast = false;
                canBeDamaged = false;
                canBeSeen = false;
            } else if(currentState == AnimStates.Stealth)
            {
                canInteract = true;
                canMove = true;
                canAttack = true;
                canCast = true;
                canBeDamaged = true;
                canBeSeen = false;
            } 
        }
        public void ResetStates()
        {

            readyToAct = true;
            readyToActTimer = 0;

            movementSpeedMultiplier = 1f;
            readyToMove = true;
            readyToMoveTimer = 0;

            attackSpeedMultiplier = 1f;
            readyToAttack = true;
            readyToAttackTimer = 0;

            castSpeedMultiplier = 1f;
            readyToCast = true;
            readyToCastTimer = 0;

            currentState = AnimStates.Idle;

        }

        public void ChangeState(AnimStates newState, float duration)
        {
            if (newState == AnimStates.Dead)
            {
                currentState = AnimStates.Dead;
                return;
            }


            if (newState == AnimStates.Stunned)
            {
                readyToAct = false;
                if (readyToActTimer < duration)
                {
                    readyToActTimer = duration;
                }
                currentState = newState;
                return;
            }

        }
        private void HandleAnimation()
        {
            if(IsRunning())
            {
                Animator.SetBool("Running", true);
            } else
            {
                Animator.SetBool("Running", false);
            }
        }


        private bool IsRunning()
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private void HandleTimers()
        {

            if (readyToActTimer > 0f)
            {
                readyToActTimer -= Time.deltaTime;
            }
            else if (readyToActTimer <= 0f)
            {
                readyToActTimer = 0f;
                readyToAct = true;
            }


            if (readyToAttackTimer > 0f)
            {
                readyToAttackTimer -= Time.deltaTime;
            }
            else if (readyToAttackTimer <= 0f)
            {
                readyToAttackTimer = 0f;
                readyToAttack = true;
            }


            if (readyToCastTimer > 0f)
            {
                readyToCastTimer -= Time.deltaTime;
            }
            else if (readyToCastTimer <= 0f)
            {
                readyToCastTimer = 0f;
                readyToCast = true;

            }


            if (readyToMoveTimer > 0f)
            {
                readyToMoveTimer -= Time.deltaTime;
            }
            else if (readyToMoveTimer <= 0f)
            {
                readyToMoveTimer = 0f;
                readyToMove = true;
            }

        }

    }



    public enum AnimStates
    {
        Idle,
        Attacking,
        Running,
        Hit,
        Stunned,
        Rooted,
        Silenced,
        Dead,
        Casting,
        Blocking,
        StartBlock,
        EndBlock,
        Immune,
        Stealth
    }
}