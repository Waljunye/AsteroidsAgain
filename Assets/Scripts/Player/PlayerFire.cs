using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using Asteroids.Object_Pool;
namespace Asteroids.Player
{
    public class PlayerFire : IPlayerFire
    {
        private Rigidbody2D _bullet;
        private Transform _barrel;
        private float _bulletShootForce;
        private float _bulletDamage;
        private BulletPool _bulletPool;

        public PlayerFire(Rigidbody2D bullet, Transform barrel, float bulletShootForce, float bulletDamage, int bulletPoolCapacity = 10)
        {
            _bullet = bullet;
            _barrel = barrel;
            _bulletShootForce = bulletShootForce;
            _bulletDamage = bulletDamage;
            _bulletPool = new BulletPool(bulletPoolCapacity);
        }
        public void Fire()
        {
            var bullet = _bulletPool.GetBullet();
            bullet.transform.position = _barrel.position;
            bullet.transform.rotation = _barrel.rotation;

            bullet.bulletCreator = BulletCreator.player;
            bullet.DamageValue = _bulletDamage;
            bullet.OnHit += () => _bulletPool.ReturnToPool(bullet.transform);
            
            bullet.gameObject.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _bulletShootForce);
        }
    }
}
