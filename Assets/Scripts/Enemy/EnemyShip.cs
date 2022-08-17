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
        private Transform _tragetTransform;

        public float WalkSpeed;
        public float RaycastDistance = 5f;
        //TODO: FIRE SYSTEM
        public void Patrool(List<Transform> patroolPoints)
        {
            _wayPoints = patroolPoints;
            _currentWPId = 0;
        }

        private void Update()
        {
            Vector3 lookAtPosition = default;
            if(_wayPoints != null)
            {
                Transform currentWp = _wayPoints[_currentWPId];
                if (Vector2.Distance(transform.position, currentWp.position) < 0.01f)
                {
                    _currentWPId = (_currentWPId + 1) % _wayPoints.Count;
                    lookAtPosition = currentWp.position;
                    lookAtPosition.y = transform.position.y;
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position, currentWp.position, WalkSpeed * Time.deltaTime);
                    
                    if(_tragetTransform == default)
                    {
                        LookAt(currentWp);
                    }
                    
                }
            }
            if(_tragetTransform != default)
            {
                LookAt(_tragetTransform);
            }
            
            
        }
        private void LookAt(Transform targetTransform)
        {
            float angle = 0;
            Vector3 relative = transform.InverseTransformPoint(targetTransform.position);
            angle = Mathf.Atan2(relative.x, relative.y) * Mathf.Rad2Deg;
            transform.Rotate(0, 0, -angle);
        }
        private void FixedUpdate()
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.up), layerMask: LayerMask.GetMask("Player"), distance: RaycastDistance);
            if(hit)
            {
                _tragetTransform = hit.transform;
            }
            else
            {
                Debug.Log("Not Hit");
                _tragetTransform = default;
            }
        }

    }
}


