using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterUIController : MonoBehaviour, ICharacterUIController
    {
        public ICharacterCore Core { get; protected set; }

        public void Initialize(ICharacterCore core)
        {
            Core = core;
        }
    }
}