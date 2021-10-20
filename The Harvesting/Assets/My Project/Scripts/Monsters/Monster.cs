using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class Monster : MonoBehaviour, IDamageable
    {
        public FloatingCombatTextManager CombatText;
        public Slider Slider;
        public float MaxHealth = 100f;
        private float health = 100f;

        public void TakeDamage(float amount)
        {
            CombatText.PlaceDamageText(transform.position, amount, 1f);
            health -= amount;
        }

        public void TakeDamage(SkillAction action, CharacterData attacker)
        {
                TakeDamage(action.Value(attacker, this));
        }

        // Start is called before the first frame update
        void Start()
        {
            health = MaxHealth;
        }

        // Update is called once per frame
        void Update()
        {
            Slider.value = health / MaxHealth;
        }
    }
}