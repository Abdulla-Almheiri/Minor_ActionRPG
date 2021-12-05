using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterUIController : CharacterUIController, IMonsterUIController
    {
        public new IMonsterCore Core { get; protected set; }
        [SerializeField] private GameObject _healthBarPrefab;
        private EnemyHealthBar _healthBarScript;
        public void Initialize(IMonsterCore core)
        {
            Core = core;
            base.Initialize(core);
            _healthBarScript = Instantiate(_healthBarPrefab, Core.GameManager.DynamicCanvas.transform).GetComponent<EnemyHealthBar>();
        }

        public void DisplayHealthBar()
        {
            _healthBarScript.AssignPosition(transform.position);
            _healthBarScript.UpdateHealth(Core.CombatController.HealthPercentage());
        }

        private void Update()
        {
            DisplayHealthBar();
        }
    }
}