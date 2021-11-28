using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IInteractor
    {
        bool Interact(IInteractable interactable);
    }
}