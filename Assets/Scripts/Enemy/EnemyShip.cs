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
        [SerializeField] private Transform _barrel;

        private List<Transform> _wayPoints;
        private int _currentWPId;
        private Transform _tragetTransform;

        public float WalkSpeed;
        public float RaycastDistance = 5f;
        public float BulletDamage = 10f;
        public float _bulletShootForce = 1000f;
        public float _fireCoolDown = 2;
        //TODO: FIRE SYSTEM
        private void Start()
        {
            StartCoroutine(Fire());
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
        public void Patrool(List<Transform> patroolPoints)
        {
            _wayPoints = patroolPoints;
            _currentWPId = 0;
        }

        private IEnumerator Fire()
        {
            while (true)
            {
                
                if (_tragetTransform != default)
                {
                    var bullet = new BulletBuilder();
                    bullet.SetCreator(BulletCreator.enemy);
                    bullet.SetDamage(BulletDamage);
                    bullet.SetOnCollisionEvent();
                    bullet.SetTransform(_barrel.position, _barrel.rotation);
                    ((Bullet)bullet).gameObject.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _bulletShootForce);
                    yield return new WaitForSeconds(_fireCoolDown);
                }
                else
                {
                    yield return null;
                }
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
                if(_tragetTransform != default)
                {
                    _tragetTransform = default;
                }
                
            }
        }

    }
}


