using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    [CreateAssetMenu(fileName ="new input key data", menuName ="Data/Input/Input Key Data")]
    public class InputKeyData : ScriptableObject
    {
        public KeyCode CharacterScreen = KeyCode.I;
        public KeyCode Skill1 = KeyCode.Alpha1;
        public KeyCode Skill2 = KeyCode.Alpha2;
        public KeyCode Skill3 = KeyCode.Alpha3;
        public KeyCode Skill4 = KeyCode.Alpha4;
        public KeyCode Skill5 = KeyCode.Alpha5;
        public KeyCode Skill6 = KeyCode.Alpha6;
        public KeyCode Skill7 = KeyCode.Alpha7;
    }
}