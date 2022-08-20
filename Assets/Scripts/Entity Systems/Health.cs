using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Health
    {
        public float Max;
        public float Current { get; private set; }
        public event Action OnLessThanZero;

        public Health(float max, Action onZeroHp = null)
        {
            Max = max;
            Current = max;
            OnLessThanZero += onZeroHp;
        }
        public void GetDamage(float damageValue)
        {
            Current -= damageValue;
            if (Current <= 0)
            {
                OnLessThanZero.Invoke();
            }
        }
    }
}

