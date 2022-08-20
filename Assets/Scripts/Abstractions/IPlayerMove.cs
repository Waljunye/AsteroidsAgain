using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Interfaces
{
    public interface IPlayerMove
    {
        float Speed { get; }
        public void Move(float inputHorizontal, float inputVertical, float deltaTime);
    }
}

