using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

namespace Harvesting {
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerSkillController : CharacterSkillController
    {
        private PlayerCore _playerCore;
        private PlayerSkillData _player;
        private CoreAttributesTemplate _coreAttributes;
        [SerializeField] private List<SkillSpawnLocationData> _skillSpawnLocations;

        protected float _elapsedTimeWeaponSkills;
        private float _primaryWeaponSkillRechargeTimer;
        private float _secondaryWeaponSkillRechargeTimer;
        private bool _bothWeaponSkillsReady;

        void Start()
        {
            Initialize(null);
        }

        protected void Update()
        {
            HandleAbilityCooldownTimers();
            HandleWeaponSkillsCooldownTimers();
        }

        protected void Initialize(PlayerCore playerCore)
        {
            _playerCore = playerCore ?? GetComponent<PlayerCore>();
            
            _coreAttributes = _playerCore.GameManager.CoreAttributes;
            _combatSettings = _playerCore.GameManager.CombatSettings;

            _player = _playerCore.PlayerSkillData;

        }


        public override bool ActivateSkill(Skill skill)
        {
            if(CanActivateSkill(skill) == false)
            {
                return false;
            }

            PutSkillOnRecharge(skill);

            if (skill.FaceDirection)
            {
                _playerCore.AnimationController.RotateToMouseDirection();
            }

            _playerCore.AnimationController.PlayPlayerSkillAnimation(skill);

            var playerAnimation = skill.PlayerAnimation;

            if (playerAnimation == null)
            {
                StartCoroutine(ActivateSkillCoroutine(skill, 0f));

            } else if(_playerCore.AnimationController.DefaultSkillAnimation != null)
            {
                StartCoroutine(ActivateSkillCoroutine(skill, _playerCore.AnimationController.DefaultSkillAnimation.AnimationHitFrameInSeconds()));

            } else
            {
                StartCoroutine(ActivateSkillCoroutine(skill, skill.PlayerAnimation.AnimationHitFrameInSeconds()));
            }

            return true;
        }

        private IEnumerator ActivateSkillCoroutine(Skill skill, float delay)
        {
            yield return new WaitForSeconds(delay);
            if(CanActivateSkill(skill, true) == false)
            {
                MakeSkillReady(skill);
                yield break;
            }

            var spawnLocation = _skillSpawnLocations.Find(x => x.LocationType == skill.PlayerSpawnLocation).Location;
            skill.Spawn(_player, spawnLocation);

        }


        /*private async Task WaitForTargetedSkillInput()
        {

        }*/


        private void PutSkillOnRecharge(Skill skill)
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

        private void MakeSkillReady(Skill skill)
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

        protected override bool CanActivateSkill(Skill skill, bool ignoreRecharge = false)
        {
            if(skill == null)
            {
                return false;
            }
            
            if(skill.IsMovementSkill == true && _playerCore.CombatController.CanMove() == false)
            {
                return false;
            }

            var isSkillReady =  SkillRecharge(skill, out _) <= MyMaths.NearZero;
            var isPlayerAble = _playerCore.CombatController.CanAttack();
            return (isSkillReady || ignoreRecharge) && isPlayerAble;
        }

        public override float SkillRecharge(Skill skill, out float seconds)
        {
            if(_player == null)
            {
                //_player = _playerCore.Data;
                print("_player is null inside PlayerSkillController");
            }
            if (skill == _player.PrimaryWeaponSkill)
            {
                seconds = skill.RechargeTime - _primaryWeaponSkillRechargeTimer;
                return  seconds / skill.RechargeTime;
            }

            if (skill == _player.SecondaryWeaponSkill)
            {
                seconds = skill.RechargeTime - _primaryWeaponSkillRechargeTimer;
                return seconds / skill.RechargeTime;
            }

            return base.SkillRecharge(skill, out seconds);
        }

        protected void HandleWeaponSkillsCooldownTimers()
        {
            if(_bothWeaponSkillsReady)
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

            if (_elapsedTimeWeaponSkills >= _combatSettings.WeaponSkillCooldownCheckRate)
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