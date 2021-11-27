using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class PlayerStatsUIScript : MonoBehaviour
    {

        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _manaSlider;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Initialize()
        {
        }
        public void UpdateHealthPercentage(float percentage)
        {
            _healthSlider.value = Mathf.Clamp(percentage, 0f, 100f) / 100f;
        }

        public void UpdateManaPercentage(float percentage)
        {
            _manaSlider.value = Mathf.Clamp(percentage, 0f, 100f) / 100f;
        }
    }
}