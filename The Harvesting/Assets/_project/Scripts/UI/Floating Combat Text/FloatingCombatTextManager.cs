using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Harvesting {
    public class FloatingCombatTextManager
    {
        private GameObjectPool _pool;
        private Canvas _canvas;
        private Camera _camera;
        private float averageDamage = 0;
        private float fontSize = 0;
        private Color originalColor;
        public FloatingCombatTextManager(GameObjectPool pool, Canvas canvas, Camera camera)
        {
            _pool = pool;
            _canvas = canvas;
            _camera = camera;

            _pool?.Init();
            if(_pool == null)
            {
                Debug.Log("Pooling system null in FloatingCombatTextManager.");
            }
        }

        public void PlaceDamageText(Vector3 pos, float amount, float spreadAmount, bool isCritical, bool isHeal, bool isHarm)
        {
            
            if (_pool == null)
            {
                return;
            }

            

            if(averageDamage == 0)
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
            var spawn = _pool.SpawnObject();
            spawn.gameObject.GetComponent<FloatingTextVariationScript>().PlayAnimation(isCritical);
            if (fontSize == 0)
            {
                fontSize = spawn.gameObject.GetComponent<TMP_Text>().fontSize;
            }
            var component = spawn.GetComponent<PoolableAnimationFinish>();
            component.WorldPosition = pos;
            component.MaintainPosition();
            
            spawn.gameObject.transform.SetParent(_canvas.transform);
            spawn.gameObject.GetComponent<TMP_Text>().SetText(((int)amount).ToString());
            spawn.gameObject.GetComponent<TMP_Text>().fontSize = fontSize * scaleMultiplier;

            if (originalColor == default)
            {
                originalColor = spawn.gameObject.GetComponent<TMP_Text>().faceColor;
            }

            if (!isHeal && !isHarm)
            {
                spawn.gameObject.GetComponent<TMP_Text>().faceColor = originalColor;
                
            } else if(isHeal)
            {
                spawn.gameObject.GetComponent<TMP_Text>().faceColor = Color.green;
            } else if(isHarm)
            {
                spawn.gameObject.GetComponent<TMP_Text>().faceColor = Color.red;
            }

        }
    }
}