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
            health -= amount;
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