using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class GroundTargetedSkillPrefab : SkillPrefab
    {
        public GameObject TargetingCircle;
        public LayerMask Layer;
        private GameObject spawn;
        // Start is called before the first frame update
        void Start()
        {
            CastingCircle();
        }

        // Update is called once per frame
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit rayHit;

            if (Physics.Raycast(ray, out rayHit, Layer))
            {
                spawn.transform.position = rayHit.point;
            }
            
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Destroy(gameObject);
            }
        }

        public void CastingCircle()
        {
            spawn = Instantiate(TargetingCircle);



        }

        
    }
}