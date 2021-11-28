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

        public ActionType ActionType = ActionType.Damage ;
        public SkillActionElement Element;
        public CharacterState CharacterStatusEffect;
        public StatusEffect DamageStatusEffect;
        public GameObject OnMonsterEffect;
        public Modifier Modifier;
        public SkillPrefab SkillVFX;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attacker"> Performer </param>
        /// <param name="receiver"></param>
        /// <returns></returns>
        public float Value(CharacterStats attacker, MonsterNEW receiver)
        {
            if(attacker == null)
            {
                return 0;
            }

            var modifier = attacker.Attributes[Modifier.Attribute];
            if (modifier != null)
            {
                return Modifier.Percentage * modifier.FinalValue() / 100f;
            } else
            {
                return 0;
            }

        }
        
        public void Trigger(Character attacker, MonsterNEW monster)
        {

            if(Random.Range(0, 100) > TriggerChance)
            {
                return;
            }

            bool isCritical = false;
            switch(ActionType)
            {
                case ActionType.Damage:
                    var modifier = attacker.Attributes[Modifier.Attribute];
                    if (modifier != null)
                    {
                        var amount = Modifier.Value + (Modifier.Percentage * modifier.FinalValue() / 100f);
                        if(Modifier.MaxValue != 0 && amount > Modifier.MaxValue)
                        {
                            amount = Modifier.MaxValue;
                        }

                        // Critical 

                        if (Random.Range(0, 100) < attacker.Attributes[attacker.CoreAttributes.CriticalChance].FinalValue())
                        {
                            var multiplier = 1f + (attacker.Attributes[attacker.CoreAttributes.CriticalDamage].FinalValue() / 100f);
                            amount *= multiplier;
                            isCritical = true;
                        }


                       monster.TakeDamage(amount, isCritical);
                    }
                    else
                    {
                        Debug.Log("Attribute not found SkillAction:Trigger().");
                        return ;
                    }
                    break;
                case ActionType.StatusEffect:
                    if(CharacterStatusEffect != null && monster.MonsterCore != null)
                    {
                        monster.MonsterCore.CombatController.AddState(CharacterStatusEffect, Modifier.Duration);
                        if (OnMonsterEffect != null)
                        {
                            monster.MonsterCore.AnimationController.AddEffect(OnMonsterEffect, Modifier.Duration);
                        }

                        // FIX STATUS EFFECTS HERE
                        if(DamageStatusEffect != null)
                        {

                        }
                    }
                    break;

            }
        }
        
    }

    public enum ActionType
    {
        Damage,
        Healing,
        StatusEffect
    }

}