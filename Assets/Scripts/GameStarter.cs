using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class GameStarter : MonoBehaviour
    {
        [SerializeField] List<Transform> positions;
        private void Start()
        {
            var enemy = Enemy.CreateEnemy(new Health(100f), gameObject.transform, EnemyType.EnemyShip);
            if(enemy is EnemyShip enemyShip)
            {
                enemyShip.Patrool(positions, 10f);
            }
        }
    }
}

