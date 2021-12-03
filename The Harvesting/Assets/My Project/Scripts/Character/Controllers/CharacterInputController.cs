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
        public bool MouseClick(out Vector3 point)
        {
            
            if (/*!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()*/ true)
            {
                point = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                RaycastHit rayHit;
                point.y = 0f;

                if (Physics.Raycast(ray, out rayHit, Core.GameManager.Layer))
                {
                    return true;
                } else
                {
                    return false;
                }
            }
        }

    }
}