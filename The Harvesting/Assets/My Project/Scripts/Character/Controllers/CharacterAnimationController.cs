using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    public abstract class CharacterAnimationController : MonoBehaviour
    {
        protected Animator _animator;
        protected LayerMask _layer;

        public Animator Animator { get => _animator; }

        protected virtual void Initialize(Animator animator)
        {
            _animator = animator ? animator : GetComponentInChildren<Animator>();
            if(_animator == null)
            {
                Debug.Log("Animator not found in children of CharacterCore: CharacterAnimationController.");
            }
        }

        protected abstract void HandleRunningAnimation();

        public void RotateToMouseDirection()
        {
            _animator.SetBool("Running", false);
            if (/*!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()*/ true)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;

                if (Physics.Raycast(ray, out rayHit, _layer))
                {
                    var direction = (rayHit.point - transform.position);
                    direction.y = 0;
                    direction = direction.normalized;
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
    }
}