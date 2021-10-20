using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Harvesting
{
    public class FloatingTextVariationScript : MonoBehaviour
    {
        private TMP_Text textMesh;
        // Start is called before the first frame update
        void Start()
        {
            textMesh.rectTransform.pivot.Set(Random.Range(-1f, 1f), textMesh.rectTransform.pivot.y);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}