using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidFactory : EnemyFactory
    {
        protected override Enemy GetEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case (EnemyType.BigAsteroid):
                    return Instantiate(Resources.Load<BigAsteroid>("Enemy/Enemy_Asteroid_Big"));
                default:
                    return Instantiate(Resources.Load<Asteroid>("Enemy/Enemy_Asteroid"));

            }
        }
    }
}

