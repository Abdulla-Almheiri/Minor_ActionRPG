using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

namespace Harvesting {
    [RequireComponent(typeof(PlayerCore))]
    [RequireComponent(typeof(PlayerAnimationController))]
    [RequireComponent(typeof(PlayerCombatController))]
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerInputController))]

    public class PlayerSkillController : CharacterSkillController
    {
        private PlayerCore _playerCore;
        private Player _player;
        private CoreAttributes _coreAttributes;
        [SerializeField] private List<SkillSpawnLocationData> _skillSpawnLocations;

        private PlayerInputController _playerInputController;
        private PlayerCombatController _playerCombatController;
        private PlayerAnimationController _playerAnimationController;
        private PlayerMovementController _playerMovementController;

        protected float _elapsedTimeWeaponSkills;
        private float _primaryWeaponSkillRechargeTimer;
        private float _secondaryWeaponSkillRechargeTimer;
        private bool _bothWeaponSkillsReady;

        public PlayerData Player;
        public LayerMask Layer;

        void Start()
        {
            Initialize();
        }

        protected void Update()
        {
            HandleAbilityCooldownTimers();
            HandleWeaponSkillsCooldownTimers();
        }

        protected void Initialize()
        {

            _playerCore = GetComponent<PlayerCore>();
            
            _coreAttributes = _playerCore.GameManager.CoreAttributes;
            _combatSettings = _playerCore.GameManager.CombatSettings;

            _playerCombatController = GetComponent<PlayerCombatController>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
            _playerMovementController = GetComponent<PlayerMovementController>();
            _playerInputController = GetComponent<PlayerInputController>();

            _player = _playerCore.Player;

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
                _playerAnimationController.RotateToMouseDirection();
            }

            _playerAnimationController.PlaySkillAnimation(skill);
            StartCoroutine(ActivateSkillCoroutine(skill, skill.PlayerAnimation.AnimationHitFrameInSeconds()));

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
            
            if(skill.IsMovementSkill == true && _playerCombatController.CanMove() == false)
            {
                return false;
            }

            var isSkillReady =  SkillRecharge(skill, out _) <= MyMaths.NearZero;
            var isPlayerAble = _playerCombatController.CanAttack();
            return (isSkillReady || ignoreRecharge) && isPlayerAble;
        }

        public override float SkillRecharge(Skill skill, out float seconds)
        {

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