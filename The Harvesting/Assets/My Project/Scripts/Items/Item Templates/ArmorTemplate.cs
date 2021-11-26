using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class ArmorTemplate : ItemTemplate
    {
        public int ItemLevel;
        public int RequiredLevel = 1;
        public List<Attribute> Attributes = new List<Attribute>();

        public override Item Generate(int level, int requiredLevel)
        {
            throw new System.NotImplementedException();
        }
        /*public override void Interact(CharacterData character)
{
   character.UseItem(this);
}*/
    }
}