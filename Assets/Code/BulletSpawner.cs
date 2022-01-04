using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private List<Bullet> _bullets;

        private void Start()
        {
            foreach (var bullet in _bullets)
            {
                bullet.gameObject.SetActive(false);
            }
        }

        public void Fire()
        {
            if (_bullets.Count > 0)
            {
                var randomIdx = Random.Range(0, _bullets.Count);
                var bullet = _bullets[randomIdx];
                _bullets.RemoveAt(randomIdx);
                bullet.Fire(this);
            }
        }

        private void Update()
        {
            
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Fire"))
            {
                Fire();
            }
        }

        public void Return(Bullet bullet)
        {
            _bullets.Add(bullet);
        }
    }
}