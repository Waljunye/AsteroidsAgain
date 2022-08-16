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
        private float _walkSpeed;
        public void Patrool(List<Transform> patroolPoints, float patroolSpeed)
        {
            _wayPoints = patroolPoints;
            _currentWPId = 0;
            _walkSpeed = patroolSpeed;
        }
        private void Update()
        {
            Vector3 lookAtPosition = default;
            Transform currentWp = _wayPoints[_currentWPId];
            if (Vector2.Distance(transform.position, currentWp.position) < 0.01f)
            {
                _currentWPId = (_currentWPId + 1) % _wayPoints.Count;
                lookAtPosition = currentWp.position;
                lookAtPosition.y = transform.position.y;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentWp.position, _walkSpeed * Time.deltaTime);
                float angle = 0;

                Vector3 relative = transform.InverseTransformPoint(currentWp.position);
                angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
                transform.Rotate(0, 0, -angle);
            }
        }

    }
}


