using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterUIController : CharacterUIController
    {
        public new IMonsterCore Core { get; protected set; }
    }
}