using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IGameItemTemplate <T> where T : IGameItem
    {
        Sprite Icon { get; }
        string Name { get; }
        int Price { get; }
        ItemQuality Quality { get; }
        T Generate(int level, int requiredLevel);
    }
}