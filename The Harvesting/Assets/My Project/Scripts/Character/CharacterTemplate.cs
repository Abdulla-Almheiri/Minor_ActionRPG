using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [CreateAssetMenu(fileName ="new character template", menuName = "Data/Character/Character Template")]
    public class CharacterTemplate : ScriptableObject
    {
        public CoreAttributes BaseAttributes;
        public List<ProgressionSkill> CharacterProgression;
        public List<MyAnimation> Animations;

        public void OnEnable()
        {
            
        }
    }

}