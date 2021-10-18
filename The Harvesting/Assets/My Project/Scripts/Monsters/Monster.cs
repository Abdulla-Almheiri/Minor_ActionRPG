using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class Monster : MonoBehaviour, IDamageable
    {
        public Slider Slider;
        public float MaxHealth = 100f;
        private float health = 100f;

        public void TakeDamage(float amount)
        {
            Debug.Log("Damage taken :    " + amount);
            health -= amount;
        }

        public void TakeDamage(SkillAction action, Character attacker)
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