using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IExperiencePointsReceiver
    {
        int Level { get; }
        bool GainExperiencePoints(int experiencePoints);
        float ExperiencePointsToNextLevel();
        float ExperiencePercentage();
    }
}