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

        public List<SkillAction> Actions;


        public void Perform(Character attacker, Character receiver)
        {
            foreach (SkillAction action in Actions)
            {
                action.Activate(attacker, receiver);
            }
        }
    }
}