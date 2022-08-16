using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using System;

namespace Asteroids
{
    public enum EnemyType { BigAsteroid, Asteroid, EnemyShip }
    public abstract class Enemy : MonoBehaviour
    {
        private Health Health;
        
        public static Enemy CreateEnemy(Health hp, Transform spawnPosition, EnemyType enemyType = EnemyType.Asteroid, Action OnDestroy = null, int creationForce = 100)
        {
            Enemy enemy;
            switch (enemyType)
            {
                case (EnemyType.Asteroid):
                    enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Enemy_Asteroid"), spawnPosition.position, Quaternion.identity);
                    break;
                case (EnemyType.BigAsteroid):
                    enemy = Instantiate(Resources.Load<BigAsteroid>("Enemy/Enemy_Asteroid_Big"), spawnPosition.position, Quaternion.identity);
                    break;
                case (EnemyType.EnemyShip):
                    enemy = Instantiate(Resources.Load<EnemyShip>("Enemy/Enemy_ship"), spawnPosition.position, Quaternion.identity);
                    break;
                default:
                    enemy = Instantiate(Resources.Load<Asteroid>("Enemy/Enemy_Asteroid"), spawnPosition.position, Quaternion.identity);
                    break;
            }
            enemy.Health = hp;
            if (OnDestroy == null)
            {
                enemy.Health.OnLessThanZero += () => Destroy(enemy.gameObject);
            }
            else
            {
                enemy.Health.OnLessThanZero += OnDestroy;
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

