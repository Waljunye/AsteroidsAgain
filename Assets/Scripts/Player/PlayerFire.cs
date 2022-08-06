using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
namespace Asteroids.Player
{
    public class PlayerFire : IPlayerFire
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _bulletShootForce;
        public PlayerFire(Rigidbody2D bullet, Transform barrel, float bulletShootForce)
        {
            _bullet = bullet;
            _barrel = barrel;
            _bulletShootForce = bulletShootForce;
        }
        public void Fire()
        {
            var instantiatedBullet = Object.Instantiate(_bullet, _barrel.position, _barrel.rotation);
            instantiatedBullet.AddForce(_barrel.up * _bulletShootForce);
        }
    }
}
