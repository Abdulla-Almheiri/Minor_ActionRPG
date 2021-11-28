using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IInteractable
    {
        bool Interact(IInteractor interactor);
    }
}