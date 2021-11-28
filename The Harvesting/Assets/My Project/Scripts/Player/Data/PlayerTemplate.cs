using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName = "new player template", menuName = "Data/Player/Player Template")]
    public class PlayerTemplate : CharacterTemplate
    {
        public List<ProgressionSkill> Progression;
        public CharacterTemplate CharacterTemplate;

    }
}