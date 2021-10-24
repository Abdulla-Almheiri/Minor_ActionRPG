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

        public void Start()
        {
            Pool.Init();
        }
        public void PlaceDamageText(Vector3 pos, float amount, float spreadAmount, bool isCritical)
        {
            if (Pool == null)
            {
                return;
            }

            

            if(averageDamage ==0)
            {
                averageDamage = amount;
            } else
            {
                averageDamage = (amount + averageDamage) / 2;
            }




            float scaleMultiplier = amount / averageDamage;
            if (scaleMultiplier > 2f) scaleMultiplier = 2f;
            if (scaleMultiplier < 1f) scaleMultiplier = 1f;
            if (isCritical)
            {
                scaleMultiplier += 2f;
            }

            pos.Set(pos.x + Random.Range(-spreadAmount/2f, spreadAmount/2f), pos.y, pos.z);
            var spawn = Pool.SpawnObject();
            spawn.gameObject.GetComponent<FloatingTextVariationScript>().PlayAnimation(isCritical);
            if (fontSize == 0)
            {
                fontSize = spawn.gameObject.GetComponent<TMP_Text>().fontSize;
            }
            var component = spawn.GetComponent<PoolableAnimationFinish>();
            component.WorldPosition = pos;
            component.MaintainPosition();
            
            spawn.gameObject.transform.SetParent(Canvas.transform);
            spawn.gameObject.GetComponent<TMP_Text>().SetText(((int)amount).ToString());
            spawn.gameObject.GetComponent<TMP_Text>().fontSize = fontSize * scaleMultiplier;
            

        }
    }
}