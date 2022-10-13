using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new input key data", menuName ="Data/Input/Input Key Data")]
    public class InputKeyData : ScriptableObject
    {
        public KeyCode CharacterScreen = KeyCode.I;
        public KeyCode[] AbilityInputKeyList = new KeyCode[6];

    }
}