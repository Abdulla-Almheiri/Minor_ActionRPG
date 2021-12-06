using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting {
    public interface IGameItem
    {
        IGameItemTemplate<GameItem> Template { get; }
        ItemType Type { get; }

    }
}