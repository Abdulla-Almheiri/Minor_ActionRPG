using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;

namespace Harvesting {
    [RequireComponent(typeof(PlayerCore))]
    public class PlayerSkillController : CharacterSkillController, IPlayerSkillController
    {
        public new IPlayerCore Core { get; protected set; }
        public Skill PrimaryWeaponSkill { get; protected set; }

        public Skill SecondaryWeaponSkill { get; protected set; }

       // private CoreAttributesTemplate _coreAttributes;

        public new List<SkillSpawnLocationData> SkillSpawnLocations { get; protected set; }

        /* private float _primaryWeaponSkillRechargeTimer;
         private float _secondaryWeaponSkillRechargeTimer;
         private bool _bothWeaponSkillsReady;*/

        public void Initialize(IPlayerCore core, CombatSettings combatSettings, List<SkillSpawnLocationData> skillSpawnLocations)
        {
            SkillSpawnLocations = skillSpawnLocations;
            Core = core;
            base.Initialize(core, combatSettings, skillSpawnLocations);
            Abilities = Core.CharacterData.Abilities;
        }

       /* private void Update()
        {
            HandleWeaponSkills();
            base.Update();
        }*/


        protected void HandleWeaponSkills()
        {
            if(Core.InputController.MouseClick(out RaycastHit other) == true)
            {
                if (other.collider.gameObject.layer == Core.GameManager.CombatSettings.EnemyLayer)
                {

                }
            }
        }
    }
}