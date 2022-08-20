using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemyShipFactory : EnemyFactory
    {
        protected override Enemy GetEnemy(EnemyType enemyType)
        {
            switch (enemyType)
            {
                case (EnemyType.EnemyShip):
                    return Instantiate(Resources.Load<EnemyShip>("Enemy/Enemy_ship"));
                default:
                    return Instantiate(Resources.Load<EnemyShip>("Enemy/Enemy_ship"));
            }
        }
    }
}

