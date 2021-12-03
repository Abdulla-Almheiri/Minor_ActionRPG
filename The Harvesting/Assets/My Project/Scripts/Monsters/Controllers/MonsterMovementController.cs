using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Harvesting
{
    public class MonsterMovementController : CharacterMovementController, IMonsterMovementController
    {
        public new IMonsterCore Core { get; protected set; }


    }
}