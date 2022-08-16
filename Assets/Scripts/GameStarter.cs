using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] List<GameObject> positions;
        private void Start()
        {
            var enemy = Enemy.CreateEnemy(new Health(100f), gameObject.transform, EnemyType.BigAsteroid);
            var enemy1 = Enemy.CreateEnemy(new Health(10f), gameObject.transform, EnemyType.Asteroid);
            if(enemy is EnemyShip enemyShip)
            {
                enemyShip.Patrool(positions);
            }
        }
    }
}

