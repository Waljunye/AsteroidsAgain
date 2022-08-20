using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;

namespace Asteroids.Player.MoveSystem
{
    internal class MoveTransform : IPlayerMove
    {
        public float Speed { get; internal set; }

        private Transform _transform;
        private Vector2 _move;
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }
        public void Move(float inputHorizontal, float inputVertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(inputHorizontal * speed, inputVertical * speed);
            _transform.localPosition += new Vector3(_move.x, _move.y);
        }
    }
}

