using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IPlayerSFXController : ICharacterSFXController
    {
        new IPlayerCore Core { get; }
        void PlayItemSound();
        void Initialize(IPlayerCore core);
    }
}