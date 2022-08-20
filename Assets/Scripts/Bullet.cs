using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public enum BulletCreator { player, enemy }
    public class Bullet : MonoBehaviour
    {
        public BulletCreator bulletCreator;
        public float DamageValue;
        public Action OnHit { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!collision.gameObject.CompareTag("Player") && bulletCreator != BulletCreator.enemy)
            {
                OnHit.Invoke();
            }
            else if(!collision.gameObject.CompareTag("Enemy") && bulletCreator != BulletCreator.player)
            {
                OnHit.Invoke();
            }
            

        }
    }
}

