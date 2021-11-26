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
        public Canvas DynamicCanvas;
        public GameObject HealthBarUIPrefab;
        private Slider slider;
        private GameObject sliderSpawn;
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
            sliderSpawn = Instantiate(HealthBarUIPrefab, DynamicCanvas.transform);
            slider =sliderSpawn.GetComponentInChildren<Slider>();
            health = MaxHealth;
        }

        void Update()
        {
            slider.value = health / MaxHealth;
            sliderSpawn.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            if(health < 1 && killed == false)
            {
                killed = true;
                MonsterCore.DropItems();
                MonsterCore.CombatController.AddState(MonsterCore.DeadState, 999999f);
                slider.gameObject.SetActive(false);
            }
        }

        public bool Alive()
        {
            return !killed;
        }
    }

}