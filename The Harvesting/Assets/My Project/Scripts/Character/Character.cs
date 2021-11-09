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

        public Dictionary<Attribute, Modifier> Attributes;


        /*public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {

        }*/

        public Character(CoreAttributes coreAttributes)
        {
            foreach(Attribute attribute in coreAttributes.Attributes)
            {
                Attributes[attribute] = new Modifier();
            }
        }

        public float Attribute(Attribute attribute)
        {
            Modifier mod = Attributes[attribute];
            return mod.Value * ((100 + mod.Percentage) / 100);
        }
    }
}