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
        public bool ContinousDamage = false;
        public float TickRatePerSecond = 1f;
        public SkillActionTriggerCondition TriggerCondition;
        [Range(0,100)]
        public float TriggerChance = 100f;
        public ActionType ActionType = ActionType.Damage ;
        public Modifier Modifier;
        public SkillPrefab SkillVFX;

        public float Value(CharacterData attacker, Monster receiver)
        {
            if(attacker == null)
            {
                return 0;
            }

            var modifier = attacker.BaseAttributes.Find(x => x.Attribute == Modifier.Attribute);
            if (modifier != null)
            {
                return Modifier.Percentage * modifier.Value / 100f;
            } else
            {
                return 0;
            }

        }

        public void Trigger(CharacterData attacker, Monster monster)
        {

            bool isCritical = false;
            switch(ActionType)
            {
                case ActionType.Damage:
                    var modifier = attacker.BaseAttributes.Find(x => x.Attribute == Modifier.Attribute);
                    if (modifier != null)
                    {
                        var amount = Modifier.Percentage * modifier.Value / 100f;


                        // Critical 

                        if (Random.Range(0, 100) < attacker.BaseAttributes.Find(x => x.Attribute.name == "CriticalChance").Percentage)
                        {
                            var multiplier = 1f + (attacker.BaseAttributes.Find(x => x.Attribute.name == "CriticalDamage").Percentage / 100f);
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