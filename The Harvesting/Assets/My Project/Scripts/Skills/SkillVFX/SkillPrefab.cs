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


        [HideInInspector]
        public SkillAction SkillAction;

        public void TriggerSkillAction(CharacterData attacker, Monster monster)
        {
           // var monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                if (SkillAction != null)
                {
                    if (Performer == null) UnityEngine.Debug.Log("Performer is NULL");
                    SkillAction.Trigger(attacker, monster);
                    //monster.TakeDamage(SkillAction, Performer);
                }

                //UnityEngine.Debug.Log("Monster HIT!!!!");
            }
        }
    }
}