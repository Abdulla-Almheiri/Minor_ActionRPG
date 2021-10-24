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
        public List<ItemDrop> Loot = new List<ItemDrop>();

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
            int i = 0;
            foreach (ItemDrop item in Loot)
            {
                if (Random.Range(0, 100) <= item.Chance)
                {
                    var spawn = Instantiate(ItemGroundUIPrefab, DynamicCanvas.transform);
                    spawn.GetComponent<ItemGroundPrefab>().Item = item.Item;
                    //spawn.transform.SetParent(null);
                    spawn.WorldPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                    i++;
                }
            }
        }
    }
}