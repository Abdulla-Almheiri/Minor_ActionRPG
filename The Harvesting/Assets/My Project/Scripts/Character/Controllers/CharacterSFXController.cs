using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterSFXController : MonoBehaviour, ICharacterSFXController
    {
        public ICharacterCore Core { get; protected set; }
    }
}