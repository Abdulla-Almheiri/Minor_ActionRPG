using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(MonsterAnimationController))]
    [RequireComponent(typeof(MonsterCombatController))]
    [RequireComponent(typeof(MonsterSkillController))]
    [RequireComponent(typeof(MonsterMovementController))]

    public class MonsterCore : MonoBehaviour
    {
        public PlayerCore PlayerCore;
        public CharacterData MonsterData;
        public MonsterAnimationController AnimationController;
        public MonsterCombatController CombatController;
        public MonsterMovementController MovementController;
        public MonsterSkillController SkillController;
        public Canvas DynamicCanvas;
        public ItemGroundPrefab ItemGroundUIPrefab;
        public Item Loot;

        public CharacterState DeadState;
        public void Start()
        {
            AnimationController = GetComponent<MonsterAnimationController>();
            CombatController = GetComponent<MonsterCombatController>();
            MovementController = GetComponent<MonsterMovementController>();
            SkillController = GetComponent<MonsterSkillController>();
        }


        public void DropItems()
        {
            var spawn = Instantiate(ItemGroundUIPrefab, DynamicCanvas.transform);
            //spawn.transform.SetParent(null);
            spawn.WorldPosition = transform.position;
        }
    }
}