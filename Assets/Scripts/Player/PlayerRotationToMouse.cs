using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
namespace Asteroids.Player
{
    public class PlayerRotationToMouse : IRotation
    {
        private Transform _transform;
        public PlayerRotationToMouse(Transform transform)
        {
            _transform = transform;
        }
        public void Rotate(Vector3 direction)
        {
            var angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg;
            _transform.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        }

    }
}

