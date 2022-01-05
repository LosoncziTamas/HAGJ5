using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private List<Bullet> _bullets;
        private bool _shouldFire = true;

        private void Start()
        {
            foreach (var bullet in _bullets)
            {
                bullet.gameObject.SetActive(false);
            }

            StartCoroutine(FireBullets());
        }

        private IEnumerator FireBullets()
        {
            while (_shouldFire)
            {
                Fire();
                yield return new WaitForSeconds(0.5f);
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
        
        private void OnGUI()
        {
            if (GUILayout.Button("Fire"))
            {
                _shouldFire = !_shouldFire;
                if (_shouldFire)
                {
                    StartCoroutine(FireBullets());
                }
            }
        }

        public void Return(Bullet bullet)
        {
            _bullets.Add(bullet);
        }
    }
}