using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SkillVFXParametersScript : MonoBehaviour
    {
        public float Speed = 1f;
        public List<ParticleSystem> ParticleSystems;
        private Color color;
        private float duration;


        void Start()
        {
            color = new Color(50f, 50f, 50f);
            foreach(ParticleSystem partSys in ParticleSystems)
            {
                partSys.Stop();
                var ParticleSettings = partSys.main;
                ParticleSettings.startLifetimeMultiplier *= Speed;
                partSys.Play();

            }
        }

        void Update()
        {

        }

        public void SetColor(Color newColor)
        {
            color = new Color(newColor.r, newColor.g, newColor.b);
        }

        public void SetDuration(float newDuration)
        {
            duration = newDuration;
        }

        public Color GetColor()
        {
            return color;
        }

        public float GetDuration()
        {
            return duration;
        }

        public void OnTriggerEnter(Collider other)
        {
            Debug.Log("First Layer.");
            if (other.GetComponent<Monster>())
            {
                other.gameObject.GetComponent<Monster>().TakeDamage(Random.Range(2f, 20f));
                Debug.Log("Monster HIT!!!!");
            }
        }
    }
}