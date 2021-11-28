using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [CreateAssetMenu(fileName ="new attribute skill trigger condition", menuName ="Data/Skills/Attribute Skill Trigger Condition")]
    public class AttributeSkillTriggerCondition : SkillTriggerCondition
    {
        public AttributeComparison AttributeComparison;
        public float AttributeAmount;
        public bool IsPercentage = true;
        public Attribute Attribute;
        public override bool Evaluate(Character character)
        {
            if(IsPercentage)
            {
                var percent = character.HealthPercentage();

                if (AttributeComparison == AttributeComparison.Above)
                {
                    return percent >= AttributeAmount;
                } else
                {
                    return character.HealthPercentage() < AttributeAmount;
                }
            } else
            {
                var amount = character.Attributes[Attribute].FinalValue();

                if (AttributeComparison == AttributeComparison.Above)
                {
                    return amount >= AttributeAmount;
                }
                else
                {
                    return amount < AttributeAmount;
                }
            }

        }
    }

    public enum AttributeComparison
    {
        Above,
        Below,
    }
}