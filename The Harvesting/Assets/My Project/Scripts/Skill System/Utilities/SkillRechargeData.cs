using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class SkillRechargeData
    {
        public Skill Skill;
        public float RemainingRechargeTime;

        public SkillRechargeData(Skill skill, float rechargeTime)
        {
            Skill = skill;
            RemainingRechargeTime = rechargeTime;
        }
    }
}