using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using System;

namespace Asteroids
{
    public abstract class Enemy : MonoBehaviour
    {
        private Health Health;
        private Rigidbody2D _rb2D;
        public static Enemy CreateAsteroidEnemy(Health hp, Action OnDestroy = null, int creationForce = 100)
        {
            var enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Enemy_Asteroid"));
            System.Random rnd = new System.Random();
            Rigidbody2D rb2D = enemy.GetComponent<Rigidbody2D>();
            rb2D.AddForce(new Vector2(rnd.Next(-creationForce, creationForce), rnd.Next(-creationForce, creationForce)));
            enemy.Health = hp;
            if (OnDestroy == null)
            {
                enemy.Health.OnLessThanZero += () => Destroy(enemy.gameObject);
            }

            return enemy;
        }
        public static Enemy CreateBigAsteroidEnemy(Health hp, Action OnDestroy = null)
        {
            var enemy = Instantiate(Resources.Load<BigAsteroid>("Enemy/Enemy_Asteroid_Big"));

            enemy.Health = hp;
            if (OnDestroy == null)
            {
                enemy.Health.OnLessThanZero += () => Destroy(enemy.gameObject);
            }

            return enemy;
        }
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

