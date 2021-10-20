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
        public ActionType ActionType = ActionType.Damage ;
        public Modifier Modifier;
        public SkillPrefab SkillVFX;

        public float Value(CharacterData attacker, Monster receiver)
        {
            if(attacker == null)
            {
                return 0;
            }

            var modifier = attacker.Attributes.Find(x => x.Attribute == Modifier.Attribute);
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
            switch(ActionType)
            {
                case ActionType.Damage:
                    var modifier = attacker.Attributes.Find(x => x.Attribute == Modifier.Attribute);
                    if (modifier != null)
                    {
                       monster.TakeDamage(Modifier.Percentage * modifier.Value / 100f);
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