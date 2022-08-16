using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Asteroids.Object_Pool
{
    public sealed class BulletPool
    {
        private readonly List<Bullet> _objectPool;
        private readonly int _poolCapacity;
        private Transform _poolRoot;

        public BulletPool(int poolCapacity)
        {
            _objectPool = new List<Bullet>();
            _poolCapacity = poolCapacity;
            if (!_poolRoot)
            {
                _poolRoot = new GameObject("BulletPool").transform;
            }
        }
        public Bullet GetBullet()
        {
            var bullet = _objectPool.FirstOrDefault(a => !a.gameObject.activeSelf);
            if(bullet == null)
            {
                var instBullet = Resources.Load<Bullet>("Bullet/Bullet");
                for(int i = 0; i < _poolCapacity; i++)
                {
                    var instantiate = Object.Instantiate(instBullet);
                    ReturnToPool(instantiate.transform);
                    _objectPool.Add(instantiate);
                }
                bullet = _objectPool.FirstOrDefault(a => !a.gameObject.activeSelf);
            }
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        public void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_poolRoot);
        }
        public void RemovePool()
        {
            Object.Destroy(_poolRoot.gameObject);
        }
    }

}
