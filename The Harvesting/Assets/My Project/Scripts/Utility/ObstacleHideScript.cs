using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Harvesting
{
    /// <summary>
    /// Script to hide objects when they are between player and camera. Requires Transparent material.
    /// </summary>
    [RequireComponent(typeof(Material))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    
    public class ObstacleHideScript : MonoBehaviour
    {
        [Range(0f, 10f)]
        public float FadeOutDuration = 1f;
        [Range(0f, 10f)]
        public float FadeInDuration = 1f;
        [Range(0f, 1f)]
        public float FadeOutAmount = 0.2f ;

        private Material mat;
        private Color opaqueColor;
        private Color transparentColor;
        private float transparency = 1f;

        void Start()
        {
 
            mat = GetComponent<Renderer>().material;
            opaqueColor = new Color(mat.color.r, mat.color.g, mat.color.b, 1.0f);
            transparentColor = new Color(mat.color.r, mat.color.g, mat.color.b, FadeOutAmount);

        }

        /// <summary>
        /// Start a cooroutine to change the transparency of an GameObject over the duration.
        /// </summary>
        /// <param name="targetTransparency"></param>
        /// <param name="duration"></param>
        private void FadeOut()
        {
            if (FadeOutDuration == 0f)
            {
                mat.SetColor("_BaseColor", transparentColor);
                return;
            }

            if (FadeOutAmount == 1f)
            {
                return;
            }

            float remainingDuration = (transparency-FadeOutAmount)/(1f-FadeOutAmount) * (FadeOutDuration);
            StartCoroutine(LerpColor(mat.color, transparentColor, remainingDuration));
        }

        public void FadeIn()
        {
            if (FadeInDuration == 0f)
            {
                mat.SetColor("_BaseColor", opaqueColor);
                return;
            }

            float remainingDuration = (1-transparency) / (1-FadeOutAmount) * (FadeInDuration);
            StartCoroutine(LerpColor(mat.color, opaqueColor, remainingDuration));
        }

        public void OnTriggerEnter(Collider other)
        {
            if (other.name == Camera.main.name)
            {

                FadeOut();
            }
        }

        public void OnTriggerExit(Collider other)
        {
            if (other.name == Camera.main.name)
            {

                FadeIn();
            }
        }

        public IEnumerator LerpColor(Color start, Color end, float durationInSeconds)
        {
            for (float t = 0; t <= durationInSeconds; t+= Time.deltaTime)
            {
                float normalizedTime = t / durationInSeconds;
                Color newColor = Color.Lerp(start, end, normalizedTime);
                transparency = newColor.a;
                mat.SetColor("_BaseColor", newColor);
                yield return null;
            }
           
        }
    }
}