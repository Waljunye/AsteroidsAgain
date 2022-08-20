using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Extentions;
namespace Asteroids
{
    public enum EnemyType { BigAsteroid, Asteroid, EnemyShip }
    public abstract class EnemyFactory : MonoBehaviour
    {
        private Enemy enemyPrototype = default;
        public Enemy CreateEnemy(Health hp, Transform spawnPosition, EnemyType enemyType = EnemyType.Asteroid, Action OnDestroy = null, float speed = 0)
        {
            Enemy enemy;
            if (enemyPrototype == default)
            {
                 enemy = GetEnemy(enemyType);
            }
            else
            {
                enemy = enemyPrototype.DeepCopy<Enemy>();
            }
            enemy.transform.position = spawnPosition.position;
            
            enemy.Health = hp;
            if (OnDestroy == null)
            {
                enemy.Health.OnLessThanZero += () => Destroy(enemy.gameObject);
            }
            else
            {
                enemy.Health.OnLessThanZero += OnDestroy;
            }
            if(enemy is EnemyShip enemyShip)
            {
                enemyShip.WalkSpeed = speed;
            }

            return enemy;
        }

        protected abstract Enemy GetEnemy(EnemyType enemyType);
    }
}

