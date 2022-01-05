using UnityEngine;

namespace Code
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private GameProperties _gameProperties;
        [SerializeField] private Direction _direction;

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
            var leftX = _gameProperties.levelEdgeLeftX;
            var rightX = _gameProperties.levelEdgeRightX;
            if (_direction == Direction.Left)
            {
                if (transform.position.x > leftX)
                {
                    transform.position += Vector3.left * Time.deltaTime * speed;
                }
                else
                {
                    Return();
                }
            }
            else
            {
                if (transform.position.x < rightX)
                {
                    transform.position += Vector3.right * Time.deltaTime * speed;
                }
                else
                {
                    Return();
                }
            }
        }

        private void Return()
        {
            transform.position = _initialPos;
            gameObject.SetActive(false);
            _spawner.Return(this);
        }

        private void OnDrawGizmos()
        {
            var leftX = _gameProperties.levelEdgeLeftX;
            var rightX = _gameProperties.levelEdgeRightX;
            
            var bottomLeft = new Vector3(leftX, 0, 0);
            var bottomRight = new Vector3(rightX, 0, 0);
            var topLeft = new Vector3(leftX, 4, 0);
            var topRight = new Vector3(rightX, 4, 0);
            
            Gizmos.color = Color.green;
            
            Gizmos.DrawLine(bottomLeft, topLeft);
            Gizmos.DrawLine(bottomRight, topRight);
        }
    }
}