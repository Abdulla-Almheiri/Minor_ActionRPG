using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [RequireComponent(typeof(SkillVFXParametersScript))]
    public abstract class SkillPrefab : MonoBehaviour
    {
        public GameObject VFXPrefab;
        public float Duration;
    }
}