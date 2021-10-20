using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(Animator))]
    public class PoolableAnimationFinish : Poolable
    {
        public bool HideInInspector = true;
        private Animator animator;
        [HideInInspector]
        public Vector3 WorldPosition;
        private Transform trans;
        private Camera cam;
        protected override void OnEnabled()
        {
            base.OnEnabled();
            if (animator == null) animator = gameObject.GetComponent<Animator>();
            MaintainPosition();
        }

        public void OnEnable()
        {
            //if(HideInInspector) gameObject.hideFlags = HideFlags.HideInHierarchy;
            trans = gameObject.GetComponent<Transform>();
            OnEnabled();
        }

        public void OnDisable()
        {
            OnDisabled();

        }

        protected override void OnDisabled()
        {
            base.OnDisabled();

        }
        public void Update()
        {
            CheckAnimationAndDisable();
            MaintainPosition();
        }

        private void CheckAnimationAndDisable()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                gameObject.SetActive(false);
            }
        }

        public void MaintainPosition()
        {
            trans.position = Camera.main.WorldToScreenPoint(WorldPosition);
        }
    }
}