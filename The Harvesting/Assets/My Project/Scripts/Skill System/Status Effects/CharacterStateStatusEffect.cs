using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new character status effect", menuName ="Data/Skills/Character Status Effect")]
    public class CharacterStateStatusEffect : StatusEffect
    {
        public CharacterState CharacterState;

    }
}