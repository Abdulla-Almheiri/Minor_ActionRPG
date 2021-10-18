using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    //[RequireComponent(typeof(SkillVFXParametersScript))]
    [RequireComponent(typeof(Collider))]
    public abstract class SkillPrefab : MonoBehaviour
    {
        [HideInInspector]
        public Character Performer;
        //public float Duration;

        [HideInInspector]
        public SkillAction SkillAction;

        public void TriggerSkillAction(Character attacker, Monster monster)
        {
           // var monster = other.GetComponent<Monster>();
            if (monster != null)
            {
                if (SkillAction != null)
                {
                    if (Performer == null) UnityEngine.Debug.Log("Performer is NULL");
                    monster.TakeDamage(SkillAction, Performer);
                }

                //UnityEngine.Debug.Log("Monster HIT!!!!");
            }
        }
    }
}