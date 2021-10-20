using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Harvesting {
    public class FloatingCombatTextManager : MonoBehaviour
    {
        public GameObjectPool Pool;
        public Canvas Canvas;
        private float averageDamage = 0;
        private float fontSize = 0;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlaceDamageText(Vector3 pos, float amount, float spreadAmount)
        {
            Pool.Init();
            if(averageDamage ==0)
            {
                averageDamage = amount;
            } else
            {
                averageDamage = (amount + averageDamage) / 2;
            }

            if(Pool == null)
            {
                return;
            }


            float scaleMultiplier = amount / averageDamage;
            if (scaleMultiplier > 2f) scaleMultiplier = 2f;
            if (scaleMultiplier < 1f) scaleMultiplier = 1f;

            pos.Set(pos.x + Random.Range(-spreadAmount/2f, spreadAmount/2f), pos.y+(spreadAmount/2f), pos.z);
            var spawn = Pool.SpawnObject();

            if (fontSize == 0)
            {
                fontSize = spawn.gameObject.GetComponent<TMP_Text>().fontSize;
            }
            var component = spawn.GetComponent<PoolableAnimationFinish>();
            component.WorldPosition = pos;
            component.MaintainPosition();
            spawn.gameObject.transform.SetParent(Canvas.transform);
            spawn.gameObject.GetComponent<TMP_Text>().text = ((int)amount).ToString();
            spawn.gameObject.GetComponent<TMP_Text>().fontSize = fontSize * scaleMultiplier;

        }
    }
}