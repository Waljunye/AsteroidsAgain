using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Interfaces
{
    public interface IHealth
    {
        Health HP { get; }
        void GetHit();
        void GetHit(float value);
    }
}

