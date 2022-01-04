using UnityEngine;

namespace Code
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameProperties _gameProperties;
        
        public Vector2 direction;

        private BulletSpawner _spawner;
        private Vector3 _initialPos;

        private void Awake()
        {
            _initialPos = transform.position;
        }

        public void Fire(BulletSpawner spawner)
        {
            gameObject.SetActive(true);
            _spawner = spawner;
        }

        public void Update()
        {
            var speed = _gameProperties.bulletSpeed;
            var boundaries = _gameProperties.boundaries;
            if (boundaries.Contains(transform.position))
            {
                transform.position += (Vector3)(direction * Time.deltaTime * speed);
            }
            else
            {
                transform.position = _initialPos;
                gameObject.SetActive(false);
                _spawner.Return(this);
            }
        }

        private void OnDrawGizmos()
        {
            var bounds = _gameProperties.boundaries;
            var bottomLeft = bounds.min;
            var bottomRight = new Vector3(bounds.xMax, bounds.yMin, 0);
            var topLeft = new Vector3(bounds.xMin, bounds.yMax, 0);
            var topRight = bounds.max;
            
            Gizmos.color = Color.green;
            
            Gizmos.DrawLine(bottomLeft, topLeft);
            Gizmos.DrawLine(topLeft, topRight);
            Gizmos.DrawLine(topRight, bottomRight);
            Gizmos.DrawLine(bottomRight, bottomLeft);
        }
    }
}