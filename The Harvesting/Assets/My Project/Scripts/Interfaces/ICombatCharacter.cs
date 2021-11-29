using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICombatCharacter : ISkillActivator, ICriticalHitter, IMoving, IKillable, IManaUser, IController
    {

    }
}