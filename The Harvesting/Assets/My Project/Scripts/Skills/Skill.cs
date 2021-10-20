using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new skill", menuName ="Data/Skills/Skill")]
    public class Skill : ScriptableObject
    {
        public Sprite Icon;
        public string Name;
      
        [TextArea(10,20)]
        public string Description;

        public bool FaceDirection = true;
        public bool IsMelee = false;
        public int Cost = 0;
        public float RechargeTime = 0f;

        public List<SkillAction> Actions;
        
        public void Activate(CharacterData activator, Transform location)
        {
            foreach (SkillAction action in Actions)
            {
                if(action.SkillVFX != null)
                {
                    var vfx = Instantiate(action.SkillVFX, location);
                    vfx.transform.parent = null;
                    vfx.SkillAction = action;
                    vfx.Performer = activator;
                }
            }


        }

    }
}