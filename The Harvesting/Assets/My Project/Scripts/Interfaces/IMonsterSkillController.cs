using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMonsterSkillController : ICharacterSkillController
    {
        new IMonsterCore Core { get; }
    }
}