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
        public Item StartingItem;
        public List<Modifier> Stats;
        public List<Modifier> TemporaryEnhancements;

        public void Start()
        {
            /*Inventory = new Inventory();
            Inventory.AddItem(StartingItem, 0);*/
        }

        /*public bool PickUpItem()
        {

            if (Input.GetMouseButton(0))
            {
                //navAgent.isStopped = false;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, Layer))
                {
                    navAgent.SetDestination(rayHit.point);
                }
            }
        }*/
    }
}
