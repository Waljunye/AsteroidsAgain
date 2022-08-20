using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Asteroids.EnemyFactory;
using ServiceLocator = Asteroids.ServiceLocator;
using Asteroids.Object_Pool;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField]private List<Transform> positions;
        [SerializeField]private List<Transform> SpawnPositions;
        private EnemyFactory _asteroidFactory;
        private void Awake()
        {
            ServiceLocator.ServiceLocator.SetService<Object_Pool.BulletPool>(new BulletPool(10));
        }
        private void Start()
        {
            _asteroidFactory = gameObject.AddComponent<EnemyShipFactory>();


            #region TEST
            Enemy enemy = default;
            foreach (Transform spawnPosition in SpawnPositions)
            {
                enemy = _asteroidFactory.CreateEnemy(new Health(10f), spawnPosition, EnemyType.Asteroid, speed: 5f);
            }
            
            if (enemy is EnemyShip enemyShip)
            {
                enemyShip.Patrool(positions);
            }
            #endregion
        }
    }
}

