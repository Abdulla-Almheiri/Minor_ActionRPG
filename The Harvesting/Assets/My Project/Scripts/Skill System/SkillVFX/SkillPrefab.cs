using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    //[RequireComponent(typeof(SkillVFXParametersScript))]
   
    public abstract class SkillPrefab : MonoBehaviour
    {
        [HideInInspector]
        public ICharacterCore Performer;
        public List<Skill> ImpactSkills;
        protected List<ICharacterCore> charactersInCollider = new List<ICharacterCore>();
        protected int NumberOfEnemiesHit = 0;

        [HideInInspector]
        public List<SkillAction> SkillActions = new List<SkillAction>();

        public void TriggerSkillActions(ICharacterCore attacker, ICharacterCore receiver)
        {
            if (SkillActions.Count != 0)
            {
                foreach (SkillAction action in SkillActions)
                {
                    TriggerSkillAction(attacker, receiver, action);
                    NumberOfEnemiesHit++;
                    print("Enemies hit :  " + NumberOfEnemiesHit);

                    if (action.ContinousDamage)
                    {
                        StartCoroutine(TriggerContinuous(action));
                    }
                }
            }
        }

        public void TriggerSkillAction(ICharacterCore attacker, ICharacterCore receiver, SkillAction action)
        {
            receiver.CombatController.ReceiveSkillAction(action, attacker, out _);

        }

        public IEnumerator TriggerContinuous(SkillAction action)
        {
            float tickRate = action.TickRatePerSecond;
            if(tickRate == 0f)
            {
                yield break;
            }
            while (true)
            {
                foreach (ICharacterCore receiver in charactersInCollider)
                {
                    // FIX HERE FOR CONTINUOUS HEALS OR ENHANCEMENTS
                    if (Performer != receiver)
                    {
                        receiver.CombatController.ReceiveSkillAction(action, Performer, out _);
                    }
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