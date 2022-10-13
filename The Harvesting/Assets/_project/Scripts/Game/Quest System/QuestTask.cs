using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Harvesting
{
    [System.Serializable]
    public class QuestTask
    {
        public string TaskDesciption;
        public GameItem Item;
        public MonsterTemplate Monster;
        public int TargetCount = 1;
        public QuestLocationScript QuestLocation;
    }

    public enum QuestTaskType
    {
        Kill,
        Collect,
        Interact,
        GoToLocation
    }
}