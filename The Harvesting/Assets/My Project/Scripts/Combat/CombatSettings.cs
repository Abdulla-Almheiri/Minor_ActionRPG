using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new combat settings", menuName ="Data/Combat/Combat Settings")]
    public class CombatSettings : ScriptableObject
    {
        [SerializeField] private CoreAttributesTemplate _coreAttributes;
        [SerializeField] private float _characterStateCheckRate = 0.1f;
        [SerializeField] private float _globalWeaponSkillCooldown = 0.2f;
        [SerializeField] private float _weaponSkillCooldownCheckRate = 0.1f;

        [SerializeField] private float _globalAbilitycooldown = 0.2f;
        [SerializeField] private float _abilityCooldownCheckRate = 0.1f;

        [SerializeField] private GameObject _targetedSkillEffectPrefab;
        public CoreAttributesTemplate CoreAttributes { get => _coreAttributes; }
        public float CharacterStateCheckRate { get => _characterStateCheckRate; }
        public float GlobalWeaponSkillCooldown { get => _globalWeaponSkillCooldown; }
        public float GlobalAbilitycooldown { get => _globalAbilitycooldown; }
        public float AbilityCooldownCheckRate { get => _abilityCooldownCheckRate; }
        public float WeaponSkillCooldownCheckRate { get => _weaponSkillCooldownCheckRate; }
    }
}