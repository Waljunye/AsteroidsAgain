using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using Asteroids.Entities;
using Asteroids.Player.MoveSystem;
namespace Asteroids.Player
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _hp;
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _bulletShootForce;
        [SerializeField] private float _acceleration;

        private Camera _mainCamera;
        private Ship _ship;

        private IPlayerMove playerMove;
        private IRotation playerRotation;
        private IPlayerFire playerFire;
        private IHealth playerHealth;

        private void Start()
        {
            _mainCamera = Camera.main;
            playerMove = new AccelerationMove(transform, _speed, _acceleration);
            playerRotation = new PlayerRotationToMouse(transform);
            playerFire = new PlayerFire(_bullet, _barrel, _bulletShootForce);
            playerHealth = new PlayerHealth(_hp, gameObject);
            _ship = new Ship(playerMove, playerRotation, playerFire, playerHealth);
        }
        private void Update()
        {
            var mousePointDirection = Input.mousePosition - _mainCamera.WorldToScreenPoint(transform.position);
            _ship.Rotate(mousePointDirection);

            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                _ship.Fire();
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            _ship.GetHit();
            Debug.Log("Hit");
        }
    }
}

