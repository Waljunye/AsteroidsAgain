using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.Interfaces;
using Asteroids.Object_Pool;
using Asteroids.ServiceLocator;
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
            _bulletPool = ServiceLocator.ServiceLocator.Resolve<Object_Pool.BulletPool>();
        }
        public void Fire()
        {
            var bullet = new BulletBuilder();
            bullet.SetCreator(BulletCreator.player);
            bullet.SetDamage(_bulletDamage);
            bullet.SetOnCollisionEvent(() => _bulletPool.ReturnToPool(((GameObject)bullet).transform));
            bullet.SetTransform(_barrel.position, _barrel.rotation);
            ((Bullet)bullet).gameObject.GetComponent<Rigidbody2D>().AddForce(_barrel.up * _bulletShootForce);
        }
    }
}
