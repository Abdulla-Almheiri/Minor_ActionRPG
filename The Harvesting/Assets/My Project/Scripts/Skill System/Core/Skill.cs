using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new skill", menuName ="Data/Skills/Skill")]
    public class Skill : ScriptableObject
    {
        [Header("SKILL DESCRIPTION")]
        public Sprite Icon;
        public string Name;
        [TextArea(5,15)]
        public string Description;
        public int ManaCost = 0;
        public float RechargeTime = 0f;
        [Space(20)]

        [Header("VISUAL EFFECT")]
        public SkillPrefab DefaultVFXPrefab;
        [Space(20)]

        [Header("ACTIVATION")]
        [Range(0, 100)]
        public float TriggerChance = 100f;
        public SkillTriggerCondition TriggerCondition;

        public bool FaceDirection = true;
        public bool IsMelee = false;
        public bool IsSpell = true;
        public bool IsMovementSkill = false;
        public bool RemovesRoot = false;
        public bool RemovesStun = false;
        public bool CanBeUsedWhileStunned = false;
        public bool RemovesSilence = false;

        public bool IsCastOnSelf = false;
        public CharacterAnimationData PlayerAnimation;


        public Skill ImpactSkill;

        private SkillPrefab defaultVFX = null;
        [Header("If Action's VFX Prefab is empty, then default one is used.")]
        public List<SkillAction> Actions;
        
        public void Activate(CharacterData activator, Transform location)
        {
            if(Random.Range(0,100) > TriggerChance && !TriggerCondition.Evaluate(activator))
            {
                return;
            }

            if (DefaultVFXPrefab != null)
            {

                defaultVFX = Instantiate(DefaultVFXPrefab, location);
                if (!IsCastOnSelf)
                {
                    defaultVFX.transform.SetParent(null);
                }
                defaultVFX.Performer = activator;
                defaultVFX.ImpactSkills.Add(ImpactSkill);
            }

            foreach (SkillAction action in Actions)
            {
                if (Random.Range(0, 100) > action.TriggerChance && !action.TriggerCondition.Evaluate(action, activator ))
                {
                    continue;
                }
                if (action.SkillVFX != null)
                {
                    var vfx = Instantiate(action.SkillVFX, location);
                    if (!IsCastOnSelf)
                    {
                        vfx.transform.parent = null;
                    }

                    vfx.SkillActions.Add(action);
                    vfx.Performer = activator;
                    vfx.ImpactSkills.Add(ImpactSkill);
                } else if(defaultVFX != null)
                {
                    defaultVFX.SkillActions.Add(action);
                }
            }


        }


        public void Initialize()
        {

        }
    }
}