using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using System;

namespace Asteroids.Player
{
    public class PlayerHealth : IHealth
    {
        public Health HP { get; private set; }
        public PlayerHealth(float startHP, GameObject unit, Action OnDeath = null)
        {
            HP = new Health(startHP);
            if(OnDeath == null)
            {
                HP.OnLessThanZero += () => UnityEngine.Object.Destroy(unit);
            }
        }


        public void GetHit()
        {
            HP.GetDamage(1);
        }
        public void GetHit(float value)
        {
            HP.GetDamage(value);
        }

    }
}

