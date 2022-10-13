using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public abstract class GameItem : IGameItem
    {
        public IGameItemTemplate<GameItem> Template { get; protected set; }

        public ItemType Type { get; protected set; }
    }
}