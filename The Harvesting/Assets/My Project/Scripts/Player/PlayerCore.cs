using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting {
    public class PlayerCore : MonoBehaviour
    {
        public PlayerData PlayerData;
        public PlayerAnimationController AnimationController;
        public PlayerCombatController CombatController;
        public PlayerSkillController SkillController;
        public Inventory Inventory;

        public List<Modifier> Stats;
        public List<Modifier> TemporaryEnhancements;

    }
}
