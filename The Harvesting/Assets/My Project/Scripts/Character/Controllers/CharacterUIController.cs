using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterUIController : MonoBehaviour, ICharacterUIController
    {
        public ICharacterCore Core { get; }
    }
}