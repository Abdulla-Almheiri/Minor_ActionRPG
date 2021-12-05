using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterAIController : CharacterAIController, IMonsterAIController
    {
        public new IMonsterCore Core { get; protected set; }
        public MonsterAI MonsterAI { get; protected set; }
        private float decisionCooldown = 0f;
        public void Initialize(IMonsterCore core, MonsterAI monsterAI)
        {
            Core = core;
            MonsterAI = monsterAI;
            base.Initialize(core);
        }

        protected void HandleAI()
        {
            //Debug.Log("Monster health is   :    " + Core.CombatController.HealthPercentage());
            float runAwayScore = 0f, meleeScore = 0f, rangedScore =0f, variation = 10f;
            decisionCooldown -= Time.deltaTime + (1-Core.CombatController.HealthPercentage())/100f ;
            if (Random.Range(0, 10f) > decisionCooldown)
            {
                if (MonsterAI.RunWhenLowOnHealth.Condition == true)
                {
                    runAwayScore += (1f - Core.CombatController.HealthPercentage()) * (MonsterAI.RunWhenLowOnHealth.Weight + Random.Range(0, variation));
                    meleeScore -= (1f - Core.CombatController.HealthPercentage()) * (MonsterAI.RunWhenLowOnHealth.Weight + Random.Range(0, variation));
                    rangedScore += (1f - Core.CombatController.HealthPercentage()) * (MonsterAI.AttackFromRange.Weight + Random.Range(0, variation));
                }

                if (MonsterAI.AttackFromRange.Condition == true)
                {
                    runAwayScore += (MonsterAI.RunWhenLowOnHealth.Weight + Random.Range(0, variation));
                    meleeScore -= (MonsterAI.RunWhenLowOnHealth.Weight + Random.Range(0, variation));
                    rangedScore +=  (MonsterAI.AttackFromRange.Weight + Random.Range(0, variation));
                }

                if (MonsterAI.CastSupportSpells.Condition == true)
                {
                    runAwayScore += (MonsterAI.CastSupportSpells.Weight + Random.Range(0, variation));
                    meleeScore -= (MonsterAI.CastSupportSpells.Weight + Random.Range(0, variation));
                    rangedScore += (MonsterAI.AttackFromRange.Weight/2 + Random.Range(0, variation));
                }

                if (MonsterAI.AttackInMelee.Condition == true)
                {
                    runAwayScore -= (MonsterAI.AttackInMelee.Weight + Random.Range(0, variation));
                    meleeScore += (MonsterAI.AttackInMelee.Weight + Random.Range(0, variation));
                    rangedScore -= (MonsterAI.AttackFromRange.Weight + Random.Range(0, variation));
                }

                if (meleeScore > runAwayScore && meleeScore > rangedScore)
                {
                    AttackInMelee();
                    decisionCooldown = 5f;
                    //Debug.Log("Chasing");
                }
                else if(runAwayScore > rangedScore)
                {
                    RunAway(runAwayScore/20f);
                    decisionCooldown = 10f;
                    
                } else
                {
                    Debug.Log("Ranged score is :   " + rangedScore);
                    RunAway(rangedScore / 10f);
                    Core.SkillController.ActivateSkill(Core.SkillController.SecondaryWeaponSkill, Core.GameManager.PlayerCore);
                    decisionCooldown = 5f;
                }
            }
        }

        protected void RunAway(float distance)
        {

            var point = (Core.GameManager.PlayerCore.MovementController.Transform.position + Core.MovementController.Transform.position).normalized * distance ;
            Core.MovementController.MoveToPoint(point);
        }

        protected void ChasePlayer()
        {
            Core.MovementController.MoveToCharacter(Core.GameManager.PlayerCore);
        }

        protected void AttackInMelee()
        {
            Core.SkillController.ActivateSkill(Core.SkillController.PrimaryWeaponSkill, Core.GameManager.PlayerCore);
        }
        public void Update()
        {
            HandleAI();
        }
    }
}