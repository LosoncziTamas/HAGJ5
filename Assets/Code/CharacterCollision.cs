using UnityEngine;

namespace Code
{
    public class CharacterCollision : MonoBehaviour
    {
        private Vector3 _startPos;
        
        private void Awake()
        {
            _startPos = transform.position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            transform.position = _startPos;
        }
    }
}