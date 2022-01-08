using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Code
{
    public class BulletSpawner : MonoBehaviour
    {
        [SerializeField] private List<Bullet> _bullets;
        [SerializeField] private GameProperties _gameProperties;

        private bool _shouldFire = true;
        private float _accumulator;
        
        private void Start()
        {
            foreach (var bullet in _bullets)
            {
                bullet.gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (_shouldFire)
            {
                _accumulator += Time.deltaTime;
                if (_accumulator >= _gameProperties.fireDelay)
                {
                    Fire();
                    _accumulator = 0f;
                }
            }
        }
        
        private void Fire()
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
            }
        }

        public void Return(Bullet bullet)
        {
            _bullets.Add(bullet);
        }
    }
}