using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    //[RequireComponent(typeof(SkillVFXParametersScript))]
   
    public abstract class SkillPrefab : MonoBehaviour
    {
        [HideInInspector]
        public CharacterData Performer;
        public List<Skill> ImpactSkills;
        protected List<Monster> monstersInCollider = new List<Monster>();

        [HideInInspector]
        public List<SkillAction> SkillActions = new List<SkillAction>();

        public void TriggerSkillActions(CharacterData attacker, Monster monster)
        {
            if (monster != null)
            {
                if (SkillActions.Count != 0)
                {
                    
                    foreach (SkillAction action in SkillActions)
                    {
                        action.Trigger(attacker, monster);
                        if(action.ContinousDamage)
                        {
                            StartCoroutine(TriggerContinuous(action));
                        }
                    }
                }

            }
        }

        public void TriggerSkillAction(SkillAction action, CharacterData attacker, Monster monster)
        {
            action.Trigger(attacker, monster);
        }

        public IEnumerator TriggerContinuous(SkillAction action)
        {
            while (true)
            {
                foreach (Monster monster in monstersInCollider)
                {
                    action.Trigger(Performer, monster);
                }
                yield return new WaitForSeconds(1f / action.TickRatePerSecond);

            }
        }

        public void OnDisable()
        {
            StopAllCoroutines();
        }

    }
}