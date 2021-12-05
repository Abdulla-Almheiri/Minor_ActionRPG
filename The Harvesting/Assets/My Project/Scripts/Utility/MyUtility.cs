using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public static class MyUtility
    {
        public static bool CompareLayers(int layer, LayerMask layerMask)
        {
            return (1 << layer) == layerMask;
        }
    }
}