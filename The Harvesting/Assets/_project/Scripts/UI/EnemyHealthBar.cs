using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Harvesting
{
    public class EnemyHealthBar : MonoBehaviour
    {
        private Vector3 _worldPosition;
        [SerializeField] private Slider _healthSlider;

        void Start()
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(_worldPosition);
        }

        void Update()
        {
            MaintainPosition();
        }
        public void AssignPosition(Vector3 position)
        {
            _worldPosition = position;
        }

        public void MaintainPosition()
        {
            gameObject.transform.position = Camera.main.WorldToScreenPoint(_worldPosition);
        }

        public void UpdateHealth(float amount)
        {
            _healthSlider.value = Mathf.Clamp(amount, 0f, 1f);
        }
    }
}