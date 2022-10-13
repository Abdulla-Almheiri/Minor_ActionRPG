using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [System.Serializable]
    public class SkillSpawnLocationData 
    {
        public Transform Location;
        public SkillSpawnLocation LocationType = SkillSpawnLocation.Center;
    }

    public enum SkillSpawnLocation
    {
        Hand,
        Above,
        Feet,
        Center,
        Chest,
        Behind
    }
}