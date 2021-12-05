using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class MonsterDetectorScript : MonoBehaviour
    {
        private List<IMonsterCore> monstersInRange = new List<IMonsterCore>();
        private IPlayerCore _player;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if(_player == null)
            {
                return;
            }
            // OPTIMIZE HERE!!!!
            foreach(IMonsterCore monster in monstersInRange)
            {
                if(monster.CombatController.IsAlive != true)
                {
                    Debug.Log("Monster REmOVED because is dead!!!" + monster);
                    monstersInRange.Remove(monster);
                }
            }
        }

        public void Initialize(IPlayerCore player)
        {
            _player = player;
        }
        private void OnTriggerEnter(Collider other)
        {
            if(_player == null)
            {
                return;
            }

            int layerMask = 1 << other.gameObject.layer;

            if ( layerMask == _player.GameManager.CombatSettings.EnemyLayer)
            {
                var monster = other.GetComponent<IMonsterCore>();
                if (monster != null && monster.CombatController.IsAlive == true)
                {
                    monstersInRange.Add(monster);
                }
               
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(_player == null)
            {
                return;
            }

            if (other.gameObject.layer == _player.GameManager.CombatSettings.EnemyLayer)
            {
                var monster = other.GetComponent<IMonsterCore>();
                if (monster != null)
                {
                    monstersInRange.Remove(monster);
                }

            }
        }
    }
}