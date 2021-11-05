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
        private int level = 1;
        private Modifier health;
        private Modifier criticalChance;
        private float criticalDamage;

        public int Level { get => level; }
        public float Health { get => level; }

        public void ReceiveSkillAction(Character performer, SkillAction skillAction)
        {

        }

        public Character()
        {

        }
    }
}