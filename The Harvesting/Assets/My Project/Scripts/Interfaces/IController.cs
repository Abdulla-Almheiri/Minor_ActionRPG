using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IController : IInitializable
    {
        Core Core { get; }
        void Initialize(Core core);

    }
}