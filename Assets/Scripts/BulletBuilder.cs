using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids.ServiceLocator;
using Asteroids.Object_Pool;
namespace Asteroids
{
    public class BulletBuilder
    {
        protected Bullet _bullet;
        private BulletPool bulletPool = ServiceLocator.ServiceLocator.Resolve<BulletPool>();
        public BulletBuilder() => _bullet = bulletPool.GetBullet();
        protected BulletBuilder(Bullet bullet)
        {
            _bullet = bullet;
        }
        public static implicit operator Bullet(BulletBuilder builder)
        {
            return builder._bullet;
        }
        public static implicit operator GameObject(BulletBuilder builder)
        {
            return builder._bullet.gameObject;
        }
        public Bullet SetCreator(BulletCreator bulletCreator)
        {
            _bullet.bulletCreator = bulletCreator;
            return this;
        }
        public Bullet SetDamage(float damage)
        {
            _bullet.DamageValue = damage;
            return this;
        }
        public Bullet SetOnCollisionEvent(Action action = default)
        {
            if(action == default)
            {
                _bullet.OnHit += () => bulletPool.ReturnToPool(_bullet.transform);
            }
            _bullet.OnHit += action;
            return this;
        }
        public Bullet SetTransform(Vector2 position, Quaternion rotation)
        {
            Transform bulletTransform = _bullet.GetComponent<Transform>();
            _bullet.gameObject.transform.position = position;
            _bullet.gameObject.transform.rotation = rotation;
            return this;
        }
    }
}


