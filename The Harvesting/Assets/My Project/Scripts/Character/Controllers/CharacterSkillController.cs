using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterSkillController : MonoBehaviour
    {
        protected CombatSettings _combatSettings;
        protected Dictionary<Skill, float> _skillRechargeTimes = new Dictionary<Skill, float>();
        protected List<SkillRechargeData> _usedSkills = new List<SkillRechargeData>();

        protected float _elapsedTime;
        protected virtual void Initialize(CombatSettings combatSettings)
        {
            _combatSettings = _combatSettings ? combatSettings : FindObjectOfType<CombatSettings>();
        }

        public virtual bool ActivateSkill(Skill skill)
        {
            if(CanActivateSkill(skill) == false)
            {
                return false;
            }

            return false;
        }

        protected virtual bool CanActivateSkill(Skill skill)
        {
            return false;
        }

        protected void HandleCooldownTimers()
        {
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _combatSettings.AbilityCooldownCheckRate)
            {
                for(int i = _usedSkills.Count; i >= 0; i--)
                {
                    _usedSkills[i].RemainingRechargeTime -= _elapsedTime;
                    _usedSkills.RemoveAt(i);
                }
                _elapsedTime = 0f;
            }
        }


    }
}