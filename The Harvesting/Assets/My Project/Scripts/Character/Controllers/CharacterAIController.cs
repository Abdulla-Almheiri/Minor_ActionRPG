using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public class CharacterAIController : MonoBehaviour, ICharacterAIController
    {
        public ICharacterCore Core { get; protected set; }
    }
}