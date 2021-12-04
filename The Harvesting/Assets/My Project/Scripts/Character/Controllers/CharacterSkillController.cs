using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        protected CoreAttributesTemplate _coreAttributes;
        public List<SkillSpawnLocationData> SkillSpawnLocations { get; protected set; }
        protected float _elapsedTimeWeaponSkills;
        protected float _primaryWeaponSkillRechargeTimer;
        protected float _secondaryWeaponSkillRechargeTimer;
        protected bool _bothWeaponSkillsReady;

        public void Initialize(ICharacterCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations)
        {
            Core = core;
            CombatSettings = combatSettings;
            Abilities = Core.CharacterData.Abilities;
            SkillSpawnLocations = skillSpawnLocations;
        }

        

        protected void HandleAbilityCooldownTimers()
        {
            _elapsedTimeAbilities += Time.deltaTime;
            if (_elapsedTimeAbilities >= CombatSettings.AbilityCooldownCheckRate)
             {
                //Debug.Log("IN LOOP -elapsedTime and count is :  " + _skillRechargeTimes.Count);
                foreach (Skill skill in _skillRechargeTimes.Keys.ToList())
                {
                    
                    if (_skillRechargeTimes[skill] <= MyMaths.NearZero)
                    {
                        _skillRechargeTimes[skill] = 0f;

                    }
                    else
                    {
                        _skillRechargeTimes[skill] -= _elapsedTimeAbilities;
                        
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

            if (_skillRechargeTimes.TryGetValue(skill, out float time) == false)
            {
                seconds = 0f;
                return 0f;
            }

            seconds = time;
            return time / skill.RechargeTime;
        }




        protected void Update()
        {
            HandleAbilityCooldownTimers();
            HandleWeaponSkillsCooldownTimers();
        }


        public bool ActivateSkill(Skill skill)
        {
            if (CanActivateSkill(skill, false) == false)
            {
               // Debug.Log("CANNOT ACTIVATE  :   " + SkillRecharge(skill, out _));
                return false;
            }

            PutSkillOnRecharge(skill);

            if (skill.FaceDirection == true)
            {
                //FIX HERE FOR MONSTER TARGET PLAYER
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;
                if (Physics.Raycast(ray, out rayHit))
                {
                    Core.AnimationController.FaceDirection(rayHit.point);
                    //Debug.Log("POINT IS   :   " + rayHit.point);
                }
                
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
            if (_skillRechargeTimes.TryGetValue(skill, out _) == false)
            {
                _skillRechargeTimes.Add(skill, skill.RechargeTime);
                //Debug.Log("KEYS ADDED and count is :   " +  _skillRechargeTimes.Count);
            }
            else
            {
                _skillRechargeTimes[skill] = skill.RechargeTime;
            }
            
        }

        protected void MakeSkillReady(Skill skill)
        {
            _skillRechargeTimes[skill] = 0f;
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

            //Debug.Log("Skill is Ready  :   " + isSkillReady + " and skill recharge is:   " + SkillRecharge(skill, out _));
            //Debug.Log("Player can attack  :   " + isPlayerAble);

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