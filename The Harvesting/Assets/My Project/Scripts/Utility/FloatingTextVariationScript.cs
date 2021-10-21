using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Harvesting
{
    public class FloatingTextVariationScript : MonoBehaviour
    {
        private TMP_Text textMesh;
        private Animator animator;
        [HideInInspector]
        //public bool IsCritical = false;
        // Start is called before the first frame update
        void Start()
        {
            animator = GetComponent<Animator>();

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayAnimation(bool isCritical)
        {
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }

            if (isCritical)
            {
                animator.StopPlayback();
                animator.Play("Critical");
            }
            else
            {
                animator.StopPlayback();
                animator.Play("Normal");
            }
        }
    }
}