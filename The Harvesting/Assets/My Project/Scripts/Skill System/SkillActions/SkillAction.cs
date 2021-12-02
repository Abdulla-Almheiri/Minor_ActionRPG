using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Skill Actions are the individual effects of Skills. 
    /// </summary>

    [System.Serializable]
    public class SkillAction
    {
        //Activation
        [Header("Activation")]
        public SkillActionTriggerCondition TriggerCondition;
        [Range(0, 100)]
        public float TriggerChance = 100f;
        [Space(20)]


        //Execution


        //Impact Event


        //VFX


        //SFX


        public bool ContinousDamage = false;
        public float TickRatePerSecond = 1f;

        public SkillActionType Type;
        public Modifier Modifier;
        public SkillActionElement Element;
        public CharacterState CharacterStatusEffect;
        public StatusEffect DamageStatusEffect;
        public GameObject OnMonsterEffect;
        public Attribute ResourceToDrain;
        public float DrainAmount;
        public bool IsDrainAmountPercentage = false;

        public SkillPrefab SkillVFX;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attacker"> Performer </param>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public float Value(CharacterStats attacker, MonsterData receiver)
        {
            if (attacker == null)
            {
                return 0;
            }

            var modifier = attacker.Attributes[Modifier.Attribute];
            if (modifier != null)
            {
                return Modifier.Percentage * modifier.FinalValue() / 100f;
            }
            else
            {
                return 0;
            }

        }

        public void Trigger(CharacterData performer, CharacterData monster)
        {

            if (Random.Range(0, 100) > TriggerChance)
            {
                return;
            }

            

        }
    }

}