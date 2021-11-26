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
        protected int NumberOfEnemiesHit = 0;

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
                        NumberOfEnemiesHit++;
                        print("Enemies hit :  " + NumberOfEnemiesHit);

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
            float tickRate = action.TickRatePerSecond;
            while (true)
            {
                foreach (Monster monster in monstersInCollider)
                {
                    if(Performer != null && monster != null) action?.Trigger(Performer, monster);
                }
                yield return new WaitForSeconds(1f / tickRate);

            }
        }

        public void OnDestroy()
        {
            StopAllCoroutines();
        }

    }
}