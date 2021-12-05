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
        public Skill PrimaryWeaponSkill { get; protected set; }

        public Skill SecondaryWeaponSkill { get; protected set; }

        protected CoreAttributesTemplate _coreAttributes;
        public List<SkillSpawnLocationData> SkillSpawnLocations { get; protected set; }
        protected float _elapsedTimeWeaponSkills;
        protected float _primaryWeaponSkillRechargeTimer;
        protected float _secondaryWeaponSkillRechargeTimer;
        protected bool _bothWeaponSkillsReady;
        protected ICharacterCore _attackCommandTarget = null;
        protected Skill _attackCommandSkill = null;

        public void Initialize(ICharacterCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations)
        {
            Core = core;
            CombatSettings = combatSettings;
            Abilities = Core.CharacterData.Abilities;
            SkillSpawnLocations = skillSpawnLocations;
            PrimaryWeaponSkill = Core.Template.PrimaryWeaponSkill;
            SecondaryWeaponSkill = Core.Template.SecondaryWeaponSkill;
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
            HandleAttackCommands();
        }

        protected void IssueAttackCommand(Skill skill, ICharacterCore target)
        {
            //Debug.Log("Attack command issued");
            _attackCommandTarget = target;
            _attackCommandSkill = skill;
        }

        protected void HandleAttackCommands()
        {
            if(_attackCommandSkill != null && _attackCommandTarget != null && _attackCommandTarget.CombatController.IsAlive == true)
            {
                if(Core.CombatController.IsWithinMeleeRange(_attackCommandTarget))
                {
                    //Debug.Log("Within melee range");
                    ActivateSkill(_attackCommandSkill, _attackCommandTarget);
                }
            }
        }

        public bool ActivateSkill(Skill skill, ICharacterCore target = default)
        {
            if (CanActivateSkill(skill, false) == false)
            {
              // Debug.Log("CANNOT ACTIVATE  :   " + SkillRecharge(skill, out _));
                return false;
            }

            if(skill.IsMelee)
            {
                int layerMask = -1; ;
                if (target != null)
                {
                    layerMask = 1 << target.GameObject.layer;
                }

                if (MyUtility.CompareLayers(Core.GameObject.layer, Core.GameManager.PlayerLayer) == true)
                {
                    if (MyUtility.CompareLayers(target.GameObject.layer, Core.GameManager.CombatSettings.EnemyLayer) != true)
                    {
                        return false;
                    }
                }

                if (MyUtility.CompareLayers(Core.GameObject.layer, Core.GameManager.CombatSettings.EnemyLayer) == true)
                {
                    if (MyUtility.CompareLayers(target.GameObject.layer, Core.GameManager.PlayerLayer) != true)
                    {
                        return false;
                    }
                }

                if (Core.CombatController.IsWithinMeleeRange(target) != true)
                {
                    Core.MovementController.MoveToCharacter(target);
                    IssueAttackCommand(skill, target);
                    return false;
                }

                CancelCurrentattackCommand();

            }
            

            PutSkillOnRecharge(skill);

            if (skill.FaceDirection == true)
            {
                if (MyUtility.CompareLayers(Core.GameObject.layer, Core.GameManager.PlayerLayer) == true)
                {//FIX HERE FOR MONSTER TARGET PLAYER
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit))
                    {
                        Core.AnimationController.FaceDirection(rayHit.point);
                        //Debug.Log("POINT IS   :   " + rayHit.point);
                    }
                } else if(target != null)
                {
                    Core.AnimationController.FaceDirection(target.MovementController.Transform.position);
                }
                
            }

            Core.AnimationController.PlaySkillAnimation(skill, out float impactPoint);

            StartCoroutine(ActivateSkillCoroutine(skill, Mathf.Min(Mathf.Abs(impactPoint), 20f), target));

            return true;
        }

        protected void CancelCurrentattackCommand()
        {
            _attackCommandTarget = null;
            _attackCommandSkill = null;
        }

        protected IEnumerator ActivateSkillCoroutine(Skill skill, float delay, ICharacterCore target = default)
        {
            yield return new WaitForSeconds(delay);
            if (CanActivateSkill(skill, true) == false)
            {
                MakeSkillReady(skill);
                yield break;
            }
            if (skill.FaceDirection == true)
            {
                if (MyUtility.CompareLayers(Core.GameObject.layer, Core.GameManager.PlayerLayer) == true)
                {//FIX HERE FOR MONSTER TARGET PLAYER
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit rayHit;
                    if (Physics.Raycast(ray, out rayHit))
                    {
                        Core.AnimationController.FaceDirection(rayHit.point);
                        //Debug.Log("POINT IS   :   " + rayHit.point);
                    }
                }
                else if (target != null)
                {
                    Core.AnimationController.FaceDirection(target.MovementController.Transform.position);
                }

            }

            Core.CombatController.IncurManaCost(skill);

            if (MyUtility.CompareLayers(Core.GameObject.layer, Core.GameManager.PlayerLayer) == true)
            {
                var spawnLocation = SkillSpawnLocations.Find(x => x.LocationType == skill.PlayerSpawnLocation).Location;
                skill.Spawn(Core, spawnLocation);
            } else
            {
                skill.Spawn(Core, Core.MovementController.Transform);
            }

        }

        
        protected void PutSkillOnRecharge(Skill skill)
        {
            if (_skillRechargeTimes.TryGetValue(skill, out _) == false)
            {
                _skillRechargeTimes.Add(skill, skill.RechargeTime);
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

            if(Core.CombatController.HasManaForSkill(skill) == false)
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

    }
}