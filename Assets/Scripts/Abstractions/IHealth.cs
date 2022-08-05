using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Interfaces
{
    public interface IHealth
    {
        float HP { get; }
        void GetHit();
    }
}

