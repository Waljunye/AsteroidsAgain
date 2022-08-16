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
        private Vector3 moveVector;
        private bool IsMoving;
        private GameObject currentDistination;
        public void GoToPosition(GameObject distination)
        {
            moveVector = transform.position - distination.transform.position;
            currentDistination = distination;
            IsMoving = true;
        }
        public async void Patrool(List<GameObject> patroolPoints)
        { 
            foreach(GameObject patrolPoint in patroolPoints)
            {
                GoToPosition(patrolPoint);
            }
        }
        public void FixedUpdate()
        {
            if(IsMoving)
            {
                transform.position += new Vector3((-moveVector.x * 0.01f), (-moveVector.y) * 0.01f);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.Equals(currentDistination))
            {
                IsMoving = false;
            }
        }
    }
}


