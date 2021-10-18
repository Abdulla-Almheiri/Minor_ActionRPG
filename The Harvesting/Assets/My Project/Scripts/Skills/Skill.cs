using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new skill", menuName ="Data/Skills/Skill")]
    public class Skill : ScriptableObject
    {
        public Image Icon;
        public string Name;
        [TextArea(10,20)]
        public string Description;

        public List<SkillAction> Actions;
        
        public float Activate(Character attacker, Monster receiver)
        {
            float amount = 0f;
            foreach (SkillAction action in Actions)
            {
                amount += action.Value(attacker, receiver);
            }

            UnityEngine.Debug.Log("The Damage is :     " + amount);
            return amount;
        }

    }
}