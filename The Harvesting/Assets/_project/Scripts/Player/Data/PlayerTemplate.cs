using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName = "new player template", menuName = "Data/Player/Player Template")]
    public class PlayerTemplate : CharacterTemplate, IPlayerTemplate
    {

        [SerializeField] protected List<ProgressionSkill> _skillProgression;
        public List<ProgressionSkill> SkillProgression { get => _skillProgression; }

    }
}