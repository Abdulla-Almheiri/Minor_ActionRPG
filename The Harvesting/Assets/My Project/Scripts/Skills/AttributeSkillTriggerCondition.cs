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
        public override bool Evaluate(CharacterData performer)
        {
            var modifier = performer.BaseAttributes.Find(x => x.Attribute == Attribute);
            if(modifier != null)
            {
                if(IsPercentage == true)
                {
                    var percentage = modifier.Value / modifier.MaxValue;
                    if(AttributeComparison == AttributeComparison.Above && percentage > AttributeAmount)
                    {
                        return true;
                    } else if (AttributeComparison == AttributeComparison.Below && percentage < AttributeAmount)
                    {
                        return true;
                    }
                } else if (AttributeComparison == AttributeComparison.Above)
                {
                    return modifier.Value > AttributeAmount;
                } else
                {
                    return modifier.Value < AttributeAmount;
                }
            }
            return false;
        }
    }

    public enum AttributeComparison
    {
        Above,
        Below,
    }
}