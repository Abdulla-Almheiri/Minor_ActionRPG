using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterSkillController : MonoBehaviour, ICharacterSkillController
    {
        
        protected CombatSettings _combatSettings;
        protected Dictionary<Skill, float> _skillRechargeTimes = new Dictionary<Skill, float>();
        protected List<SkillRechargeData> _usedSkills = new List<SkillRechargeData>();

        protected float _elapsedTimeAbilities;

        protected virtual void Initialize(CombatSettings combatSettings)
        {
            _combatSettings = combatSettings;
        }

        public abstract bool ActivateSkill(Skill skill);
        
        protected abstract bool CanActivateSkill(Skill skill, bool ignoreRecharge);

        protected void HandleAbilityCooldownTimers()
        {
            _elapsedTimeAbilities += Time.deltaTime;
             if (_elapsedTimeAbilities >= _combatSettings.AbilityCooldownCheckRate)
             {
                 for(int i = _usedSkills.Count -1; i >= 0; i--)
                 {
                     var skill = _usedSkills[i];
                     skill.RemainingRechargeTime -= _elapsedTimeAbilities;
                     if (skill.RemainingRechargeTime <= MyMaths.NearZero)
                     {
                        skill.RemainingRechargeTime = 0f;
                     }
                 }

                 _elapsedTimeAbilities = 0f;
             }

        }

        public virtual float SkillRecharge(Skill skill, out float seconds)
        {
            if (skill.RechargeTime == 0)
            {
                seconds = 0f;
                return 0f;
            }

            var usedSkill = _usedSkills.Find(x => x.Skill == skill);

            if (usedSkill == null)
            {
                seconds = 0f;
                return 0f;
            }

            seconds = skill.RechargeTime - usedSkill.RemainingRechargeTime;

            return usedSkill.RemainingRechargeTime / skill.RechargeTime;
        }
    }
}