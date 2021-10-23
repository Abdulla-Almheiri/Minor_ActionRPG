using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting {
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerSkillController : MonoBehaviour
    {
        public PlayerCore PlayerCore;
        private PlayerCombatController combatController;
        private PlayerAnimationController animationController;

        public PlayerData Player;
        public LayerMask Layer;
        public Transform Loc1, Loc2, Loc3;
        public SkillUIScript SkillUI;
        public float SkillCooldownCheckRate = 0.2f;
        private float skillCheckTimer;
        public float GlobalCooldown = 0.5f;
        private float GlobalSkillTimer = 0f;
        private NavMeshAgent navMeshAgent;
        private float[] cooldowns;

        void Start()
        {
            Player.Initialize();
            combatController = GetComponent<PlayerCombatController>();
            animationController = GetComponent<PlayerAnimationController>();

            navMeshAgent = GetComponent<NavMeshAgent>();
            cooldowns = new float[20];
            skillCheckTimer = SkillCooldownCheckRate;
        }

        void Update()
        {
            HandleInput();
            HandleCooldown();
        }

        public void RotateToMouseDirection()
        {
            animationController.Animator.SetBool("Running", false);
            if (/*!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()*/ true)
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
            if (cooldowns[number] > 0)
            {
                return;
            }


            // TO DO : Character state and Animation checks
            CharacterState characterState = combatController.CurrentCharacterState();




            var skill = Player.Skills[number];
            var location = transform;
            skill.Initialize();


            if (skill.IsMelee && characterState.CanAttack == false)
            {
                return;
            }

            if (skill.IsSpell && characterState.CanCast == false)
            {
                return;
            }

            if (skill.IsMovementSkill && characterState.CanMove == false)
            {
                return;
            }

            animationController.Animator.SetBool("Running", false);
            animationController.Animator.SetTrigger("Cast4");



            if (skill?.FaceDirection == true)
            {
                RotateToMouseDirection();
            }

            if (skill?.DefaultVFXPrefab != null)
            {
                if (skill.DefaultVFXPrefab is ProjectileSkillPrefab)
                {
                    location = Loc1;
                }
                else if (skill.DefaultVFXPrefab is MeleeSkillPrefab)
                {
                    location = transform;
                }
            }

            cooldowns[number] = skill.RechargeTime;
            

            /// FIX HERE
            skill?.Activate(Player, location?location:transform);

        }
        private IEnumerator ActivationEnumerator(int number)
        {
            
            if (cooldowns[number] > 0)
            {
                yield break;
            }


            // TO DO : Character state and Animation checks
            CharacterState characterState = combatController.CurrentCharacterState();

            


            var skill = Player.Skills[number];
            var location = transform;

            

            if (skill.IsMelee && characterState.CanAttack == false)
            {
                yield break;
            }

            if (skill.IsSpell && characterState.CanCast == false)
            {
                yield break;
            }

            if (skill.IsMovementSkill && characterState.CanMove == false)
            {
                yield break;
            }

            animationController.Animator.SetBool("Running", false);
            animationController.Animator.SetTrigger("Cast4");
            
            

            if (skill?.FaceDirection == true)
            {
                RotateToMouseDirection();
            }

            if (skill?.DefaultVFXPrefab != null)
            {
                if (skill.DefaultVFXPrefab is ProjectileSkillPrefab)
                {
                    location = Loc1;
                } else if(skill.DefaultVFXPrefab is MeleeSkillPrefab)
                {
                    location = transform;
                }

            }

            cooldowns[number] = skill.RechargeTime;
            yield return new WaitForSeconds(skill.PlayerAnimation.ImpactPointSeconds()/animationController.Animator.speed);
            skill?.Activate(Player, location);
            
        }

        private void HandleInput()
        {
            for (int i = 0; i < Player.Skills.Count; i++)
            {
                if (Input.GetKeyDown((KeyCode)49 + i))
                {
                    ActivateSkill(i);
                }
            }
        }


        private void HandleCooldown()
        {
            skillCheckTimer -= Time.deltaTime;
            if (skillCheckTimer <= 0)
            {
                for (int i = 0; i < cooldowns.Length; i++)
                {
                    cooldowns[i] -= SkillCooldownCheckRate - skillCheckTimer;
                }
                skillCheckTimer = SkillCooldownCheckRate;
            }
        }

        /// <summary>
        /// Returns skill cooldown progress. Values 0 to 1 or -1 for incorrect input.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public float SkillRecharge(int number)
        {
            if (number > cooldowns.Length || Player.Skills.Count <= number || Player.Skills[number] == null)
            {
                return -1f;
            }
            float recharge = Player.Skills[number].RechargeTime;

            if (recharge == 0)
            {
                return 1f;
            }

            return Mathf.Clamp((recharge - cooldowns[number]) / recharge, 0f , 1f);
        }
    }

    
    

}