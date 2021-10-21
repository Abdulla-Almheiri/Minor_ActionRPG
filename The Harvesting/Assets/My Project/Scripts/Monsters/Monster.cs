using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class Monster : MonoBehaviour
    {
        public FloatingCombatTextManager CombatText;
        public Slider Slider;
        public float MaxHealth = 100f;
        private float health = 100f;

        public void TakeDamage(float amount, bool isCritical)
        {
            
            CombatText.PlaceDamageText(transform.position, amount, 1f, isCritical );
            health -= amount;
        }

        public void TakeDamage(SkillAction action, CharacterData attacker, bool isCritical)
        {
                TakeDamage(action.Value(attacker, this), isCritical);
        }

        void Start()
        {
            health = MaxHealth;
        }

        void Update()
        {
            Slider.value = health / MaxHealth;
        }
    }
}