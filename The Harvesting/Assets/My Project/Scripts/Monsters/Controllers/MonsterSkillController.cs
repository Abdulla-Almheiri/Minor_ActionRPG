using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    public class MonsterSkillController : CharacterSkillController, IMonsterSkillController
    {
        public new IMonsterCore  Core { get; protected set; }

    }
}