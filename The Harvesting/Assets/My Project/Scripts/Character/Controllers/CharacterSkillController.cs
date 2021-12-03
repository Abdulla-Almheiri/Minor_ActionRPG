using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterSkillController : MonoBehaviour, ICharacterSkillController
    {
        public ICharacterCore Core { get; protected set; }

        public CombatSettings CombatSettings { get; protected set; }
        protected Dictionary<Skill, float> _skillRechargeTimes = new Dictionary<Skill, float>();
        protected List<SkillRechargeData> _usedSkills = new List<SkillRechargeData>();

        protected float _elapsedTimeAbilities = 0f;
        public List<Skill> Abilities { get; protected set; } = new List<Skill>();
        //public Skill PrimaryWeaponSkill { get; protected set; }

        //public Skill SecondaryWeaponSkill { get; protected set; }

        private CoreAttributesTemplate _coreAttributes;
        public List<SkillSpawnLocationData> SkillSpawnLocations { get; protected set; }
        protected float _elapsedTimeWeaponSkills;
        protected float _primaryWeaponSkillRechargeTimer;
        protected float _secondaryWeaponSkillRechargeTimer;
        protected bool _bothWeaponSkillsReady;

        public void Initialize(ICharacterCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations)
        {
            Core = core;
            CombatSettings = combatSettings;
            Abilities = Core.Data.Abilities;
            SkillSpawnLocations = skillSpawnLocations;
        }

        

        protected void HandleAbilityCooldownTimers()
        {
            _elapsedTimeAbilities += Time.deltaTime;
             if (_elapsedTimeAbilities >= CombatSettings?.AbilityCooldownCheckRate)
             {
                if (_usedSkills.Count != 0)
                {
                    for (int i = _usedSkills.Count - 1; i >= 0; i--)
                    {
                        var skill = _usedSkills[i];
                        skill.RemainingRechargeTime -= _elapsedTimeAbilities;
                        if (skill.RemainingRechargeTime <= MyMaths.NearZero)
                        {
                            skill.RemainingRechargeTime = 0f;
                        }
                    }
                }

                 _elapsedTimeAbilities = 0f;
             }

        }

        public float SkillRecharge(Skill skill, out float seconds)
        {

            //FIX FOR WEAPON SKILLS

           /* if (skill.IsMelee == true)
            {

                seconds = skill.RechargeTime - _primaryWeaponSkillRechargeTimer;
                return seconds / skill.RechargeTime;
            }

            if (skill == SecondaryWeaponSkill)
            {
                seconds = skill.RechargeTime - _primaryWeaponSkillRechargeTimer;
                return seconds / skill.RechargeTime;
            }*/


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




        protected void Update()
        {
            HandleAbilityCooldownTimers();
            HandleWeaponSkillsCooldownTimers();
        }


        public bool ActivateSkill(Skill skill, Vector3 direction)
        {
            if (CanActivateSkill(skill) == false)
            {
                return false;
            }

            PutSkillOnRecharge(skill);

            if (skill.FaceDirection)
            {

                Core.AnimationController.FaceDirection(direction);
            }

            Core.AnimationController.PlaySkillAnimation(skill, out float impactPoint);

            StartCoroutine(ActivateSkillCoroutine(skill, Mathf.Min(Mathf.Abs(impactPoint), 20f)));

            return true;
        }

        protected IEnumerator ActivateSkillCoroutine(Skill skill, float delay)
        {
            yield return new WaitForSeconds(delay);
            if (CanActivateSkill(skill, true) == false)
            {
                MakeSkillReady(skill);
                yield break;
            }

            var spawnLocation = SkillSpawnLocations.Find(x => x.LocationType == skill.PlayerSpawnLocation).Location;
            skill.Spawn(Core, spawnLocation);

        }


        /*private async Task WaitForTargetedSkillInput()
        {

        }*/


        protected void PutSkillOnRecharge(Skill skill)
        {
            var rechargeData = _usedSkills.Find(x => x.Skill == skill);
            if (rechargeData == null)
            {
                _usedSkills.Add(new SkillRechargeData(skill, skill.RechargeTime));
                return;
            }

            rechargeData.Skill = skill;
            rechargeData.RemainingRechargeTime = skill.RechargeTime;
        }

        protected void MakeSkillReady(Skill skill)
        {
            if (SkillRecharge(skill, out _) > MyMaths.NearZero)
            {
                return;
            }

            var result = _usedSkills.Find(x => x.Skill == skill);
            if (result != null)
            {
                result.RemainingRechargeTime = 0f;
            }
        }

        protected  bool CanActivateSkill(Skill skill, bool ignoreRecharge = false)
        {
            if (skill == null)
            {
                return false;
            }

            if (skill.IsMovementSkill == true && Core.CombatController.CanMove() == false)
            {
                return false;
            }

            var isSkillReady = SkillRecharge(skill, out _) <= MyMaths.NearZero;
            var isPlayerAble = Core.CombatController.CanAttack();
            return (isSkillReady || ignoreRecharge) && isPlayerAble;
        }

        /*public float SkillRecharge(Skill skill, out float seconds)
        {
            if (Core == null)
            {
                //_player = _playerCore.Data;
                print("_player is null inside PlayerSkillController");
            }
            if (skill == PrimaryWeaponSkill)
            {

                seconds = skill.RechargeTime - _primaryWeaponSkillRechargeTimer;
                return seconds / skill.RechargeTime;
            }

            if (skill == SecondaryWeaponSkill)
            {
                seconds = skill.RechargeTime - _primaryWeaponSkillRechargeTimer;
                return seconds / skill.RechargeTime;
            }

            return base.SkillRecharge(skill, out seconds);
        }*/

        protected void HandleWeaponSkillsCooldownTimers()
        {
            if (_bothWeaponSkillsReady)
            {
                return;
            }

            var primaryWeaponSkillCheck = _primaryWeaponSkillRechargeTimer > 0f;
            var secondaryWeaponSkillCheck = _secondaryWeaponSkillRechargeTimer > 0f;

            if (primaryWeaponSkillCheck == false && secondaryWeaponSkillCheck == false)
            {
                _bothWeaponSkillsReady = true;
                return;
            }

            _elapsedTimeWeaponSkills += Time.deltaTime;

            if (_elapsedTimeWeaponSkills >= CombatSettings.WeaponSkillCooldownCheckRate)
            {

                if (primaryWeaponSkillCheck)
                {
                    _primaryWeaponSkillRechargeTimer -= _elapsedTimeWeaponSkills;
                }

                if (secondaryWeaponSkillCheck)
                {
                    _secondaryWeaponSkillRechargeTimer -= _elapsedTimeWeaponSkills;
                }

                _elapsedTimeWeaponSkills = 0f;
            }

        }
    }
}