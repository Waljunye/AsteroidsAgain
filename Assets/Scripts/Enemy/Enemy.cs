using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using System;

namespace Asteroids
{
    
    public abstract class Enemy : MonoBehaviour
    {
        public Health Health;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                //TODO: OBJECT POOL FOR ENEMIES
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Bullet collidedBullet;
            if(collision.gameObject.TryGetComponent<Bullet>(out collidedBullet))
            {
                if(collidedBullet.bulletCreator.Equals(BulletCreator.player))
                {
                    Debug.Log(this.Health.Current);
                    Health.GetDamage(collidedBullet.DamageValue);
                }
                
            }
        }
    }
}

