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
        public bool MouseClick(out RaycastHit point)
        {
            
            if (/*!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()*/ true)
            {
                point = new RaycastHit();
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;
                //point.y = 0f;

                if (Physics.Raycast(ray, out rayHit, 0))
                {
                    point = rayHit;
                    return true;
                } else
                {
                    return false;
                }
            }
        }

    }
}