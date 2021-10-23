using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

namespace Harvesting
{
    public class Monster : MonoBehaviour
    {
        public FloatingCombatTextManager CombatText;
        public Slider Slider;
        public float MaxHealth = 100f;
        private float health = 100f;
        public MonsterCore MonsterCore;

        private bool killed = false;
        public void TakeDamage(float amount, bool isCritical)
        {
            if (killed)
            {
                return;
            }

            CombatText.PlaceDamageText(transform.position, amount, 1f, isCritical);
            health -= amount;
        }

        public void TakeDamage(SkillAction action, CharacterData attacker, bool isCritical)
        {
            if(killed)
            {
                return;
            }
            TakeDamage(action.Value(attacker, this), isCritical);
        }

        void Start()
        {
            health = MaxHealth;
        }

        void Update()
        {
            Slider.value = health / MaxHealth;

            if(health <= 0 && killed == false)
            {
                killed = true;
                MonsterCore.DropItems();
                MonsterCore.CombatController.AddState(MonsterCore.DeadState, 999999f);
                Slider.gameObject.SetActive(false);
            }
        }

        public bool Alive()
        {
            return !killed;
        }
    }

}