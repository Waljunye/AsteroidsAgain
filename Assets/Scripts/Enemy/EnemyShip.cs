using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Asteroids
{
    public class EnemyShip : Enemy
    {
        private List<Transform> _wayPoints;
        private int _currentWPId;
        private float _speed;
        public void Patrool(List<Transform> patroolPoints, float patroolSpeed)
        {
            _wayPoints = patroolPoints;
            _currentWPId = 0;
            _speed = patroolSpeed;
        }
        private void Update()
        {
            Transform currentWp = _wayPoints[_currentWPId];
            if(Vector2.Distance(transform.position, currentWp.position) < 0.01f)
            {
                _currentWPId = (_currentWPId + 1) % _wayPoints.Count;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentWp.position, _speed * Time.deltaTime);
            }
        }

    }
}


