using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface ICharacterCombatController
    {
        ICharacterCore Core { get; }
        CombatSettings CombatSettings { get; }
        public float Size { get; }
        float CurrentHealth { get; }
        float CurrentMana { get; }
        bool IsAlive { get; }
        void Initialize(ICharacterCore core);
        bool AddCharacterState(CharacterState characterState, float rawDuration);
        float AttributeValue(Attribute attribute);
        void ReceiveSkillAction(SkillAction skillAction, ICharacterCore performer, out SkillActionEventData skillActionEventData);
        bool CanMove();
        bool CanAttack();
        bool CanCast();
        bool CanBlock();
        bool CanInteract();
        bool CanBeDamaged();
        bool CanBeHealed();
        void LevelUp(int newLevel);
        float HealthPercentage();
        float ManaPercentage();
        void IncurManaCost(Skill skill);
        void RefundManaCost(Skill skill);
        bool HasManaForSkill(Skill skill);
        bool IsWithinMeleeRange(ICharacterCore character);
        void TriggerOnHitEffects();
    }
}