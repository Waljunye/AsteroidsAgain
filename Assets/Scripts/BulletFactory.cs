using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BulletFactory : MonoBehaviour
    {
        public static Rigidbody2D CreateBullet(Rigidbody2D prefab, Transform barrel, float bulletDamage, BulletCreator bulletCreator)
        {
            var bullet = Instantiate(prefab, barrel.position, barrel.rotation);
            var bulletComponent = bullet.gameObject.AddComponent<Bullet>();
            bulletComponent.DamageValue = bulletDamage;
            bulletComponent.bulletCreator = bulletCreator;
            return bullet;
        }
    }
}


