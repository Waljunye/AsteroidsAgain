
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using Asteroids.Player.MoveSystem;
namespace Asteroids.Entities
{
    public class Ship : IPlayerMove, IRotation, IPlayerFire, IHealth
    {
        private readonly IPlayerMove _moveImplementation;
        private readonly IRotation _rotationImplementation;
        private readonly IPlayerFire _playerFireImplementation;
        private readonly IHealth _healthSystemImplementation;

        public float Speed => _moveImplementation.Speed;
        public Health HP => _healthSystemImplementation.HP;

        public Ship(IPlayerMove moveImplementation, IRotation rotationImplementation, IPlayerFire playerFireImplementation, IHealth healthSystemImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
            _playerFireImplementation = playerFireImplementation;
            _healthSystemImplementation = healthSystemImplementation;
        }

        public void Move(float inputHorizontal, float inputVertical, float deltaTime)
        {
            _moveImplementation.Move(inputHorizontal, inputVertical, deltaTime);
        }

        public void Rotate(Vector3 direction)
        {
            _rotationImplementation.Rotate(direction);
        }
        public void AddAcceleration()
        {
            if(_moveImplementation is AccelerationMove acceleration)
            {
                acceleration.AddAcceleration();
            }
        }
        public void RemoveAcceleration()
        {
            if (_moveImplementation is AccelerationMove acceleration)
            {
                acceleration.RemoveAcceleration();
            }
        }

        public void Fire()
        {
            _playerFireImplementation.Fire();
        }

        public void GetHit()
        {
            _healthSystemImplementation.GetHit();
        }
        public void GetHit(float value)
        {
            _healthSystemImplementation.GetHit(value);
        }
    }
}

