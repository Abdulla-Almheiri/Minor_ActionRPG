using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterInputController : MonoBehaviour, ICharacterInputController
    {
        public ICharacterCore Core { get; protected set; }

        public InputKeyData InputKeyData { get; protected set; }

        public void Initialize(ICharacterCore core, InputKeyData inputKeyData)
        {
            Core = core;
            InputKeyData = inputKeyData;
        }
        public bool MouseClick(out RaycastHit point, LayerMask layerMask)
        {
            point = default;
            if (Input.GetMouseButtonDown(0) == true)
            {
                point = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;
                //point.y = 0f;

                if (Physics.Raycast(ray, out rayHit, 100f, layerMask))
                {
                    point = rayHit;
                    Debug.Log("Raycast out  :" + point.collider.gameObject.name);
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }

    }
}