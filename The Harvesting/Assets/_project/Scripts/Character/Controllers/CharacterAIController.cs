using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class CharacterAIController : MonoBehaviour, ICharacterAIController
    {
        public ICharacterCore Core { get; protected set; }
        public void Initialize(ICharacterCore core)
        {
            Core = core;
        }
    }
}