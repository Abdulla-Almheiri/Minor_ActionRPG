using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public struct SkillActionEventData
    {
        public float FinalValue;
        public bool Displayed;
        public bool IsCritical;
        public bool IsCastOnSelf;
        public SkillActionElement Element;

        public SkillActionEventData(bool displayed, float finalValue, bool isCritical, bool isCastOnSelf, SkillActionElement element)
        {
            Displayed = displayed;
            IsCastOnSelf = isCastOnSelf;
            FinalValue = finalValue;
            IsCritical = isCritical;
            Element = element;
        }

    }
}

