using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    /// <summary>
    /// Character Class. Contains Character game data.
    /// </summary>
    public class Character
    {
        public CharacterModifier Health;
        public Dictionary<Attribute, CharacterModifier> Attributes;

        public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {

        }

        public Character(CoreAttributes coreAttributes)
        {
            foreach(Attribute attribute in coreAttributes.AdditionalAttributes)
            {
                Attributes[attribute] = new CharacterModifier();
            }
        }

        public float Attribute(Attribute attribute)
        {
            CharacterModifier mod = Attributes[attribute];
            return mod.Value();
        }
     
    }
}