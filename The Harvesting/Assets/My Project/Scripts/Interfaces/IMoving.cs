using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Harvesting
{
    public interface IMoving
    {
        float MovementSpeed { get; }
        public void Move(Vector3 targetPosition);
    }
}