using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
namespace Asteroids.Player.MoveSystem
{
    public class MoveRigibody : IPlayerMove
    {
        private Rigidbody2D _rigidbody2D;
        private float _speed;
        public float Speed { get; private set; }

        public MoveRigibody(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            _speed = speed;
        }
        public void Move(float inputHorizontal, float inputVertical, float deltaTime)
        {
            var speed = deltaTime * _speed;
            _rigidbody2D.AddForce(new Vector2(inputHorizontal * speed, inputVertical * speed), ForceMode2D.Force);
        }
    }
}

